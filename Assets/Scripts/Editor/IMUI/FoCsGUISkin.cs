using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsGUI
	{
		public static partial class Styles
		{
			private static GUIStyle downArrow = null;

			public static GUIStyle DownArrow
			{
				get
				{
					if(downArrow != null)
						return downArrow;
					downArrow = new GUIStyle("RL FooterButton");
					downArrow.normal = new GUIStyleState
									   {
										   background = GetTexture("FoCs_d_1_arrow")
									   };
					downArrow.name = nameof(DownArrow);
					return downArrow;
				}
			}

			private static GUIStyle down2Arrow = null;

			public static GUIStyle Down2Arrow
			{
				get
				{
					if(down2Arrow != null)
						return down2Arrow;
					down2Arrow = new GUIStyle("RL FooterButton");
					down2Arrow.normal = new GUIStyleState
										{
											background = GetTexture("FoCs_d_2_arrow")
										};
					down2Arrow.name = nameof(Down2Arrow);
					return down2Arrow;
				}
			}

			private static GUIStyle upArrow = null;

			public static GUIStyle UpArrow
			{
				get
				{
					if(upArrow != null)
						return upArrow;
					upArrow = new GUIStyle("RL FooterButton");
					upArrow.normal = new GUIStyleState
									 {
										 background = GetTexture("FoCs_u_1_arrow")
									 };
					upArrow.name = nameof(UpArrow);
					return upArrow;
				}
			}

			private static GUIStyle up2Arrow = null;

			public static GUIStyle Up2Arrow
			{
				get
				{
					if(up2Arrow != null)
						return up2Arrow;
					up2Arrow = new GUIStyle("RL FooterButton");
					up2Arrow.normal = new GUIStyleState
									  {
										  background = GetTexture("FoCs_u_2_arrow")
									  };
					up2Arrow.name = nameof(Up2Arrow);
					return up2Arrow;
				}
			}

			private static GUIStyle inLineOptionsMenu;

			public static GUIStyle InLineOptionsMenu
			{
				get
				{
					if(inLineOptionsMenu != null)
						return inLineOptionsMenu;
					inLineOptionsMenu = new GUIStyle("Icon.TrackOptions")
										 {
											 overflow =
											 {
												 top = -4,
												 bottom = 4
											 }
										 };
					inLineOptionsMenu.name = nameof(InLineOptionsMenu);
					return inLineOptionsMenu;
				}
			}

			private static GUIStyle buttonNoOutline;

			public static GUIStyle ButtonNoOutline
			{
				get
				{
					if(buttonNoOutline != null)
						return buttonNoOutline;
					buttonNoOutline = new GUIStyle(GUI.skin.button)
									   {
										   normal =
										   {
											   background = null
										   },
										   active =
										   {
											   background = null
										   },
										   focused =
										   {
											   background = null
										   },
										   hover =
										   {
											   background = null
										   }
									   };
					buttonNoOutline.name = nameof(ButtonNoOutline);
					return buttonNoOutline;
				}
			}

			private static GUIStyle crossCircle;

			public static GUIStyle CrossCircle
			{
				get
				{
					if(crossCircle != null)
						return crossCircle;
					crossCircle = new GUIStyle("TL SelectionBarCloseButton")
								   {
									   fixedHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing,
									   fixedWidth = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing
								   };
					crossCircle.name = nameof(CrossCircle);
					return crossCircle;
				}
			}

			private static GUIStyle toolbar;

			public static GUIStyle Toolbar
			{
				get
				{
					if(toolbar != null)
						return toolbar;
					toolbar = new GUIStyle(Unity.Toolbar)
							  {
								  fixedHeight = 0
							  };
					toolbar.name = nameof(Toolbar);
					return toolbar;
				}
			}

			private static GUIStyle toolbarButton;

			public static GUIStyle ToolbarButton
			{
				get
				{
					if(toolbarButton != null)
						return toolbarButton;
					toolbarButton = new GUIStyle(Unity.ToolbarButton)
									{
										fixedHeight = 0
									};
					toolbarButton.name = nameof(ToolbarButton);
					return toolbarButton;
				}
			}

			private static GUIStyle buttonDetailed;

			public static GUIStyle ButtonDetailed
			{
				get
				{
					if(buttonDetailed != null)
						return buttonDetailed;
					buttonDetailed = new GUIStyle(Unity.Button)
									 {
										 normal =
										 {
											 background = GetTexture("FoCs_panel_detailed")
										 },
										 hover =
										 {
											 background = GetTexture("FoCs_panel_detailed_hover")
										 },
										 active =
										 {
											 background = GetTexture("FoCs_panel_detailed_active")
										 }
									 };
					buttonDetailed.name = nameof(ButtonDetailed);
					return buttonDetailed;
				}
			}

			private static GUIStyle buttonThick;

			public static GUIStyle ButtonThick
			{
				get
				{
					if(buttonThick != null)
						return buttonThick;
					buttonThick = new GUIStyle(Unity.Button)
								  {
									  normal =
									  {
										  background = GetTexture("FoCs_panel_thick")
									  },
									  hover =
									  {
										  background = GetTexture("FoCs_panel_thick_hover")
									  },
									  active =
									  {
										  background = GetTexture("FoCs_panel_thick_active")
									  }
								  };
					buttonThick.name = nameof(ButtonThick);
					return buttonThick;
				}
			}

			private static GUIStyle buttonThin;

			public static GUIStyle ButtonThin
			{
				get
				{
					if(buttonThin != null)
						return buttonThin;
					buttonThin = new GUIStyle(Unity.Button)
								 {
									 normal =
									 {
										 background = GetTexture("FoCs_panel_thin")
									 },
									 hover =
									 {
										 background = GetTexture("FoCs_panel_thin_hover")
									 },
									 active =
									 {
										 background = GetTexture("FoCs_panel_thin_active")
									 }
								 };
					buttonThin.name = nameof(ButtonThin);
					return buttonThin;
				}
			}

			public static GUIStyle[] StylesArray => new[]
													  {
														  DownArrow,
														  Down2Arrow,
														  UpArrow,
														  Up2Arrow,
														  InLineOptionsMenu,
														  ButtonNoOutline,
														  CrossCircle,
														  Toolbar,
														  ToolbarButton,
														  ButtonDetailed,
														  ButtonThick,
														  ButtonThin
													  };
		}
	}
}