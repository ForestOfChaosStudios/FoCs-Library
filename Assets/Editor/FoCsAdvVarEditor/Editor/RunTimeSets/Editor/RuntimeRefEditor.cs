using ForestOfChaosAdvVar.RuntimeRef;
using ForestOfChaosLibraryEditor;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosAdvVarEditor.RuntimeRef
{
	[CustomEditor(typeof(RunTimeRef), true)]
	public class RuntimeRefEditor: FoCsEditor<RunTimeRef>
	{
		public override void OnInspectorGUI()
		{
			using(Disposables.HorizontalScope(GUI.skin.box))
				EditorGUILayout.LabelField($"Has reference: {Target.HasReference}");
		}
	}
}
