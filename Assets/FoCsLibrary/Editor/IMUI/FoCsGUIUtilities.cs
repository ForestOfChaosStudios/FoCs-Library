using UnityEditor;

namespace ForestOfChaosLibrary.Editor
{
	// ReSharper disable once MismatchedFileName
	public static partial class FoCsGUI
	{
		public static float SingleLine            => EditorGUIUtility.singleLineHeight;
		public static float Padding               => EditorGUIUtility.standardVerticalSpacing;
		public static float SingleLinePlusPadding => SingleLine + EditorGUIUtility.standardVerticalSpacing;
		public static float IndentSize            => EditorGUIUtility.singleLineHeight;
	}
}
