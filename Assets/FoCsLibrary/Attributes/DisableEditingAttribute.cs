#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: DisableEditingAttribute.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Attributes {
    public class DisableEditingAttribute: PropertyAttribute {
        public bool AllowConfirmedEdit;
        public bool CurrentlyEditable;

        public DisableEditingAttribute() {
            AllowConfirmedEdit = false;
            CurrentlyEditable  = false;
        }

        public DisableEditingAttribute(bool allowConfirmedEdit) => AllowConfirmedEdit = allowConfirmedEdit;

        public DisableEditingAttribute(bool allowConfirmedEdit, bool currentlyEditable): this(allowConfirmedEdit) => CurrentlyEditable = currentlyEditable;
    }
}