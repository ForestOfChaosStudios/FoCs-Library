using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	[FoCsControlPanel.ControlPanelTab]
	public static class ReorderableListSettingsTab
		{
		public static void DrawGUI(FoCsControlPanel owner)
		{
			using(FoCsEditor.Disposables.HorizontalScope(FoCsGUI.Styles.UnitySkins.Box, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true)))
			{
				FoCsGUI.Layout.Label("List Settings");
			}
		}
	}
}
