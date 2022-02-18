#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsGUIUtilities.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEditor;

namespace ForestOfChaos.Unity.Editor {
    // ReSharper disable once MismatchedFileName
    public static partial class FoCsGUI {
        public static float SingleLine => EditorGUIUtility.singleLineHeight;

        public static float Padding => EditorGUIUtility.standardVerticalSpacing;

        public static float SingleLinePlusPadding => SingleLine + EditorGUIUtility.standardVerticalSpacing;

        public static float IndentSize => EditorGUIUtility.singleLineHeight;
    }
}