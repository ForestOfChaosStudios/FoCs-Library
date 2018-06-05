using UnityEditor;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsGUI
	{
		public static float SingleLine            { get; } = EditorGUIUtility.singleLineHeight;
		public static float Padding               { get; } = EditorGUIUtility.standardVerticalSpacing;
		public static float SingleLinePlusPadding { get; } = SingleLine + EditorGUIUtility.standardVerticalSpacing;
		public static float IndentSize            { get; } = EditorGUIUtility.singleLineHeight;
	}
}
