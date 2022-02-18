#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: FoCsImage.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEngine;
using UImage = UnityEngine.UI.Image;

namespace ForestOfChaos.Unity.FoCsUI.Image {
    public abstract class FoCsImage: FoCs2DBehavior {
        public UImage Image;
        public Action onMouseClick;

        public abstract string Text { get; set; }

        public abstract GameObject TextGO { get; }
    }
}