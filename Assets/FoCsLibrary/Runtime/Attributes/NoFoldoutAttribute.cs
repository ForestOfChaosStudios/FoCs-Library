#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: NoFoldoutAttribute.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.Attributes {
    public class NoFoldoutAttribute: PropertyAttribute {
        public readonly bool ShowVariableName;

        public NoFoldoutAttribute(bool showName = true) => ShowVariableName = showName;
    }
}