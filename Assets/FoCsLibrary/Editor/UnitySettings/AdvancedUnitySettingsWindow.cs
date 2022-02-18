#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: AdvancedUnitySettingsWindow.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Linq;
using ForestOfChaos.Unity.Editor.Utilities;
using ForestOfChaos.Unity.Editor.Windows;
using ForestOfChaos.Unity.Extensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.UnitySettings {
    [FoCsWindow]
    public class AdvancedUnitySettingsWindow: FoCsTabbedWindow<AdvancedUnitySettingsWindow> {
        private const string                                 Title = "Advanced Unity Settings Window";
        private       FoCsTab<AdvancedUnitySettingsWindow>[] tabs;

        public override FoCsTab<AdvancedUnitySettingsWindow>[] Tabs {
            get {
                if (tabs == null)
                    CreatePrivateTabsArray();

                return tabs;
            }
        }

        [MenuItem(FileStrings.FORESTOFCHAOS_TOOLS_ + Title)]
        internal static void Init() {
            GetWindowAndShow();
            Window.titleContent.text = Title;
        }

        private void OnEnable() {
            CreatePrivateTabsArray();
        }

        private void CreatePrivateTabsArray() {
            var arry = UnitySettingsReader.RawAssets;
            tabs = new FoCsTab<AdvancedUnitySettingsWindow>[arry.Length];

            for (var i = 0; i < arry.Length; i++)
                tabs[i] = new SearchableTab(arry[i], arry[i].Assets.Select(a => new SerializedObject(a)).ToArray());
        }

        private class SearchableTab: FoCsTab<AdvancedUnitySettingsWindow> {
            //private                 HandlerController[]         handlerControllers = null;
            //private                 UnityReorderableListStorage storage             = null;
            private const           float              EXTRA_LABEL_WIDTH = 128;
            private const           float              LEFT_BORDER       = 32f;
            private const           float              RIGHT_BORDER      = 0;
            private static readonly GUIContent         SearchGuiContent  = new GUIContent("Search: ", "This will only show properties that match, Ignores case.");
            private readonly        SerializedObject[] Assets;
            private                 string             Search;
            private                 Vector2            vector2 = Vector2.zero;

            public override string TabName { get; }

            public SearchableTab(string tabName, SerializedObject[] assets) {
                TabName = tabName;
                Assets  = assets;
            }

            public override void DrawTab(FoCsWindow<AdvancedUnitySettingsWindow> owner) {
                //if(storage == null)
                //	storage = new UnityReorderableListStorage(owner);

                using (Disposables.HorizontalScope(GUI.skin.box))
                    EditorGUILayout.LabelField(TabName);

                using (Disposables.HorizontalScope()) {
                    DrawSpace(LEFT_BORDER * 0.5f);
                    Search = FoCsGUI.Layout.TextField(SearchGuiContent, Search);
                }

                using (Disposables.LabelAddWidth(EXTRA_LABEL_WIDTH)) {
                    using (Disposables.SetIndent(1)) {
                        //if(handlerControllers.IsNullOrEmpty())
                        //{
                        //	handlerControllers = new HandlerController[Assets.Length];
                        //
                        //	for(var i = 0; i < handlerControllers.Length; i++)
                        //		handlerControllers[i] = new HandlerController();
                        //}

                        for (var i = 0; i < Assets.Length; i++) {
                            var asset = Assets[i];
                            //var handlerController = handlerControllers[i];
                            asset.Update();

                            //handlerController.VerifyIPropertyLayoutHandlerArrayNoObject(storage);
                            //handlerController.VerifyHandlingDictionary(asset);

                            using (Disposables.HorizontalScope()) {
                                DrawSpace(LEFT_BORDER);

                                using (var scrollViewScope = Disposables.ScrollViewScope(vector2, true)) {
                                    vector2 = scrollViewScope.scrollPosition;

                                    using (var changeCheckScope = Disposables.ChangeCheck()) {
                                        foreach (var property in asset.Properties()) {
                                            if (Search.IsNullOrEmpty())
                                                FoCsGUI.Layout.PropertyField(property);
                                            else if (property.name.ToLower().Contains(Search.ToLower()))
                                                FoCsGUI.Layout.PropertyField(property);
                                        }

                                        if (changeCheckScope.changed)
                                            asset.ApplyModifiedProperties();
                                    }
                                }

                                DrawSpace(RIGHT_BORDER);
                            }
                        }
                    }
                }

                DrawFooter();
            }

            private void DrawFooter() {
                using (Disposables.VerticalScope()) {
                    if (FoCsGUI.Layout.Button("Force save")) {
                        foreach (var serializedObject in Assets)
                            EditorUtility.SetDirty(serializedObject.targetObject);
                    }

                    using (Disposables.HorizontalScope(GUI.skin.box)) {
                        EditorGUILayout
                                .HelpBox("Warning, This window has not been tested for all the settings being validated.\nIt is still recommended to use the Unity settings windows.",
                                         MessageType.Warning);
                    }
                }
            }
        }
    }
}