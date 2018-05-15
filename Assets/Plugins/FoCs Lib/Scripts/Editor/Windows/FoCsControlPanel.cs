using System;
using System.Collections.Generic;
using ForestOfChaosLib.Editor.Windows;
using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	public class FoCsControlPanel: FoCsWindow<FoCsControlPanel>
	{
		private const string SHORT_TITLE = "Control Panel";
		private const string TITLE = "FoCs " + SHORT_TITLE;

		public static GUISkin skin;

		[MenuItem(FileStrings.FORESTOFCHAOS_ + SHORT_TITLE)]
		private static void Init()
		{
			GetWindow();
			Window.titleContent = new GUIContent(TITLE);
			Window.Show();
		}

		protected override void OnGUI()
		{
			FoCsGUI.Layout.Label(TITLE, FoCsGUI.Styles.UnitySkins.BoldLabel);
			using(FoCsEditor.Disposables.HorizontalScope())
			{
				using(FoCsEditor.Disposables.VerticalScope(GUILayout.Width(200)))
				{
					DrawWindowButton();
				}
				using(FoCsEditor.Disposables.VerticalScope())
				{
					using(FoCsEditor.Disposables.HorizontalScope())
						DrawButton();
					DrawButton();
					using(FoCsEditor.Disposables.VerticalScope(GUILayout.ExpandHeight(true)))
					{ }
					using(FoCsEditor.Disposables.HorizontalScope())
						DrawUISettings();
				}
			}
		}

		private static void DrawUISettings()
		{
			if(FoCsGUI.Layout.Button("Get", FoCsGUI.Styles.ToolbarButton, GUILayout.Height(32)))
			{
				if(skin)
				{ }
			}

			if(FoCsGUI.Layout.Button("Set", FoCsGUI.Styles.ToolbarButton, GUILayout.Height(32)))
			{
				if(skin)
					skin.customStyles = FoCsGUI.Styles.StylesArray;
			}
			skin = (GUISkin)EditorGUILayout.ObjectField(skin, typeof(GUISkin), false);
		}

		private void Update()
		{
			if(mouseOverWindow)
			{
				Repaint();
			}
		}

		private static void DrawButton()
		{
			FoCsGUI.Layout.Button("Thin",     FoCsGUI.Styles.ButtonThin    , GUILayout.Height(32));
			FoCsGUI.Layout.Button("Thick",    FoCsGUI.Styles.ButtonThick   , GUILayout.Height(32));
			FoCsGUI.Layout.Button("Detailed", FoCsGUI.Styles.ButtonDetailed, GUILayout.Height(32));
		}

		private static void DrawWindowButton()
		{
			var windows = GetTypesWith<FoCsWindowAttribute>(false);
			foreach(var key in windows)
			{
				using(FoCsEditor.Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar))
				{
					var @event = FoCsGUI.Layout.Button(key.Name.SplitCamelCase(), FoCsGUI.Styles.ToolbarButton, GUILayout.Height(32));
					if(@event)
					{
						Window.ShowNotification(new GUIContent($"Clicked: {key.Name.SplitCamelCase()}"));
					}
				}
			}
		}

		private static List<Type> GetTypesWith<TAttribute>(bool inherit)
			where TAttribute: Attribute
		{
			var list = new List<Type>();
			foreach(var t in typeof(TAttribute).Assembly.GetTypes())
			{
				if(t.IsDefined(typeof(TAttribute), inherit))
					list.Add(t);
			}
			return list;
		}
	}
}