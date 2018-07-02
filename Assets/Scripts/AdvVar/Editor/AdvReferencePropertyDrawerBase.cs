using System;
using ForestOfChaosLib.AdvVar.Base;
using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.PropertyDrawers;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Editor
{
	[CustomPropertyDrawer(typeof(AdvVariable), true)]
	public class AdvReferencePropertyDrawerBase: ObjectReferenceDrawer
	{
		internal const           float        WIDTH                     = 16f;
		internal const           string       REFERENCE_STR             = "Reference";
		internal const           string       LOCAL_VALUE_STR           = "LocalValue";
		internal const           string       USE_LOCAL_STR             = "UseLocal";
		internal static readonly GUIContent   localConstantGUIContent   = new GUIContent("Use Local Value", "Use Local Value");
		internal static readonly GUIContent   globalReferenceGUIContent = new GUIContent("Use Reference",   "Use Reference");
		internal static readonly GUIContent[] OPTIONS_ARRAY             = {localConstantGUIContent, globalReferenceGUIContent};

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			foldout = DoDraw(position, property, foldout, ref label);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			var @ref = property.GetReference();

			if(@ref.objectReferenceValue)
				serializedObject = new SerializedObject(@ref.objectReferenceValue);

			return PropertyHeight(serializedObject, foldout);
		}

		public static bool DoDraw(Rect position, SerializedProperty property, bool foldout, ref GUIContent label)
		{
			var useLocal        = property.GetUseLocal();
			var localValue      = property.GetLocal();
			var globalReference = property.GetReference();

			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;

				useLocal.boolValue =
						FoCsGUI.DrawPropertyWithMenu(position.Edit(RectEdit.SetHeight(SingleLine), RectEdit.ChangeY(1)), useLocal.boolValue? localValue : globalReference, label, OPTIONS_ARRAY, useLocal.boolValue? 0 : 1).Value == 0;
			}

			if(globalReference.objectReferenceValue)
				return DrawReferenceObjectsData(position, foldout, ref useLocal, ref globalReference);

			return foldout;
		}

		public static void DoDraw(Rect position, SerializedProperty property, GUIContent label, Action<Rect> drawLocalValue)
		{
			var useLocal        = property.FindPropertyRelative(USE_LOCAL_STR);
			var localValue      = property.FindPropertyRelative(LOCAL_VALUE_STR);
			var globalReference = property.FindPropertyRelative(REFERENCE_STR);

			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;

				if(useLocal.boolValue)
				{
					if(drawLocalValue == null)
						useLocal.boolValue = FoCsGUI.DrawPropertyWithMenu(position.Edit(RectEdit.SetHeight(SingleLinePlusPadding), RectEdit.ChangeY(1)), localValue, label, OPTIONS_ARRAY, useLocal.boolValue? 0 : 1).Value == 0;
					else
						useLocal.boolValue = FoCsGUI.DrawActionWithMenu(position.Edit(RectEdit.SetHeight(SingleLinePlusPadding), RectEdit.ChangeY(1)), drawLocalValue, label, OPTIONS_ARRAY, useLocal.boolValue? 0 : 1).Value == 0;
				}
				else
					useLocal.boolValue = FoCsGUI.DrawPropertyWithMenu(position.Edit(RectEdit.SetHeight(SingleLinePlusPadding), RectEdit.ChangeY(1)), globalReference, label, OPTIONS_ARRAY, useLocal.boolValue? 0 : 1).Value == 0;
			}
		}

		public static bool DoDraw(Rect position, SerializedProperty property, bool foldout, GUIContent label, Action<Rect> drawLocalValue)
		{
			var useLocal        = property.FindPropertyRelative(USE_LOCAL_STR);
			var localValue      = property.FindPropertyRelative(LOCAL_VALUE_STR);
			var globalReference = property.FindPropertyRelative(REFERENCE_STR);

			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;

				if(useLocal.boolValue)
				{
					if(drawLocalValue == null)
						useLocal.boolValue = FoCsGUI.DrawPropertyWithMenu(position.Edit(RectEdit.SetHeight(SingleLinePlusPadding), RectEdit.ChangeY(1)), localValue, label, OPTIONS_ARRAY, useLocal.boolValue? 0 : 1).Value == 0;
					else
						useLocal.boolValue = FoCsGUI.DrawActionWithMenu(position.Edit(RectEdit.SetHeight(SingleLinePlusPadding), RectEdit.ChangeY(1)), drawLocalValue, label, OPTIONS_ARRAY, useLocal.boolValue? 0 : 1).Value == 0;
				}
				else
					useLocal.boolValue = FoCsGUI.DrawPropertyWithMenu(position.Edit(RectEdit.SetHeight(SingleLinePlusPadding), RectEdit.ChangeY(1)), globalReference, label, OPTIONS_ARRAY, useLocal.boolValue? 0 : 1).Value == 0;
			}

			if(globalReference.objectReferenceValue)
				return DrawReferenceObjectsData(position, foldout, ref useLocal, ref globalReference);

			return foldout;
		}

		public static bool DoDraw(Rect position, SerializedProperty property, bool foldout, ref GUIContent label, ref SerializedObject serializedObject, Action<Rect> drawLocalValue)
		{
			var useLocal        = property.FindPropertyRelative(USE_LOCAL_STR);
			var localValue      = property.FindPropertyRelative(LOCAL_VALUE_STR);
			var globalReference = property.FindPropertyRelative(REFERENCE_STR);

			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;

				if(useLocal.boolValue)
				{
					if(drawLocalValue == null)
						useLocal.boolValue = FoCsGUI.DrawPropertyWithMenu(position.Edit(RectEdit.SetHeight(SingleLinePlusPadding), RectEdit.ChangeY(1)), localValue, label, OPTIONS_ARRAY, useLocal.boolValue? 0 : 1).Value == 0;
					else
						useLocal.boolValue = FoCsGUI.DrawActionWithMenu(position.Edit(RectEdit.SetHeight(SingleLinePlusPadding), RectEdit.ChangeY(1)), drawLocalValue, label, OPTIONS_ARRAY, useLocal.boolValue? 0 : 1).Value == 0;
				}
				else
					useLocal.boolValue = FoCsGUI.DrawPropertyWithMenu(position.Edit(RectEdit.SetHeight(SingleLinePlusPadding), RectEdit.ChangeY(1)), globalReference, label, OPTIONS_ARRAY, useLocal.boolValue? 0 : 1).Value == 0;
			}

			if(globalReference.objectReferenceValue)
				return DrawReferenceObjectsData(position, foldout, ref useLocal, ref globalReference);

			return foldout;
		}

		private static bool DrawReferenceObjectsData(Rect position, bool foldout, ref SerializedProperty useLocal, ref SerializedProperty globalReference)
		{
			var serializedObject = new SerializedObject(globalReference.objectReferenceValue);
			var iterator         = serializedObject.GetIterator();
			iterator.Next(true);

			if(!useLocal.boolValue && (globalReference.objectReferenceValue != null))
			{
				foldout = EditorGUI.Foldout(position.Edit(RectEdit.SetHeight(SingleLine), RectEdit.SetWidth(SingleLine), RectEdit.ChangeY(2)), foldout, foldoutGUIContent);

				if(foldout)
				{
					position.height += 1;
					DrawSurroundingBox(position);
					position.y += Padding;

					using(FoCsEditor.Disposables.Indent())
					{
						using(var changeCheckScope = FoCsEditor.Disposables.ChangeCheck())
						{
							var next = iterator.NextVisible(true);

							if(FoCsEditor.IsDefaultScriptProperty(iterator))
								iterator.NextVisible(true);

							if(next)
							{
								var drawPos = position.Edit(RectEdit.AddY(SingleLine), RectEdit.SubtractHeight(SingleLinePlusPadding));

								do
								{
									if(!FoCsEditor.IsPropertyHidden(iterator))
										drawPos = DrawSubProp(iterator, drawPos);
								}
								while(iterator.NextVisible(false));
							}

							if(changeCheckScope.changed)
								serializedObject.ApplyModifiedProperties();
						}
					}
				}
			}

			return foldout;
		}
	}

	internal static class AdvPropDrawerExt
	{
		public static SerializedProperty GetUseLocal(this  SerializedProperty property) => property.FindPropertyRelative(AdvReferencePropertyDrawerBase.USE_LOCAL_STR);
		public static SerializedProperty GetLocal(this     SerializedProperty property) => property.FindPropertyRelative(AdvReferencePropertyDrawerBase.LOCAL_VALUE_STR);
		public static SerializedProperty GetReference(this SerializedProperty property) => property.FindPropertyRelative(AdvReferencePropertyDrawerBase.REFERENCE_STR);
	}
}