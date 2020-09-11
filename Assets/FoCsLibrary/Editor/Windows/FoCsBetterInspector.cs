#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsBetterInspector.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


using System.Collections.Generic;
using ForestOfChaosLibrary.Editor.Utilities;
using ForestOfChaosLibrary.Extensions;
using UnityEditor;
using UnityEngine;
using UEditor = UnityEditor.Editor;

namespace ForestOfChaosLibrary.Editor.Windows {
    public class FoCsBetterInspector: FoCsWindow<FoCsBetterInspector> {
        private const           string                      Title = "Better Inspector";
        private static readonly GUIContent                  Label = new GUIContent("Add Object to window");
        private                 Vector2                     scrollPos;
        public                  List<Object>                Object           = new List<Object>();
        private                 Dictionary<Object, UEditor> ObjectsToEditors = new Dictionary<Object, UEditor>();

        [MenuItem(FileStrings.FORESTOFCHAOS_ + Title)]
        private static void Init() {
            GetWindow();
            Window.titleContent.text = Title;
            Window.Show();
        }

        protected override void OnGUI() {
            if (ObjectsToEditors.IsNullOrEmpty())
                ObjectsToEditors = new Dictionary<Object, UEditor>();

            if (Object.IsNullOrEmpty())
                Object = new List<Object>();

            using (var scroll = Disposables.ScrollViewScope(scrollPos, true, FoCsGUI.LayoutOptions.Expand())) {
                scrollPos = scroll.scrollPosition;

                using (Disposables.HorizontalScope()) {
                    foreach (var o in Object) {
                        if (!ObjectsToEditors.ContainsKey(o))
                            GenerateEditor(o);

                        using (Disposables.VerticalScope(FoCsGUI.LayoutOptions.Width(500)))
                            ObjectsToEditors[o].OnInspectorGUI();
                    }
                }
            }

            using (var cc = Disposables.ChangeCheck()) {
                var obj = FoCsGUI.Layout.ObjectField<Object>(null, Label, true);

                if (cc.changed) {
                    if (obj != null) {
                        Object.AddWithDuplicateCheck(obj);
                        GenerateEditor(obj);
                    }
                }
            }
        }

        private void GenerateEditor(Object obj) {
            if (!ObjectsToEditors.ContainsKey(obj))
                ObjectsToEditors[obj] = UEditor.CreateEditor(obj);
        }

        private void Update() {
            if (mouseOverWindow)
                Repaint();
        }
    }
}