#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: ConditionalHideAttribute.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using UnityEngine;

namespace ForestOfChaos.Unity.Attributes {
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct)]
    public class ConditionalHideAttribute: PropertyAttribute {
        /// <summary>
        ///     The name of the bool field that will be in control
        /// </summary>
        public string ConditionalSourceField;

        /// <summary>
        ///     TRUE = Hide in inspector / FALSE = Disable in inspector
        /// </summary>
        public bool HideInInspector;

        public ConditionalHideAttribute(string conditionalSourceField) {
            ConditionalSourceField = conditionalSourceField;
            HideInInspector        = false;
        }

        public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector) {
            ConditionalSourceField = conditionalSourceField;
            HideInInspector        = hideInInspector;
        }
    }
}