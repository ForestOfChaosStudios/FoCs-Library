using ForestOfChaosAdvVar;
using ForestOfChaosLibrary.Editor;
using ForestOfChaosLibrary.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosAdvVar.Editor
{
	[CustomEditor(typeof(StringReference))]
	[CanEditMultipleObjects]
	public class StringReferenceEditor: FoCsEditor
	{
		public override void OnInspectorGUI()
		{
			using(Disposables.Indent())
			{
				DoDrawHeader();
				VerifyHandler();

				using(var changeCheckScope = Disposables.ChangeCheck())
				{
					serializedObject.Update();

					foreach(var serializedProperty in serializedObject.Properties())
					{
						if(serializedProperty.name == "storedValue")
							DoTextBox(serializedProperty);
						else
							DrawProperty(serializedProperty);
					}

					if(changeCheckScope.changed)
						serializedObject.ApplyModifiedProperties();
				}

				EditorGUILayout.GetControlRect(false, FoCsGUI.Padding);
			}
		}

		private void DoTextBox(SerializedProperty serializedProperty)
		{
			EditorGUILayout.LabelField("Value");
			serializedProperty.stringValue = EditorGUILayout.TextArea(serializedProperty.stringValue, GUILayout.Height(EditorGUIUtility.singleLineHeight * 5));
		}
	}
}