using System;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsGUI
	{
		public static partial class Styles
		{
			public static FoCsStyle DownArrow = new FoCsStyle(() =>
			{
				var style = new GUIStyle("RL FooterButton") {normal = new GUIStyleState {background = GetTexture("FoCs_d_1_arrow")}, name = "DownArrow"};

				return style;
			});

			public static FoCsStyle Down2Arrow = new FoCsStyle(() =>
			{
				var style = new GUIStyle("RL FooterButton") {normal = new GUIStyleState {background = GetTexture("FoCs_d_2_arrow")}, name = "Down2Arrow"};

				return style;
			});

			public static FoCsStyle UpArrow = new FoCsStyle(() =>
			{
				var style = new GUIStyle("RL FooterButton") {normal = new GUIStyleState {background = GetTexture("FoCs_u_1_arrow")}, name = "UpArrow"};

				return style;
			});

			public static FoCsStyle Up2Arrow = new FoCsStyle(() =>
			{
				var style = new GUIStyle("RL FooterButton") {normal = new GUIStyleState {background = GetTexture("FoCs_u_2_arrow")}, name = "Up2Arrow"};

				return style;
			});


			public static FoCsStyle InLineOptionsMenu = new FoCsStyle(() =>
			{
				var style = new GUIStyle("Icon.TrackOptions") {overflow = {top = -4, bottom = 4}, name = "InLineOptionsMenu"};

				return style;
			});

			public static FoCsStyle ButtonNoOutline = new FoCsStyle(() =>
			{
				var style = new GUIStyle(GUI.skin.button) {normal = {background = null}, active = {background = null}, focused = {background = null}, hover = {background = null}, name = "ButtonNoOutline"};

				return style;
			});

			public static FoCsStyle CrossCircle = new FoCsStyle(() =>
			{
				var style = new GUIStyle("TL SelectionBarCloseButton")
				{
						fixedHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing,
						fixedWidth  = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing,
						name        = "CrossCircle"
				};

				return style;
			});

			public static FoCsStyle Toolbar = new FoCsStyle(() =>
			{
				var style = new GUIStyle(Unity.Toolbar) {fixedHeight = 0, name = "Toolbar"};

				return style;
			});

			public static FoCsStyle ToolbarButton = new FoCsStyle(() =>
			{
				var style = new GUIStyle(Unity.ToolbarButton) {fixedHeight = 0, name = "ToolbarButton"};

				return style;
			});


			public static FoCsStyle Find = new FoCsStyle(() =>
			{
				var style = new GUIStyle("RL FooterButton") {normal = {background = GetTexture("FoCs_find")}, hover = {background = GetTexture("FoCs_find_hover")}, active = {background = GetTexture("FoCs_find_active")}, name = "Find"};

				return style;
			});


			private const float RowField_ALPHA = 0.6f;

			public static FoCsStyle RowField = new FoCsStyle(() =>
			{
				var style = new GUIStyle("Button") {name = "RowField"};

				style.margin = new RectOffset(0, 0, 0, 0);

				style.normal.textColor   = Color.white;
				style.onNormal.textColor = Color.white;

				style.normal.background   = TextureUtilities.GetSolidTexture(new Color(0.6f, 0.6f, 0.6f, RowField_ALPHA));
				style.onNormal.background = TextureUtilities.GetSolidTexture(new Color(0.7f, 0.7f, 0.7f, RowField_ALPHA));

				style.hover.textColor   = Color.white;
				style.onHover.textColor = Color.white;

				style.hover.background   = TextureUtilities.GetSolidTexture(new Color(0.9f, 0.4f, 0f, RowField_ALPHA));
				style.onHover.background = TextureUtilities.GetSolidTexture(new Color(1f,   0.5f, 0f, RowField_ALPHA));

				style.active.textColor   = Color.white;
				style.onActive.textColor = Color.white;

				style.active.background   = TextureUtilities.GetSolidTexture(new Color(0.4f, 0.9f, 0.4f, RowField_ALPHA));
				style.onActive.background = TextureUtilities.GetSolidTexture(new Color(0.5f, 1f,   0.5f, RowField_ALPHA));

				style.onFocused.textColor  = Color.white;
				style.onFocused.background = TextureUtilities.GetSolidTexture(new Color(0.17f, 0f, 0.69f, RowField_ALPHA));

				return style;
			});

			public static FoCsStyle RowOddField = new FoCsStyle(() =>
			{
				var style = new GUIStyle(RowField) {name = "RowOddField"};

				style.normal.background = TextureUtilities.GetSolidTexture(new Color(0.5f, 0.51f, 0.51f, 1));

				return style;
			});


			public class FoCsStyle
			{
				public GUIStyle Style { get; }

				public FoCsStyle(GUIStyle _style)
				{
					Style = _style;
				}

				public FoCsStyle(Func<GUIStyle> _style)
				{
					Style = _style();
				}

				public static implicit operator GUIStyle(FoCsStyle input) => input.Style;
				public static implicit operator FoCsStyle(GUIStyle input) => new FoCsStyle(input);
			}
		}
	}
}
