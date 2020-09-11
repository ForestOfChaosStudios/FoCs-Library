#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: ContextMenuData.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ForestOfChaos.Unity.Attributes;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor {
    public partial class FoCsEditor {
        private static readonly Type                                ContextMenuType       = typeof(ContextMenu);
        private static readonly Type                                ContextMenuLayoutType = typeof(ContextMenuLayoutAttribute);
        protected               Dictionary<string, ContextMenuData> contextData           = new Dictionary<string, ContextMenuData>();

        private static IEnumerable<MethodInfo> GetAllMethods(Type t) {
            const BindingFlags binding = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            return t == null? Enumerable.Empty<MethodInfo>() : t.GetMethods(binding).Concat(GetAllMethods(t.BaseType));
        }

        protected void InitContextMenu() {
            if (contextData == null)
                contextData = new Dictionary<string, ContextMenuData>();
            else
                contextData.Clear();

            // Get context menu
            var targetType = target.GetType();
            var methods    = GetAllMethods(targetType).ToArray();

            for (var index = 0; index < methods.GetLength(0); ++index) {
                var methodInfo                  = methods[index];
                var contextMenuAttributes       = methodInfo.GetCustomAttributes(ContextMenuType,       false);
                var contextMenuLayoutAttributes = methodInfo.GetCustomAttributes(ContextMenuLayoutType, false);

                for (var i = 0; i < contextMenuAttributes.Length; i++) {
                    var contextMenu = (ContextMenu)contextMenuAttributes[i];

                    if (contextMenu == null)
                        continue;

                    ContextMenuLayoutAttribute layout = null;

                    for (var innerIndex = 0; innerIndex < contextMenuLayoutAttributes.Length; innerIndex++) {
                        var contextMenuLayoutAttribute = (ContextMenuLayoutAttribute)contextMenuLayoutAttributes[innerIndex];

                        if (contextMenuLayoutAttribute == null)
                            continue;

                        layout = contextMenuLayoutAttribute;

                        break;
                    }

                    if (contextData.ContainsKey(contextMenu.menuItem)) {
                        var data = contextData[contextMenu.menuItem];

                        if (contextMenu.validate)
                            data.Validate = methodInfo;
                        else
                            data.Function = methodInfo;

                        if (layout != null)
                            data.Layout = new ContextMenuData.LayoutOptions(layout);

                        contextData[data.MenuItem] = data;
                    }
                    else {
                        var data = new ContextMenuData(contextMenu.menuItem);

                        if (contextMenu.validate)
                            data.Validate = methodInfo;
                        else
                            data.Function = methodInfo;

                        if (layout != null)
                            data.Layout = new ContextMenuData.LayoutOptions(layout);

                        contextData.Add(data.MenuItem, data);
                    }
                }
            }
        }

        public void DrawContextMenuButtons() {
            if (contextData.Count == 0)
                return;

            FoCsGUI.Layout.Space(4);
            FoCsGUI.Layout.LabelField("Context Menu:", FoCsGUI.Styles.Unity.BoldLabel);
            //TODO: Refine ContextMenuLayoutAttribute Logic
            var rectRows = new Dictionary<int, Rect>();

            foreach (var kv in contextData) {
                var enabledState = GUI.enabled;
                var isEnabled    = true;

                if (kv.Value.Validate != null)
                    isEnabled = (bool)kv.Value.Validate.Invoke(target, null);

                GUI.enabled = isEnabled;

                if (kv.Value.Function != null) {
                    if (kv.Value.Layout.HasValue) {
                        var  layout = kv.Value.Layout.Value;
                        Rect rect;

                        if (rectRows.ContainsKey(layout.Column))
                            rect = rectRows[layout.Column];
                        else {
                            FoCsGUI.Layout.Space();
                            rect = GUILayoutUtility.GetLastRect();
                            rectRows.Add(layout.Column, rect);
                        }

                        using (var scope = Disposables.RectHorizontalScope(layout.AmountPerLine, rect)) {
                            if (layout.Row != 0)
                                scope.GetNext(layout.Row);

                            if (FoCsGUI.Button(scope.GetNext(), kv.Key))
                                InvokeMethod(kv);
                        }
                    }
                    else {
                        if (FoCsGUI.Layout.Button(kv.Key))
                            InvokeMethod(kv);
                    }
                }

                GUI.enabled = enabledState;
            }
        }

        private void InvokeMethod(KeyValuePair<string, ContextMenuData> kv) {
            kv.Value.Function.Invoke(target, null);
        }

        // Based off of https://github.com/SubjectNerd-Unity/ReorderableInspector/blob/master/Editor/ReorderableArrayInspector.cs
        // Though I have added an extra attribute that allows you to specify how the buttons will be laid out
        protected struct ContextMenuData {
            public string         MenuItem;
            public MethodInfo     Function;
            public MethodInfo     Validate;
            public LayoutOptions? Layout;

            public ContextMenuData(string item) {
                MenuItem = item;
                Function = null;
                Validate = null;
                Layout   = null;
            }

            public struct LayoutOptions {
                public int Row;
                public int Column;
                public int AmountPerLine;

                public LayoutOptions(int row, int column, int amountPerLine) {
                    Row           = row;
                    Column        = column;
                    AmountPerLine = amountPerLine;
                }

                public LayoutOptions(ContextMenuLayoutAttribute layout) {
                    Row           = layout.Row;
                    Column        = layout.Column;
                    AmountPerLine = layout.AmountPerLine;
                }
            }
        }
    }
}