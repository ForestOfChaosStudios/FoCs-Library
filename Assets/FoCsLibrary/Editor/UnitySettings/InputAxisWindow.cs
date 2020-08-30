#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library.Editor
//       File: InputAxisWindow.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:49 AM
#endregion


using ForestOfChaosLibrary.Editor.UnitySettings;
using ForestOfChaosLibrary.Editor.Utilities;
using ForestOfChaosLibrary.Editor.Windows;
using UnityEditor;

namespace ForestOfChaosLibrary.Editor.InputManager {
    public class InputAxisWindow: FoCsWindow<InputAxisWindow> {
        private const string Title = "InputAxisWindow";

        [MenuItem(FileStrings.FORESTOFCHAOS_TOOLS_ + Title)]
        private static void Init() {
            GetWindowAndShow();
            Window.titleContent.text = Title;
        }

        protected override void OnGUI() {
            foreach (var axisName in ReadInputManager.GetAxisProperties())
                EditorGUILayout.PropertyField(axisName, true);
        }
    }
}