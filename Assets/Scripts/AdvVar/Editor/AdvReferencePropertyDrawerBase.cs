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
			DoDraw(position, property, ref foldout, ref label);
		}

		public static void DoDraw(Rect position, SerializedProperty property, ref bool foldout, ref GUIContent label)
		{
			property.serializedObject.Update();
			var useLocal        = property.FindPropertyRelative(USE_LOCAL_STR);
			var localValue      = property.FindPropertyRelative(LOCAL_VALUE_STR);
			var globalReference = property.FindPropertyRelative(REFERENCE_STR);

			using(var cc = FoCsEditor.Disposables.ChangeCheck())
			{
				using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
				{
					label = propScope.content;

					useLocal.boolValue = FoCsGUI.DrawPropertyWithMenu(position.Edit(RectEdit.SetHeight(SingleLinePlusPadding)), useLocal.boolValue? localValue : globalReference, label, OPTIONS_ARRAY, useLocal.boolValue? 0 : 1).Value == 0;
				}

				if(cc.changed)
				{
					property.serializedObject.ApplyModifiedProperties();
				}
			}

			if(globalReference.objectReferenceValue)
				DrawReferenceObjectsData(position, ref foldout, ref useLocal, ref globalReference);
		}

		public static void DoDraw(Rect position, SerializedProperty property, ref bool foldout, ref GUIContent label, ref SerializedObject serializedObject, Action<Rect> drawLocalValue)
		{
			var useLocal        = property.FindPropertyRelative(USE_LOCAL_STR);
			var localValue      = property.FindPropertyRelative(LOCAL_VALUE_STR);
			var globalReference = property.FindPropertyRelative(REFERENCE_STR);

			using(var cc = FoCsEditor.Disposables.ChangeCheck())
			{
				using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
				{
					label = propScope.content;

					if(useLocal.boolValue)
					{
						if(drawLocalValue == null)
							useLocal.boolValue = FoCsGUI.DrawPropertyWithMenu(position.Edit(RectEdit.SetHeight(SingleLinePlusPadding)), localValue, label, OPTIONS_ARRAY, useLocal.boolValue? 0 : 1).Value == 0;
						else
							useLocal.boolValue = FoCsGUI.DrawActionWithMenu(position.Edit(RectEdit.SetHeight(SingleLinePlusPadding)), drawLocalValue, label, OPTIONS_ARRAY, useLocal.boolValue? 0 : 1).Value == 0;
					}
					else
						useLocal.boolValue = FoCsGUI.DrawPropertyWithMenu(position.Edit(RectEdit.SetHeight(SingleLinePlusPadding)), globalReference, label, OPTIONS_ARRAY, useLocal.boolValue? 0 : 1).Value == 0;
				}

				if(cc.changed)
				{
					property.serializedObject.ApplyModifiedProperties();
				}
			}

			if(globalReference.objectReferenceValue)
				DrawReferenceObjectsData(position, ref foldout, ref useLocal, ref globalReference);
		}


		private static SerializedObject DrawReferenceObjectsData(Rect position, ref bool foldout, ref SerializedProperty useLocal, ref SerializedProperty globalReference)
		{
			var serializedObject = new SerializedObject(globalReference.objectReferenceValue);
			var iterator         = serializedObject.GetIterator();
			iterator.Next(true);

			if(!useLocal.boolValue && (globalReference.objectReferenceValue != null))
			{
				foldout = EditorGUI.Foldout(position.Edit(RectEdit.SetHeight(SingleLine), RectEdit.SetWidth(SingleLine)), foldout, foldoutGUIContent);

				if(foldout)
				{
					DrawSurroundingBox(position);

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

			return serializedObject;
		}
	}
}
