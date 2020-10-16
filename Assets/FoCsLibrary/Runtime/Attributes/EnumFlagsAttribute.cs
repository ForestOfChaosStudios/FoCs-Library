#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: EnumFlagsAttribute.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Attributes {
    public class EnumFlagsAttribute: PropertyAttribute {
        public readonly bool DrawButtons;

        public EnumFlagsAttribute(bool drawButtons = false) => DrawButtons = drawButtons;
    }
}