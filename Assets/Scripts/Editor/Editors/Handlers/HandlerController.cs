using System.Collections.Generic;
using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using Dictionary = System.Collections.Generic.Dictionary<ForestOfChaosLib.Editor.FoCsEditor.SortableSerializedProperty, ForestOfChaosLib.Editor.IPropertyLayoutHandler>;

namespace ForestOfChaosLib.Editor
{
	public class HandlerController
	{
		public  IPropertyLayoutHandler[]   Handlers = null;
		public  PropertyHandler            fallbackHandler;
		private Dictionary                 PropertyHandlingDictionary;
		public  Dictionary.ValueCollection Values => PropertyHandlingDictionary.Values;
		public  Dictionary.KeyCollection   Keys   => PropertyHandlingDictionary.Keys;

		public IPropertyLayoutHandler GetHandler(SerializedProperty property)
		{
			foreach(var handler in Handlers)
			{
				if(handler.IsValidProperty(property))
					return handler;
			}

			return fallbackHandler;
		}

		public IPropertyLayoutHandler this[FoCsEditor.SortableSerializedProperty i]
		{
			get { return PropertyHandlingDictionary[i]; }
			set { PropertyHandlingDictionary[i] = value; }
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

			PropertyHandlingDictionary = new Dictionary<FoCsEditor.SortableSerializedProperty, IPropertyLayoutHandler>(serializedObject.VisibleProperties());

			foreach(var property in serializedObject.Properties())
				PropertyHandlingDictionary.Add(property, GetHandler(property));
		}

		public void VerifyIPropertyLayoutHandlerArray(FoCsEditor owner)
		{
			if(Handlers == null)
				Handlers = new IPropertyLayoutHandler[] {new ObjectReferenceHandler(owner), new ListHandler(owner), new DefaultScriptPropertyHandler(owner),};

			if(fallbackHandler == null)
				fallbackHandler = new PropertyHandler();
		}

		public void VerifyIPropertyLayoutHandlerArrayNoObject(FoCsEditor owner)
		{
			if(Handlers == null)
				Handlers = new IPropertyLayoutHandler[] { new ListHandler(owner), new DefaultScriptPropertyHandler(owner),};

			if(fallbackHandler == null)
				fallbackHandler = new PropertyHandler();
		}

		public void VerifyIPropertyLayoutHandlerArray(ObjectReferenceHandler owner)
		{
			if(Handlers == null)
				Handlers = new IPropertyLayoutHandler[] {new ListHandler(owner.owner), new DefaultScriptPropertyHandler(owner.owner),};

			if(fallbackHandler == null)
				fallbackHandler = new PropertyHandler();
		}
	}
}
