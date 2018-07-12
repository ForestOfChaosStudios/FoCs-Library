using System.Collections.Generic;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Editor.Windows;
using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;
using RLP = ForestOfChaosLib.Editor.FoCsEditor.ReorderableListProperty;

namespace ForestOfChaosLib.Editor.UnitySettings
{
	[FoCsWindow]
	public class AdvancedUnitySettingsWindow: TabedWindow<AdvancedUnitySettingsWindow>
	{
		private const string                             Title = "Advanced Unity Settings Window";
		private       Tab<AdvancedUnitySettingsWindow>[] tabs;
		public override Tab<AdvancedUnitySettingsWindow>[] Tabs
		{
			get
			{
				if(tabs == null)
					CreatePrivateTabsArray();

				return tabs;
			}
		}

		[MenuItem(FileStrings.FORESTOFCHAOS_ + Title)]
		internal static void Init()
		{
			GetWindowAndShow();
			Window.titleContent.text = Title;
		}

		private void OnEnable()
		{
			CreatePrivateTabsArray();
		}

		private void CreatePrivateTabsArray()
		{
			var arry = UnitySettingsReader.Assets;
			tabs = new Tab<AdvancedUnitySettingsWindow>[arry.Length];

			for(var i = 0; i < arry.Length; i++)
			{
				//if(arry[i].FileName == UnitySettingsReader.EditorSettings.FileName)
				//	tabs[i] = new SearchableTab(arry[i], arry[i]);
				//else
					tabs[i] = new SearchableTab(arry[i], arry[i]);
			}
		}

		private class Tab: Tab<AdvancedUnitySettingsWindow>
		{
			protected const    float                   EXTRA_LABEL_WIDTH = 128;
			protected const    float                   LEFT_BORDER       = 32f;
			protected const    float                   RIGHT_BORDER      = 0;
			protected readonly SerializedObject        Asset;
			private readonly   Dictionary<string, RLP> reorderableLists = new Dictionary<string, RLP>(1);
			protected          Vector2                 vector2          = Vector2.zero;
			public override    string                  TabName { get; }

			public Tab(string tabName, SerializedObject asset)
			{
				TabName = tabName;
				Asset   = asset;
			}

			public override void DrawTab(FoCsWindow<AdvancedUnitySettingsWindow> owner)
			{
				using(FoCsEditor.Disposables.HorizontalScope(GUI.skin.box))
					EditorGUILayout.LabelField(TabName);

				using(FoCsEditor.Disposables.LabelAddWidth(EXTRA_LABEL_WIDTH))
				{
					Asset.Update();

					using(FoCsEditor.Disposables.HorizontalScope())
					{
						DrawSpace(LEFT_BORDER);

						using(var scrollViewScope = FoCsEditor.Disposables.ScrollViewScope(vector2, true))
						{
							vector2 = scrollViewScope.scrollPosition;

							using(var changeCheckScope = FoCsEditor.Disposables.ChangeCheck())
							{
								var unityDefProp = true;

								foreach(var property in Asset.Properties())
								{
									if(unityDefProp)
									{
										unityDefProp = false;

										continue;
									}

									DrawProperty(property);
								}

								if(changeCheckScope.changed)
									EditorUtility.SetDirty(Asset.targetObject);
							}
						}

						DrawSpace(RIGHT_BORDER);
					}
				}

				DrawFooter();
			}

			protected void DrawFooter()
			{
				using(FoCsEditor.Disposables.VerticalScope())
				{
					if(FoCsGUI.Layout.Button("Force save"))
						EditorUtility.SetDirty(Asset.targetObject);

					using(FoCsEditor.Disposables.HorizontalScope(GUI.skin.box))
						EditorGUILayout.HelpBox("Warning, This window has not been tested for all the settings being validated.\nIt is still recommended to use the Unity settings windows.", MessageType.Warning);
				}
			}

			private void DrawListProperty(SerializedProperty itr)
			{
				var ReorderableListProperty = GetReorderableList(itr);

				using(FoCsEditor.Disposables.VerticalScope(GUI.skin.box))
					ReorderableListProperty.HandleDrawing();
			}

			private static void DrawSingleProperty(SerializedProperty itr)
			{
				using(FoCsEditor.Disposables.HorizontalScope(GUI.skin.box))
					EditorGUILayout.PropertyField(itr, true);
			}

			protected void DrawProperty(SerializedProperty itr)
			{
				if(itr.isArray && (itr.propertyType != SerializedPropertyType.String))
					DrawListProperty(itr);
				else
					DrawSingleProperty(itr);
			}

			private RLP GetReorderableList(SerializedProperty property)
			{
				var id = property.propertyPath + "-" + property.name;
				RLP ret;

				if(reorderableLists.TryGetValue(id, out ret))
				{
					ret.Property = property;

					return ret;
				}

				ret = new RLP(property);
				reorderableLists.Add(id, ret);

				return ret;
			}
		}

		private class SearchableTab:Tab
		{
			public SearchableTab(string tabName, SerializedObject asset): base(tabName, asset) { }
			private string Search;
			private static readonly GUIContent SearchGuiContent= new GUIContent("Search: ", "This will only show properties that match, Ignores case.");
			public override void DrawTab(FoCsWindow<AdvancedUnitySettingsWindow> owner)
			{
				using (FoCsEditor.Disposables.HorizontalScope(GUI.skin.box))
					EditorGUILayout.LabelField(TabName);

				Search = FoCsGUI.Layout.TextField(SearchGuiContent, Search);

                using (FoCsEditor.Disposables.LabelAddWidth(EXTRA_LABEL_WIDTH))
				{
					Asset.Update();

					using (FoCsEditor.Disposables.HorizontalScope())
					{
						DrawSpace(LEFT_BORDER);

						using (var scrollViewScope = FoCsEditor.Disposables.ScrollViewScope(vector2, true))
						{
							vector2 = scrollViewScope.scrollPosition;

							using (var changeCheckScope = FoCsEditor.Disposables.ChangeCheck())
							{
								var unityDefProp = true;

								foreach (var property in Asset.Properties())
								{
									if (unityDefProp)
									{
										unityDefProp = false;

										continue;
									}
									if(Search.IsNullOrEmpty())
										DrawProperty(property);
									else if(property.name.ToLower().Contains(Search.ToLower()))
                                        DrawProperty(property);
								}

								if (changeCheckScope.changed)
									EditorUtility.SetDirty(Asset.targetObject);
							}
						}

						DrawSpace(RIGHT_BORDER);
					}
				}

				DrawFooter();
			}
		}
	}
}