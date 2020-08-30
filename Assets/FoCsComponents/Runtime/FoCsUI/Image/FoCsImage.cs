#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Components
//       File: FoCsImage.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System;
using UnityEngine;
using UImage = UnityEngine.UI.Image;

namespace ForestOfChaosLibrary.FoCsUI.Image {
    public abstract class FoCsImage: FoCs2DBehavior {
        public UImage Image;
        public Action onMouseClick;

        public abstract string Text { get; set; }

        public abstract GameObject TextGO { get; }
    }
}