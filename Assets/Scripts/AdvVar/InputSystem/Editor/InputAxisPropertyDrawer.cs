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
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if(ShowLabel(label.text))
				return SingleLinePlusPadding * 5;
			return SingleLinePlusPadding * 4;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var showLabel = ShowLabel(label.text);

			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;

				if(EditorGUI.indentLevel <= 1)
					position = position.Edit(RectEdit.ChangeX(16f));

				var axisProp       = property.FindPropertyRelative("Axis");
				var ValueInverted  = new EditorEntry("Invert Result",                                                    property.FindPropertyRelative("ValueInverted"));
				var OnlyButtonEvents = new EditorEntry("Only Button Events",                                                      property.FindPropertyRelative("OnlyButtonEvents"));
				var UseSmoothInput = new EditorEntry("Use Smooth Input",                                                 property.FindPropertyRelative("UseSmoothInput"));
				var Axis           = new EditorEntry($"Axis: {axisProp.stringValue}",                                    axisProp);
				var value          = new EditorEntry($"{(ValueInverted.Property.boolValue? "Non Inverted " : "")}Value", property.FindPropertyRelative("value"));
				var deadZone       = new EditorEntry("DeadZone",                                                         property.FindPropertyRelative("deadZone"));

				using(var horizontalScope = FoCsEditor.Disposables.RectHorizontalScope(2, position))
				{
					using(FoCsEditor.Disposables.LabelFieldSetWidth((horizontalScope.FirstRect.width * LABEL_SIZE)))
					{
						using(var verticalScope = FoCsEditor.Disposables.RectVerticalScope(showLabel? 5 : 4, horizontalScope.GetNext()))
						{
							if(showLabel)
								FoCsGUI.Label(verticalScope.GetNext(RectEdit.SetHeight(SingleLine)), label);

							DrawDropDown(Axis, verticalScope.GetNext(RectEdit.SetHeight(SingleLine)));
							ProgressBar(verticalScope.GetNext(RectEdit.SetHeight(SingleLine)), value);
							deadZone.Draw(verticalScope.GetNext(RectEdit.SetHeight(SingleLine)));
							OnlyButtonEvents.Draw(verticalScope.GetNext(RectEdit.SetHeight(SingleLine)));
						}

						using(var verticalScope = FoCsEditor.Disposables.RectVerticalScope(showLabel? 5 : 4, horizontalScope.GetNext(RectEdit.ChangeX(SingleLine))))
						{
							if(showLabel)
								verticalScope.GetNext();

							Axis.Draw(verticalScope.GetNext(RectEdit.SetHeight(SingleLine)));
							value.Draw(verticalScope.GetNext(RectEdit.SetHeight(SingleLine)));
							ValueInverted.Draw(verticalScope.GetNext(RectEdit.SetHeight(SingleLine)));
							UseSmoothInput.Draw(verticalScope.GetNext(RectEdit.SetHeight(SingleLine)));
						}
					}
				}
			}
		}

		public static bool ShowLabel(string label)
		{
			if(label == "Value")
				return false;
			return !label.Contains("element");
		}
		private static void DrawDropDown(SerializedProperty Axis, Rect pos)
		{
			var array = ReadInputManager.GetAxisNames();
			var num   = -1;

			if(array.Contains(Axis.stringValue))
				num = array.ToList().IndexOf(Axis.stringValue);

			using(var cc = FoCsEditor.Disposables.ChangeCheck())
			{
				var index = EditorGUI.Popup(pos, PopupContent, num, array.Select(a => new GUIContent(a)).ToArray());

				if(cc.changed && array.InRange(index))
					Axis.stringValue = array[index];
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
