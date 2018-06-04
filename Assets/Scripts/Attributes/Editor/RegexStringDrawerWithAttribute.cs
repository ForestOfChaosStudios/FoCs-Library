using System.Text.RegularExpressions;
using ForestOfChaosLib.Attributes;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers.Attributes
{
	[CustomPropertyDrawer(typeof(RegexStringAttribute))]
	public class RegexStringDrawerWithAttribute: FoCsPropertyDrawerWithAttribute<RegexStringAttribute>
	{
		private const int helpHeight = 30;
		private const int textHeight = 16;

		public override float GetPropertyHeight(SerializedProperty prop, GUIContent label)
		{
			if(IsValid(prop))
				return base.GetPropertyHeight(prop, label);

			return base.GetPropertyHeight(prop, label) + helpHeight;
		}

		public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
		{
			var fieldPosition = position;
			fieldPosition.height = textHeight;
			DrawTextField(fieldPosition, prop, label);
			var helpPosition = EditorGUI.IndentedRect(position);
			helpPosition.y      += textHeight;
			helpPosition.height =  helpHeight;
			DrawHelpBox(helpPosition, prop);
		}

		private static void DrawTextField(Rect position, SerializedProperty prop, GUIContent label)
		{
			EditorGUI.BeginChangeCheck();
			var value = EditorGUI.TextField(position, label, prop.stringValue);

			if(EditorGUI.EndChangeCheck())
				prop.stringValue = value;
		}

		private void DrawHelpBox(Rect position, SerializedProperty prop)
		{
			if(IsValid(prop))
				return;

			EditorGUI.HelpBox(position, GetAttribute.helpMessage, MessageType.Error);
		}

		private bool IsValid(SerializedProperty prop) => Regex.IsMatch(prop.stringValue, GetAttribute.pattern);
	}
}
