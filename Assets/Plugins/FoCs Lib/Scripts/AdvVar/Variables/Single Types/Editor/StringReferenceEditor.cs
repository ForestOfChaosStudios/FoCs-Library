using ForestOfChaosLib.AdvVar;
using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.ImGUI;
using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StringReference))]
[CanEditMultipleObjects]
public class StringReferenceEditor: FoCsEditor
{
	public override void OnInspectorGUI()
	{
		using(EditorDisposables.Indent())
		{
			DoDrawHeader();
			using(var changeCheckScope = EditorDisposables.ChangeCheck())
			{
				var cachedGuiColor = GUI.color;
				serializedObject.Update();

				foreach(var serializedProperty in serializedObject.Properties())
				{
					GUI.color = cachedGuiColor;
					if(serializedProperty.name == "_value")
					{
						DoTextBox(serializedProperty);
					}
					else
					{
						HandleProperty(serializedProperty);
					}
				}

				if(changeCheckScope.changed)
				{
					serializedObject.ApplyModifiedProperties();
				}
			}

			EditorGUILayout.GetControlRect(false, FoCsEditorUtilities.Padding);

			DrawGUI();
		}
	}

	private void DoTextBox(SerializedProperty serializedProperty)
	{
		EditorGUILayout.LabelField("Value");
		serializedProperty.stringValue = EditorGUILayout.TextArea(serializedProperty.stringValue,GUILayout.Height(EditorGUIUtility.singleLineHeight * 5));
	}
}
