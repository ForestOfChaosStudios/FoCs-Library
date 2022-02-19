#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: UnityReorderableListProperty.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections.Generic;
using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Utilities;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEditorInternal;
using UnityEngine;
using Object = UnityEngine.Object;
using ORD = ForestOfChaos.Unity.Editor.PropertyDrawers.ObjectReferenceDrawer;

namespace ForestOfChaos.Unity.Editor {
    public class UnityReorderableListProperty {
        public static    int                      GLOBAL_CURRENT_ID;
        private static   ReorderableList.Defaults _reorderableListDefaults;
        private readonly Dictionary<string, ORD>  objectDrawers = new Dictionary<string, ORD>();
        public           int                      ID;
        private          SerializedProperty       _property;
        public           SerializedPropertyType   SerializedPropertyType = SerializedPropertyType.Generic;

        public static ReorderableList.Defaults Defaults => _reorderableListDefaults ?? (_reorderableListDefaults = new ReorderableList.Defaults());

        public ReorderableList List { get; private set; }

        public bool IsExpanded { get; set; }

        public SerializedProperty Property {
            get => _property;
            set {
                _property               = value;
                List.serializedProperty = _property;
            }
        }

        private UnityReorderableListProperty() {
            ID = GLOBAL_CURRENT_ID;
            ++GLOBAL_CURRENT_ID;
        }

        public UnityReorderableListProperty(SerializedProperty property): this() {
            _property = property;
            InitList();
        }

        public UnityReorderableListProperty(SerializedProperty property, bool dragable, bool displayHeader = false, bool displayAdd = true, bool displayRemove = true): this() {
            _property = property;
            InitList(dragable, displayHeader, displayAdd, displayRemove);
        }

        ~UnityReorderableListProperty() {
            _property         =  null;
            List              =  null;
        }

        public static implicit operator UnityReorderableListProperty(SerializedProperty input) => new UnityReorderableListProperty(input);

        public static implicit operator SerializedProperty(UnityReorderableListProperty input) => input.Property;

        private void InitList(bool dragable = true, bool displayHeader = true, bool displayAdd = true, bool displayRemove = true) {
            List = new ReorderableList(Property.serializedObject, Property, dragable, displayHeader, displayAdd, displayRemove) {
                    drawHeaderCallback    = OnListDrawHeaderCallback,
                    onCanRemoveCallback   = OnListOnCanRemoveCallback,
                    drawElementCallback   = DrawElement,
                    elementHeightCallback = OnListElementHeightCallback,
                    drawFooterCallback    = OnListDrawFooterCallback,
                    showDefaultBackground = true
            };

            if (!Property.serializedObject.isEditingMultipleObjects)
                SetSerializedPropertyType();
        }

        public void DrawHeader() {
            DrawHeader(GUILayoutUtility.GetRect(0.0f, List.headerHeight, GUILayout.ExpandWidth(true)));
        }

        public void DrawHeader(Rect headerRect) {
            Defaults.DrawHeaderBackground(headerRect);
            headerRect.xMin   += 6f;
            headerRect.xMax   -= 6f;
            headerRect.height -= 2f;
            ++headerRect.y;

            List.drawHeaderCallback?.Invoke(headerRect);

            if (SerializedPropertyType != SerializedPropertyType.ObjectReference)
                return;

            if (!_property.arrayElementType.Contains("PPtr<"))
                return;

            var @event = Event.current;

            if (headerRect.Contains(@event.mousePosition)) {
                if ((@event.type == EventType.DragUpdated) || (@event.type == EventType.DragPerform)) {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                    if (@event.type == EventType.DragPerform) {
                        DoDropAdd();
                        DragAndDrop.AcceptDrag();
                    }

                    @event.Use();
                }
            }
        }

        public void HandleDrawing() {
            using (Disposables.VerticalScope()) {
                IsExpanded = Property.isExpanded;

                if (IsExpanded) {
                    List.DoLayoutList();
                }
                else {
                    DrawHeader();
                }
            }
        }

