#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar.Editor
//       File: AdvFolderEditor.cs
//    Created: 2020/04/25
// LastEdited: 2022/02/19
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ForestOfChaos.Unity.AdvVar.Base;
using ForestOfChaos.Unity.AdvVar.Editor.Windows;
using ForestOfChaos.Unity.Editor;
using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Utilities;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ForestOfChaos.Unity.AdvVar.Editor {
    [InitializeOnLoad]
    internal static class AdvFolderStaticEditor {
        static AdvFolderStaticEditor() {
            AdvFolderEditor.ReInit();
        }
    }

    [CanEditMultipleObjects]
    [CustomEditor(typeof(AdvSOFolder))]
    public class AdvFolderEditor: FoCsEditor {
        private static SortedDictionary<AdvFolderNameAttribute, List<Type>> typeDictionary;
        private        int                                                  ActiveTab;
        private        AdvFolderNameAttribute                               ActiveTabName;
        private        bool                                                 showChildrenSettings = true;
        private        bool                                                 repaintCalled;

        protected override void OnEnable() {
            //base.OnEnable();
            Init();
        }

        public override void OnInspectorGUI() {
            repaintCalled = false;

            if (serializedObject.isEditingMultipleObjects) {
                FoCsGUI.Layout.WarningBox("Editing Multiple Objects Is Not Permitted!");

                return;
            }

            FoCsGUI.Layout.InfoBox("These options will add child assets to the current asset, this is done to help with sorting of the huge amount of Scriptable Objects this system could generate.");

            if (typeDictionary == null) {
                Init();
                Repaint();
                repaintCalled = true;

                return;
            }

            DrawMenuTabs();
            DrawTypeTabs();
            DoPadding();
            DrawChildrenGUI();
        }

        public static void Init() {
            if (typeDictionary == null)
                typeDictionary = GetDictionaryTypes();
        }

        public static void ReInit() {
            typeDictionary = GetDictionaryTypes();
        }

        private void DrawChildrenGUI() {
            using (Disposables.Indent()) {
                var assets = AssetDatabase.LoadAllAssetsAtPath(AssetPath());

                if (assets.Length <= 1)
                    return;

                using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar))
                    showChildrenSettings = FoCsGUI.Layout.Foldout(showChildrenSettings, $"Children [{assets.Length - 1}]");

                if (!showChildrenSettings)
                    return;

                using (Disposables.VerticalScope(GUI.skin.box)) {
                    for (var i = 0; i < assets.Length; i++) {
                        var obj = assets[i];

                        if (!obj)
                            continue;

                        if (AssetDatabase.IsSubAsset(obj))
                            DrawChildObject(obj, i);

                        if (repaintCalled)
                            return;
                    }
                }
            }
        }

        private void DrawTypeTabs() {
            FoCsGUI.Layout.LabelField("Type of Scriptable Object to add", FoCsGUI.Styles.Unity.BoldLabel);

            if (ActiveTabName is AnyAdvFolder)
                DrawAddTypeButton(typeDictionary.Keys.SelectMany(key => typeDictionary[key]).ToList());
            else
                DrawAddTypeButton(typeDictionary[ActiveTabName]);
        }

        private void DrawAddTypeButton(List<Type> types) {
            FoCsGUI.Layout.LabelField("Categories of Scriptable Objects that can be added", FoCsGUI.Styles.Unity.BoldLabel);
            var width = (Screen.width / 250) + 1;

            for (var i = 0; i < types.Count; i += width) {
                using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar)) {
                    for (var j = 0; j < width; j += 1) {
                        var index = i + j;

                        if (!types.InRange(index))
                            break;

                        DrawAddTypeButton(types[index]);
                    }
                }
            }
        }

        private void DrawMenuTabs() {
            FoCsGUI.Layout.LabelField("Categories of Scriptable Objects that can be added", FoCsGUI.Styles.Unity.BoldLabel);
            var width    = (Screen.width / 200) + 1;
            var nameList = typeDictionary.Keys.ToList();

            if (!nameList.InRange(ActiveTab))
                ActiveTab = 0;

            for (var i = 0; i < nameList.Count; i += width) {
                if (!nameList.InRange(i))
                    break;

                using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar)) {
                    for (var j = 0; j < width; j += 1) {
                        var index = i + j;

                        if (!nameList.InRange(index))
                            break;

                        var key = nameList[index];

                        if (ActiveTab == index)
                            ActiveTabName = key;

                        using (var cc = Disposables.ChangeCheck()) {
                            var @event = FoCsGUI.Layout.Toggle(key.ToggleName.SplitCamelCase(), ActiveTab == index, FoCsGUI.Styles.Unity.ToolbarButton);

                            if (cc.changed && @event) {
                                if (ActiveTab == index)
                                    continue;

                                ActiveTab     = index;
                                ActiveTabName = key;
                                Repaint();
                                repaintCalled = true;

                                return;
                            }
                        }
                    }
                }
            }
        }

        private static void DoPadding(bool hasLabel = true) => DoPadding(EditorGUIUtility.standardVerticalSpacing, hasLabel);

        private static void DoPadding(float height, bool hasLabel = true) => EditorGUILayout.GetControlRect(hasLabel, height);

        //TODO: add Un Parent Button
        private void DrawChildObject(Object[] assets, int index) => DrawChildObject(assets[index], index);
        //TODO: add Un Parent Button

        private void DrawChildObject(Object obj, int index) {
            using (Disposables.HorizontalScope()) {
                FoCsGUI.Layout.Label($"[{index}] {obj.GetType().Name.SplitCamelCase()}", GUILayout.Width(Screen.width / 4f));

                using (var changeCheckScope = Disposables.ChangeCheck()) {
                    using (Disposables.IndentSet(0))
                        obj.name = EditorGUILayout.DelayedTextField(obj.name);

                    if (changeCheckScope.changed) {
                        EditorUtility.SetDirty(target);
                        AssetDatabase.ImportAsset(AssetPath(target));
                    }
                }

                var deleteEvent = FoCsGUI.Layout.Button(new GUIContent("X"), FoCsGUI.Styles.CrossCircle, GUILayout.Width(FoCsGUI.Styles.CrossCircle.Style.fixedWidth));

                if (deleteEvent) {
                    if (EditorUtility.DisplayDialog("Delete Child", $"Delete {obj.name}", "Yes Delete", "No Cancel")) {
                        DestroyImmediate(obj, true);
                        EditorUtility.SetDirty(target);
                        AssetDatabase.ImportAsset(AssetPath(target));
                        Repaint();
                        repaintCalled = true;

                        return;
                    }
                }
            }

            DoPadding(1, false);
        }

        private void DrawAddTypeButton(Type type) {
            var name   = type.ToGenericTypeString();
            var @event = FoCsGUI.Layout.Button(name);

            if (@event) {
                FoCsSubmitStringWindow.SetUpInstance(new CreateArgs {
                        Title                = $"Enter Name of the new {name}",
                        WindowTitle          = "Enter Name",
                        CancelMessage        = "Cancel",
                        Data                 = $"New {name}",
                        SubmitMessage        = $"Create new {name}",
                        OnSubmit             = OnCreateSubmit,
                        HasAnotherButton     = true,
                        SubmitAnotherMessage = $"Create new {name} & Add Another",
                        OnSubmitAnother      = OnCreateSubmit,
                        OnCancel             = OnCreateCancel,
                        target               = target,
                        type                 = type
                });
            }
        }

        private static void OnCreateSubmit(FoCsSubmitStringWindow.SubmitStringArguments obj) {
            if (obj is CreateArgs args) {
                var sO = CreateInstance(args.type);
                sO.name = args.Data;
                AssetDatabase.AddObjectToAsset(sO, args.target);
                EditorUtility.SetDirty(args.target);
                AssetDatabase.ImportAsset(AssetPath(args.target));
            }
        }

        private static void OnCreateCancel(FoCsSubmitStringWindow.SubmitStringArguments obj) { }

        private static void OnRenameSubmit(FoCsSubmitStringWindow.SubmitStringArguments obj) {
            if (obj is Args args) {
                args.target.name = args.Data;
                EditorUtility.SetDirty(args.target);
                AssetDatabase.ImportAsset(AssetPath(args.target));
            }
        }

        private static void OnRenameCancel(FoCsSubmitStringWindow.SubmitStringArguments obj) { }

        private static void DrawDevOptions() {
            EditorGUILayout.LabelField("To Add You Own Scriptable Objects To This List, Add the ");
            EditorGUILayout.LabelField("[AdvancedFolderName(toggleName: \"Custom Types\", order: 42)]");
        }

        public static SortedDictionary<AdvFolderNameAttribute, List<Type>> GetDictionaryTypes() {
            var types = ReflectionUtilities.GetTypesWith<AdvFolderNameAttribute, ScriptableObject>(false);

            var finalList = new SortedDictionary<AdvFolderNameAttribute, List<Type>> {
                    { new AnyAdvFolder(), new List<Type>() }
            };

            foreach (var type in types) {
                var attribute = (AdvFolderNameAttribute)type.GetCustomAttribute(typeof(AdvFolderNameAttribute), false);

                if (finalList.ContainsKey(attribute)) {
                    if (finalList[attribute] == null)
                        finalList[attribute] = new List<Type>();

                    finalList[attribute].AddWithDuplicateCheck(type);
                }
                else
                    finalList.Add(attribute, new List<Type> { type });
            }

            return finalList;
        }

        private class AnyAdvFolder: AdvFolderNameAttribute {
            public AnyAdvFolder(): base("Any", 999999) { }
        }

        private class Args: FoCsSubmitStringWindow.SubmitStringArguments {
            public Object target;
        }

        private class CreateArgs: Args {
            public Type type;
        }
    }
}