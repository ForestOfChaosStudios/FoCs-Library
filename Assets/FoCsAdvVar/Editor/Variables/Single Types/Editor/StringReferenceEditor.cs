#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar.Editor
//       File: StringReferenceEditor.cs
//    Created: 2020/04/25 | 5:51 AM
// LastEdited: 2020/10/11 | 10:11 PM
#endregion

using ForestOfChaos.Unity.Editor;
using ForestOfChaos.Unity.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Editor {
    [CanEditMultipleObjects]
    [CustomEditor(typeof(StringReference))]
    public class StringReferenceEditor: FoCsEditor {
        public override void OnInspectorGUI() {
            using (Disposables.Indent()) {
                DoDrawHeader();
                VerifyHandler();

                using (var changeCheckScope = Disposables.ChangeCheck()) {
                    serializedObject.Update();

                    foreach (var serializedProperty in serializedObject.Properties()) {
                        if (serializedProperty.name == "storedValue")
                            DoTextBox(serializedProperty);
                        else
                            DrawProperty(serializedProperty);
                    }

                    if (changeCheckScope.changed)
                        serializedObject.ApplyModifiedProperties();
                }

                FoCsGUI.Layout.GetControlRect(false, FoCsGUI.Padding);
            }
        }

        private static void DoTextBox(SerializedProperty serializedProperty) {
            FoCsGUI.Layout.LabelField("Value");
            serializedProperty.stringValue = EditorGUILayout.TextArea(serializedProperty.stringValue, GUILayout.Height(EditorGUIUtility.singleLineHeight * 5));
        }
    }
}