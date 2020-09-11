#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsTabbedWindow.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


using System;
using ForestOfChaos.Unity.Extensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.Windows {
    public abstract class FoCsTabbedWindow<T>: FoCsWindow<T> where T: FoCsWindow {
        public enum TitleBarPos {
            Top,
            Bottom,
            Left,
            Right
        }

        public  int         activeTab;
        private Vector2     scrollPos          = Vector2.zero;
        public  float       TitleBarLabelWidth = 100;
        public  TitleBarPos TitleBarPosition   = TitleBarPos.Top;
        public  bool        TitleBarScrollable;

        public abstract FoCsTab<T>[] Tabs { get; }

        public float TitleBarLabelWidthTotal => TitleBarScrollable? TitleBarLabelWidth + 20 : TitleBarLabelWidth;

        protected override void OnGUI() {
            switch (TitleBarPosition) {
                case TitleBarPos.Top:
                    DrawTop();

                    break;
                case TitleBarPos.Bottom:
                    DrawBottom();

                    break;
                case TitleBarPos.Left:
                    DrawLeft();

                    break;
                case TitleBarPos.Right:
                    DrawRight();

                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void DrawActiveTab() {
            if (!Tabs.IsNullOrEmpty())
                Tabs[activeTab].DrawTab(this);
        }

        private void DrawHeaderGUI() {
            for (var i = 0; i < Tabs.Length; i++) {
                if (Tabs[i] != null) {
                    if (GUILayout.Toggle(i == activeTab, Tabs[i].TabName, EditorStyles.toolbarButton, GUILayout.MinWidth(TitleBarLabelWidth)))
                        activeTab = i;
                }
            }
        }

        private void DrawTop() {
            if (TitleBarScrollable) {
                using (Disposables.VerticalScope()) {
                    using (var scrollViewScope = Disposables.ScrollViewScope(scrollPos, true, GUILayout.ExpandWidth(true), GUILayout.Height(33))) {
                        scrollPos = scrollViewScope.scrollPosition;

                        using (Disposables.HorizontalScope(EditorStyles.toolbar, GUILayout.ExpandWidth(true)))
                            DrawHeaderGUI();
                    }

                    using (Disposables.VerticalScope(GUILayout.ExpandHeight(true)))
                        DrawActiveTab();
                }
            }
            else {
                using (Disposables.VerticalScope()) {
                    using (Disposables.HorizontalScope(EditorStyles.toolbar, GUILayout.ExpandWidth(true)))
                        DrawHeaderGUI();

                    using (Disposables.VerticalScope(GUILayout.ExpandHeight(true)))
                        DrawActiveTab();
                }
            }
        }

        private void DrawBottom() {
            if (TitleBarScrollable) {
                using (Disposables.VerticalScope(GUILayout.ExpandHeight(true)))
                    DrawActiveTab();

                using (Disposables.VerticalScope()) {
                    using (var scrollViewScope = Disposables.ScrollViewScope(scrollPos, true, GUILayout.ExpandWidth(true), GUILayout.Height(33))) {
                        scrollPos = scrollViewScope.scrollPosition;

                        using (Disposables.HorizontalScope(EditorStyles.toolbar, GUILayout.ExpandWidth(true)))
                            DrawHeaderGUI();
                    }
                }
            }
            else {
                using (Disposables.VerticalScope()) {
                    using (Disposables.VerticalScope(GUILayout.ExpandHeight(true)))
                        DrawActiveTab();

                    using (Disposables.HorizontalScope(EditorStyles.toolbar, GUILayout.ExpandWidth(true)))
                        DrawHeaderGUI();
                }
            }
        }

        private void DrawLeft() {
            if (TitleBarScrollable) {
                using (Disposables.HorizontalScope(GUILayout.ExpandWidth(true))) {
                    using (var scrollViewScope = Disposables.ScrollViewScope(scrollPos, true, GUILayout.ExpandHeight(true), GUILayout.Width(TitleBarLabelWidthTotal))) {
                        using (Disposables.VerticalScope(GUILayout.Width(TitleBarLabelWidth))) {
                            scrollPos = scrollViewScope.scrollPosition;
                            DrawHeaderGUI();
                        }
                    }

                    DrawActiveTab();
                }
            }
            else {
                using (Disposables.HorizontalScope()) {
                    using (Disposables.VerticalScope(EditorStyles.toolbar, GUILayout.Width(TitleBarLabelWidth)))
                        DrawHeaderGUI();

                    using (Disposables.VerticalScope(GUILayout.ExpandWidth(true)))
                        DrawActiveTab();
                }
            }
        }

        private void DrawRight() {
            if (TitleBarScrollable) {
                using (Disposables.HorizontalScope(GUILayout.ExpandWidth(true))) {
                    DrawActiveTab();

                    using (var scrollViewScope = Disposables.ScrollViewScope(scrollPos, true, GUILayout.ExpandHeight(true), GUILayout.Width(TitleBarLabelWidthTotal))) {
                        using (Disposables.VerticalScope(GUILayout.Width(TitleBarLabelWidth))) {
                            scrollPos = scrollViewScope.scrollPosition;
                            DrawHeaderGUI();
                        }
                    }
                }
            }
            else {
                using (Disposables.HorizontalScope()) {
                    using (Disposables.VerticalScope(GUILayout.ExpandWidth(true)))
                        DrawActiveTab();

                    using (Disposables.VerticalScope(EditorStyles.toolbar, GUILayout.Width(TitleBarLabelWidth)))
                        DrawHeaderGUI();
                }
            }
        }
    }
}