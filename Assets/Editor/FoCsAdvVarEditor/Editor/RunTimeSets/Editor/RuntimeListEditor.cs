using ForestOfChaosAdvVar.RuntimeRef;
using ForestOfChaosLibrary.Editor;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosAdvVar.Editor.RuntimeRef
{
	[CustomEditor(typeof(RunTimeList), true)]
	public class RuntimeListEditor: FoCsEditor<RunTimeList>
	{
		public override void OnInspectorGUI()
		{
			using(Disposables.HorizontalScope(GUI.skin.box))
				EditorGUILayout.LabelField($"List has {Target.Count} entries.");

			EditorGUILayout.HelpBox("Run Time Lists cause errors in Unity's serialize system.", MessageType.Warning);
		}
	}
}
