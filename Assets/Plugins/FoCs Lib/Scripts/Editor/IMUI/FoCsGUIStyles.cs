using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.ImGUI
{
	[InitializeOnLoad]
	public static class FoCsGUIStyles
	{
		public static FoCsGUIData FoCsGUIData { get; }

		static FoCsGUIStyles()
		{
			EditorHelpers.CreateAndCheckFolder(FOLDER, DIR);
			FoCsGUIData = (FoCsGUIData)EditorGUIUtility.Load(FILE_PATH_NAME);
			if(FoCsGUIData != null)
				return;
			FoCsGUIData = ScriptableObject.CreateInstance<FoCsGUIData>();

			AssetDatabase.CreateAsset(FoCsGUIData, FILE_PATH_NAME);
			AssetDatabase.SaveAssets();
		}


		internal const string FILE_PATH_NAME = PATH +"\\" + SkinFileName + SkinFileExt;


		internal const string SkinFileName = "FoCsEditorData";

		internal const string SkinFileExt = ".asset";


		internal const string PATH = FOLDER +"\\" + DIR;
		internal const string FOLDER = "Assets";
		internal const string DIR = "Editor Default Resources";

		private static GUIStyle _InLineOptionsMenu;

		private static GUIStyle _ButtonNoOutline;

		private static GUIStyle _CrossCircle;

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