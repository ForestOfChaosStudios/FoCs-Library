#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: UnityGUIExtensions.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Extensions {
    public static class UnityGUIExtensions {
        public static void DrawChecked(this GUIStyle style, Rect pos, bool isHover = false, bool isActive = false, bool on = false, bool hasKeyboardFocus = false) {
            if (Event.current.type == EventType.Repaint)
                style.Draw(pos, isHover, isActive, on, hasKeyboardFocus);
        }
    }
}