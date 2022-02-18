#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsWindowAttribute.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
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