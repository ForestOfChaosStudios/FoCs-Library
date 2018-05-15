using System.Collections.Generic;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;
using UnityEngine;
using RLP = ForestOfChaosLib.Editor.FoCsEditor.ReorderableListProperty;

namespace ForestOfChaosLib.Editor.UnitySettings
{
	[FoCsWindow]
	public class AdvancedUnitySettingsWindow: TabedWindow<AdvancedUnitySettingsWindow>
	{
		private const string Title = "Advanced Unity Settings Window";

		private Tab<AdvancedUnitySettingsWindow>[] _tabs;

		public override Tab<AdvancedUnitySettingsWindow>[] Tabs
		{
			get
			{
				if(_tabs == null)
					CreatePrivateTabsArray();
				return _tabs;
			}
		}

		[MenuItem(FileStrings.FORESTOFCHAOS_ + Title)]
		private static void Init()
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
			_tabs = new Tab<AdvancedUnitySettingsWindow>[arry.Length];
			for(var i = 0; i < arry.Length; i++)
				_tabs[i] = new Tab(arry[i], arry[i]);
		}

		private class Tab: Tab<AdvancedUnitySettingsWindow>
		{
			private const float EXTRA_LABEL_WIDTH = 128;

			private const float LEFT_BORDER = 32f;

			private const float RIGHT_BORDER = 0;


			private readonly SerializedObject Asset;

			private readonly Dictionary<string, RLP> reorderableLists = new Dictionary<string, RLP>(1);

			private Vector2 vector2 = Vector2.zero;

			public override string TabName { get; }

			public Tab(string tabName, SerializedObject asset)
			{
				TabName = tabName;
				Asset = asset;
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

			private void DrawFooter()
			{
				using(FoCsEditor.Disposables.VerticalScope())
				{
					if(FoCsGUI.AutoRect.Button("Force save"))
						EditorUtility.SetDirty(Asset.targetObject);

					using(FoCsEditor.Disposables.HorizontalScope(GUI.skin.box))
					{
						EditorGUILayout.
								HelpBox("Warning, This window has not been tested for all the settings being validated.\nIt is still recommended to use the Unity settings windows.",
										MessageType.Warning);
					}
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

			private void DrawProperty(SerializedProperty itr)
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
	}
}