        public void HandleDrawing(Rect rect) {
            IsExpanded = Property.isExpanded;

            if (IsExpanded)
                List.DoList(rect);
            else
                DrawHeader(rect);
        }

        private void SetSerializedPropertyType() {
            if (_property.arraySize == 0) {
                _property.InsertArrayElementAtIndex(0);
                SerializedPropertyType = _property.GetArrayElementAtIndex(0).propertyType;
                _property.DeleteArrayElementAtIndex(0);
            }
            else
                SerializedPropertyType = _property.GetArrayElementAtIndex(0).propertyType;
        }

        private void DrawElement(Rect rect, int index, bool active, bool focused) {
            DoDrawElement(rect, index);
        }

        private void DoDrawElement(Rect rect, int index) {
            var element     = List.serializedProperty.GetArrayElementAtIndex(index);
            var indentLevel = -1;

            if (element.propertyType == SerializedPropertyType.ObjectReference)
                indentLevel = 0;

            using (Disposables.Indent(indentLevel)) {
                if (element.propertyType == SerializedPropertyType.ObjectReference)
                    HandleObjectReference(rect, List.serializedProperty.GetArrayElementAtIndex(index));
                else {
                    List.elementHeight =  rect.height = Mathf.Max(EditorGUIUtility.singleLineHeight, EditorGUI.GetPropertyHeight(element, element.isExpanded));
                    rect.y             += 1;
                    FoCsGUI.PropertyField(rect, element, new GUIContent(element.displayName), true);
                }
            }
        }

        private void HandleObjectReference(Rect rect, SerializedProperty prop) {
            var drawer                       = GetObjectDrawer(prop);
            var GuiCont                      = new GUIContent(prop.displayName);
            List.elementHeight = rect.height = ObjectReferenceElementHeight(prop, GuiCont);
            drawer.OnGUI(rect, _property, GuiCont);
        }

        private float ObjectReferenceElementHeight(SerializedProperty prop) => ObjectReferenceElementHeight(prop, new GUIContent(prop.displayName));

        private float ObjectReferenceElementHeight(SerializedProperty prop, GUIContent content) {
            var drawer = GetObjectDrawer(prop);

            return drawer.GetPropertyHeight(prop, content);
        }

        public static Object[] DropZone(Rect rect) {
            var eventType  = Event.current.type;
            var isAccepted = false;

            if (rect.Contains(Event.current.mousePosition)) {
                if ((eventType == EventType.DragUpdated) || (eventType == EventType.DragPerform)) {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                    if (eventType == EventType.DragPerform) {
                        DragAndDrop.AcceptDrag();
                        isAccepted = true;
                    }

                    Event.current.Use();
                }
            }

            return isAccepted? DragAndDrop.objectReferences : null;
        }

        private void DoDropAdd() {
            foreach (var obj in DragAndDrop.objectReferences) {
                var typeName = obj.GetType().Name;
                var length   = _property.arraySize;
                _property.InsertArrayElementAtIndex(length);
                var prop = _property.GetArrayElementAtIndex(length);
                prop.objectReferenceValue = obj;

                if (prop.objectReferenceValue != null)
                    continue;

                if (prop.type.Contains(typeName)) {
                    prop.objectReferenceValue = obj;

                    if (prop.objectReferenceValue != null)
                        continue;
                }

                var transform  = obj as Transform;
                var gameObject = obj as GameObject;

                if (transform) {
                    switch (typeName) {
                        case "Transform":
                            prop.objectReferenceValue = transform;

                            if (prop.objectReferenceValue != null)
                                continue;
                            else
                                break;
                        case "GameObject":
                            prop.objectReferenceValue = transform.gameObject;

                            if (prop.objectReferenceValue != null)
                                continue;
                            else
                                break;
                    }

                    gameObject = transform.gameObject;
                }
                else if (gameObject) {
                    switch (typeName) {
                        case "Transform":
                            prop.objectReferenceValue = gameObject.transform;

                            if (prop.objectReferenceValue != null)
                                continue;
                            else
                                break;
                        case "GameObject":
                            prop.objectReferenceValue = gameObject;

                            if (prop.objectReferenceValue != null)
                                continue;
                            else
                                break;
                    }
                }

                if (gameObject) {
                    foreach (var component in gameObject.GetComponents<Component>()) {
                        if (!prop.type.Contains(component.GetType().Name)) {
                            if (prop.objectReferenceValue != null)
                                continue;
                        }

                        prop.objectReferenceValue = component;

                        break;
                    }
                }

                if (prop.objectReferenceValue == null)
                    _property.DeleteArrayElementAtIndex(_property.arraySize - 1);
            }

            GUI.changed = true;
        }

