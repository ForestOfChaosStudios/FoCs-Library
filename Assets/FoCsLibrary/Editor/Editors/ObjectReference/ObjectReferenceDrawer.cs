using System.Collections.Generic;
using ForestOfChaosLibrary.Editor.Utilities;
using ForestOfChaosLibrary.Extensions;
using ForestOfChaosLibrary.Utilities;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor.PropertyDrawers
{
	/// <summary>
	///     This class is no longer used by the FoCsEditor, the new <see cref="ObjectReference" />
	///     However it can't currently be removed as AdvRef uses it.
	/// </summary>
	public class ObjectReferenceDrawer: FoCsPropertyDrawer
	{
		private static readonly   UnityReorderableListStorage URLPStorage       = new UnityReorderableListStorage();
		protected static readonly GUIContent                  foldoutGUIContent = new GUIContent("", "Open up the References Data");
		private                   bool                        foldout;
		public                    AnimBool                    IsExpanded;
		public                    SerializedObject            SerializedObject { get; protected set; }

		public bool Foldout
		{
			get { return foldout; }
			set
			{
				foldout = value;

				if(IsExpanded != null)
					IsExpanded.value = foldout;
			}
		}

		protected virtual bool AllowFoldout => true;
		public ObjectReferenceDrawer(): this(false) { }

		public ObjectReferenceDrawer(bool _foldout)
		{
			Foldout = _foldout;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			CheckAnimBool(property);
			DoMainRefGUI(position, property, ref label);
			var elementHeight = FoCsGUI.GetPropertyHeight(property, FoCsGUI.AttributeCheck.DoCheck);

			if((property.objectReferenceValue == null) || !AllowFoldout)
			{
				SerializedObject = null;

				return;
			}

			if(SerializedObject == null)
				SerializedObject = new SerializedObject(property.objectReferenceValue);
			else
				SerializedObject.Update();

			Foldout = DoFoldoutGUI(position, Foldout);
			DrawReference(position.Edit(RectEdit.ChangeY(elementHeight - SingleLine)), SerializedObject, Foldout);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			CheckAnimBool(property);

			return PropertyHeight(property, SerializedObject, Foldout);
		}

		public void DoMainRefGUI(Rect position, SerializedProperty property, ref GUIContent label)
		{
			CheckAnimBool(property);
			var elementHeight = FoCsGUI.GetPropertyHeight(property, FoCsGUI.AttributeCheck.DoCheck);

			using(var propScope = Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;

				using(var changeCheckScope = Disposables.ChangeCheck())
				{
					FoCsGUI.PropertyField(position.Edit(RectEdit.SetHeight(elementHeight)), property, label);

					if(changeCheckScope.changed && (property.objectReferenceValue != null))
					{
						property.serializedObject.ApplyModifiedProperties();
						SerializedObject = new SerializedObject(property.objectReferenceValue);
					}
				}
			}
		}

		public bool DoFoldoutGUI(Rect position, bool internalFoldout)
		{
			internalFoldout = EditorGUI.Foldout(position.Edit(RectEdit.SetHeight(SingleLine), RectEdit.SetWidth(SingleLine), RectEdit.ChangeY(1)), internalFoldout, foldoutGUIContent);

			return internalFoldout;
		}

		private void CheckAnimBool(SerializedProperty property)
		{
			if(IsExpanded == null)
			{
				IsExpanded       = new AnimBool(property.isExpanded);
				IsExpanded.speed = 1;
			}

			IsExpanded.value = property.isExpanded;
		}

		public static void DrawReference(Rect position, SerializedObject serializedObject, bool foldout)
		{
			if(serializedObject.VisibleProperties() == 0)
				return;

			serializedObject.Update();
			var iterator = serializedObject.GetIterator();
			iterator.Next(true);

			if(!foldout)
				return;

			DrawSurroundingBox(position);

			using(var changeCheckScope = Disposables.ChangeCheck())
			{
				using(Disposables.Indent())
				{
					var drawPos = position.Edit(RectEdit.AddY(SingleLine), RectEdit.SubtractHeight(SingleLine), RectEdit.ChangeY(1));

					do
					{
						if(!FoCsEditor.IsPropertyHidden(iterator))
							drawPos = DrawSubProp(iterator, drawPos);
					}
					while(iterator.NextVisible(false));

					if(changeCheckScope.changed)
						serializedObject.ApplyModifiedProperties();
				}
			}
		}

		protected static void DrawSurroundingBox(Rect position)
		{
			if(Event.current.type == EventType.Repaint)
				GUI.skin.box.Draw(position.Edit(RectEdit.ChangeY(SingleLine - 1), RectEdit.SubtractWidth(SingleLine + 7), RectEdit.AddX(SingleLine + 9)), false, false, false, false);
		}

		protected static Rect DrawSubProp(SerializedProperty prop, Rect drawPos)
		{
			if(prop.isArray && (prop.propertyType != SerializedPropertyType.String))
			{
				var list   = URLPStorage.GetList(prop);
				var height = list.GetTotalHeight();
				drawPos.height = height;

				using(Disposables.SetIndent(0))
				{
					if(prop.isExpanded)
						list.HandleDrawing(drawPos.Edit(RectEdit.ChangeX(16)));
					else
						list.DrawHeader(drawPos.Edit(RectEdit.ChangeX(16)));
				}

				drawPos.y += height + Padding;
			}
			else
			{
				var height = FoCsGUI.GetPropertyHeight(prop, FoCsGUI.AttributeCheck.DoCheck);
				drawPos.height = height;
				FoCsGUI.PropertyField(drawPos, prop, prop.isExpanded, FoCsGUI.AttributeCheck.DoCheck);
				drawPos.y += height + Padding;
			}

			return drawPos;
		}

		protected static float SubPropHeight(SerializedProperty prop, bool padding = true)
		{
			if(prop.isArray && (prop.propertyType != SerializedPropertyType.String))
			{
				var list   = URLPStorage.GetList(prop);
				var height = list.GetTotalHeight();

				return height + (padding? Padding : 0);
			}
			else
			{
				var height = FoCsGUI.GetPropertyHeight(prop, FoCsGUI.AttributeCheck.DoCheck);

				return height + (padding? Padding : 0);
			}
		}

		public static float PropertyHeight(SerializedProperty property, SerializedObject serializedObject, bool foldout)
		{
			if((serializedObject == null) || !foldout || (serializedObject.VisibleProperties() == 0))
				return Mathf.Max(FoCsGUI.GetPropertyHeight(property), SingleLine);

			var iterator = serializedObject.GetIterator();
			iterator.Next(true);
			var height = SingleLine + Padding;

			using(Disposables.Indent())
			{
				do
				{
					if(!FoCsEditor.IsPropertyHidden(iterator))
						height += SubPropHeight(iterator);
				}
				while(iterator.NextVisible(false));
			}

			return height;
		}

#region Storage
		private static readonly Dictionary<string, ObjectReferenceDrawer> objectDrawers = new Dictionary<string, ObjectReferenceDrawer>(10);

		public static ObjectReferenceDrawer GetObjectDrawer(SerializedProperty property)
		{
			var                   id = string.Format("{0}:{1}-{2}", property.serializedObject.targetObject.name, property.propertyPath, property.name);
			ObjectReferenceDrawer objDraw;

			if(objectDrawers.TryGetValue(id, out objDraw))
				return objDraw;

			objDraw = new ObjectReferenceDrawer();
			objectDrawers.Add(id, objDraw);

			return objDraw;
		}
#endregion
	}
}
