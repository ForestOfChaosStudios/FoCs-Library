#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsControlPanelTabAttribute.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:49 AM
#endregion


using System;

namespace ForestOfChaosLibrary.Editor {
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