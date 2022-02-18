#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: EnumFlagsAttributeDrawer.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.Attributes;
using ForestOfChaos.Unity.Editor.PropertyDrawers;
using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.Attributes {
    [CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
    public class EnumFlagsAttributeDrawer: FoCsPropertyDrawerWithAttribute<EnumFlagsAttribute> {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if (!GetAttribute.DrawButtons) {
                property.intValue = EditorGUI.MaskField(position, label, property.intValue, property.enumNames);

                return;
            }

            var buttonsIntValue = 0;
            var labelWidth      = EditorGUIUtility.labelWidth;
            var enumLength      = property.enumNames.Length;
            var buttonPressed   = new bool[enumLength];
            FoCsGUI.Label(new Rect(position.x, position.y, labelWidth, position.height), label);

            using (var cc = Disposables.ChangeCheck()) {
                //if(property.enumNames.Length <= 4)
                buttonsIntValue = DoLessThen4Draw(position, property, buttonsIntValue, labelWidth, enumLength, buttonPressed);
                //else
                //	buttonsIntValue = DoMoreThen4Draw(position, property, buttonsIntValue, labelWidth, enumLength, buttonPressed);

                if (cc.changed)
                    property.intValue = buttonsIntValue;
            }
        }

        private static int DoLessThen4Draw(Rect position, SerializedProperty property, int buttonsIntValue, float labelWidth, int enumLength, bool[] buttonPressed) {
            using (var scope = Disposables.RectHorizontalScope(enumLength, position.Edit(RectEdit.SetWidth(position.width - labelWidth), RectEdit.AddX(labelWidth)))) {
                for (var i = 0; i < enumLength; i++) {
                    // Check if the button is/was pressed
                    if ((property.intValue & 1 << i) == (1 << i))
                        buttonPressed[i] = true;

                    buttonPressed[i] = GUI.Toggle(scope.GetNext(), buttonPressed[i], property.enumNames[i], "Button");

                    if (buttonPressed[i])
                        buttonsIntValue += 1 << i;
                }
            }

            return buttonsIntValue;
        }

        //private static int DoMoreThen4Draw(Rect position, SerializedProperty property, int buttonsIntValue, float labelWidth, int enumLength, bool[] buttonPressed)
        //{
        //	for(var x = 0; x < enumLength; x += 4)
        //	{
        //		using(var scope = Disposables.RectHorizontalScope(4, position.Edit(RectEdit.SetWidth(position.width - labelWidth), RectEdit.AddX(labelWidth), RectEdit.SetHeight(SingleLine))))
        //		{
        //			for(var i = x; i < 4; i++)
        //			{
        //				// Check if the button is/was pressed
        //				if((property.intValue & 1 << i) == (1 << i))
        //					buttonPressed[i] = true;
        //
        //				buttonPressed[i] = GUI.Toggle(scope.GetNext(), buttonPressed[i], property.enumNames[i], "Button");
        //
        //				if(buttonPressed[i])
        //					buttonsIntValue += 1 << i;
        //			}
        //		}
        //	}
        //
        //	return buttonsIntValue;
        //}

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            if (!GetAttribute.DrawButtons)
                return SingleLine;

            if (property.enumNames.Length > 4)
                return SingleLine * (property.enumNames.Length / 4f);

            return SingleLine;
        }
    }
}