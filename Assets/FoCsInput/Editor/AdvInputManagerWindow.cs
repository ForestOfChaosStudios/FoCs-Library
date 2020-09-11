#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Input.Editor
//       File: AdvInputManagerWindow.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:04 AM
#endregion


using ForestOfChaos.Unity.Editor;
using ForestOfChaos.Unity.Editor.Utilities;
using ForestOfChaos.Unity.Editor.Windows;
using ForestOfChaos.Unity.AdvVar.InputSystem;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.InputManager.Editor {
    public class AdvInputManagerWindow: FoCsWindow<AdvInputManagerWindow> {
        public const  string InputManagerEnumName = "PlayerInputManagerEnum";
        private const string Title                = "Input Manager";

        [MenuItem(FileStrings.FORESTOFCHAOS_TOOLS_ + "Player Input Manager Window")]
        internal static void Init() {
            GetWindowAndShow();
            Window.titleContent.text = Title;
        }

        protected void Update() {
            Repaint();
        }

        protected override void OnGUI() {
            if (AdvInputManager.InstanceNull)
                return;

            using (Disposables.VerticalScope(GUI.skin.box)) {
                foreach (var input in AdvInputManager.Instance.Axes)
                    DrawInput(input.Value);
            }
        }

        private static void DrawInput(InputAxis input) {
            using (Disposables.HorizontalScope(GUI.skin.box)) {
                EditorGUILayout.LabelField($"Axis: {input.Axis}");
                EditorGUILayout.LabelField($"Inverted: {input.ValueInverted}");
                var barSize = EditorGUILayout.BeginHorizontal();
                GUILayout.Space(32);

                using (Disposables.VerticalScope(GUI.skin.box)) {
                    GUILayout.Space(16);
                    EditorGUI.ProgressBar(barSize, (input.Value + 1) * 0.5f, $"Value: {input.Value}");
                }

                EditorGUILayout.EndHorizontal();
            }
        }
    }
}