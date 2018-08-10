using System.Collections.Generic;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers
{
	public class ObjectReferenceDrawer: FoCsPropertyDrawer
	{
		protected static readonly GUIContent       foldoutGUIContent = new GUIContent("", "Open up the References Data");
		protected                 bool             foldout;
		protected                 SerializedObject serializedObject;
		public AnimBool IsExpanded;
		protected virtual bool AllowFoldout
		{
			get { return true; }
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			CheckAnimBool(property);

			var elementHeight = FoCsGUI.GetPropertyHeight(property,FoCsGUI.AttributeCheck.DoCheck);

			using(var propScope = FoCsEditor.Disposables.PropertyScope(position,label,property))
			{
				label = propScope.content;

				using(var changeCheckScope = FoCsEditor.Disposables.ChangeCheck())
				{
					FoCsGUI.PropertyField(position.Edit(RectEdit.SetHeight(elementHeight)),property,label);

					if(changeCheckScope.changed && (property.objectReferenceValue != null))
					{
						property.serializedObject.ApplyModifiedProperties();
						serializedObject = new SerializedObject(property.objectReferenceValue);
					}
				}
			}

			if((property.objectReferenceValue == null) || !AllowFoldout)
			{
				serializedObject = null;

				return;
			}

			if(serializedObject == null)
				serializedObject = new SerializedObject(property.objectReferenceValue);
			else
				serializedObject.Update();

			foldout = DrawReference(position.Edit(RectEdit.ChangeY(elementHeight - SingleLine)), serializedObject, foldout);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			CheckAnimBool(property);
			return PropertyHeight(property, serializedObject, foldout);
		}

		private void CheckAnimBool(SerializedProperty property)
		{
			if(IsExpanded == null)
				IsExpanded = new AnimBool(property.isExpanded);

			IsExpanded.value = property.isExpanded;
		}

		public static bool DrawReference(Rect position, SerializedObject serializedObject, bool foldout)
		{
			if(serializedObject.VisibleProperties() == 0)
				return false;

			var iterator = serializedObject.GetIterator();
			iterator.Next(true);
			foldout = EditorGUI.Foldout(position.Edit(RectEdit.SetHeight(SingleLine), RectEdit.SetWidth(SingleLine), RectEdit.ChangeY(1)), foldout, foldoutGUIContent);

			if(!foldout)
				return false;

			DrawSurroundingBox(position);

			using(var changeCheckScope = FoCsEditor.Disposables.ChangeCheck())
			{
				using(FoCsEditor.Disposables.Indent())
				{
					var drawPos = position.Edit(RectEdit.AddY(SingleLine), RectEdit.SubtractHeight(SingleLine), RectEdit.ChangeY(1));

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

			return true;
		}

		protected static void DrawSurroundingBox(Rect position)
		{
			if(Event.current.type == EventType.Repaint)
				GUI.skin.box.Draw(position.Edit(RectEdit.ChangeY(SingleLine - 1), RectEdit.SubtractWidth(SingleLine + 7), RectEdit.AddX(SingleLine + 9)), false, false, false, false);
		}

		protected static Rect DrawSubProp(SerializedProperty prop, Rect drawPos)
		{
			if(prop.isArray && (prop.propertyType != SerializedPropertyType.String))
			{
				var list   = FoCsEditor.GetReorderableList(prop);
				var height = list.GetTotalHeight();
				drawPos.height = height;

				using(FoCsEditor.Disposables.SetIndent(0))
				{
					list.HandleDrawing(drawPos.Edit(RectEdit.ChangeX(16)));
				}

				drawPos.y += height + Padding;
			}
			else
			{
				var height = FoCsGUI.GetPropertyHeight(prop, FoCsGUI.AttributeCheck.DoCheck);
				drawPos.height = height;
				FoCsGUI.PropertyField(drawPos, prop, prop.isExpanded, FoCsGUI.AttributeCheck.DoCheck);
				drawPos.y += height + Padding;
			}

			return drawPos;
		}

		protected static float SubPropHeight(SerializedProperty prop, bool padding = true)
		{
			if(prop.isArray && (prop.propertyType != SerializedPropertyType.String))
			{
				var list   = FoCsEditor.GetReorderableList(prop);
				var height = list.GetTotalHeight();

				return height + (padding? Padding : 0);
			}
			else
			{
				var height = FoCsGUI.GetPropertyHeight(prop, FoCsGUI.AttributeCheck.DoCheck);

				return height + (padding? Padding : 0);
			}
		}

		public static float PropertyHeight(SerializedProperty property, SerializedObject serializedObject, bool foldout)
		{
			if((serializedObject == null) || !foldout || (serializedObject.VisibleProperties() == 0))
				return Mathf.Max(FoCsGUI.GetPropertyHeight(property), SingleLine);

			var iterator = serializedObject.GetIterator();
			iterator.Next(true);
			var height = SingleLine + Padding;

			using(FoCsEditor.Disposables.Indent())
			{
				do
				{
					if(!FoCsEditor.IsPropertyHidden(iterator))
						height += SubPropHeight(iterator);
				}
				while(iterator.NextVisible(false));
			}

			return height;
		}

#region Storage
		private static readonly Dictionary<string, ObjectReferenceDrawer> objectDrawers = new Dictionary<string, ObjectReferenceDrawer>(10);

		public static ObjectReferenceDrawer GetObjectDrawer(SerializedProperty property)
		{
			var                   id = string.Format("{0}:{1}-{2}", property.serializedObject.targetObject.name, property.propertyPath, property.name);
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
