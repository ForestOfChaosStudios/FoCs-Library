#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsInfoTab.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Editor {
    [FoCsControlPanel.FoCsControlPanelTabAttribute]
    public static class FoCsInfoTab {
        public static void DrawGUI(FoCsControlPanel owner) {
            using (Disposables.HorizontalScope(FoCsGUI.Styles.Unity.Box, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true)))
                FoCsGUI.Layout.Label("FoCs Info");
        }
    }
}