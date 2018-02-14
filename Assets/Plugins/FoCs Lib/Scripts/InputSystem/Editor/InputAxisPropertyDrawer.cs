using System.Linq;
using ForestOfChaosLib.CSharpExtensions;
using ForestOfChaosLib.Editor.UnitySettings;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.InputManager;
using ForestOfChaosLib.UnityScriptsExtensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers
{
	[CustomPropertyDrawer(typeof(InputAxis))]
	public class InputAxisPropertyDrawer: FoCsPropertyDrawer
	{
		internal const float LABEL_SIZE = 0.5f;
		internal const float FIELD_SIZE = 1 - LABEL_SIZE;
		internal static readonly GUIContent enableSyncAxisNamesGUIContent = new GUIContent("Enable Sync", "Enable Sync Axis Names");
		internal static readonly GUIContent disableSyncAxisNamesGUIContent = new GUIContent("Disable Sync", "Disable Sync Axis Names");

		internal static readonly GUIContent ProgressBarContent = new GUIContent("Current Value", "Shows what the current value of the Axis is.");
		internal static readonly GUIContent PopupContent = new GUIContent("Input Axis", "Chose from the available Unity Input Axis values.");

		internal static readonly GUIContent[] OPTIONS_ARRAY =
		{
			enableSyncAxisNamesGUIContent,
			disableSyncAxisNamesGUIContent
		};

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => EditorGUIUtility.singleLineHeight * 3;

		public override void OnGUI(Rect wholePosition, SerializedProperty property, GUIContent label)
		{
			if(EditorGUI.indentLevel <= 1)
				wholePosition = wholePosition.ChangeX(16f);


			var axisProp = property.FindPropertyRelative("Axis");


			var ValueInverted = new EditorEntry("Invert Result", property.FindPropertyRelative("ValueInverted"));
			var OnlyButton = new EditorEntry("Only Button", property.FindPropertyRelative("OnlyButton"));
			var Axis = new EditorEntry($"Axis: {axisProp.stringValue}", axisProp);
			var m_Value = new EditorEntry($"{(ValueInverted.Property.boolValue? "Non Inverted " : "")}Value", property.FindPropertyRelative("m_Value"));
			var m_DeadZone = new EditorEntry("DeadZone", property.FindPropertyRelative("m_DeadZone"));

			using(EditorDisposables.Indent(-1))
			{
				using(var verticalScope = EditorDisposables.RectVerticalScope(3, wholePosition))
				{
					using(var horizontalScope = EditorDisposables.RectHorizontalScope(2, verticalScope.GetNext()))
					{
						using(EditorDisposables.LabelFieldSetWidth(horizontalScope.FirstRect.width * LABEL_SIZE))
						{
							Axis.Draw(horizontalScope.GetNext());
							var array = ReadInputManager.GetAxisNames();
							var num = -1;
							if(array.Contains(Axis.Property.stringValue))
								num = array.ToList().IndexOf(Axis.Property.stringValue);
							using(var cc = EditorDisposables.ChangeCheck())
							{
								var index = EditorGUI.Popup(horizontalScope.GetNext(), PopupContent, num, array.Select(a => new GUIContent(a)).ToArray());
								if(cc.changed && array.InRange(index))
									Axis.Property.stringValue = array[index];
							}
						}
					}
					using(var horizontalScope = EditorDisposables.RectHorizontalScope(2, verticalScope.GetNext()))
					{
						using(EditorDisposables.LabelFieldSetWidth(horizontalScope.FirstRect.width * LABEL_SIZE))
						{
							ProgressBar(horizontalScope.GetNext(), m_Value);
							m_Value.Draw(horizontalScope.GetNext());
						}
					}
					using(var horizontalScope = EditorDisposables.RectHorizontalScope(2, verticalScope.GetNext()))
					{
						using(EditorDisposables.LabelFieldSetWidth(horizontalScope.FirstRect.width * LABEL_SIZE))
						{
							m_DeadZone.Draw(horizontalScope.GetNext());

							using(var horizontalScope2 = EditorDisposables.RectHorizontalScope(2, horizontalScope.GetNext()))
							{
								using(EditorDisposables.LabelFieldSetWidth(horizontalScope2.FirstRect.width * LABEL_SIZE))
								{
									ValueInverted.Draw(horizontalScope2.GetNext());
									OnlyButton.Draw(horizontalScope2.GetNext());
								}
							}
						}
					}
				}
			}
		}

		private static void ProgressBar(Rect pos, EditorEntry m_Value)
		{
			using(var horizontalScope = EditorDisposables.RectHorizontalScope(2, pos))
			{
				EditorGUI.LabelField(horizontalScope.GetNext(), ProgressBarContent);
				FoCsEditorUtilities.DrawSplitProgressBar(horizontalScope.GetNext(), m_Value.Property.floatValue);
			}
		}
	}
}