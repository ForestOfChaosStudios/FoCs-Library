using ForestOfChaosLib.Editor.Windows;
using UnityEditor;

namespace ForestOfChaosLib.WIP.Editor.ObjectBrowser
{
	public class ObjectBrowserWindow: TabedWindow<ObjectBrowserWindow>
	{
		public override Tab<ObjectBrowserWindow>[] Tabs { get; } =
			{
				new ObjectBrowserTab("Tab 1"),
				new ObjectBrowserTab("Tab 2"),
				new ObjectBrowserTab("Tab 3"),
				new ObjectBrowserTab("Tab 4")
			};

		[MenuItem("Forest Of Chaos/Object Browser")]
		private static void Init()
		{
			GetWindow();
		}

		public class ObjectBrowserTab: Tab<ObjectBrowserWindow>
		{
			public override string TabName { get; }

			public ObjectBrowserTab(string tabName)
			{
				TabName = tabName;
			}

			public override void DrawTab(Window<ObjectBrowserWindow> owner)
			{ }
		}
	}
}