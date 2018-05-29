using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.ScreenCap
{
	[FoCsWindow]
	public class ScreenCapWindow: TabedWindow<ScreenCapWindow>
	{
		public int scale = 1;

		public string defaultPath;

		public string path;

		public string filename = "";

		private void OnEnable()
		{
			defaultPath = Application.streamingAssetsPath + "/../../";
			path        = Application.streamingAssetsPath + "/../../";
		}

		public override Tab<ScreenCapWindow>[] Tabs { get; } = {new ScreenshotTab(), new TimelapseTab(),};

		private const string Title = "Screen Capture Window";

		[MenuItem(FileStrings.FORESTOFCHAOS_ + Title)]
		internal static void Init()
		{
			GetWindowAndOpenUtility();
			Window.minSize      = new Vector2(400, 220);
			Window.titleContent = new GUIContent(Title);
		}
	}
}