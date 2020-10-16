#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: ObjectReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:10 PM
#endregion

using ForestOfChaos.Unity.Editor.Utilities;
using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Utilities;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor {
    /// <summary>
    ///     A class that manages the Object Reference drawing, used by FoCsEditor
    /// </summary>
    public class ObjectReference {
        private readonly HandlerController           Handler = new HandlerController();
        public           AnimBool                    IsReferenceOpen;
        private          UnityReorderableListStorage listHandler;
        public           FoCsEditor                  owner;
        public           SerializedProperty          Property;
        private          bool                        referenceOpen;
        public           SerializedObject            SerializedObject;

        private UnityReorderableListStorage ListHandler => listHandler ?? (listHandler = new UnityReorderableListStorage(owner));

        public bool ReferenceOpen {
            get => referenceOpen;
            set {
                referenceOpen          = value;
                IsReferenceOpen.target = value;
            }
        }

        public ObjectReference() => IsReferenceOpen = new AnimBool(false) {speed = 0.7f};

        public ObjectReference(SerializedProperty _property, FoCsEditor _owner) {
            Property        = _property;
            owner           = _owner;
            IsReferenceOpen = new AnimBool(false) {speed = 0.7f};
        }

        /// <summary>
        ///     Draws the Object Reference field, and foldout GUI
        /// </summary>
        public void DrawHeader(bool hasHeaderText = false) {
            DrawHeader(true, hasHeaderText);
        }

        /// <summary>
        ///     Draws the Object Reference field, and foldout GUI
        /// </summary>
        public void DrawHeader(bool showFoldout, bool hasHeaderText) {
            using (var cc = Disposables.ChangeCheck()) {
                var prop = FoCsGUI.Layout.PropertyField(Property, false);

                if (prop.EventIsMouseRInRect) {
                    Property.DrawCreateAndAssignObjectMenu();
                    prop.Event.Use();
                }

                if (cc.changed) {
                    if (Property.objectReferenceValue == null) {
                        SerializedObject      = null;
                        ReferenceOpen         = false;
                        IsReferenceOpen.value = false;
                    }
                    else {
                        SerializedObject = new SerializedObject(Property.objectReferenceValue);
                        Handler.ClearHandlingDictionary();
                    }
                }
            }

            if (!Property.objectReferenceValue)
                return;

            if ((SerializedObject == null) && (Property.objectReferenceValue != owner.target)) {
                Handler.ClearHandlingDictionary();
                SerializedObject = new SerializedObject(Property.objectReferenceValue);
            }

            VerifyHandler();
            var rect = GUILayoutUtility.GetLastRect();

            if (hasHeaderText)
                rect = rect.Edit(RectEdit.SetWidth(16), RectEdit.SetHeight(rect.height * 0.5f), RectEdit.AddY(rect.height * 0.5f));
            else
                rect = rect.Edit(RectEdit.SetWidth(16));

            if (showFoldout)
                ReferenceOpen = FoCsGUI.Foldout(rect, ReferenceOpen);
        }

        private static void DrawRightClickMenu(SerializedProperty property) {
            var type = property.GetPropertyType();

            if (!type.IsSubclassOf(typeof(ScriptableObject)))
                return;

            var guiContent  = new GUIContent($"Create And Assign New {type.Name}");
            var genericMenu = new GenericMenu();
            genericMenu.AddItem(guiContent, false, property.GenerateAddAssignNewItem);
            genericMenu.ShowAsContext();
        }

        /// <summary>
        ///     Draws the Object references referenced Object...
        /// </summary>
        /// <param name="URLStorage"></param>
        public void DrawReference(UnityReorderableListStorage URLStorage) {
            if (!ReferenceOpen)
                return;

            SerializedObject.Update();

            using (Disposables.VerticalScope(FoCsGUI.Styles.Unity.Box)) {
                using (Disposables.Indent()) {
                    foreach (var property in SerializedObject.Properties())
                        Handler.Handle(property, true);
                }
            }

            SerializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        ///     Verify the internal data of the HandlerController
        /// </summary>
        public void VerifyHandler() {
            Handler.VerifyIPropertyLayoutHandlerArray(owner);
            Handler.VerifyHandlingDictionary(SerializedObject);
        }
    }
}