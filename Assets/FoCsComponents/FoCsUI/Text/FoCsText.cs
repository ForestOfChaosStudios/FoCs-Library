#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: FoCsText.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.FoCsUI.Text {
    public abstract class FoCsText: FoCs2DBehavior {
        public abstract string Text { get; set; }

        public abstract GameObject TextGO { get; }
    }
}