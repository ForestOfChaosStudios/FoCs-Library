using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;

namespace ForestOfChaosLib.ScreenCap
{
	public class ScreenCapWindow: TabedWindow<ScreenCapWindow>
	{
		public override Tab<ScreenCapWindow>[] Tabs { get; } = {new ScreenshotTab(), new TimelapseTab(),};

		private const string Title = "Screen Capture Window";

		[MenuItem(FileStrings.FORESTOFCHAOS_ + Title)]
		private static void Init()
		{
			GetWindow();
			window.titleContent.text = Title;
		}
	}
}