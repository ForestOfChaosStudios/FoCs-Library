using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	public class ObjectReference
	{
		private FoCsEditor.UnityReorderableListStorage listHandler;

		private FoCsEditor.UnityReorderableListStorage ListHandler
		{
			get { return listHandler ?? (listHandler = new FoCsEditor.UnityReorderableListStorage(owner)); }
		}
		private readonly HandlerController Handler = new HandlerController();
		public  AnimBool IsReferenceOpen;
		private bool     referenceOpen;
		public FoCsEditor owner;
		public bool ReferenceOpen
		{
			get { return referenceOpen; }
			set
			{
				referenceOpen     = value;
				IsReferenceOpen.target = value;
			}
		}

		public SerializedProperty Property;
		public SerializedObject   SerializedObject;

		public ObjectReference(SerializedProperty _property,FoCsEditor _owner)
		{
			Property   = _property;
			owner = _owner;
			IsReferenceOpen = new AnimBool(false) {speed = 0.7f};

		}

		public void DrawHeader()
		{
			using(var cc = FoCsEditor.Disposables.ChangeCheck())
			{
				FoCsGUI.Layout.PropertyField(Property, false);

				if(cc.changed)
				{
					if(Property.objectReferenceValue == null)
					{
						SerializedObject = null;
						ReferenceOpen = false;
						IsReferenceOpen.value = false;
					}
					else
					{
						SerializedObject = new SerializedObject(Property.objectReferenceValue);
						Handler.ClearHandlingDictionary();
					}
				}
			}

			if(!Property.objectReferenceValue)
				return;

			if(SerializedObject == null)
			{
				Handler.ClearHandlingDictionary();
				SerializedObject = new SerializedObject(Property.objectReferenceValue);
			}
			Handler.VerifyIPropertyLayoutHandlerArrayNoObject(owner);
			Handler.VerifyHandlingDictionary(SerializedObject);

			ReferenceOpen = FoCsGUI.Foldout(GUILayoutUtility.GetLastRect().Edit(RectEdit.SetWidth(16)), ReferenceOpen);
		}


		public void DrawReference(FoCsEditor.UnityReorderableListStorage URLStorage)
		{
			if(!ReferenceOpen)
				return;

			using(FoCsEditor.Disposables.VerticalScope(FoCsGUI.Styles.Unity.Box))
			{
				using(FoCsEditor.Disposables.Indent())
				{
					foreach(var property in SerializedObject.Properties())
					{
						Handler[property].HandleProperty(property);
					}
				}
			}
		}
	}
}
