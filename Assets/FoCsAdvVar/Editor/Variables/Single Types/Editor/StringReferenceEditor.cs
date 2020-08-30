#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.AdvVar.Editor
//       File: StringReferenceEditor.cs
//    Created: 2020/04/25 | 5:51 AM
// LastEdited: 2020/08/31 | 7:49 AM
#endregion


using ForestOfChaosLibrary.Editor;
using ForestOfChaosLibrary.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Editor {
    [CustomEditor(typeof(StringReference))]
    [CanEditMultipleObjects]
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

                EditorGUILayout.GetControlRect(false, FoCsGUI.Padding);
            }
        }

        private void DoTextBox(SerializedProperty serializedProperty) {
            EditorGUILayout.LabelField("Value");
            serializedProperty.stringValue = EditorGUILayout.TextArea(serializedProperty.stringValue, GUILayout.Height(EditorGUIUtility.singleLineHeight * 5));
        }
    }
}