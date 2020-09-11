#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: HandlerController.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


using ForestOfChaosLibrary.Editor.Utilities;
using UnityEditor;
using Dictionary = System.Collections.Generic.Dictionary<ForestOfChaosLibrary.Editor.FoCsEditor.SortableSerializedProperty, ForestOfChaosLibrary.Editor.IPropertyLayoutHandler>;

namespace ForestOfChaosLibrary.Editor {
    public class HandlerController {
        public  PropertyHandler          fallbackHandler;
        public  IPropertyLayoutHandler[] Handlers;
        private Dictionary               PropertyHandlingDictionary;

        public Dictionary.ValueCollection Values => PropertyHandlingDictionary.Values;

        public Dictionary.KeyCollection Keys => PropertyHandlingDictionary.Keys;

        public IPropertyLayoutHandler this[FoCsEditor.SortableSerializedProperty key] {
            get {
                if (PropertyHandlingDictionary.ContainsKey(key))
                    return PropertyHandlingDictionary[key];

                return null;
            }
            set => PropertyHandlingDictionary[key] = value;
        }

        public IPropertyLayoutHandler GetHandler(SerializedProperty property) {
            foreach (var handler in Handlers) {
                if (handler.IsValidProperty(property))
                    return handler;
            }

            return fallbackHandler;
        }

        public void Handle(SerializedProperty property) {
            this[property]?.HandleProperty(property);
        }

        public void DrawAfterEditor(SerializedProperty property) {
            this[property]?.DrawAfterEditor(property);
        }

        public void ClearHandlingDictionary() {
            if (PropertyHandlingDictionary != null) {
                PropertyHandlingDictionary.Clear();
                PropertyHandlingDictionary = null;
            }
        }

        public void VerifyHandlingDictionary(SerializedObject serializedObject) {
            if (PropertyHandlingDictionary != null)
                return;

            PropertyHandlingDictionary = new Dictionary(serializedObject.VisibleProperties());

            foreach (var property in serializedObject.Properties())
                PropertyHandlingDictionary.Add(property, GetHandler(property));
        }

        public void VerifyIPropertyLayoutHandlerArray(FoCsEditor owner) {
            if (Handlers == null)
                Handlers = new IPropertyLayoutHandler[] {new ObjectReferenceHandler(owner), new ListHandler(owner), new DefaultScriptPropertyHandler(owner)};

            if (fallbackHandler == null)
                fallbackHandler = new PropertyHandler();
        }

        public void VerifyIPropertyLayoutHandlerArray(ObjectReferenceHandler owner) {
            if (Handlers == null)
                Handlers = new IPropertyLayoutHandler[] {new ListHandler(owner.owner), new DefaultScriptPropertyHandler(owner.owner)};

            if (fallbackHandler == null)
                fallbackHandler = new PropertyHandler();
        }

        public void VerifyIPropertyLayoutHandlerArrayNoObject(FoCsEditor owner) {
            if (Handlers == null)
                Handlers = new IPropertyLayoutHandler[] {new ListHandler(owner), new DefaultScriptPropertyHandler(owner)};

            if (fallbackHandler == null)
                fallbackHandler = new PropertyHandler();
        }

        public void VerifyIPropertyLayoutHandlerArrayNoObject(UnityReorderableListStorage storage) {
            if (Handlers == null)
                Handlers = new IPropertyLayoutHandler[] {new ListHandler(storage), new DefaultScriptPropertyHandler()};

            if (fallbackHandler == null)
                fallbackHandler = new PropertyHandler();
        }
    }
}