        public float GetTotalHeight() {
            if (!Property.isExpanded)
                return List.headerHeight + FoCsGUI.Padding;

            var height = List.headerHeight + List.footerHeight + 4 + FoCsGUI.Padding;

            if (Property.isExpanded && (List.serializedProperty.arraySize == 0))
                return List.elementHeight + height;


            for (var i = 0; i < List.serializedProperty.arraySize; i++)
                height += OnListElementHeightCallback(i);

            return height;
        }

#region Storage
        private ORD GetObjectDrawer(SerializedProperty prop) {
            var id = $"{prop.propertyPath}-{prop.name}";

            if (objectDrawers.TryGetValue(id, out var objDraw))
                return objDraw;

            objDraw = new ORD();
            objectDrawers.Add(id, objDraw);

            return objDraw;
        }
#endregion

        public static class ListStyles {
            public static readonly GUIContent IconToolbarPlus     = EditorGUIUtility.IconContent("Toolbar Plus",      "|Add to list");
            public static readonly GUIContent IconToolbar         = EditorGUIUtility.IconContent("Toolbar Plus",      "|Add to list");
            public static readonly GUIContent IconToolbarPlusMore = EditorGUIUtility.IconContent("Toolbar Plus More", "Choose to add to list");
            public static readonly GUIContent IconToolbarMinus    = EditorGUIUtility.IconContent("Toolbar Minus",     "Remove selection from list");
            private static         GUIStyle   miniLabel;
            public static readonly GUIStyle   DraggingHandle    = new GUIStyle("RL DragHandle");
            public static readonly GUIStyle   HeaderBackground  = new GUIStyle("RL Header");
            public static readonly GUIStyle   FooterBackground  = new GUIStyle("RL Footer");
            public static readonly GUIStyle   BoxBackground     = new GUIStyle("RL Background");
            public static readonly GUIStyle   PreButton         = new GUIStyle("RL FooterButton");
            public static readonly GUIStyle   ElementBackground = new GUIStyle("RL Element");

            public static GUIStyle MiniLabel {
                get {
                    if (miniLabel != null)
                        return miniLabel;

                    miniLabel = new GUIStyle(EditorStyles.miniLabel) { alignment = TextAnchor.UpperCenter };

                    return miniLabel;
                }
            }
        }

#region Delegate Methods
        private float OnListElementHeightCallback(int index) {
            if (List.serializedProperty.arraySize < index)
                return 0;

            var prop = List.serializedProperty.GetArrayElementAtIndex(index);

            if (List.serializedProperty.GetArrayElementAtIndex(index).propertyType == SerializedPropertyType.ObjectReference)
                return List.elementHeight = Mathf.Max(EditorGUIUtility.singleLineHeight, ObjectReferenceElementHeight(prop)) + 4.0f;

            return List.elementHeight = Mathf.Max(EditorGUIUtility.singleLineHeight, EditorGUI.GetPropertyHeight(prop, prop.isExpanded)) + 4.0f;
        }

        private bool OnListOnCanRemoveCallback(ReorderableList list) => List.count > 0;

