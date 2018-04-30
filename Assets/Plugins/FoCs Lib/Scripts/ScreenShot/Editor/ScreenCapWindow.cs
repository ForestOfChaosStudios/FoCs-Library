using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.ScreenCap
{
	public class ScreenCapWindow: TabedWindow<ScreenCapWindow>
	{
		public int scale = 1;

		public string defaultPath;

		public string path;

		public string filename = "";

		private void OnEnable()
		{
			defaultPath = Application.streamingAssetsPath + "/../../";
			path = Application.streamingAssetsPath + "/../../";
		}

		public override Tab<ScreenCapWindow>[] Tabs { get; } = {new ScreenshotTab(), new TimelapseTab(),};

		private const string Title = "Screen Capture Window";

		private static void Init()
		{
			GetWindowAndOpenTab();
			window.titleContent.text = Title;
		}

		[MenuItem(FileStrings.FORESTOFCHAOS_ + Title)]
		private static void OpenWind()
		{
			GetWindow();
			window.minSize = new Vector2(400,220);

			window.ShowUtility();
		}
	}
}