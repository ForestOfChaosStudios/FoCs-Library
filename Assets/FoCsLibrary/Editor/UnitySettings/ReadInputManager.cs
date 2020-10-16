#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: ReadInputManager.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:11 PM
#endregion

using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.UnitySettings {
    //From https://answers.unity.com/questions/951770/get-array-of-all-input-manager-axes.html
    //And https://answers.unity.com/questions/566736/get-list-of-axes.html
    //The same Unity User "Sarkahn"
    public class ReadInputManager {
        private static Object InputManagerAsset => UnitySettingsReader.InputManager;

        public static SerializedObject GetInputAxisSerializedObject() => new SerializedObject(InputManagerAsset);

        public static SerializedProperty GetAxisArrayProperty() {
            var obj = GetInputAxisSerializedObject();

            return obj.FindProperty("m_Axes");
        }

        public static SerializedProperty[] GetAxisProperties() {
            var obj       = GetInputAxisSerializedObject();
            var axisArray = obj.FindProperty("m_Axes");

            if (axisArray.arraySize == 0)
                return new SerializedProperty[0];

            var returnVal = new SerializedProperty[axisArray.arraySize];

            for (var i = 0; i < axisArray.arraySize; ++i)
                returnVal[i] = axisArray.GetArrayElementAtIndex(i).Copy();

            return returnVal;
        }

        public static string[] GetAxisNames() {
            var axisArray = GetAxisArrayProperty();

            if (axisArray.arraySize == 0)
                return new string[0];

            var returnVal = new string[axisArray.arraySize];

            for (var i = 0; i < axisArray.arraySize; ++i) {
                var axis = axisArray.GetArrayElementAtIndex(i);
                var name = axis.FindPropertyRelative("m_Name").stringValue;
                returnVal[i] = name;
            }

            return returnVal;
        }
    }
}