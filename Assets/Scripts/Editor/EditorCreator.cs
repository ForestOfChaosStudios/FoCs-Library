using UnityEditor;

namespace ForestOfChaosLib.Editor
{
	public static class EditorCreator
	{
		//[MenuItem("Assets/Create Editor")]
		private static void CreateEditor() { }

		// Note that we pass the same path, and also pass "true" to the second argument.
		//[MenuItem("Assets/Create Editor", true)]
		private static bool CreateEditorValidation() => Selection.activeObject.GetType() == typeof(MonoScript);
	}
}
