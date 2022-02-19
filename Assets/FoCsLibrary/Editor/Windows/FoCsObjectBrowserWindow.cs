#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsObjectBrowserWindow.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Utilities;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ForestOfChaos.Unity.Editor.Windows {
    [FoCsWindow]
    public class FoCsObjectBrowserWindow: FoCsWindow<FoCsObjectBrowserWindow> {
        private const           string            GUI_SELECTION_LABEL = "ObjectBrowserSelectItemID";
        private const           string            TITLE               = "Object Browser";
        private const           float             TYPE_WIDTH          = 0.3f;
        private                 Vector2           typeScrollPos       = Vector2.zero;
        private                 Vector2           sceneScrollPos      = Vector2.zero;
        private                 Vector2           assetsScrollPos     = Vector2.zero;
        private static readonly List<TypeRow>     typeList            = new List<TypeRow>();
        private readonly        List<Object>      foundSceneObjects   = new List<Object>();
        private readonly        List<Object>      foundAssetsObjects  = new List<Object>();
        private readonly        GUIContent        pingContent         = new GUIContent("", "Ping Object");
        private                 int               typeLabelHighlightIndex;
        public                  bool              EnableCompo = true;
        public                  bool              EnableAsset = true;

        private TypeRow ActiveType {
            get => typeList[ActiveIndex];
            set => ActiveIndex = typeList.IndexOf(value);
        }

        private string TypeSearch { get; set; }

        private string SceneSearch { get; set; }

        private string AssetSearch { get; set; }

        private int ActiveIndex { get; set; }

        private static float TypeWidth => Screen.width * TYPE_WIDTH;

        [MenuItem("Forest Of Chaos/" + TITLE)]
        private static void Init() {
            GetWindowAndShow();
            Window.titleContent.text = TITLE;
        }

        private void OnEnable() {
            InitTypeList();
        }

        private void Update() {
            if (mouseOverWindow)
                Repaint();
        }
        private static bool TypesToIncludePredicate(Type type) =>
                !(type.IsGenericType                               ||
                  type.IsAbstract                                  ||
                  (type.Assembly == typeof(EditorWindow).Assembly) ||
                  type.IsSubclassOf(typeof(UnityEditor.Editor))    ||
                  type.IsSubclassOf(typeof(EditorWindow)));

        private void InitTypeList() {
            if (!typeList.IsEmpty())
                return;

            typeList.AddRange(ReflectionUtilities.GetInheritedClasses<ScriptableObject>()
                                                 .Concat(ReflectionUtilities.GetInheritedClasses<Component>())
                                                 .Where(TypesToIncludePredicate)
                                                 .Select(type => new TypeRow(type)));

            typeList.AddWithDuplicateCheck(new TypeRow(typeof(Transform)));
            typeList.AddWithDuplicateCheck(new TypeRow(typeof(GameObject)));
            typeList.AddWithDuplicateCheck(new TypeRow(typeof(ScriptableObject)));
            typeList.TrimExcess();
        }

        protected override void OnGUI() {
            using (var cc = Disposables.ChangeCheck()) {
                using (Disposables.HorizontalScope()) {
                    using (Disposables.VerticalScope(FoCsGUI.LayoutOptions.Width(120))) {
                        if (DrawTypePanel())
                            return;
                    }

                    using (Disposables.VerticalScope()) {
                        if (DrawObjectPanel())
                            return;
                    }
                }

                if (cc.changed)
                    Repaint();
            }
        }

        private bool DrawTypePanel() {
            using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, FoCsGUI.LayoutOptions.Height(16)))
                FoCsGUI.Layout.Label("Type Selection", FoCsGUI.Styles.ToolbarButton, FoCsGUI.LayoutOptions.Height(16));

            if (DrawTypeSearchBox())
                return true;

            using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, FoCsGUI.LayoutOptions.ExpandWidth().Height(18))) {
                EnableCompo = FoCsGUI.Layout.Toggle(!EnableCompo? "Components Hidden" : "Components Shown", EnableCompo, FoCsGUI.Styles.ToolbarButton, FoCsGUI.LayoutOptions.Height(21));

                EnableAsset = FoCsGUI.Layout.Toggle(!EnableAsset? "Scriptable Objects Hidden" : "Scriptable Objects Shown",
                                                     EnableAsset,
                                                     FoCsGUI.Styles.ToolbarButton,
                                                     FoCsGUI.LayoutOptions.Height(21));
            }

            using (Disposables.ScrollViewScope(ref typeScrollPos, true, false, true)) {
                typeLabelHighlightIndex = 0;

                for (var i = 0; i < typeList.Count; i++) {
                    if (!EnableCompo && typeList[i].IsComponent)
                        continue;

                    if (!EnableAsset && typeList[i].IsScriptableObject)
                        continue;

                    if (TypeSearch.IsNullOrEmpty()) {
                        DrawTypeLabel(i);
                        continue;
                    }

                    if (!SearchString(typeList[i].Name, TypeSearch))
                        continue;

                    DrawTypeLabel(i);
                }
            }

            return false;
        }

        private void DrawTypeLabel(int i) {
            GUI.SetNextControlName(GUI_SELECTION_LABEL);

            using (var cc = Disposables.ChangeCheck()) {
                var @event = FoCsGUI.Layout.Toggle(typeList[i].Name.SplitCamelCase(),
                                                   ActiveIndex == i,
                                                   (typeLabelHighlightIndex % 2) == 0? FoCsGUI.Styles.RowField : FoCsGUI.Styles.RowFieldOdd,
                                                   FoCsGUI.LayoutOptions.ExpandWidth().Height(18));

                typeLabelHighlightIndex = (typeLabelHighlightIndex + 1) % 2;

                if (!cc.changed || !@event)
                    return;

                GUI.FocusControl(GUI_SELECTION_LABEL);
                ActiveIndex = i;
                ChangeObjectType();
            }
        }

        private bool DrawTypeSearchBox() {
            using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, FoCsGUI.LayoutOptions.ExpandWidth(true))) {
                FoCsGUI.Layout.Label("Search", FoCsGUI.LayoutOptions.Width(60));

                using (var cc = Disposables.ChangeCheck()) {
                    TypeSearch = FoCsGUI.Layout.TextField(TypeSearch, FoCsGUI.LayoutOptions.ExpandWidth(true));

                    if (cc.changed)
                        Repaint();

                    return cc.changed;
                }
            }
        }

        private void DrawSceneSearchBox() {
            using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, FoCsGUI.LayoutOptions.ExpandWidth().Height(18))) {
                using (Disposables.HorizontalScope(FoCsGUI.Styles.ToolbarButton, FoCsGUI.LayoutOptions.ExpandWidth().Height(18))) {
                    FoCsGUI.Layout.Label("Current Loaded Scene Objects", FoCsGUI.LayoutOptions.Height(18));
                    FoCsGUI.Layout.Label("Search",                       FoCsGUI.LayoutOptions.Width(60).Height(18));

                    using (var cc = Disposables.ChangeCheck()) {
                        var str = FoCsGUI.Layout.TextField(SceneSearch, FoCsGUI.Styles.Unity.ToolbarTextField, FoCsGUI.LayoutOptions.Width((Screen.width * 0.3f) - 120));

                        if (!cc.changed)
                            return;

                        SceneSearch = str;
                        Repaint();
                    }
                }
            }
        }

        private void DrawAssetSearchBox() {
            using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, FoCsGUI.LayoutOptions.ExpandWidth().Height(18))) {
                using (Disposables.HorizontalScope(FoCsGUI.Styles.ToolbarButton, FoCsGUI.LayoutOptions.ExpandWidth().Height(18))) {
                    FoCsGUI.Layout.Label("Assets", FoCsGUI.LayoutOptions.Height(18));
                    FoCsGUI.Layout.Label("Search", FoCsGUI.LayoutOptions.Width(60).Height(18));

                    using (var cc = Disposables.ChangeCheck()) {
                        var str = FoCsGUI.Layout.TextField(AssetSearch, FoCsGUI.Styles.Unity.ToolbarTextField, FoCsGUI.LayoutOptions.Width((Screen.width * 0.3f) - 120));

                        if (!cc.changed)
                            return;

                        AssetSearch = str;
                        Repaint();
                    }
                }
            }
        }

        private bool DrawObjectPanel() {
            using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, FoCsGUI.LayoutOptions.Height(16)))
                FoCsGUI.Layout.Label(ActiveType.Name.SplitCamelCase(), FoCsGUI.Styles.ToolbarButton, FoCsGUI.LayoutOptions.Height(16));

            if (!EnableCompo && !EnableAsset) {
                FoCsGUI.Layout.GetControlRect(FoCsGUI.LayoutOptions.ExpandHeight());
            }
            else if (!EnableCompo && EnableAsset) {
                DrawFoundAsset(FoCsGUI.LayoutOptions.ExpandHeight());
            }
            else {
                DrawFoundScene(FoCsGUI.LayoutOptions.MinHeight((Screen.height * 0.4f) + 1).ExpandHeight());
                DrawFoundAsset(FoCsGUI.LayoutOptions.ExpandHeight());
            }

            DrawInfo();

            return false;
        }

        private void DrawFoundScene(params GUILayoutOption[] options) {
            DrawSceneSearchBox();

            using (var scroll = Disposables.ScrollViewScope(sceneScrollPos, true, options)) {
                sceneScrollPos = scroll.scrollPosition;

                using (Disposables.VerticalScope()) {
                    if (foundSceneObjects.Count == 0) {
                        FoCsGUI.Layout.InfoBox($"No Objects of {ActiveType.Name} In scene.");

                        return;
                    }

                    if (SceneSearch.IsNullOrEmpty()) {
                        foreach (var foundObject in foundSceneObjects)
                            DrawFoundObject(foundObject);

                        return;
                    }

                    SearchAndDrawResults(foundSceneObjects, SceneSearch);
                }
            }
        }

        private void SearchAndDrawResults(IEnumerable<Object> foundObjects, string searchLocation) {
            foreach (var foundObject in foundObjects.Where(foundObject => SearchString(foundObject, searchLocation))) {
                DrawFoundObject(foundObject);
            }
        }

        private void DrawFoundAsset(params GUILayoutOption[] options) {
            DrawAssetSearchBox();

            using (var scroll = Disposables.ScrollViewScope(assetsScrollPos, true, options)) {
                assetsScrollPos = scroll.scrollPosition;

                using (Disposables.VerticalScope(FoCsGUI.LayoutOptions.ExpandHeight())) {
                    if (foundAssetsObjects.Count == 0) {
                        FoCsGUI.Layout.InfoBox($"No Objects of {ActiveType.Name}. Can be found in the Assets Database.");

                        return;
                    }

                    if (AssetSearch.IsNullOrEmpty()) {
                        foreach (var foundObject in foundAssetsObjects)
                            DrawFoundObject(foundObject);

                        return;
                    }

                    SearchAndDrawResults(foundAssetsObjects, AssetSearch);
                }
            }
        }

        private bool SearchString(Object foundObject, string search) => SearchString(foundObject.name, search);

        private bool SearchString(string foundObject, string search) => foundObject.ToLower().Contains(search.ToLower());

        private void DrawFoundObject(Object foundObject) {
            using (Disposables.HorizontalScope()) {
                var eventPingButton = FoCsGUI.Layout.Button(pingContent, FoCsGUI.Styles.Find, FoCsGUI.LayoutOptions.Width(16));
                FoCsGUI.Layout.Label("  ", FoCsGUI.LayoutOptions.Width(8));
                FoCsGUI.Layout.Button(foundObject.name,                                            FoCsGUI.Styles.Unity.Label, FoCsGUI.LayoutOptions.Width(300));
                FoCsGUI.Layout.Button($"Full Type: {foundObject.GetType().Name.SplitCamelCase()}", FoCsGUI.Styles.Unity.Label);

                if (eventPingButton.Pressed) {
                    EditorGUIUtility.PingObject(foundObject);
                }

                //TODO: Drag Drop Code
                //if(labelEvent.EventIsMouse0 && labelEvent.Event.type == EventType.mouseDown)
                //{
                //	DragAndDrop.PrepareStartDrag();
                //	DragAndDrop.objectReferences = new[]
                //								   {
                //									   foundObject
                //								   };
                //	DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                //	DragAndDrop.StartDrag($"FoCsOB.Drag({foundObject.name})");
                //	Debug.Log(foundObject.name);
                //}
            }
        }

        private void DrawInfo() {
            using (Disposables.VerticalScope(FoCsGUI.LayoutOptions.MaxHeight(16 * 3))) {
                using (Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar, FoCsGUI.LayoutOptions.Height(16)))
                    FoCsGUI.Layout.Label("Type Info", FoCsGUI.Styles.ToolbarButton, FoCsGUI.LayoutOptions.Height(16));

                using (Disposables.HorizontalScope()) {
                    FoCsGUI.Layout.Label("Assembly:");
                    FoCsGUI.Layout.Label(ActiveType.Type.Assembly.GetName().Name);
                }

                using (Disposables.HorizontalScope()) {
                    var baseType = ActiveType.Type.BaseType;

                    if (baseType == null)
                        return;

                    FoCsGUI.Layout.Label("Inherits from:");
                    string labelText;

                    if (baseType.IsGenericType) {
                        var genArg = new StringBuilder();
                        genArg.Append('<');
                        var genArgArray = baseType.GetGenericArguments();

                        for (var i = 0; i < genArgArray.Length; i++) {
                            if (i != 0)
                                genArg.Append(',');

                            genArg.Append(genArgArray[i].Name);
                        }

                        genArg.Append('>');
                        labelText = $"{baseType.Name.Replace("`1", "")}{genArg}";
                    }
                    else {
                        labelText = baseType.Name.SplitCamelCase();
                    }

                    FoCsGUI.Layout.Label(labelText);
                }
            }
        }

        private void ChangeObjectType() {
            foundAssetsObjects.Clear();
            foundSceneObjects.Clear();

            foundAssetsObjects.AddRange(FoCsAssetFinder.FindAssetsByTypeWithScene(ActiveType.Type));

            for (var i = foundAssetsObjects.Count - 1; i >= 0; i--) {
                if (foundAssetsObjects[i] == null) {
                    foundAssetsObjects.RemoveAt(i);

                    continue;
                }

                if (AssetDatabase.Contains(foundAssetsObjects[i]))
                    continue;

                foundSceneObjects.Add(foundAssetsObjects[i]);
                foundAssetsObjects.RemoveAt(i);
            }

            foundSceneObjects.Sort(Sorter);
            foundAssetsObjects.Sort(Sorter);
            foundAssetsObjects.TrimExcess();
            foundSceneObjects.TrimExcess();
        }

        private static int Sorter(Object x, Object y) => string.Compare(x.name, y.name, StringComparison.Ordinal);

        private class TypeRow {
            public Type Type { get; }
            public bool IsScriptableObject { get; }
            public bool IsComponent { get; }

            public TypeRow(Type type) {
                Type          = type;
                IsScriptableObject = type.IsSubclassOf(typeof(ScriptableObject));
                IsComponent        = type.IsSubclassOf(typeof(Component));
            }

            public string Name => Type.Name;
        }
    }
}