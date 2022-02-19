#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsScriptableObjectEditor.cs
//    Created: 2022/02/19
// LastEdited: 2022/02/19
#endregion

using System.IO;
using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.Windows {

    public abstract class FoCsScriptableObjectEditor<TWindow, TScriptableObject>: FoCsWindow<TWindow>
            where TScriptableObject: ScriptableObject
            where TWindow: FoCsWindow {
        private const string GUI_SELECTION_LABEL = "FoCsScriptableObjectEditor" + nameof(TWindow);

        private static float SidePanelWidth => 240;

        private readonly GUIContent        pingContent   = new GUIContent("", "Ping Object");
        private          string            searchTerm    = "";
        private          Vector2           typeScrollPos = Vector2.zero;
        private          TScriptableObject selectedObject;
        private          bool              isInNewItemPage = false;
        private readonly NewPageData       NewData         = new NewPageData();

        private UnityEditor.Editor editor;

        private string PathToCreate {
            get => EditorPrefs.GetString(nameof(FoCsObjectBrowserWindow) + nameof(TScriptableObject) + nameof(PathToCreate), "Assets/SO");
            set => EditorPrefs.SetString(nameof(FoCsObjectBrowserWindow) + nameof(TScriptableObject) + nameof(PathToCreate), value);
        }

        protected override void OnGUI() {
            using (var cc = Disposables.ChangeCheck()) {
                using (Disposables.HorizontalScope(FoCsGUI.LayoutOptions.ExpandHeight())) {
                    using (Disposables.VerticalScope(GUILayout.Width(120))) {
                        DrawSidePanel();
                    }

                    if (isInNewItemPage) {
                        DrawNewItemPage();
                    }
                    else {
                        DrawDetailsPanel();
                    }
                }

                if ((editor != null) && editor is FoCsEditor foCsEditor) {
                    if(foCsEditor.RequiresConstantRepaint())
                        Repaint();
                }

                if (cc.changed)
                    Repaint();
            }
        }


        private bool DrawSearchBox() {
            using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, FoCsGUI.LayoutOptions.ExpandWidth())) {
                FoCsGUI.Layout.Label("Search", FoCsGUI.LayoutOptions.Width(60));

                using (var cc = Disposables.ChangeCheck()) {
                    searchTerm = FoCsGUI.Layout.TextField(searchTerm, FoCsGUI.LayoutOptions.ExpandWidth());

                    if (cc.changed)
                        Repaint();

                    return cc.changed;
                }
            }
        }

        private bool DrawDetailsPanel() {
            if (selectedObject == null)
                return false;

            using (Disposables.VerticalScope()) {
                using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, FoCsGUI.LayoutOptions.Height(16))) {
                    FoCsGUI.Layout.Label(selectedObject.name, FoCsGUI.Styles.ToolbarButton, FoCsGUI.LayoutOptions.Height(16));
                }

                using (var cc = Disposables.ChangeCheck()) {
                    if (cc.changed)
                        Repaint();

                    if ((selectedObject != null) && (editor != null))
                        editor.OnInspectorGUI();

                    return cc.changed;
                }
            }
        }

        private bool DrawNewItemPage() {
            using (Disposables.VerticalScope()) {
                using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, FoCsGUI.LayoutOptions.Height(16))) {
                    FoCsGUI.Layout.Label("New Item", FoCsGUI.Styles.ToolbarButton, FoCsGUI.LayoutOptions.Height(16));
                }

                using (var cc = Disposables.ChangeCheck()) {
                    //if (editor != null)
                    //    editor.OnInspectorGUI();

                    string str;

                    using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, FoCsGUI.LayoutOptions.Height(16))) {
                        NewData.Name = FoCsGUI.Layout.TextField("New Item Name",     NewData.Name, FoCsGUI.LayoutOptions.Height(16));
                        str          = FoCsGUI.Layout.TextField("New Item Location", PathToCreate, FoCsGUI.LayoutOptions.Height(16));
                    }

                    var createButton = FoCsGUI.Layout.Button("Save asset", FoCsGUI.LayoutOptions.Height(20));

                    if (createButton.Pressed) {
                        var realName = NewData.Name;

                        if (realName.IsNullOrEmpty())
                            realName = $"new {typeof(TScriptableObject).Name}";

                        var newItem = NewPageData.GetNew();
                        newItem.name = realName;

                        AssetDatabase.CreateAsset(newItem, Path.Combine(PathToCreate, $"{realName}.asset"));
                        selectedObject = newItem;
                        HandleEditor(newItem);
                        isInNewItemPage = false;
                        Repaint();
                    }

                    if (cc.changed) {
                        PathToCreate = str;
                        Repaint();
                    }

                    return cc.changed;
                }
            }
        }

        private bool DrawSidePanel() {
            using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, FoCsGUI.LayoutOptions.Height(16)))
                FoCsGUI.Layout.Label("Select", FoCsGUI.Styles.ToolbarButton, FoCsGUI.LayoutOptions.Height(16));

            if (DrawSearchBox())
                return true;

            using (Disposables.ScrollViewScope(ref typeScrollPos, true, false, true)) {
                var objects = GetObjects();

                for (var i = 0; i < objects.Length; i++) {
                    var obj = objects[i];

                    if (searchTerm.IsNotNullOrEmpty()) {
                        if (!IsObjectInSearch(obj)) {
                            continue;
                        }
                    }

                    DrawSidePanelLabel(objects[i], i);
                }
            }

            return DrawSideBarFooter();
        }

        private void DrawSidePanelLabel(TScriptableObject obj, int index) {
            using (var cc = Disposables.ChangeCheck()) {
                using (Disposables.HorizontalScope(((index % 2) == 0? FoCsGUI.Styles.RowField : FoCsGUI.Styles.RowFieldOdd))) {
                    var eventPingButton = FoCsGUI.Layout.Button(pingContent, FoCsGUI.Styles.Find, FoCsGUI.LayoutOptions.ForceWidth(16));

                    GUI.SetNextControlName(GUI_SELECTION_LABEL);
                    var @event = FoCsGUI.Layout.Toggle(obj.name, selectedObject == obj, FoCsGUI.Styles.Unity.Label, FoCsGUI.LayoutOptions.ExpandWidth().Height(18));

                    if (eventPingButton.Pressed) {
                        EditorGUIUtility.PingObject(obj);
                    }

                    if (!cc.changed || !@event)
                        return;

                    if (@event.Pressed) {
                        selectedObject = obj;
                        ChangeSelectedObject();
                        Repaint();
                    }

                    GUI.FocusControl(GUI_SELECTION_LABEL);
                }
            }
        }

        private bool DrawSideBarFooter() {
            using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, FoCsGUI.LayoutOptions.ExpandWidth())) {
                var @event = FoCsGUI.Layout.Button("Create New Item", FoCsGUI.Styles.Unity.ToolbarButton, FoCsGUI.LayoutOptions.ExpandWidth().Height(18));

                if (@event.Pressed) {
                    StartNewItemPage();
                    Repaint();
                }

                return @event.Pressed;
            }
        }

        private void StartNewItemPage() {
            isInNewItemPage = true;
            NewData.newItem = NewPageData.GetNew();
            HandleEditor(NewData.newItem);
        }

        private void HandleEditor(TScriptableObject obj) {
            if (editor == null) {
                editor = UnityEditor.Editor.CreateEditor(obj);
            }
            else {
                UnityEditor.Editor.CreateCachedEditor(obj, editor.GetType(), ref editor);
            }
        }

        private bool IsObjectInSearch(Object obj) {
            if (obj == null)
                return false;

            return obj.name.ToLower().Contains(searchTerm.ToLower());
        }

        private void ChangeSelectedObject() {
            isInNewItemPage = false;

            if (selectedObject == null)
                return;

            HandleEditor(selectedObject);
        }

        private static TScriptableObject[] GetObjects() => FoCsAssetFinder.FindAssetsByType<TScriptableObject>();

        private class NewPageData {

            public string Name { get; set; }

            public TScriptableObject newItem { get; set; }

            public NewPageData() {
                Name = $"new {typeof(TScriptableObject).Name}";
            }

            public static TScriptableObject GetNew() => CreateInstance<TScriptableObject>();
        }
    }
}