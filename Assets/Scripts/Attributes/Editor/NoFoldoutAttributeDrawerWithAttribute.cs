using ForestOfChaosLib.Attributes;
using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers.Attributes
{
	[CustomPropertyDrawer(typeof(NoFoldoutAttribute), true)]
	public class NoFoldoutAttributeDrawerWithAttribute: FoCsPropertyDrawerWithAttribute<NoFoldoutAttribute>
	{
		public override void OnGUI(Rect position, SerializedProperty serializedProperty, GUIContent label)
		{
			serializedProperty.isExpanded = true;
			var rect = position;
			rect.height = SingleLine;

			if(GetAttribute.ShowVariableName)
			{
				EditorGUI.LabelField(rect, label);
				rect.y += SingleLine;
			}
			using(FoCsEditor.Disposables.Indent())
			{
				foreach(var child in serializedProperty.GetChildren())
				{
					EditorGUI.PropertyField(rect, child, true);
					rect.y += EditorGUI.GetPropertyHeight(child, GUIContent.none, true);
				}
			}
		}

		public override float GetPropertyHeight(SerializedProperty serializedProperty, GUIContent label)
		{
			var totalHeight = GetAttribute.ShowVariableName?
				SingleLine :
				0f;

			serializedProperty.isExpanded = true;

			foreach(var child in serializedProperty.GetChildren())
			{
				totalHeight += EditorGUI.GetPropertyHeight(child, GUIContent.none, true);
			}

			return totalHeight;
		}
	}
}