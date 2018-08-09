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
		public AnimBool IsExpanded;
		private bool foldout;
		public bool Foldout
		{
			get { return foldout; }
			set { foldout = IsExpanded.value = value; }
		}
		public SerializedProperty Property;
		public SerializedObject SerializedObject;

		public static void Draw(ObjectReference objRef, HeaderMode onlyHeader = HeaderMode.Normal)
		{
			if(((onlyHeader == HeaderMode.Normal) || (onlyHeader == HeaderMode.OnlyHeader) || (objRef.Property.objectReferenceValue == null) || (!objRef.Foldout && objRef.Property.objectReferenceValue)) && (onlyHeader != HeaderMode.NoHeader))
			{
				using(var cc = FoCsEditor.Disposables.ChangeCheck())
				{
					FoCsGUI.Layout.PropertyField(objRef.Property, false);

					if(cc.changed)
					{
						objRef.SerializedObject = null;
					}
				}

				if(objRef.Property.objectReferenceValue)
				{
					if(FoCsGUI.Foldout(GUILayoutUtility.GetLastRect().Edit(RectEdit.SetWidth(16)), objRef.Foldout).Pressed)
					{
						objRef.Foldout = !objRef.Foldout;
					}
				}

				return;
			}
			if(objRef.SerializedObject == null)
				objRef.SerializedObject = new SerializedObject(objRef.Property.objectReferenceValue);

			if(onlyHeader != HeaderMode.NoHeader)
			{
				FoCsGUI.Layout.PropertyField(objRef.Property, false);

				if(FoCsGUI.Foldout(GUILayoutUtility.GetLastRect().Edit(RectEdit.SetWidth(16)), objRef.Foldout).Pressed)
					objRef.Foldout = !objRef.Foldout;
			}

			using(FoCsEditor.Disposables.VerticalScope(FoCsGUI.Styles.Unity.Box))
			{
				if(objRef.Foldout)
				{
					using(FoCsEditor.Disposables.Indent())
					{
						foreach(var prop in objRef.SerializedObject.Properties())
						{
							FoCsGUI.Layout.PropertyField(prop, prop.isExpanded);
						}
					}
				}
			}
		}

		public enum HeaderMode
		{
			Normal,
			OnlyHeader,
			NoHeader
		}

		/*
		public static void Draw(SerializedProperty property)
		{
			if(!property.isExpanded || property.objectReferenceValue == null)
			{
				FoCsGUI.Layout.PropertyField(property, false);

				if(property.objectReferenceValue)
				{
					if(FoCsGUI.Foldout(GUILayoutUtility.GetLastRect().Edit(RectEdit.SetWidth(16)), property.isExpanded).Pressed)
					{
						property.isExpanded = true;
					}
				}

				return;
			}


			var serializedObject = new SerializedObject(property.objectReferenceValue);

			using(FoCsEditor.Disposables.VerticalScope(FoCsGUI.Styles.Unity.Box))
			{
				FoCsGUI.Layout.PropertyField(property, false);

				if(property.objectReferenceValue)
				{
					if(FoCsGUI.Foldout(GUILayoutUtility.GetLastRect().Edit(RectEdit.SetWidth(16)), property.isExpanded).Pressed)
					{
						property.isExpanded = false;
					}
				}

				using(FoCsEditor.Disposables.Indent())
				{
					foreach(var prop in serializedObject.Properties())
					{
						FoCsGUI.Layout.PropertyField(prop, prop.isExpanded);
					}
				}
			}
		}
		*/
	}
}