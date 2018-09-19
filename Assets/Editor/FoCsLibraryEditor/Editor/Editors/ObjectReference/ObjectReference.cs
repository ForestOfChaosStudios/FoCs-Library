using ForestOfChaosLibraryEditor.Utilities;
using ForestOfChaosLibrary.Extensions;
using ForestOfChaosLibrary.Utilities;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace ForestOfChaosLibraryEditor
{
	/// <summary>
	///     A class that manages the Object Reference drawing, used by FoCsEditor
	/// </summary>
	public class ObjectReference
	{
		private readonly HandlerController           Handler = new HandlerController();
		public           AnimBool                    IsReferenceOpen;
		private          UnityReorderableListStorage listHandler;
		public           FoCsEditor                  owner;
		public           SerializedProperty          Property;
		private          bool                        referenceOpen;
		public           SerializedObject            SerializedObject;
		private          UnityReorderableListStorage ListHandler => listHandler ?? (listHandler = new UnityReorderableListStorage(owner));

		public bool ReferenceOpen
		{
			get { return referenceOpen; }
			set
			{
				referenceOpen          = value;
				IsReferenceOpen.target = value;
			}
		}

		public ObjectReference(SerializedProperty _property, FoCsEditor _owner)
		{
			Property        = _property;
			owner           = _owner;
			IsReferenceOpen = new AnimBool(false) {speed = 0.7f};
		}

		/// <summary>
		///     Draws the Object Reference field, and foldout GUI
		/// </summary>
		public void DrawHeader()
		{
			DrawHeader(true);
		}

		/// <summary>
		///     Draws the Object Reference field, and foldout GUI
		/// </summary>
		public void DrawHeader(bool showFoldout)
		{
			using(var cc = Disposables.ChangeCheck())
			{
				FoCsGUI.Layout.PropertyField(Property, false);

				if(cc.changed)
				{
					if(Property.objectReferenceValue == null)
					{
						SerializedObject      = null;
						ReferenceOpen         = false;
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

			VerifyHandler();

			if(showFoldout)
				ReferenceOpen = FoCsGUI.Foldout(GUILayoutUtility.GetLastRect().Edit(RectEdit.SetWidth(16)), ReferenceOpen);
		}

		/// <summary>
		///     Draws the Object references referenced Object...
		/// </summary>
		/// <param name="URLStorage"></param>
		public void DrawReference(UnityReorderableListStorage URLStorage)
		{
			if(!ReferenceOpen)
				return;

			SerializedObject.Update();

			using(Disposables.VerticalScope(FoCsGUI.Styles.Unity.Box))
			{
				using(Disposables.Indent())
				{
					foreach(var property in SerializedObject.Properties())
						Handler.Handle(property);
				}
			}

			SerializedObject.ApplyModifiedProperties();
		}

		/// <summary>
		///     Verify the internal data of the HandlerController
		/// </summary>
		public void VerifyHandler()
		{
			Handler.VerifyIPropertyLayoutHandlerArray(owner);
			Handler.VerifyHandlingDictionary(SerializedObject);
		}
	}
}
