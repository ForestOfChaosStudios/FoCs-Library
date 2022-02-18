#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: NoFoldoutAttribute.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Attributes {
    public class NoFoldoutAttribute: PropertyAttribute {
        public readonly bool ShowVariableName;

        public NoFoldoutAttribute(bool showName = true) => ShowVariableName = showName;
    }
}