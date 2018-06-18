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
		protected                 bool             foldout;
		protected                 SerializedObject serializedObject;

		protected virtual bool AllowFoldout => true;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;

				using(var changeCheckScope = FoCsEditor.Disposables.ChangeCheck())
				{
					FoCsGUI.PropertyField(position.Edit(RectEdit.SetHeight(SingleLine)), property, label);
//					var @event = FoCsGUI.PropertyField(position.Edit(RectEdit.SetHeight(SingleLine)), property, label);
//
//					if(@event.EventIsMouseRInRect)
//					{
//						var hasRef  = property.objectReferenceValue != null;
//						var    menu    = new GenericMenu();
//						var objName = "Object";
//
//						{
//							var s = property.type.Replace("PPtr<$", "").Replace(">", "");
//							if(s.HasContent())
//								objName = s;
//						}
//
//						if(hasRef)
//							menu.AddItem(new GUIContent("Remove Reference", "Will remove current Reference"), false, () => CreateObject(property));
//						else
//							menu.AddDisabledItem(new GUIContent("Remove Reference", "Will remove current Reference"));
//
//						menu.AddSeparator("");
//						menu.AddItem(new GUIContent($"Create {objName}",              "Will create it in the root asset folder"),  false, () => CreateObject(property));
//						menu.AddItem(new GUIContent($"Create {objName} At Path",      "Will create at the path of your choosing"), false, () => CreateObjectAtPath(property));
//						menu.AddItem(new GUIContent($"Create {objName} In AdvFolder", "Will create as a child of an AdvFolder"),   false, () => CreateObjectOnAdvFolder(property));
//						menu.ShowAsContext();
//						Event.current.Use();
//					}

					if(changeCheckScope.changed && (property.objectReferenceValue != null))
					{
						property.serializedObject.ApplyModifiedProperties();
						serializedObject = new SerializedObject(property.objectReferenceValue);
					}
				}
			}

			if(property.objectReferenceValue == null || !AllowFoldout)
			{
				serializedObject = null;

				return;
			}

			if(serializedObject == null)
				serializedObject = new SerializedObject(property.objectReferenceValue);

			if(serializedObject.VisibleProperties() == 0)
				return;

			var iterator = serializedObject.GetIterator();
			iterator.Next(true);
			foldout = EditorGUI.Foldout(position.Edit(RectEdit.SetHeight(SingleLine), RectEdit.SetWidth(SingleLine)), foldout, foldoutGUIContent);

			if(!foldout)
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
			if(Event.current.type == EventType.Repaint)
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

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => PropertyHeight(serializedObject, foldout);

		public static float PropertyHeight(SerializedObject serializedObject, bool foldout)
		{
			if((serializedObject == null) || !foldout || (serializedObject.VisibleProperties() == 0))
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

//		private void CreateObjectOnAdvFolder(SerializedProperty property) { }
//		private void CreateObjectAtPath(SerializedProperty property) { }
//		private void CreateObject(SerializedProperty property) { }

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
