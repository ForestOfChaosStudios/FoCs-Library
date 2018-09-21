using UnityEngine;

namespace ForestOfChaosLibrary.Editor
{
	[FoCsControlPanel.ControlPanelTabAttribute]
	public static class FoCsInfoTab
	{
		public static void DrawGUI(FoCsControlPanel owner)
		{
			using(Disposables.HorizontalScope(FoCsGUI.Styles.Unity.Box, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true)))
				FoCsGUI.Layout.Label("FoCs Info");
		}
	}
}
