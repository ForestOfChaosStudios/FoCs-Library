#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: NoFoldoutAttribute.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Attributes {
    public class NoFoldoutAttribute: PropertyAttribute {
        public readonly bool ShowVariableName;

        public NoFoldoutAttribute(bool showName = true) => ShowVariableName = showName;
    }
}