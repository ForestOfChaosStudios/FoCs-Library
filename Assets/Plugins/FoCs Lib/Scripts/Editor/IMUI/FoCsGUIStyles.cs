using ForestOfChaosLib.CSharpExtensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.ImGUI
{
	public static class FoCsGUIStyles
	{
		private static GUIStyle _InLineOptionsMenu;

		public static GUIStyle InLineOptionsMenu
		{
			get
			{
				if(_InLineOptionsMenu != null)
					return _InLineOptionsMenu;
				_InLineOptionsMenu = new GUIStyle("Icon.TrackOptions");
				_InLineOptionsMenu.overflow.top = -4;
				_InLineOptionsMenu.overflow.bottom = 4;
				return _InLineOptionsMenu;
			}
		}

		private static GUIStyle _ButtonNoOutline;

		public static GUIStyle ButtonNoOutline
		{
			get
			{
				if(_ButtonNoOutline != null)
					return _ButtonNoOutline;
				_ButtonNoOutline = new GUIStyle(GUI.skin.button);
				_ButtonNoOutline.normal.background = null;
				_ButtonNoOutline.active.background = null;
				_ButtonNoOutline.focused.background = null;
				_ButtonNoOutline.hover.background = null;
				return _ButtonNoOutline;
			}
		}

		private static GUIStyle _CrossCircle;

		public static GUIStyle CrossCircle
		{
			get
			{
				if(_CrossCircle.IsNull())
				{
					_CrossCircle = new GUIStyle("TL SelectionBarCloseButton");
					_CrossCircle.fixedHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
					_CrossCircle.fixedWidth = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
				}
				return _CrossCircle;
			}
		}
	}

	public static class FoCsGUIImages
	{
		private static Texture objectField;

		public static Texture ObjectField
		{
			get { return objectField ?? (objectField = EditorGUIUtility.FindTexture("IN ObjectField f@2x")); }
		}
	}
}