        private void OnListDrawHeaderCallback(Rect rect) {
            var xMax = rect.xMax;
            var x    = xMax - 8f;

            if (List.displayAdd)
                x -= 25f;

            if (List.displayRemove)
                x -= 25f;

            using (Disposables.IndentSet(0)) {
                var style = _property.prefabOverride? EditorStyles.boldLabel : GUIStyle.none;
                
                FoCsGUI.Label(rect.GetModifiedRect(RectEdit.Indent()), $"{_property.displayName} [{_property.arraySize}]", style);

                _property.isExpanded = FoCsGUI.Foldout(rect.GetModifiedRect(RectEdit.SubtractWidth(64)), _property.isExpanded);
            }

            using (Disposables.DisabledScope(!_property.isExpanded)) {
                var rect2            = new Rect(x, rect.y, xMax - x,         rect.height);
                var addButtonRect    = new Rect(xMax            - 29f - 25f, rect2.y - 3f, 25f, 13f);
                var removeButtonRect = new Rect(xMax            - 29f,       rect2.y - 3f, 25f, 13f);

                if (List.displayAdd)
                    AddButtonsGUI(addButtonRect.GetModifiedRect(RectEdit.AddY(3)));

                if (List.displayRemove)
                    RemoveButtonsGUI(removeButtonRect.GetModifiedRect(RectEdit.AddY(3)));
            }
        }

        private void OnListDrawFooterCallback(Rect rowRect) {
            var xMax = rowRect.xMax;
            var x    = xMax - 8f;

            if (List.displayAdd)
                x -= 25f;

            if (List.displayRemove)
                x -= 25f;

            var rect             = new Rect(x, rowRect.y, xMax - x,         rowRect.height);
            var addButtonRect    = new Rect(xMax               - 29f - 25f, rect.y - 3f, 25f, 13f);
            var removeButtonRect = new Rect(xMax               - 29f,       rect.y - 3f, 25f, 13f);

            if (Event.current.type == EventType.Repaint)
                ListStyles.FooterBackground.Draw(rect, false, false, false, false);

            if (List.displayAdd)
                AddButtonsGUI(addButtonRect);

            if (List.displayRemove)
                RemoveButtonsGUI(removeButtonRect);
        }

        private void AddButtonsGUI(Rect addButtonRect) {
            using (Disposables.DisabledScope((List.onCanAddCallback != null) && !List.onCanAddCallback(List))) {
                var @event = Event.current;

                if (SerializedPropertyType == SerializedPropertyType.ObjectReference) {
                    if (@event.type == EventType.Repaint) {
                        if (!DragAndDrop.objectReferences.IsNullOrEmpty()) {
                            using (Disposables.ColorChanger(Color.green))
                                FoCsGUI.Styles.Unity.Box.Draw(addButtonRect, false, false, false, false);
                        }
                    }

                    if (addButtonRect.Contains(@event.mousePosition)) {
                        if ((@event.type == EventType.DragUpdated) || (@event.type == EventType.DragPerform)) {
                            DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                            if (@event.type == EventType.DragPerform) {
                                DoDropAdd();
                                DragAndDrop.AcceptDrag();
                            }

                            @event.Use();
                        }
                    }
                }

                if (!FoCsGUI.Button(addButtonRect, List.onAddDropdownCallback == null? ListStyles.IconToolbarPlus : ListStyles.IconToolbarPlusMore, ListStyles.PreButton))
                    return;

                if (List.onAddDropdownCallback != null)
                    List.onAddDropdownCallback(addButtonRect, List);
                else if (List.onAddCallback != null)
                    List.onAddCallback(List);
                else
                    Defaults.DoAddButton(List);

                List.onChangedCallback?.Invoke(List);
            }
        }

        private void RemoveButtonsGUI(Rect removeButtonRect) {
            using (Disposables.DisabledScope((List.index < 0) || (List.index >= List.count) || ((List.onCanRemoveCallback != null) && !List.onCanRemoveCallback(List)))) {
                if (!FoCsGUI.Button(removeButtonRect, ListStyles.IconToolbarMinus, ListStyles.PreButton))
                    return;

                if (List.onRemoveCallback == null)
                    Defaults.DoRemoveButton(List);
                else
                    List.onRemoveCallback(List);

                List.onChangedCallback?.Invoke(List);
            }
        }
#endregion

#region Delegate Setters
        /// <summary>
        ///     SetAddCallBack
        /// </summary>
        /// <param name="a">The callback to be used instead of default</param>
        /// <returns>This</returns>
        public UnityReorderableListProperty SetAddCallBack(ReorderableList.AddCallbackDelegate a) {
            List.onAddCallback = a;

            return this;
        }

