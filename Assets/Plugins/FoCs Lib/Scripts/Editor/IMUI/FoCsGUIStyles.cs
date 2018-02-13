using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.ImGUI
{
	public static class FoCsGUIStyles
	{
		private static GUISkin skin;
		internal static string SkinFileName = "FoCsSkin";
		internal static string SkinGUID = "9d2742e5c3c229d4c99d91613bd3c761";

		internal static string Path = @"Assets\Plugins\FoCs Lib\Editor Resources";
		private static GUIStyle _InLineOptionsMenu;

		private static GUIStyle _ButtonNoOutline;

		private static GUIStyle _CrossCircle;

		public static GUISkin Skin
		{
			get
			{
				if(skin != null)
					return skin;
				skin = (GUISkin)EditorGUIUtility.Load(Path + "\\" + SkinFileName);
				return skin;
			}
		}

		public static GUIStyle InLineOptionsMenu
		{
			get
			{
				if(_InLineOptionsMenu != null)
					return _InLineOptionsMenu;
				_InLineOptionsMenu = new GUIStyle("Icon.TrackOptions")
									 {
										 overflow =
										 {
											 top = -4,
											 bottom = 4
										 }
									 };
				return _InLineOptionsMenu;
			}
		}

		public static GUIStyle ButtonNoOutline
		{
			get
			{
				if(_ButtonNoOutline != null)
					return _ButtonNoOutline;
				_ButtonNoOutline = new GUIStyle(GUI.skin.button)
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
				return _ButtonNoOutline;
			}
		}

		public static GUIStyle CrossCircle
		{
			get
			{
				if(_CrossCircle != null)
					return _CrossCircle;
				_CrossCircle = new GUIStyle("TL SelectionBarCloseButton")
							   {
								   fixedHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing,
								   fixedWidth = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing
							   };
				return _CrossCircle;
			}
		}
	}
}