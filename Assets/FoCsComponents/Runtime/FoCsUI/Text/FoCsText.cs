#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: FoCsText.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.FoCsUI.Text {
    public abstract class FoCsText: FoCs2DBehavior {
        public abstract string Text { get; set; }

        public abstract GameObject TextGO { get; }
    }
}