using ForestOfChaosLibraryEditor.Utilities;
using UnityEditor;
using Dictionary = System.Collections.Generic.Dictionary<ForestOfChaosLibraryEditor.FoCsEditor.SortableSerializedProperty, ForestOfChaosLibraryEditor.IPropertyLayoutHandler>;

namespace ForestOfChaosLibraryEditor
{
	public class HandlerController
	{
		public  PropertyHandler            fallbackHandler;
		public  IPropertyLayoutHandler[]   Handlers;
		private Dictionary                 PropertyHandlingDictionary;
		public  Dictionary.ValueCollection Values => PropertyHandlingDictionary.Values;
		public  Dictionary.KeyCollection   Keys   => PropertyHandlingDictionary.Keys;

		public IPropertyLayoutHandler this[FoCsEditor.SortableSerializedProperty key]
		{
			get
			{
				if(PropertyHandlingDictionary.ContainsKey(key))
					return PropertyHandlingDictionary[key];
				return null;
			}
			set { PropertyHandlingDictionary[key] = value; }
		}

		public IPropertyLayoutHandler GetHandler(SerializedProperty property)
		{
			foreach(var handler in Handlers)
			{
				if(handler.IsValidProperty(property))
					return handler;
			}

			return fallbackHandler;
		}

		public void Handle(SerializedProperty property)
		{
			this[property]?.HandleProperty(property);
		}

		public void DrawAfterEditor(SerializedProperty property)
		{
			this[property]?.DrawAfterEditor(property);
		}

		public void ClearHandlingDictionary()
		{
			if(PropertyHandlingDictionary != null)
			{
				PropertyHandlingDictionary.Clear();
				PropertyHandlingDictionary = null;
			}
		}

		public void VerifyHandlingDictionary(SerializedObject serializedObject)
		{
			if(PropertyHandlingDictionary != null)
				return;

			PropertyHandlingDictionary = new Dictionary(serializedObject.VisibleProperties());

			foreach(var property in serializedObject.Properties())
				PropertyHandlingDictionary.Add(property, GetHandler(property));
		}

		public void VerifyIPropertyLayoutHandlerArray(FoCsEditor owner)
		{
			if(Handlers == null)
				Handlers = new IPropertyLayoutHandler[] {new ObjectReferenceHandler(owner), new ListHandler(owner), new DefaultScriptPropertyHandler(owner)};

			if(fallbackHandler == null)
				fallbackHandler = new PropertyHandler();
		}

		public void VerifyIPropertyLayoutHandlerArray(ObjectReferenceHandler owner)
		{
			if(Handlers == null)
				Handlers = new IPropertyLayoutHandler[] {new ListHandler(owner.owner), new DefaultScriptPropertyHandler(owner.owner)};

			if(fallbackHandler == null)
				fallbackHandler = new PropertyHandler();
		}

		public void VerifyIPropertyLayoutHandlerArrayNoObject(FoCsEditor owner)
		{
			if(Handlers == null)
				Handlers = new IPropertyLayoutHandler[] {new ListHandler(owner), new DefaultScriptPropertyHandler(owner)};

			if(fallbackHandler == null)
				fallbackHandler = new PropertyHandler();
		}

		public void VerifyIPropertyLayoutHandlerArrayNoObject(UnityReorderableListStorage storage)
		{
			if(Handlers == null)
				Handlers = new IPropertyLayoutHandler[] {new ListHandler(storage), new DefaultScriptPropertyHandler()};

			if(fallbackHandler == null)
				fallbackHandler = new PropertyHandler();
		}
	}
}
