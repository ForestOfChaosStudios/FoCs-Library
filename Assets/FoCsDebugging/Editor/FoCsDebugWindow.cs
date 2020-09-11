#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Debugging.Editor
//       File: FoCsDebugWindow.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


using ForestOfChaos.Unity.Debugging;
using ForestOfChaos.Unity.Editor.Utilities;
using ForestOfChaos.Unity.Editor.Windows;
using UnityEditor;
using UnityEngine;
using KeyValue = System.Collections.Generic.KeyValuePair<string, ForestOfChaos.Unity.Debugging.FoCsDebug.Data>;

namespace ForestOfChaos.Unity.Editor.Debugging {
    [FoCsWindow]
    public class FoCsDebugWindow: FoCsWindow<FoCsDebugWindow> {
        private const string  WINDOW_NAME = "FoCsDebugWindow";
        private const int     LABEL_WIDTH = 64;
        private const int     ENTRY_WIDTH = 200;
        private       Vector2 ScrollPos;

        [MenuItem(FileStrings.FORESTOFCHAOS_TOOLS_ + WINDOW_NAME)]
        internal static void Init() {
            GetWindowAndShow();
            Window.titleContent.text = WINDOW_NAME;
        }

        protected override void OnGUI() {
            using (var scroll = Disposables.ScrollViewScope(ScrollPos, true)) {
                ScrollPos = scroll.scrollPosition;

                foreach (var data in FoCsDebug.DataDictionary)
                    DrawField(data);
            }
        }

        private static void DrawField(KeyValue data) {
            using (Disposables.HorizontalScope(GUI.skin.box)) {
                FoCsGUI.Layout.LabelField(data.Key, GUILayout.Width(LABEL_WIDTH));

                using (Disposables.HorizontalScope()) {
                    DrawData(data.Value);
                    var tempData = data.Value.previousData;

                    for (var i = 0; i < 5; i++) {
                        if (tempData == null)
                            break;

                        DrawData(tempData);
                        tempData = tempData.previousData;
                    }

                    if (tempData != null)
                        tempData.previousData = null;
                }
            }
        }

        private static void DrawData(FoCsDebug.Data data) {
            using (Disposables.VerticalScope(GUILayout.Width(ENTRY_WIDTH))) {
                FoCsGUI.Layout.LabelField(data.Value);
                FoCsGUI.Layout.LabelField($"Time: {data.Time}");
            }
        }

        protected void Update() {
            if (Application.isPlaying)
                Repaint();
        }
    }
}