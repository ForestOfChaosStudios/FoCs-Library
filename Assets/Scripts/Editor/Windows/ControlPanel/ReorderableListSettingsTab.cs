using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	[FoCsControlPanel.ControlPanelTabAttribute]
	public static class ReorderableListSettingsTab
	{
		private static readonly GUIContent Enabled  = new GUIContent("List Limiter Enabled");
		private static readonly GUIContent Disabled = new GUIContent("List Limiter Disabled");

		public static void DrawGUI(FoCsControlPanel owner)
		{
			using(FoCsEditor.Disposables.VerticalScope(FoCsGUI.Styles.Unity.Box, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true)))
			{
				FoCsGUI.Layout.Label("List Limiter", FoCsGUI.Styles.Unity.BoldLabel);
				FoCsGUI.Layout.InfoBox("Careful, Disabling this may cause lag in larger lists. This is also the case when its active, but it is reduced. This is caused by the way the Unity Editor is drawn.");
				FoCsEditor.ReorderableListProperty.LimitingEnabled = FoCsGUI.Layout.Toggle(FoCsEditor.ReorderableListProperty.LimitingEnabled? Enabled : Disabled, FoCsEditor.ReorderableListProperty.LimitingEnabled);

				using(var cc = FoCsEditor.Disposables.ChangeCheck())
				{
					FoCsGUI.Layout.Label("List Range", FoCsGUI.Styles.Unity.BoldLabel);
					FoCsGUI.Layout.InfoBox("Change max number of displayed items in the lists. DEFAULT = 25");
					var num = FoCsGUI.Layout.IntField("Total Display Count", FoCsEditor.ReorderableListProperty.ListLimiter.TOTAL_VISIBLE_COUNT);

					if(cc.changed)
						FoCsEditor.ReorderableListProperty.ListLimiter.TOTAL_VISIBLE_COUNT = num;
				}
			}
		}
	}
}