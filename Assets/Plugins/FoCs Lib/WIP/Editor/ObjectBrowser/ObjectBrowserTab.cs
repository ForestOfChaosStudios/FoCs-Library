using ForestOfChaosLib.Editor.ImGUI;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.WIP.Editor.ObjectBrowser
{
	public class ObjectBrowserTab: Tab<ObjectBrowserWindow>
	{
		private const float TYPE_WIDTH = 250;
		private Vector2 typeScrollPos = Vector2.zero;
		public override string TabName { get; }

		public ObjectBrowserTab(string tabName)
		{
			TabName = tabName;
		}

		public override void DrawTab(Window<ObjectBrowserWindow> owner)
		{
			FoCsGUILayout.Label("Object Browser");
			using(EditorDisposables.HorizontalScope())
			{
				using(EditorDisposables.VerticalScope(GUILayout.Width(TYPE_WIDTH)))
					DrawTypePanel();
				using(EditorDisposables.VerticalScope())
					DrawObjectPanel();
			}
		}

		private void DrawTypePanel()
		{
			using(EditorDisposables.HorizontalScope(EditorStyles.toolbar))
				FoCsGUILayout.Label("Type Selection", EditorStyles.toolbarButton);
			using(var scroll = EditorDisposables.ScrollViewScope(typeScrollPos, true))
			{
				using(EditorDisposables.ColorChanger(Color.blue))
				{
					FoCsGUILayout.Button("Type Selection", EditorStyles.toolbarButton);
					//FoCsGUILayout.Button("Type Selection", GUI.skin.);
				}
				FoCsGUILayout.Button("Type Selection");
				FoCsGUILayout.Button("Type Selection");
				typeScrollPos = scroll.scrollPosition;
			}
		}

		private void DrawObjectPanel()
		{
			using(EditorDisposables.HorizontalScope(EditorStyles.toolbar))
				FoCsGUILayout.Label("Objects", EditorStyles.toolbarButton);
		}
	}
}