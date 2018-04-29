using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Editor
{
	[CustomEditor(typeof(RunTimeList), true)]
	public class RuntimeListEditor: FoCsEditor<RunTimeList>
	{
		public override void OnInspectorGUI()
		{
			using(FoCsEditorDisposables.HorizontalScope(GUI.skin.box))
				EditorGUILayout.LabelField($"List has {Target.Count} entries.");
			EditorGUILayout.HelpBox("Run Time Lists cause errors in Unity's serialize system.", MessageType.Warning);
		}
	}
}