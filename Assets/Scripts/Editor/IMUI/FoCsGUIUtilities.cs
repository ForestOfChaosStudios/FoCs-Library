using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsGUI
	{
		public static class Utilities
		{
			public static float SingleLine            { get; } = EditorGUIUtility.singleLineHeight;
			public static float Padding               { get; } = EditorGUIUtility.standardVerticalSpacing;
			public static float SingleLinePlusPadding { get; } = SingleLine + EditorGUIUtility.standardVerticalSpacing;
			public static float IndentSize            { get; } = EditorGUIUtility.singleLineHeight;

			public static void DrawSplitProgressBar(Rect pos, float value, string name = "", bool isPositiveLeft = true)
			{
				//TODO: add label
				var leftPos = pos;
				leftPos.width *= 0.5f;
				var rightPos = leftPos;
				rightPos.x    += leftPos.width;
				leftPos.x     += leftPos.width;
				leftPos.width *= -1;
				float leftValue  = 0;
				float rightValue = 0;

				if(isPositiveLeft)
				{
					if(value >= 0)
					{
						leftValue  = value;
						rightValue = 0;
					}
					else
					{
						leftValue  = 0;
						rightValue = -value;
					}
				}
				else
				{
					if(value <= 0)
					{
						leftValue  = -value;
						rightValue = 0;
					}
					else
					{
						leftValue  = 0;
						rightValue = value;
					}
				}

				EditorGUI.ProgressBar(leftPos,  +leftValue,  "");
				EditorGUI.ProgressBar(rightPos, +rightValue, "");
			}
		}
	}
}
