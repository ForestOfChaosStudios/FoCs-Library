using ForestOfChaosLibrary.Editor.Utilities;
using ForestOfChaosLibrary.Editor.Windows;
using ForestOfChaosLibrary.ScreenCap;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor.ScreenCap
{
	[FoCsWindow]
	public class ScreenCapWindow: TabedWindow<ScreenCapWindow>
	{
		private const   string                 Title = "Screen Capture Window";
		public          string                 defaultPath;
		public          string                 filename = "";
		public          string                 path;
		public          int                    scale = 1;
		public override Tab<ScreenCapWindow>[] Tabs { get; } = {new ScreenshotTab(), new TimelapseTab()};

		private void OnEnable()
		{
			defaultPath = Application.streamingAssetsPath + "/../../";
			path        = Application.streamingAssetsPath + "/../../";
		}

		[MenuItem(FileStrings.FORESTOFCHAOS_ + Title)]
		internal static void Init()
		{
			GetWindowAndOpenUtility();
			Window.minSize      = new Vector2(400, 220);
			Window.titleContent = new GUIContent(Title);
		}
	}
}
