using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;

namespace ForestOfChaosLib.Screenshot
{
	public class ScreenCapWindow: TabedWindow<ScreenCapWindow>
	{
		private Tab<ScreenCapWindow>[] _tabs = {new ScreenshotTaker(), new TimelapseTaker(),};

		public override Tab<ScreenCapWindow>[] Tabs
		{
			get { return _tabs; }
		}

		private const string Title = "Screen Capture Window";

		[MenuItem(FileStrings.FORESTOFCHAOS_ + Title)]
		private static void Init()
		{
			GetWindow();
			window.titleContent.text = Title;
		}
	}
}