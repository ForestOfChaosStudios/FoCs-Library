#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsWindowAttribute.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:49 AM
#endregion


using System;

namespace ForestOfChaosLibrary.Editor {
    /// <summary>
    ///     This Attribute is used for Windows that can be opened via the FoCs Control Panel
    ///     Requires a method
    ///     "static Init()"
    ///     "override void OnGUI()"
    /// </summary>
    public class FoCsWindowAttribute: Attribute { }
}