        /// <summary>
        ///     SetAddDropdownCallback
        /// </summary>
        /// <param name="a">The callback to be used instead of default</param>
        /// <returns>This</returns>
        public UnityReorderableListProperty SetAddDropdownCallback(ReorderableList.AddDropdownCallbackDelegate a) {
            List.onAddDropdownCallback = a;

            return this;
        }

        /// <summary>
        ///     SetCanAddCallback
        /// </summary>
        /// <param name="a">The callback to be used instead of default</param>
        /// <returns>This</returns>
        public UnityReorderableListProperty SetCanAddCallback(ReorderableList.CanAddCallbackDelegate a) {
            List.onCanAddCallback = a;

            return this;
        }

        /// <summary>
        ///     SetCanRemoveCallback
        /// </summary>
        /// <param name="a">The callback to be used instead of default</param>
        /// <returns>This</returns>
        public UnityReorderableListProperty SetCanRemoveCallback(ReorderableList.CanRemoveCallbackDelegate a) {
            List.onCanRemoveCallback = a;

            return this;
        }

        /// <summary>
        ///     SetReorderCallback
        /// </summary>
        /// <param name="a">The callback to be used instead of default</param>
        /// <returns>This</returns>
        public UnityReorderableListProperty SetReorderCallback(ReorderableList.ReorderCallbackDelegate a) {
            List.onReorderCallback = a;

            return this;
        }

        /// <summary>
        ///     SetDrawElementBackgroundCallback
        /// </summary>
        /// <param name="a">The callback to be used instead of default</param>
        /// <returns>This</returns>
        public UnityReorderableListProperty SetDrawElementBackgroundCallback(ReorderableList.ElementCallbackDelegate a) {
            List.drawElementBackgroundCallback = a;

            return this;
        }

        /// <summary>
        ///     SetDrawElementCallback
        /// </summary>
        /// <param name="a">The callback to be used instead of default</param>
        /// <returns>This</returns>
        public UnityReorderableListProperty SetDrawElementCallback(ReorderableList.ElementCallbackDelegate a) {
            List.drawElementCallback = a;

            return this;
        }

        /// <summary>
        ///     SetDrawFooterCallback
        /// </summary>
        /// <param name="a">The callback to be used instead of default</param>
        /// <returns>This</returns>
        public UnityReorderableListProperty SetDrawFooterCallback(ReorderableList.FooterCallbackDelegate a) {
            List.drawFooterCallback = a;

            return this;
        }

        /// <summary>
        ///     SetDrawHeaderCallback
        /// </summary>
        /// <param name="a">The callback to be used instead of default</param>
        /// <returns>This</returns>
        public UnityReorderableListProperty SetDrawHeaderCallback(ReorderableList.HeaderCallbackDelegate a) {
            List.drawHeaderCallback = a;

            return this;
        }

        /// <summary>
        ///     SetElementHeightCallback
        /// </summary>
        /// <param name="a">The callback to be used instead of default</param>
        /// <returns>This</returns>
        public UnityReorderableListProperty SetElementHeightCallback(ReorderableList.ElementHeightCallbackDelegate a) {
            List.elementHeightCallback = a;

            return this;
        }

        /// <summary>
        ///     SetSelectCallback
        /// </summary>
        /// <param name="a">The callback to be used instead of default</param>
        /// <returns>This</returns>
        public UnityReorderableListProperty SetSelectCallback(ReorderableList.SelectCallbackDelegate a) {
            List.onSelectCallback = a;

            return this;
        }
#endregion
    }
}