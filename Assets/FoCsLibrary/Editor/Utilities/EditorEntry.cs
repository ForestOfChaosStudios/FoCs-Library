#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: EditorEntry.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.Utilities {
    public class EditorEntry {
        public readonly string             LabelName;
        public          SerializedProperty Property;

        public EditorEntry(string str, SerializedProperty prop) {
            Property  = prop;
            LabelName = str;
        }

        public EditorEntry(SerializedProperty prop) {
            Property  = prop;
            LabelName = prop.displayName;
        }

        public static implicit operator SerializedProperty(EditorEntry editorString) => editorString.Property;

        public static implicit operator string(EditorEntry editorString) => editorString.LabelName;

        public void Draw(Rect position) {
            EditorGUI.PropertyField(position, Property, new GUIContent(LabelName));
        }

        public void Draw(Rect position, string toolTip) {
            EditorGUI.PropertyField(position, Property, new GUIContent(LabelName, toolTip));
        }
    }
}