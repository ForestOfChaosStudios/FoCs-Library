#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: EnumFlagsAttribute.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:47 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.Attributes {
    public class EnumFlagsAttribute: PropertyAttribute {
        public readonly bool DrawButtons;

        public EnumFlagsAttribute(bool drawButtons = false) => DrawButtons = drawButtons;
    }
}