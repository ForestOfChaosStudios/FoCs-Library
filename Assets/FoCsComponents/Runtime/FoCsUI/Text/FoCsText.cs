#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Components
//       File: FoCsText.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.FoCsUI.Text {
    public abstract class FoCsText: FoCs2DBehavior {
        public abstract string Text { get; set; }

        public abstract GameObject TextGO { get; }
    }
}