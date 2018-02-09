using UnityEditor;

namespace ForestOfChaosLib.Editor.Utilities
{
	public static class FoCsEditorUtilities
	{
		public static float SingleLine { get; } = EditorGUIUtility.singleLineHeight;

		public static float Padding { get; } = EditorGUIUtility.standardVerticalSpacing;

		public static float SingleLinePlusPadding { get; } = SingleLine + EditorGUIUtility.standardVerticalSpacing;
		public static float IndentSize { get; } = EditorGUIUtility.singleLineHeight;
	}
}