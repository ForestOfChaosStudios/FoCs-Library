#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsInfoTab.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.Editor {
    [FoCsControlPanel.FoCsControlPanelTabAttribute]
    public static class FoCsInfoTab {
        public static void DrawGUI(FoCsControlPanel owner) {
            using (Disposables.HorizontalScope(FoCsGUI.Styles.Unity.Box, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true)))
                FoCsGUI.Layout.Label("FoCs Info");
        }
    }
}