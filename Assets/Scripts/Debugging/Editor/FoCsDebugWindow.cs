using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;
using UnityEngine;
using KeyValue = System.Collections.Generic.KeyValuePair<string, ForestOfChaosLib.Debugging.FoCsDebug.Data>;

namespace ForestOfChaosLib.Debugging
{
	[FoCsWindow]
	public class FoCsDebugWindow: FoCsWindow<FoCsDebugWindow>
	{
		private const string  WINDOW_NAME = "FoCsDebugWindow";
		private const int     LABEL_WIDTH = 64;
		private const int     ENTRY_WIDTH = 200;
		private       Vector2 ScrollPos;

		[MenuItem(FileStrings.FORESTOFCHAOS_ + WINDOW_NAME)]
		internal static void Init()
		{
			GetWindowAndShow();
			Window.titleContent.text = WINDOW_NAME;
		}

		private static KeyValue TEST_DATA = new KeyValue("a", FoCsDebug.Data.Empty());

		protected override void OnGUI()
		{
			if(TEST_DATA.Key == "a")
				TEST_DATA = new KeyValue("TEST", FoCsDebug.Data.Build("1", "17"));

			FoCsGUI.Layout.Label($"Time: {Time.time}");
			DrawField(TEST_DATA);

			using(var scroll = Disposables.ScrollViewScope(ScrollPos, true))
			{
				ScrollPos = scroll.scrollPosition;

				foreach(var data in FoCsDebug.DataDictionary)
					DrawField(data);
			}
		}

		private static void DrawField(KeyValue data)
		{
			using(Disposables.HorizontalScope(GUI.skin.box))
			{
				FoCsGUI.Layout.LabelField(data.Key, GUILayout.Width(LABEL_WIDTH));

				using(Disposables.HorizontalScope())
				{
					DrawData(data.Value);
					var tempData = data.Value.previousData;

					for(var i = 0; i < 5; i++)
					{
						if(tempData == null)
							break;

						DrawData(tempData);
						tempData = tempData.previousData;
					}
				}
			}
		}

		private static void DrawData(FoCsDebug.Data data)
		{
			using(Disposables.VerticalScope(GUILayout.Width(ENTRY_WIDTH)))
			{
				FoCsGUI.Layout.LabelField(data.Value);
				FoCsGUI.Layout.LabelField($"Time: {data.Time}");
			}
		}

		protected void Update()
		{
			if(Application.isPlaying)
				Repaint();
		}
	}
}