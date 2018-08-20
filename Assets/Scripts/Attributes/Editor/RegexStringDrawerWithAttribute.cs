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

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if(IsValid(property))
				return base.GetPropertyHeight(property, label);

			return base.GetPropertyHeight(property, label) + helpHeight;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;
				var fieldPosition = position;
				fieldPosition.height = textHeight;
				DrawTextField(fieldPosition, property, label);
				var helpPosition = EditorGUI.IndentedRect(position);
				helpPosition.y      += textHeight;
				helpPosition.height =  helpHeight;
				DrawHelpBox(helpPosition, property);
			}
		}

		private static void DrawTextField(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginChangeCheck();
			var value = EditorGUI.TextField(position, label, property.stringValue);

			if(EditorGUI.EndChangeCheck())
				property.stringValue = value;
		}

		private void DrawHelpBox(Rect position, SerializedProperty property)
		{
			if(IsValid(property))
				return;

			EditorGUI.HelpBox(position, GetAttribute.helpMessage, MessageType.Error);
		}

		private bool IsValid(SerializedProperty property)
		{
			return Regex.IsMatch(property.stringValue, GetAttribute.pattern);
		}
	}
}
