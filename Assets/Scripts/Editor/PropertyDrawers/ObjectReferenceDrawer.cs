using System.Collections.Generic;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers
{
	public class ObjectReferenceDrawer: FoCsPropertyDrawer
	{
		protected static readonly GUIContent       foldoutGUIContent = new GUIContent("", "Open up the References Data");
		protected                 bool             foldOut;
		protected                 SerializedObject serializedObject;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;

				using(var changeCheckScope = FoCsEditor.Disposables.ChangeCheck())
				{
					FoCsGUI.PropertyField(position.Edit(RectEdit.SetHeight(SingleLine)), property, label);

					if(changeCheckScope.changed && (property.objectReferenceValue != null))
						serializedObject = new SerializedObject(property.objectReferenceValue);
				}
			}

			if(property.objectReferenceValue == null)
			{
				serializedObject = null;

				return;
			}

			serializedObject = new SerializedObject(property.objectReferenceValue);

			if(serializedObject.VisibleProperties() == 0)
				return;

			var iterator = serializedObject.GetIterator();
			iterator.Next(true);
			foldOut = EditorGUI.Foldout(position.Edit(RectEdit.SetHeight(SingleLine), RectEdit.SetWidth(SingleLine)), foldOut, foldoutGUIContent);

			if(!foldOut)
				return;

			DrawSurroundingBox(position);

			using(var changeCheckScope = FoCsEditor.Disposables.ChangeCheck())
			{
				using(FoCsEditor.Disposables.Indent())
				{
					var drawPos = position.Edit(RectEdit.AddY(SingleLinePlusPadding), RectEdit.SubtractHeight(SingleLinePlusPadding));

					do
					{
						if(!FoCsEditor.IsPropertyHidden(iterator))
							drawPos = DrawSubProp(iterator, drawPos);
					}
					while(iterator.NextVisible(false));

					if(changeCheckScope.changed)
						serializedObject.ApplyModifiedProperties();
				}
			}
		}

		protected static void DrawSurroundingBox(Rect position)
		{
			if(Event.current.type == EventType.repaint)
				GUI.skin.box.Draw(position.Edit(RectEdit.ChangeY(-1), RectEdit.AddWidth(2)), false, false, false, false);
		}

		protected static Rect DrawSubProp(SerializedProperty prop, Rect drawPos)
		{
			var height = FoCsGUI.GetPropertyHeight(prop, FoCsGUI.AttributeCheck.DoCheck);
			drawPos.height = height;
			FoCsGUI.PropertyField(drawPos, prop, prop.isExpanded, FoCsGUI.AttributeCheck.DoCheck);
			drawPos.y += height + Padding;

			return drawPos;
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if((serializedObject == null) || !foldOut || (serializedObject.VisibleProperties() == 0))
				return SingleLine;

			var iterator = serializedObject.GetIterator();
			iterator.Next(true);
			iterator.Next(true);
			var height = 0f;

			do
			{
				if(!FoCsEditor.IsPropertyHidden(iterator))
					height += FoCsGUI.GetPropertyHeight(iterator, iterator.isExpanded, FoCsGUI.AttributeCheck.DoCheck) + Padding;
			}
			while(iterator.NextVisible(false));

			return height;
		}

#region Storage
		private static readonly Dictionary<string, ObjectReferenceDrawer> objectDrawers = new Dictionary<string, ObjectReferenceDrawer>(10);

		public static ObjectReferenceDrawer GetObjectDrawer(SerializedProperty property)
		{
			var                   id = $"{property.serializedObject.targetObject.name}:{property.propertyPath}-{property.name}";
			ObjectReferenceDrawer objDraw;

			if(objectDrawers.TryGetValue(id, out objDraw))
				return objDraw;

			objDraw = new ObjectReferenceDrawer();
			objectDrawers.Add(id, objDraw);

			return objDraw;
		}
#endregion
	}
}
