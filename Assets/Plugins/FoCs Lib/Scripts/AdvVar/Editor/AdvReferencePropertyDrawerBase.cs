using ForestOfChaosLib.AdvVar.Base;
using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.ImGUI;
using ForestOfChaosLib.Editor.PropertyDrawers.Types;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.UnityScriptsExtensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Editor
{
	[CustomPropertyDrawer(typeof(AdvVariable), true)]
	public class AdvReferencePropertyDrawerBase: ObjectReferenceDrawer
	{
		internal const float WIDTH = 16f;
		internal const string VARIABLE_STR = "Variable";
		internal const string CONSTANT_VALUE_STR = "ConstantValue";
		internal const string USE_CONSTANT_STR = "UseConstant";

		internal static readonly GUIContent localConstantGUIContent = new GUIContent("Use Local Constant", "Use Local Constant");
		internal static readonly GUIContent globalReferenceGUIContent = new GUIContent("Use Global Reference", "Use Global Reference");

		internal static readonly GUIContent[] OPTIONS_ARRAY =
		{
			localConstantGUIContent,
			globalReferenceGUIContent
		};

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var UseConstant = property.FindPropertyRelative(USE_CONSTANT_STR);
			var ConstantValue = property.FindPropertyRelative(CONSTANT_VALUE_STR);
			var Variable = property.FindPropertyRelative(VARIABLE_STR);

			using(var changeCheckScope = EditorDisposables.ChangeCheck())
			{
				UseConstant.boolValue = FoCsGUI.DrawPropertyWithMenu(position.SetHeight(SingleLinePlusPadding),
																	 UseConstant.boolValue?
																		 ConstantValue :
																		 Variable,
																	 label,
																	 OPTIONS_ARRAY,
																	 UseConstant.boolValue?
																		 0 :
																		 1) ==
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
				foldOut = EditorGUI.Foldout(position.SetHeight(SingleLine).SetWidth(SingleLine), foldOut, foldoutGUIContent);
				if(foldOut)
				{
					if(Event.current.type == EventType.repaint)
						GUI.skin.box.Draw(position.ChangeY(-1).MoveWidth(4).MoveHeight(2).ChangeX(-1), false, false, false, false);

					using(EditorDisposables.Indent())
					{
						using(var changeCheckScope = EditorDisposables.ChangeCheck())
						{
							var next = iterator.NextVisible(true);

							if(FoCsEditor.IsDefaultScriptProperty(iterator))
								iterator.NextVisible(true);
							if(next)
							{
								var drawPos = position.MoveY(SingleLinePlusPadding).MoveHeight(-SingleLinePlusPadding);
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