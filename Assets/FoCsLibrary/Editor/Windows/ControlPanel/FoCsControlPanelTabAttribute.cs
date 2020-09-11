#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsControlPanelTabAttribute.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


using System;

namespace ForestOfChaos.Unity.Editor {
    // ReSharper disable once MismatchedFileName
    public class FoCsControlPanel {
        /// <summary>
        ///     This Attribute is used for Tabs that show in the FoCs Control Panel
        ///     Requires a method
        ///     static "Init()"
        ///     public static void DrawGUI(FoCsControlPanel owner)
        /// </summary>
        public class FoCsControlPanelTabAttribute: Attribute { }
    }
}