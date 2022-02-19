#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsCopyPasteUtilityTab.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.Editor.Utilities;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.Windows {
    [FoCsControlPanel.FoCsControlPanelTab]
    public static class FoCsCopyPasteUtilityTab {
        public static void DrawGUI(FoCsControlPanel owner) {
            using (Disposables.HorizontalScope()) {
                FoCsGUI.Layout.Label("Type of Object", GUILayout.Width(Screen.width * 0.4f));
                FoCsGUI.Layout.Label("Method of copy");
            }

            foreach (var copyMode in CopyPasteUtility.TypeCopyData) {
                using (Disposables.HorizontalScope()) {
                    FoCsGUI.Layout.Label(copyMode.Key.ToString(), GUILayout.Width(Screen.width * 0.4f));
                    FoCsGUI.Layout.Label(copyMode.Value.ToString());
                }
            }
        }
    }
}