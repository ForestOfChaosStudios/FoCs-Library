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
        public readonly bool   ShowVariableName;
        public readonly bool   IndentChildItems;
        public readonly string ArrayElementNameReplacement;

        public NoFoldoutAttribute(bool showName, bool indentChildItems = true, string arrayElementNameReplacement = null) {
            ShowVariableName            = showName;
            IndentChildItems            = indentChildItems;
            ArrayElementNameReplacement = arrayElementNameReplacement;
        }

        public NoFoldoutAttribute():this(true,true,null) {
        }

        public NoFoldoutAttribute(string arrayElementNameReplacement) : this(true, true, arrayElementNameReplacement) {
        }
    }
}