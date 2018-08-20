using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	[FoCsControlPanel.ControlPanelTab]
	public static class ReorderableListSettingsTab
	{
		private static readonly GUIContent Enabled  = new GUIContent("List Limiter Enabled");
		private static readonly GUIContent Disabled = new GUIContent("List Limiter Disabled");
		private static          bool       ShowDebug;
		private static readonly GUIContent DebugEnabled  = new GUIContent("Enable Debug Info");
		private static readonly GUIContent DebugDisabled = new GUIContent("Disable Debug Info");

		public static void DrawGUI(FoCsControlPanel owner)
		{
			using(Disposables.VerticalScope(FoCsGUI.Styles.Unity.Box, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true)))
			{
				FoCsGUI.Layout.Label("List Limiter", FoCsGUI.Styles.Unity.BoldLabel);
				FoCsGUI.Layout.InfoBox("Careful, Disabling this may cause lag in larger lists. This is also the case when its active, but it is reduced. This is caused by the way the Unity Editor is drawn.");
				UnityReorderableListProperty.LimitingEnabled = FoCsGUI.Layout.Toggle(UnityReorderableListProperty.LimitingEnabled? Enabled : Disabled, UnityReorderableListProperty.LimitingEnabled);

				using(var cc = Disposables.ChangeCheck())
				{
					FoCsGUI.Layout.Label("List Range", FoCsGUI.Styles.Unity.BoldLabel);
					FoCsGUI.Layout.InfoBox("Change max number of displayed items in the lists. DEFAULT = 25");
					var num = FoCsGUI.Layout.IntField("Total Display Count", UnityReorderableListProperty.ListLimiter.TOTAL_VISIBLE_COUNT);

					if(cc.changed)
						UnityReorderableListProperty.ListLimiter.TOTAL_VISIBLE_COUNT = num;
				}

				FoCsGUI.Layout.Label();
				FoCsGUI.Layout.Label();
				ShowDebug = FoCsGUI.Layout.Toggle(ShowDebug? DebugEnabled : DebugDisabled, ShowDebug);

				if(ShowDebug)
					ReorderableListCacheTab.DrawGUI(owner);
			}
		}
	}

	public static class ReorderableListCacheTab
	{
		public static void DrawGUI(FoCsControlPanel owner)
		{
			using(Disposables.VerticalScope())
			{
				foreach(var reorderableListStorage in UnityReorderableListStorage.storages)
				{
					foreach(var reorderableListProperty in reorderableListStorage.URLPList)
					{
						using(Disposables.VerticalScope(FoCsGUI.Styles.Unity.Box))
						{
							using(Disposables.HorizontalScope())
							{
								FoCsGUI.Layout.Label("Key");
								FoCsGUI.Layout.Label(reorderableListProperty.Key);
							}

							using(Disposables.HorizontalScope())
							{
								FoCsGUI.Layout.Label("Limiter");
								FoCsGUI.Layout.Label(reorderableListProperty.Value.Limiter != null? reorderableListProperty.Value.Limiter.ToString() : "NULL");
							}
						}
					}
				}
			}
		}
	}
}
