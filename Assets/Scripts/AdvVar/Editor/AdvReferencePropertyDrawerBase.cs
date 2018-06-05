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
		internal const           string       VARIABLE_STR              = "Variable";
		internal const           string       CONSTANT_VALUE_STR        = "ConstantValue";
		internal const           string       USE_CONSTANT_STR          = "UseConstant";
		internal static readonly GUIContent   localConstantGUIContent   = new GUIContent("Use Local Constant",   "Use Local Constant");
		internal static readonly GUIContent   globalReferenceGUIContent = new GUIContent("Use Global Reference", "Use Global Reference");
		internal static readonly GUIContent[] OPTIONS_ARRAY             = {localConstantGUIContent, globalReferenceGUIContent};

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;
				var UseConstant   = property.FindPropertyRelative(USE_CONSTANT_STR);
				var ConstantValue = property.FindPropertyRelative(CONSTANT_VALUE_STR);
				var Variable      = property.FindPropertyRelative(VARIABLE_STR);

				using(var changeCheckScope = FoCsEditor.Disposables.ChangeCheck())
				{
					UseConstant.boolValue = FoCsGUI.DrawPropertyWithMenu(position.Edit(RectEdit.SetHeight(SingleLinePlusPadding)), UseConstant.boolValue? ConstantValue : Variable, label, OPTIONS_ARRAY, UseConstant.boolValue? 0 : 1).Value ==
					                        0;

					if(changeCheckScope.changed && Variable.objectReferenceValue)
						serializedObject = new SerializedObject(Variable.objectReferenceValue);
				}

				if(Variable.objectReferenceValue == null)
				{
					serializedObject = null;

					return;
				}

				serializedObject = new SerializedObject(Variable.objectReferenceValue);
				var iterator = serializedObject.GetIterator();
				iterator.Next(true);

				if(!UseConstant.boolValue && (Variable.objectReferenceValue != null))
				{
					foldOut = EditorGUI.Foldout(position.Edit(RectEdit.SetHeight(SingleLine), RectEdit.SetWidth(SingleLine)), foldOut, foldoutGUIContent);

					if(foldOut)
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
			}
		}
	}
}
