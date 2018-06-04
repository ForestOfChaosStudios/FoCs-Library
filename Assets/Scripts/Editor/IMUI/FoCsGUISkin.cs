using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsGUI
	{
		public static partial class Styles
		{
			private static GUIStyle downArrow;
			private static GUIStyle down2Arrow;
			private static GUIStyle upArrow;
			private static GUIStyle up2Arrow;
			private static GUIStyle inLineOptionsMenu;
			private static GUIStyle buttonNoOutline;
			private static GUIStyle crossCircle;
			private static GUIStyle toolbar;
			private static GUIStyle toolbarButton;
			private static GUIStyle buttonDetailed;
			private static GUIStyle buttonThick;
			private static GUIStyle buttonThin;
			private static GUIStyle find;

			public static GUIStyle DownArrow
			{
				get
				{
					if(downArrow != null)
						return downArrow;

					downArrow = new GUIStyle("RL FooterButton") {normal = new GUIStyleState {background = GetTexture("FoCs_d_1_arrow")}, name = nameof(DownArrow)};

					return downArrow;
				}
			}

			public static GUIStyle Down2Arrow
			{
				get
				{
					if(down2Arrow != null)
						return down2Arrow;

					down2Arrow = new GUIStyle("RL FooterButton") {normal = new GUIStyleState {background = GetTexture("FoCs_d_2_arrow")}, name = nameof(Down2Arrow)};

					return down2Arrow;
				}
			}

			public static GUIStyle UpArrow
			{
				get
				{
					if(upArrow != null)
						return upArrow;

					upArrow = new GUIStyle("RL FooterButton") {normal = new GUIStyleState {background = GetTexture("FoCs_u_1_arrow")}, name = nameof(UpArrow)};

					return upArrow;
				}
			}

			public static GUIStyle Up2Arrow
			{
				get
				{
					if(up2Arrow != null)
						return up2Arrow;

					up2Arrow = new GUIStyle("RL FooterButton") {normal = new GUIStyleState {background = GetTexture("FoCs_u_2_arrow")}, name = nameof(Up2Arrow)};

					return up2Arrow;
				}
			}

			public static GUIStyle InLineOptionsMenu
			{
				get
				{
					if(inLineOptionsMenu != null)
						return inLineOptionsMenu;

					inLineOptionsMenu = new GUIStyle("Icon.TrackOptions") {overflow = {top = -4, bottom = 4}, name = nameof(InLineOptionsMenu)};

					return inLineOptionsMenu;
				}
			}

			public static GUIStyle ButtonNoOutline
			{
				get
				{
					if(buttonNoOutline != null)
						return buttonNoOutline;

					buttonNoOutline = new GUIStyle(GUI.skin.button) {normal = {background = null}, active = {background = null}, focused = {background = null}, hover = {background = null}, name = nameof(ButtonNoOutline)};

					return buttonNoOutline;
				}
			}

			public static GUIStyle CrossCircle
			{
				get
				{
					if(crossCircle != null)
						return crossCircle;

					crossCircle = new GUIStyle("TL SelectionBarCloseButton")
					{
							fixedHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing,
							fixedWidth  = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing,
							name        = nameof(CrossCircle)
					};

					return crossCircle;
				}
			}

			public static GUIStyle Toolbar
			{
				get
				{
					if(toolbar != null)
						return toolbar;

					toolbar = new GUIStyle(Unity.Toolbar) {fixedHeight = 0, name = nameof(Toolbar)};

					return toolbar;
				}
			}

			public static GUIStyle ToolbarButton
			{
				get
				{
					if(toolbarButton != null)
						return toolbarButton;

					toolbarButton = new GUIStyle(Unity.ToolbarButton) {fixedHeight = 0, name = nameof(ToolbarButton)};

					return toolbarButton;
				}
			}

			public static GUIStyle ButtonDetailed
			{
				get
				{
					if(buttonDetailed != null)
						return buttonDetailed;

					buttonDetailed = new GUIStyle(Unity.Button)
					{
							normal = {background = GetTexture("FoCs_panel_detailed")},
							hover  = {background = GetTexture("FoCs_panel_detailed_hover")},
							active = {background = GetTexture("FoCs_panel_detailed_active")},
							name   = nameof(ButtonDetailed)
					};

					return buttonDetailed;
				}
			}

			public static GUIStyle ButtonThick
			{
				get
				{
					if(buttonThick != null)
						return buttonThick;

					buttonThick = new GUIStyle(Unity.Button)
					{
							normal = {background = GetTexture("FoCs_panel_thick")},
							hover  = {background = GetTexture("FoCs_panel_thick_hover")},
							active = {background = GetTexture("FoCs_panel_thick_active")},
							name   = nameof(ButtonThick)
					};

					return buttonThick;
				}
			}

			public static GUIStyle ButtonThin
			{
				get
				{
					if(buttonThin != null)
						return buttonThin;

					buttonThin = new GUIStyle(Unity.Button)
					{
							normal = {background = GetTexture("FoCs_panel_thin")},
							hover  = {background = GetTexture("FoCs_panel_thin_hover")},
							active = {background = GetTexture("FoCs_panel_thin_active")},
							name   = nameof(ButtonThin)
					};

					return buttonThin;
				}
			}

			public static GUIStyle Find
			{
				get
				{
					if(find != null)
						return find;

					find = new GUIStyle("RL FooterButton") {normal = {background = GetTexture("FoCs_find")}, hover = {background = GetTexture("FoCs_find_hover")}, active = {background = GetTexture("FoCs_find_active")}, name = nameof(Find)};

					return find;
				}
			}

			public static GUIStyle[] StylesArray => new[] {DownArrow, Down2Arrow, UpArrow, Up2Arrow, InLineOptionsMenu, ButtonNoOutline, CrossCircle, Toolbar, ToolbarButton, ButtonDetailed, ButtonThick, ButtonThin};
		}
	}
}
