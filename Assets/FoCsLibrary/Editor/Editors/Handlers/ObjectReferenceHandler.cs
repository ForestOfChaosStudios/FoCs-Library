#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: ObjectReferenceHandler.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using System.Collections.Generic;
using ForestOfChaos.Unity.Attributes;
using ForestOfChaos.Unity.Editor.PropertyDrawers;
using ForestOfChaos.Unity.Extensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor {
    public class ObjectReferenceHandler: IPropertyLayoutHandler {
        public readonly  FoCsEditor                        owner;
        private readonly Dictionary<string, EditorFoldout> ShowAfter = new Dictionary<string, EditorFoldout>();
        private          UnityReorderableListStorage       storage;

        public UnityReorderableListStorage URLStorage {
            get => storage ?? (storage = new UnityReorderableListStorage(owner));
            set => storage = value;
        }

        public ObjectReferenceHandler(FoCsEditor _owner) => owner = _owner;

        public ObjectReferenceHandler(UnityReorderableListStorage _URLStorage) {
            storage = _URLStorage;
            owner   = null;
        }

        private void NormalDraw(ObjectReference drawer) {
            using (var cc = Disposables.ChangeCheck()) {
                drawer.IsReferenceOpen.target = drawer.ReferenceOpen;
                drawer.DrawHeader();

                using (var fade = Disposables.FadeGroupScope(drawer.IsReferenceOpen.faded)) {
                    if (fade.visible)
                        drawer.DrawReference(URLStorage);
                }

                if (cc.changed)
                    URLStorage.owner.Repaint();
            }
        }

        private void DrawWithHeader(ObjectReference drawer) {
            using (var cc = Disposables.ChangeCheck()) {
                drawer.IsReferenceOpen.target = drawer.ReferenceOpen;
                drawer.DrawHeader(true, true);

                using (var fade = Disposables.FadeGroupScope(drawer.IsReferenceOpen.faded)) {
                    if (fade.visible)
                        drawer.DrawReference(URLStorage);
                }

                if (cc.changed)
                    URLStorage.owner.Repaint();
            }
        }

        public void HandleProperty(SerializedProperty property) {
            var drawer  = owner.GetObjectDrawer(property, owner);
            var @object = property.objectReferenceValue;

            if (@object == null) {
                NormalDraw(drawer);

                return;
            }

            var attribute    = property.GetSerializedPropertyAttributes();
            var hasAttribute = AttributeType.None;

            if (attribute.IsNullOrEmpty())
                hasAttribute = AttributeType.None;
            else {
                foreach (var a in attribute) {
                    if (a is ShowAsComponentAttribute) {
                        hasAttribute = AttributeType.ShowAsComponent;

                        break;
                    }

                    if (a is NoObjectFoldoutAttribute) {
                        hasAttribute = AttributeType.NoObjectFoldout;

                        break;
                    }

                    if (a is HeaderAttribute) {
                        hasAttribute = AttributeType.Header;

                        break;
                    }
                }
            }

            switch (hasAttribute) {
                case AttributeType.ShowAsComponent: {
                    drawer.DrawHeader();
                    var id = property.GetId();

                    if (!ShowAfter.ContainsKey(id))
                        ShowAfter.Add(id, new EditorFoldout { Foldout = true });

                    break;
                }
                case AttributeType.NoObjectFoldout:
                    drawer.DrawHeader();

                    break;
                case AttributeType.Header:
                    DrawWithHeader(drawer);

                    break;
                default:
                    NormalDraw(drawer);

                    break;
            }
        }

        public float PropertyHeight(SerializedProperty property) => FoCsGUI.SingleLine;

        public bool IsValidProperty(SerializedProperty property) =>
                (property.propertyType == SerializedPropertyType.ObjectReference) && !FoCsEditor.IsDefaultScriptProperty(property);

        public void DrawAfterEditor(SerializedProperty serializedProperty) {
            var id = serializedProperty.GetId();

            if (!ShowAfter.ContainsKey(id))
                return;

            var obj = serializedProperty.objectReferenceValue;

            if (obj == null)
                return;

            var editorFoldout = ShowAfter[id];
            editorFoldout.Foldout = EditorGUILayout.InspectorTitlebar(editorFoldout.Foldout, obj);

            using (Disposables.IndentZeroed()) {
                if (editorFoldout.Foldout) {
                    UnityEditor.Editor.CreateCachedEditor(obj, null, ref editorFoldout.Editor);
                    editorFoldout.Editor.OnInspectorGUI();
                }
            }

            ShowAfter[id] = editorFoldout;
        }

        [Flags]
        private enum AttributeType {
            None            = 0,
            ShowAsComponent = 1,
            NoObjectFoldout = 2,
            Header          = 3
        }

        private struct EditorFoldout {
            public bool               Foldout;
            public UnityEditor.Editor Editor;
        }
    }
}