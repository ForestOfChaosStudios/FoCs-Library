#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: EnumFlagsAttribute.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Attributes {
    public class EnumFlagsAttribute: PropertyAttribute {
        public readonly bool DrawButtons;

        public EnumFlagsAttribute(bool drawButtons = false) => DrawButtons = drawButtons;
    }
}