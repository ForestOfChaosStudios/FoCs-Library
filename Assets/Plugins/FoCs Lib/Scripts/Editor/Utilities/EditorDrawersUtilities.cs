using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.Utilities
{
//TODO REDO THIS WHOLE FILE
	public class EditorDrawersUtilities
	{
		public static void DrawSplitProgressBar(Rect pos, float value, string name = "", bool isPosativeLeft = true)
		{
			var leftPos = pos;
			leftPos.width *= 0.5f;
			var rightPos = leftPos;
			rightPos.x += leftPos.width;
			leftPos.x += leftPos.width;
			leftPos.width *= -1;

			float leftValue = 0;
			float rightValue = 0;

			if(isPosativeLeft)
			{
				if(value >= 0)
				{
					leftValue = value;
					rightValue = 0;
				}
				else
				{
					leftValue = 0;
					rightValue = -value;
				}
			}
			else
			{
				if(value <= 0)
				{
					leftValue = -value;
					rightValue = 0;
				}
				else
				{
					leftValue = 0;
					rightValue = value;
				}
			}

			EditorGUI.ProgressBar(leftPos, +leftValue, "");
			EditorGUI.ProgressBar(rightPos, +rightValue, "");
		}
	}
}