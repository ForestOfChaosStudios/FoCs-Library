#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: RegexStringAttribute.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Attributes {
    public class RegexStringAttribute: PropertyAttribute {
        public readonly string helpMessage;
        public readonly string pattern;

        public RegexStringAttribute(string _pattern, string _helpMessage) {
            pattern     = _pattern;
            helpMessage = _helpMessage;
        }
    }
}