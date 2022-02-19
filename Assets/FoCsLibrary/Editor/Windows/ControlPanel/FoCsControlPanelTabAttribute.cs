#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsControlPanelTabAttribute.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;

namespace ForestOfChaos.Unity.Editor.Windows {
    // ReSharper disable once MismatchedFileName
    public partial class FoCsControlPanel {
        /// <summary>
        ///     This Attribute is used for Tabs that show in the FoCs Control Panel
        ///     Requires a method
        ///     static "Init()"
        ///     public static void DrawGUI(FoCsControlPanel owner)
        /// </summary>
        public class FoCsControlPanelTabAttribute: Attribute { }
    }
}