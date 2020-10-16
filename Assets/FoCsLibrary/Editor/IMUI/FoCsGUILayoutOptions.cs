#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsGUILayoutOptions.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:10 PM
#endregion

using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor {
    public static partial class FoCsGUI {
        public static class LayoutOptions {

            public static OptionsArray Expand(bool val = true) => new OptionsArray(GUILayout.ExpandHeight(val), GUILayout.ExpandWidth(val));

            public static OptionsArray ExpandHeight(bool val = true) => GUILayout.ExpandHeight(val);

            public static OptionsArray SingleLineHeight() => Height(SingleLine);

            public static OptionsArray Height(float val) => GUILayout.Height(val);

            public static OptionsArray MinHeight(float val) => GUILayout.MinHeight(val);

            public static OptionsArray MaxHeight(float val) => GUILayout.MaxHeight(val);

            public static OptionsArray ForceHeight(float val) =>
                    new[] {
                            GUILayout.Height(val), GUILayout.MinHeight(val), GUILayout.MaxHeight(val)
                    };

            public static OptionsArray ExpandWidth(bool val = true) => GUILayout.ExpandWidth(val);

            public static OptionsArray Width(float val) => GUILayout.Width(val);

            public static OptionsArray MinWidth(float val) => GUILayout.MinWidth(val);

            public static OptionsArray MaxWidth(float val) => GUILayout.MaxWidth(val);

            public static OptionsArray ForceWidth(float val) =>
                    new[] {
                            GUILayout.Width(val), GUILayout.MinWidth(val), GUILayout.MaxWidth(val)
                    };

            public struct OptionsArray {
                public OptionsArray(List<GUILayoutOption> guiLayout) => _GuiLayout = guiLayout;

                public OptionsArray(params GUILayoutOption[] guiLayout) => _GuiLayout = new List<GUILayoutOption>(guiLayout);

                private List<GUILayoutOption> _GuiLayout;

                public OptionsArray AddMoreOptions(GUILayoutOption option) {
                    _GuiLayout.Add(option);

                    return this;
                }

                public OptionsArray AddMoreOptions(GUILayoutOption[] option) {
                    _GuiLayout.AddRange(option);

                    return this;
                }

                public static OptionsArray operator +(OptionsArray a, OptionsArray b) {
                    var rtn = new OptionsArray {
                            _GuiLayout = new List<GUILayoutOption>(a._GuiLayout.Count + b._GuiLayout.Count)
                    };

                    rtn._GuiLayout.AddRange(a._GuiLayout);
                    rtn._GuiLayout.AddRange(b._GuiLayout);

                    return rtn;
                }

                public static implicit operator GUILayoutOption[](OptionsArray input) => input._GuiLayout.ToArray();

                public static implicit operator OptionsArray(GUILayoutOption input) =>
                        new OptionsArray {
                                _GuiLayout = new List<GUILayoutOption> {
                                        input
                                }
                        };

                public static implicit operator OptionsArray(GUILayoutOption[] input) =>
                        new OptionsArray {
                                _GuiLayout = new List<GUILayoutOption>(input)
                        };
            }
        }
    }
}