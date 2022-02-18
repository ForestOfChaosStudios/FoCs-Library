#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: GetSetterAttribute.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Attributes {
    public class GetSetterAttribute: PropertyAttribute {
        public readonly string name;
        public          bool   CallSetter = true;
        public          bool   dirty      = false;

        public GetSetterAttribute(string name) => this.name = name;
    }
}