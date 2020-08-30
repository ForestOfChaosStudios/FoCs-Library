#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library.Editor
//       File: ScreenCapWindow.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:49 AM
#endregion


using ForestOfChaosLibrary.Editor.Utilities;
using ForestOfChaosLibrary.Editor.Windows;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor.ScreenCap {
    [FoCsWindow]
    public class ScreenCapWindow: FoCsTabbedWindow<ScreenCapWindow> {
        private const string Title = "Screen Capture Window";
        public        string defaultPath;
        public        string filename = "";
        public        string path;
        public        int    scale = 1;

        public override FoCsTab<ScreenCapWindow>[] Tabs { get; } = {new ScreenshotTab(), new TimelapseTab()};

        private void OnEnable() {
            defaultPath = Application.streamingAssetsPath + "/../../";
            path        = Application.streamingAssetsPath + "/../../";
        }

        [MenuItem(FileStrings.FORESTOFCHAOS_TOOLS_ + Title)]
        internal static void Init() {
            GetWindowAndOpenUtility();
            Window.minSize      = new Vector2(400, 220);
            Window.titleContent = new GUIContent(Title);
        }
    }
}