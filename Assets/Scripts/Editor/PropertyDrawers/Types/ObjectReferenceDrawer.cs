using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers.Types
{
	public class ObjectReferenceDrawer: FoCsPropertyDrawer
	{
		protected static readonly GUIContent foldoutGUIContent = new GUIContent("", "Open up the References Data");

		protected bool foldOut;
		protected SerializedObject serializedObject;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using (var changeCheckScope = FoCsEditor.Disposables.ChangeCheck())
			{
				EditorGUI.PropertyField(position.SetHeight(SingleLine), property);
				if ((changeCheckScope.changed) && (property.objectReferenceValue != null))
					serializedObject = new SerializedObject(property.objectReferenceValue);
			}
			if (property.objectReferenceValue == null)
			{
				serializedObject = null;
				return;
			}
			serializedObject = new SerializedObject(property.objectReferenceValue);
			if (serializedObject.VisibleProperties() == 0)
				return;

			var iterator = serializedObject.GetIterator();
			iterator.Next(true);

			foldOut = EditorGUI.Foldout(position.SetHeight(SingleLine).SetWidth(SingleLine), foldOut, foldoutGUIContent);
			if (!foldOut)
				return;
			DrawSurroundingBox(position);
			using (var changeCheckScope = FoCsEditor.Disposables.ChangeCheck())
			{
				using (FoCsEditor.Disposables.Indent())
				{
					var drawPos = position.MoveY(SingleLinePlusPadding).MoveHeight(-SingleLinePlusPadding);
					do
					{
						if (!FoCsEditor.IsPropertyHidden(iterator))
							drawPos = DrawSubProp(iterator, drawPos);
					}
					while (iterator.NextVisible(false));
					if (changeCheckScope.changed)
						serializedObject.ApplyModifiedProperties();
				}
			}
		}

		protected static void DrawSurroundingBox(Rect position)
		{
			if (Event.current.type == EventType.repaint)
				GUI.skin.box.Draw(position.ChangeY(-1).MoveWidth(2), false, false, false, false);
		}

		protected static Rect DrawSubProp(SerializedProperty prop, Rect drawPos)
		{
			var height = EditorGUI.GetPropertyHeight(prop);
			drawPos.height = height;
			EditorGUI.PropertyField(drawPos, prop, prop.isExpanded);
			drawPos.y += height + Padding;
			return drawPos;
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if(serializedObject == null || !foldOut || serializedObject.VisibleProperties() == 0)
				return SingleLine;

			var iterator = serializedObject.GetIterator();
			iterator.Next(true);
			iterator.Next(true);

			var height = 0f;
			do
			{
				if(!FoCsEditor.IsPropertyHidden(iterator))
				{
					height += EditorGUI.GetPropertyHeight(iterator, iterator.isExpanded) + Padding;
				}
			}
			while(iterator.NextVisible(false));
			return height;
		}
	}
}