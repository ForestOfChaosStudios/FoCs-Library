using ForestOfChaosLibrary.Editor.Utilities;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor
{
	[FoCsControlPanel.FoCsControlPanelTab]
	public static class FoCsCopyPasteUtilityTab
	{
		public static void DrawGUI(FoCsControlPanel owner)
		{
			using(Disposables.HorizontalScope())
			{
				FoCsGUI.Layout.Label("Type of Object", GUILayout.Width(Screen.width * 0.4f));
				FoCsGUI.Layout.Label("Method of copy");
			}

			foreach(var copyMode in CopyPasteUtility.TypeCopyData)
			{
				using(Disposables.HorizontalScope())
				{
					FoCsGUI.Layout.Label(copyMode.Key.ToString(), GUILayout.Width(Screen.width * 0.4f));
					FoCsGUI.Layout.Label(copyMode.Value.ToString());
				}
			}
		}
	}
}
