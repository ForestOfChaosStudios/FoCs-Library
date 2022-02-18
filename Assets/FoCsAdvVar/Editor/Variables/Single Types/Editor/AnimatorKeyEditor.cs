#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar.Editor
//       File: AnimatorKeyEditor.cs
//    Created: 2020/04/25
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.Editor;
using ForestOfChaos.Unity.Editor.Animation;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Editor {
    [CanEditMultipleObjects]
    [CustomEditor(typeof(AnimatorKeyReference))]
    public class AnimatorKeyEditor: FoCsEditor {
        private static readonly GUIContent ValueContent = new GUIContent("Value");

        public override void OnInspectorGUI() {
            serializedObject.Update();

            using (Disposables.Indent()) {
                using (var cc = Disposables.ChangeCheck()) {
                    AnimatorKeyDrawer.DoDraw(FoCsGUI.Layout.GetControlRect(true, FoCsGUI.SingleLine), serializedObject.FindProperty("storedValue"), ValueContent);

                    if (cc.changed)
                        serializedObject.ApplyModifiedProperties();
                }
            }
        }
    }
}