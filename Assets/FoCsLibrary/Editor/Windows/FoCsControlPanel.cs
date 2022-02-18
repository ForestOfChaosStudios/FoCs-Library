#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsControlPanel.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using System.Collections.Generic;
using System.Reflection;
using ForestOfChaos.Unity.Editor.Utilities;
using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.Windows {
    public class FoCsControlPanel: FoCsWindow<FoCsControlPanel> {
        private const  string     SHORT_TITLE = "Control Panel";
        private const  string     TITLE       = "FoCs " + SHORT_TITLE;
        public static  GUISkin    skin;
        private static List<Type> windowList;
        private static List<Type> tabList;

        private static List<Type> WindowList => windowList ?? (windowList = ReflectionUtilities.GetTypesWith<FoCsWindowAttribute>(false));

        private static List<Type> TabList => tabList ?? (tabList = ReflectionUtilities.GetTypesWith<Editor.FoCsControlPanel.FoCsControlPanelTabAttribute>(false));

        private static int ActiveTab {
            get => EditorPrefs.GetInt("FoCsCP.ActiveIndex");
            set => EditorPrefs.SetInt("FoCsCP.ActiveIndex", value);
        }

        [MenuItem(FileStrings.FORESTOFCHAOS_ + SHORT_TITLE)]
        private static void Init() {
            GetWindowAndShow();
            Window.titleContent = new GUIContent(TITLE);
        }

        protected override void OnGUI() {
            FoCsGUI.Layout.Label(TITLE, FoCsGUI.Styles.Unity.BoldLabel);

            using (Disposables.HorizontalScope()) {
                using (Disposables.VerticalScope(GUILayout.Width(200)))
                    DrawWindowButtons();

                using (Disposables.VerticalScope()) {
                    using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar))
                        DrawTabButtons();

                    if (TabList.InRange(ActiveTab)) {
                        var meth = TabList[ActiveTab].GetMethod("DrawGUI");

                        if (meth != null)
                            meth.Invoke(null, new object[] { this });
                    }
                }
            }
        }

        private void Update() {
            if (mouseOverWindow)
                Repaint();
        }

        private static void DrawWindowButtons() {
            foreach (var key in WindowList) {
                using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar)) {
                    var @event = FoCsGUI.Layout.Button(key.Name.SplitCamelCase(), FoCsGUI.Styles.ToolbarButton, GUILayout.Height(32));

                    if (@event.Value) {
                        //Window.ShowNotification(new GUIContent($"Clicked: {key.Name.SplitCamelCase()}"));
                        var meth = key.GetMethod("Init", BindingFlags.NonPublic | BindingFlags.Static);

                        if (meth != null)
                            meth.Invoke(null, null);

                        //var otherWin = GetWindow(key);
                    }
                }
            }
        }

        private static void DrawTabButtons() {
            var index = 0;

            foreach (var key in TabList) {
                using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar)) {
                    var @event = FoCsGUI.Layout.Toggle(key.Name.SplitCamelCase(), ActiveTab == index, FoCsGUI.Styles.ToolbarButton, GUILayout.Height(32));

                    if (@event)
                        ActiveTab = index;
                }

                ++index;
            }
        }
    }
}