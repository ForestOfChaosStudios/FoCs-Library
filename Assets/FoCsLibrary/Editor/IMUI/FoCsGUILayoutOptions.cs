#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsGUILayoutOptions.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections.Generic;
using UnityEngine;
using static ForestOfChaos.Unity.Editor.FoCsGUI.LayoutOptions;

namespace ForestOfChaos.Unity.Editor {
    public static partial class FoCsGUI {
        public static class LayoutOptions {

            public static OptionsArray Expand(bool val = true) => new OptionsArray(GUILayout.ExpandHeight(val), GUILayout.ExpandWidth(val));

            public static OptionsArray ExpandHeight(bool val = true) => GUILayout.ExpandHeight(val);

            public static OptionsArray ExpandWidth(bool val = true) => GUILayout.ExpandWidth(val);

            public static OptionsArray SingleLineHeight(float multiplier = 1) => Height(SingleLine * multiplier);

            public static OptionsArray Height(float val) => GUILayout.Height(val);

            public static OptionsArray MinHeight(float val) => GUILayout.MinHeight(val);

            public static OptionsArray MaxHeight(float val) => GUILayout.MaxHeight(val);

            public static OptionsArray Width(float val) => GUILayout.Width(val);

            public static OptionsArray MinWidth(float val) => GUILayout.MinWidth(val);

            public static OptionsArray MaxWidth(float val) => GUILayout.MaxWidth(val);

            public static OptionsArray ForceHeight(float val) => new OptionsArray(GUILayout.Height(val), GUILayout.MinHeight(val), GUILayout.MaxHeight(val));

            public static OptionsArray ForceWidth(float val) => new OptionsArray(GUILayout.Width(val), GUILayout.MinWidth(val), GUILayout.MaxWidth(val));

            public readonly struct OptionsArray {
                public OptionsArray(List<GUILayoutOption> guiLayout) => this.guiLayout = guiLayout;
                public OptionsArray(GUILayoutOption          guiLayout) => this.guiLayout = new List<GUILayoutOption>(1){ guiLayout };
                public OptionsArray(GUILayoutOption          guiLayout, GUILayoutOption guiLayout1) => this.guiLayout = new List<GUILayoutOption>(2){ guiLayout, guiLayout1 };
                public OptionsArray(GUILayoutOption          guiLayout, GUILayoutOption guiLayout1, GUILayoutOption guiLayout2) => this.guiLayout = new List<GUILayoutOption>(3){ guiLayout, guiLayout1, guiLayout2 };
                public OptionsArray(params GUILayoutOption[] guiLayout) => this.guiLayout = new List<GUILayoutOption>(guiLayout);

                private readonly List<GUILayoutOption> guiLayout;

                public OptionsArray AddMoreOptions(GUILayoutOption option) {
                    guiLayout.Add(option);

                    return this;
                }

                public OptionsArray AddMoreOptions(GUILayoutOption[] option) {
                    guiLayout.AddRange(option);

                    return this;
                }

                public OptionsArray AddMoreOptions(OptionsArray option) {
                    guiLayout.AddRange(option.guiLayout);

                    return this;
                }

                public static OptionsArray operator +(OptionsArray a, OptionsArray b) {
                    var rtn = new OptionsArray(new List<GUILayoutOption>(a.guiLayout.Count + b.guiLayout.Count));

                    rtn.guiLayout.AddRange(a.guiLayout);
                    rtn.guiLayout.AddRange(b.guiLayout);

                    return rtn;
                }

                public static implicit operator GUILayoutOption[](OptionsArray input) => input.guiLayout.ToArray();

                public static implicit operator OptionsArray(GUILayoutOption input) => new OptionsArray(new List<GUILayoutOption>(1) {input});

                public static implicit operator OptionsArray(GUILayoutOption[] input) => new OptionsArray (new List<GUILayoutOption>(input));
            }
        }
    }

    public static class OptionsArrayExtensions {
        public static OptionsArray Expand(this           OptionsArray optionsArray, bool  val = true) => optionsArray.AddMoreOptions(FoCsGUI.LayoutOptions.Expand(val));
        public static OptionsArray ExpandHeight(this     OptionsArray optionsArray, bool  val = true) => optionsArray.AddMoreOptions(FoCsGUI.LayoutOptions.ExpandHeight(val));
        public static OptionsArray ExpandWidth(this      OptionsArray optionsArray, bool  val = true) => optionsArray.AddMoreOptions(FoCsGUI.LayoutOptions.ExpandWidth(val));
        public static OptionsArray SingleLineHeight(this OptionsArray optionsArray, float val = 1)    => optionsArray.AddMoreOptions(FoCsGUI.LayoutOptions.SingleLineHeight(val));
        public static OptionsArray Height(this           OptionsArray optionsArray, float val)        => optionsArray.AddMoreOptions(FoCsGUI.LayoutOptions.Height(val));
        public static OptionsArray MinHeight(this        OptionsArray optionsArray, float val)        => optionsArray.AddMoreOptions(FoCsGUI.LayoutOptions.MinHeight(val));
        public static OptionsArray MaxHeight(this        OptionsArray optionsArray, float val)        => optionsArray.AddMoreOptions(FoCsGUI.LayoutOptions.MaxHeight(val));
        public static OptionsArray ForceHeight(this      OptionsArray optionsArray, float val)        => optionsArray.AddMoreOptions(FoCsGUI.LayoutOptions.ForceHeight(val));
        public static OptionsArray Width(this            OptionsArray optionsArray, float val)        => optionsArray.AddMoreOptions(FoCsGUI.LayoutOptions.Width(val));
        public static OptionsArray MinWidth(this         OptionsArray optionsArray, float val)        => optionsArray.AddMoreOptions(FoCsGUI.LayoutOptions.MinWidth(val));
        public static OptionsArray MaxWidth(this         OptionsArray optionsArray, float val)        => optionsArray.AddMoreOptions(FoCsGUI.LayoutOptions.MaxWidth(val));
        public static OptionsArray ForceWidth(this       OptionsArray optionsArray, float val)        => optionsArray.AddMoreOptions(FoCsGUI.LayoutOptions.ForceWidth(val));
    }
}