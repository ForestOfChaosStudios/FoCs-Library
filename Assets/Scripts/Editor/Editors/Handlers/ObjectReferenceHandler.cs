using System;
using System.Collections.Generic;
using ForestOfChaosLib.Attributes;
using ForestOfChaosLib.Editor.PropertyDrawers;
using UnityEditor;

namespace ForestOfChaosLib.Editor
{
	public class ObjectReferenceHandler: IPropertyLayoutHandler
	{
		private         UnityReorderableListStorage       storage;
		public readonly FoCsEditor                        owner;
		private         Dictionary<string, EditorFoldout> ShowAfter = new Dictionary<string, EditorFoldout>();

		public ObjectReferenceHandler(FoCsEditor _owner)
		{
			owner = _owner;
		}

		public ObjectReferenceHandler(UnityReorderableListStorage _URLStorage)
		{
			storage = _URLStorage;
			owner   = null;
		}

		public UnityReorderableListStorage URLStorage
		{
			get { return storage ?? (storage = new UnityReorderableListStorage(owner)); }
			set { storage = value; }
		}

		public void HandleProperty(SerializedProperty property)
		{
			var drawer  = owner.GetObjectDrawer(property, owner);
			var @object = property.objectReferenceValue;

			if(@object == null)
			{
				NormalDraw(drawer);

				return;
			}

			var attribute    = property.GetSerializedPropertyAttributes<ShowAsComponentAttribute>();
			var hasAttribute = AttributeType.None;

			foreach(var a in attribute)
			{
				if(a is ShowAsComponentAttribute)
				{
					hasAttribute = AttributeType.ShowAsComponent;

					break;
				}

				if(a is NoObjectFoldoutAttribute)
				{
					hasAttribute = AttributeType.NoObjectFoldout;

					break;
				}
			}

			if(hasAttribute == AttributeType.ShowAsComponent)
			{
				drawer.DrawHeader(false);
				var id = property.GetId();

				if(!ShowAfter.ContainsKey(id))
					ShowAfter.Add(id, new EditorFoldout());
			}
			else if(hasAttribute == AttributeType.NoObjectFoldout)
				drawer.DrawHeader(false);
			else
				NormalDraw(drawer);
		}

		private void NormalDraw(ObjectReference drawer)
		{
			using(var cc = Disposables.ChangeCheck())
			{
				drawer.IsReferenceOpen.target = drawer.ReferenceOpen;
				drawer.DrawHeader();

				using(var fade = Disposables.FadeGroupScope(drawer.IsReferenceOpen.faded))
				{
					if(fade.visible)
						drawer.DrawReference(URLStorage);
				}

				if(cc.changed)
					URLStorage.owner.Repaint();
			}
		}

		[Flags]
		private enum AttributeType
		{
			None            = 0,
			ShowAsComponent = 1,
			NoObjectFoldout = 2
		}

		public float PropertyHeight(SerializedProperty property) => FoCsGUI.SingleLine;
		public bool IsValidProperty(SerializedProperty property) => (property.propertyType == SerializedPropertyType.ObjectReference) && !FoCsEditor.IsDefaultScriptProperty(property);

		public void DrawAfterEditor(SerializedProperty serializedProperty)
		{
			var id = serializedProperty.GetId();

			if(!ShowAfter.ContainsKey(id))
				return;

			var obj = serializedProperty.objectReferenceValue;

			if(obj == null)
				return;

			var editorFoldout = ShowAfter[id];
			editorFoldout.Foldout = EditorGUILayout.InspectorTitlebar(editorFoldout.Foldout, obj);

			using(Disposables.IndentZeroed())
			{
				if(editorFoldout.Foldout)
				{
					UnityEditor.Editor.CreateCachedEditor(obj, null, ref editorFoldout.Editor);
					editorFoldout.Editor.OnInspectorGUI();
				}
			}

			ShowAfter[id] = editorFoldout;
		}

		private struct EditorFoldout
		{
			public bool               Foldout;
			public UnityEditor.Editor Editor;
		}
	}
}
