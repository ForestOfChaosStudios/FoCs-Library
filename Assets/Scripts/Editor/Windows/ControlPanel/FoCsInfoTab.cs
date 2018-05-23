using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	[FoCsControlPanel.ControlPanelTab]
	public static class FoCsInfoTab
	{
		public static void DrawGUI(FoCsControlPanel owner)
		{
			using(FoCsEditor.Disposables.HorizontalScope(FoCsGUI.Styles.Unity.Box, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true)))
			{
				FoCsGUI.Layout.Label("FoCs Info");
			}
		}
	}
}