#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: HandlerController.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using ForestOfChaos.Unity.Editor.Utilities;
using UnityEditor;
using Dictionary = System.Collections.Generic.Dictionary<ForestOfChaos.Unity.Editor.FoCsEditor.SortableSerializedProperty, ForestOfChaos.Unity.Editor.IPropertyLayoutHandler>;

namespace ForestOfChaos.Unity.Editor {
    public class HandlerController {

        private static List<Func<IPropertyLayoutHandler>> CustomHandlers { get; } = new List<Func<IPropertyLayoutHandler>>();

        public PropertyHandler FallbackHandler { get; private set; }

        public List<IPropertyLayoutHandler> Handlers { get; private set; }

        private Dictionary PropertyHandlingDictionary { get; set; }

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

            return FallbackHandler;
        }

        public void Handle(SerializedProperty property, bool isNested) {
            if (isNested)
                FallbackHandler.HandleProperty(property);
            else
                this[property]?.HandleProperty(property);
        }

        public void DrawAfterEditor(SerializedProperty property) {
            this[property]?.DrawAfterEditor(property);
        }

        public void ClearHandlingDictionary() {
            if (PropertyHandlingDictionary == null)
                return;

            PropertyHandlingDictionary.Clear();
            PropertyHandlingDictionary = null;
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
                Handlers = new List<IPropertyLayoutHandler> { new ObjectReferenceHandler(owner), new ListHandler(owner), new DefaultScriptPropertyHandler(owner) };

            VerifyIPropertyLayout();
        }

        public void VerifyIPropertyLayoutHandlerArray(ObjectReferenceHandler owner) {
            if (Handlers == null)
                Handlers = new List<IPropertyLayoutHandler> { new ListHandler(owner.owner), new DefaultScriptPropertyHandler(owner.owner) };

            VerifyIPropertyLayout();
        }

        public void VerifyIPropertyLayoutHandlerArrayNoObject(FoCsEditor owner) {
            if (Handlers == null)
                Handlers = new List<IPropertyLayoutHandler> { new ListHandler(owner), new DefaultScriptPropertyHandler(owner) };

            VerifyIPropertyLayout();
        }

        public void VerifyIPropertyLayoutHandlerArrayNoObject(UnityReorderableListStorage storage) {
            if (Handlers == null)
                Handlers = new List<IPropertyLayoutHandler> { new ListHandler(storage), new DefaultScriptPropertyHandler() };

            VerifyIPropertyLayout();
        }

        private void VerifyIPropertyLayout() {
            if (CustomHandlers.Count > 0)
                Handlers.AddRange(CustomHandlers.Select(a => a()));

            if (FallbackHandler == null)
                FallbackHandler = new PropertyHandler();
        }

        public static void AddCustomHandler(Func<IPropertyLayoutHandler> handler) {
            CustomHandlers.Add(handler);
        }
    }
}