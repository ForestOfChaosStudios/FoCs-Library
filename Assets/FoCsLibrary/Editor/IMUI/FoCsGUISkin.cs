﻿#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsGUISkin.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:10 PM
#endregion

using System;
using ForestOfChaos.Unity.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor {
    // ReSharper disable once MismatchedFileName
    public static partial class FoCsGUI {
        public static partial class Styles {
            private const float RowField_ALPHA = 0.6f;

            public static FoCsStyle DownArrow = new FoCsStyle(() => {
                var style = new GUIStyle("RL FooterButton");
                style.name              = "DownArrow";
                style.normal.background = GetTexture("FoCs_d_1_arrow");

                return style;
            });

            public static FoCsStyle Down2Arrow = new FoCsStyle(() => {
                var style = new GUIStyle("RL FooterButton");
                style.name              = "Down2Arrow";
                style.normal.background = GetTexture("FoCs_d_2_arrow");

                return style;
            });

            public static FoCsStyle UpArrow = new FoCsStyle(() => {
                var style = new GUIStyle("RL FooterButton");
                style.name              = "UpArrow";
                style.normal.background = GetTexture("FoCs_u_1_arrow");

                return style;
            });

            public static FoCsStyle Up2Arrow = new FoCsStyle(() => {
                var style = new GUIStyle("RL FooterButton");
                style.name              = "Up2Arrow";
                style.normal.background = GetTexture("FoCs_u_2_arrow");

                return style;
            });

            public static FoCsStyle InLineOptionsMenu = new FoCsStyle(() => {
                var style = new GUIStyle(Unity.ToggleGroup);
                style.name = "InLineOptionsMenu";

                return style;
            });

            public static FoCsStyle CrossCircle = new FoCsStyle(() => {
                var style = new GUIStyle("RL FooterButton");
                style.name        = "CrossCircle";
                style.fixedHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                style.fixedWidth  = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

                return style;
            });

            public static FoCsStyle Toolbar = new FoCsStyle(() => {
                var style = new GUIStyle(Unity.Toolbar);
                style.name        = "Toolbar";
                style.fixedHeight = 0;

                return style;
            });

            public static FoCsStyle ToolbarButton = new FoCsStyle(() => {
                var style = new GUIStyle(Unity.ToolbarButton);
                style.name        = "ToolbarButton";
                style.fixedHeight = 0;

                return style;
            });

            public static FoCsStyle Find = new FoCsStyle(() => {
                var style = new GUIStyle("RL FooterButton");
                style.name              = "Find";
                style.active.background = GetTexture("FoCs_find_active");
                style.hover.background  = GetTexture("FoCs_find_hover");
                style.normal.background = GetTexture("FoCs_find");

                return style;
            });

            public static FoCsStyle RowField = new FoCsStyle(() => {
                var style = new GUIStyle("Button");
                style.name                 = "RowField";
                style.margin               = new RectOffset(0, 0, 0, 0);
                style.normal.textColor     = Color.white;
                style.normal.background    = TextureUtilities.GetSolidTexture(new Color(0.6f, 0.6f, 0.6f, RowField_ALPHA));
                style.onNormal.textColor   = Color.white;
                style.onNormal.background  = TextureUtilities.GetSolidTexture(new Color(0.3f, 0.7f, 0.7f, RowField_ALPHA));
                style.hover.textColor      = Color.white;
                style.hover.background     = TextureUtilities.GetSolidTexture(new Color(0.9f, 0.4f, 0f, RowField_ALPHA));
                style.onHover.textColor    = Color.white;
                style.onHover.background   = TextureUtilities.GetSolidTexture(new Color(1f, 0.5f, 0f, RowField_ALPHA));
                style.active.textColor     = Color.white;
                style.active.background    = TextureUtilities.GetSolidTexture(new Color(0.4f, 0.9f, 0.4f, RowField_ALPHA));
                style.onActive.textColor   = Color.white;
                style.onActive.background  = TextureUtilities.GetSolidTexture(new Color(0.5f, 1f, 0.5f, RowField_ALPHA));
                style.focused.textColor    = Color.white;
                style.focused.background   = TextureUtilities.GetSolidTexture(new Color(0.17f, 0f, 0.69f, RowField_ALPHA));
                style.onFocused.textColor  = Color.white;
                style.onFocused.background = TextureUtilities.GetSolidTexture(new Color(0.25f, 0f, 1f, RowField_ALPHA));

                return style;
            });

            public static FoCsStyle RowFieldOdd = new FoCsStyle(() => {
                var style = new GUIStyle(RowField);
                style.name              = "RowFieldOdd";
                style.normal.background = TextureUtilities.GetSolidTexture(new Color(0.5f, 0.51f, 0.51f, 1));

                return style;
            });

            public class FoCsStyle {
                public GUIStyle Style { get; }

                public FoCsStyle(GUIStyle _style) => Style = _style;

                public FoCsStyle(Func<GUIStyle> _style) => Style = _style();

                public static implicit operator GUIStyle(FoCsStyle input) => input.Style;

                public static implicit operator FoCsStyle(GUIStyle input) => new FoCsStyle(input);
            }
        }
    }
}