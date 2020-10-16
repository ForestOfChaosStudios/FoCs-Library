#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsWindowAttribute.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:11 PM
#endregion

using System;

namespace ForestOfChaos.Unity.Editor {
    /// <summary>
    ///     This Attribute is used for Windows that can be opened via the FoCs Control Panel
    ///     Requires a method
    ///     "static Init()"
    ///     "override void OnGUI()"
    /// </summary>
    public class FoCsWindowAttribute: Attribute { }
}