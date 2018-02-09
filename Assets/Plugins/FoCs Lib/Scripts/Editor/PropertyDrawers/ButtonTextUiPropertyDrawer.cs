using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers
{
	//[CustomPropertyDrawer(typeof (ButtonText))]
	public class ButtonTextUiPropertyDrawer: PropertyDrawer
	{
		private readonly float singleLine = EditorGUIUtility.singleLineHeight;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			const string ButtonString = "Button";
			const string TextString = "Text";

			var Btn = property.FindPropertyRelative("Btn");
			var Txt = property.FindPropertyRelative("Text");

			var LabelString = EditorHelpers.GetStringLengthinPix(label.text);
			var ButtonStringLength = EditorHelpers.GetStringLengthinPix(ButtonString);
			var TextStringLength = EditorHelpers.GetStringLengthinPix(TextString);

			var halfRowWidthForData = (position.width - LabelString) / 2;

			EditorGUI.LabelField(new Rect(position.x, position.y, LabelString, singleLine), label);

			EditorGUI.LabelField(new Rect(position.x + LabelString, position.y, ButtonStringLength, singleLine), ButtonString);
			EditorGUI.PropertyField(new Rect(position.x + LabelString + ButtonStringLength, position.y, halfRowWidthForData - ButtonStringLength, singleLine),
									Btn,
									GUIContent.none);

			EditorGUI.LabelField(new Rect(position.x + halfRowWidthForData + LabelString, position.y, TextStringLength, singleLine), TextString);
			EditorGUI.PropertyField(new Rect(position.x + LabelString + halfRowWidthForData + TextStringLength,
											 position.y,
											 halfRowWidthForData - TextStringLength,
											 singleLine),
									Txt,
									GUIContent.none);

			property.serializedObject.ApplyModifiedProperties();
		}
	}
}