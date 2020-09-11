#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: EnumFlagsAttribute.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using UnityEngine;

namespace ForestOfChaos.Unity.Attributes {
    public class EnumFlagsAttribute: PropertyAttribute {
        public readonly bool DrawButtons;

        public EnumFlagsAttribute(bool drawButtons = false) => DrawButtons = drawButtons;
    }
}