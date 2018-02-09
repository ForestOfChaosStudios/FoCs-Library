using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.UnityScriptsExtensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers.Types
{
	public class ObjectDrawer: FoCsPropertyDrawer
	{
		internal static readonly GUIContent foldoutGUIContent = new GUIContent("", "Open up the References Data");

		private bool foldOut;
		private SerializedObject serializedObject;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var changeCheckScope = EditorDisposables.ChangeCheck())
			{
				EditorGUI.PropertyField(position.SetHeight(SingleLine), property);
				if((changeCheckScope.changed) && (property.objectReferenceValue != null))
					serializedObject = new SerializedObject(property.objectReferenceValue);
			}
			if(property.objectReferenceValue == null)
			{
				serializedObject = null;
				return;
			}
			serializedObject = new SerializedObject(property.objectReferenceValue);
			var iterator = serializedObject.GetIterator();
			iterator.Next(true);

			foldOut = EditorGUI.Foldout(position.SetHeight(SingleLine).SetWidth(SingleLine), foldOut, foldoutGUIContent);
			if(!foldOut)
				return;
				if(Event.current.type == EventType.repaint)
					GUI.skin.box.Draw(position.ChangeY(-1), false, false, false, false);
			using(var changeCheckScope = EditorDisposables.ChangeCheck())
			{
				using(EditorDisposables.Indent())
				{
					var drawPos = position.MoveY(SingleLinePlusPadding).MoveHeight(-SingleLinePlusPadding);
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

		private static Rect DrawSubProp(SerializedProperty prop, Rect drawPos)
		{
			var height = EditorGUI.GetPropertyHeight(prop);
			drawPos.height = height;
			EditorGUI.PropertyField(drawPos, prop, prop.isExpanded);
			drawPos.y += height;
			return drawPos;
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if(serializedObject == null)
				return SingleLine;

			var iterator = serializedObject.GetIterator();
			iterator.Next(true);

			if(!foldOut)
				return SingleLine;
			var height = 4.5f;
			iterator.Next(true);
			do
			{
				if(FoCsEditor.IsPropertyHidden(iterator))
					continue;

				height += EditorGUI.GetPropertyHeight(iterator, iterator.isExpanded);
			}
			while(iterator.NextVisible(false));
			return height;
		}
	}
}