using UnityEditor;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public static partial class FoCsGUI
	{
		public static float SingleLine
		{
			get { return EditorGUIUtility.singleLineHeight; }
		}

		public static float Padding
		{
			get { return EditorGUIUtility.standardVerticalSpacing; }
		}

		public static float SingleLinePlusPadding
		{
			get { return SingleLine + EditorGUIUtility.standardVerticalSpacing; }
		}

		public static float IndentSize
		{
			get { return EditorGUIUtility.singleLineHeight; }
		}
	}
}
