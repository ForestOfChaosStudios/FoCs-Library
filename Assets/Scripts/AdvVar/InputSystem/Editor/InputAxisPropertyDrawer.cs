using System.Linq;
using ForestOfChaosLib.Editor.UnitySettings;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.InputManager;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers
{
	[CustomPropertyDrawer(typeof(InputAxis))]
	public class InputAxisPropertyDrawer: FoCsPropertyDrawer
	{
		internal const           float        LABEL_SIZE                     = 0.5f;
		internal const           float        FIELD_SIZE                     = 1 - LABEL_SIZE;
		internal static readonly GUIContent   enableSyncAxisNamesGUIContent  = new GUIContent("Enable Sync",   "Enable Sync Axis Names");
		internal static readonly GUIContent   disableSyncAxisNamesGUIContent = new GUIContent("Disable Sync",  "Disable Sync Axis Names");
		internal static readonly GUIContent   ProgressBarContent             = new GUIContent("Current Value", "Shows what the current value of the Axis is.");
		internal static readonly GUIContent   PopupContent                   = new GUIContent("Input Axis",    "Chose from the available Unity Input Axis values.");
		internal static readonly GUIContent[] OPTIONS_ARRAY                  = {enableSyncAxisNamesGUIContent, disableSyncAxisNamesGUIContent};
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => SingleLinePlusPadding * 4;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;

				if(EditorGUI.indentLevel <= 1)
					position = position.Edit(RectEdit.ChangeX(16f));

				var axisProp       = property.FindPropertyRelative("Axis");
				var ValueInverted  = new EditorEntry("Invert Result",                                                    property.FindPropertyRelative("ValueInverted"));
				var OnlyButton     = new EditorEntry("Only Button",                                                      property.FindPropertyRelative("OnlyButton"));
				var UseSmoothInput = new EditorEntry("Use Smooth Input",                                                 property.FindPropertyRelative("UseSmoothInput"));
				var Axis           = new EditorEntry($"Axis: {axisProp.stringValue}",                                    axisProp);
				var m_Value        = new EditorEntry($"{(ValueInverted.Property.boolValue? "Non Inverted " : "")}Value", property.FindPropertyRelative("value"));
				var m_DeadZone     = new EditorEntry("DeadZone",                                                         property.FindPropertyRelative("deadZone"));

				using(FoCsEditor.Disposables.Indent(-1))
				{
					using(var verticalScope = FoCsEditor.Disposables.RectVerticalScope(4, position))
					{
						using(FoCsEditor.Disposables.LabelFieldSetWidth((verticalScope.FirstRect.width * LABEL_SIZE) * LABEL_SIZE))
						{
							using(var horizontalScope = FoCsEditor.Disposables.RectHorizontalScope(2, verticalScope.GetNext()))
							{
								Axis.Draw(horizontalScope.GetNext(RectEdit.SetHeight(SingleLine)));
								var array = ReadInputManager.GetAxisNames();
								var num   = -1;

								if(array.Contains(Axis.Property.stringValue))
									num = array.ToList().IndexOf(Axis.Property.stringValue);

								using(var cc = FoCsEditor.Disposables.ChangeCheck())
								{
									using(FoCsEditor.Disposables.LabelFieldSetWidth((horizontalScope.FirstRect.width * LABEL_SIZE) - SingleLine))
									{
										var index = EditorGUI.Popup(horizontalScope.GetNext(RectEdit.SetHeight(SingleLine), RectEdit.ChangeX(SingleLine)), PopupContent, num, array.Select(a => new GUIContent(a)).ToArray());

										if(cc.changed && array.InRange(index))
											Axis.Property.stringValue = array[index];
									}
								}
							}

							using(var horizontalScope = FoCsEditor.Disposables.RectHorizontalScope(2, verticalScope.GetNext()))
							{
								ProgressBar(horizontalScope.GetNext(RectEdit.SetHeight(SingleLine)), m_Value);

								using(FoCsEditor.Disposables.LabelFieldSetWidth((horizontalScope.FirstRect.width * LABEL_SIZE) - SingleLine))
									m_Value.Draw(horizontalScope.GetNext(RectEdit.SetHeight(SingleLine), RectEdit.ChangeX(SingleLine)));
							}

							using(var horizontalScope = FoCsEditor.Disposables.RectHorizontalScope(2, verticalScope.GetNext()))
							{
								m_DeadZone.Draw(horizontalScope.GetNext(RectEdit.SetHeight(SingleLine)));

								using(FoCsEditor.Disposables.LabelFieldSetWidth((horizontalScope.FirstRect.width * LABEL_SIZE) - SingleLine))
									ValueInverted.Draw(horizontalScope.GetNext(RectEdit.SetHeight(SingleLine), RectEdit.ChangeX(SingleLine)));
							}

							using(var horizontalScope = FoCsEditor.Disposables.RectHorizontalScope(2, verticalScope.GetNext()))
							{
								OnlyButton.Draw(horizontalScope.GetNext(RectEdit.SetHeight(SingleLine)));

								using(FoCsEditor.Disposables.LabelFieldSetWidth((horizontalScope.FirstRect.width * LABEL_SIZE) - SingleLine))
									UseSmoothInput.Draw(horizontalScope.GetNext(RectEdit.SetHeight(SingleLine), RectEdit.ChangeX(SingleLine)));
							}
						}
					}
				}
			}
		}

		private static void ProgressBar(Rect pos, EditorEntry m_Value)
		{
			using(var horizontalScope = FoCsEditor.Disposables.RectHorizontalScope(2, pos))
			{
				EditorGUI.LabelField(horizontalScope.GetNext(), ProgressBarContent);
				var value = (m_Value.Property.floatValue + 1) * 0.5f;
				FoCsGUI.ProgressBar(horizontalScope.GetNext(), value);
			}
		}
	}
}
