using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Editor
{
	[CustomEditor(typeof(RunTimeRef), true)]
	public class RuntimeRefEditor: FoCsEditor<RunTimeRef>
	{
		public override void OnInspectorGUI()
		{
			using(EditorDisposables.HorizontalScope(GUI.skin.box))
				EditorGUILayout.LabelField($"Has reference: {Target.HasReference}");
		}
	}
}