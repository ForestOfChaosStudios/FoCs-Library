using UnityEngine;

namespace ForestOfChaosLibrary.Extensions
{
	public static class UnityGUIExtensions
	{
		public static void DrawChecked(this GUIStyle style, Rect pos, bool isHover = false, bool isActive = false, bool on = false, bool hasKeyboardFocus = false)
		{
			if(Event.current.type == EventType.Repaint)
				style.Draw(pos, isHover, isActive, on, hasKeyboardFocus);
		}
	}
}
