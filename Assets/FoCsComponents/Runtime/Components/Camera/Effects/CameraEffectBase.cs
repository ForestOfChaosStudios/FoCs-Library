#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Components
//       File: CameraEffectBase.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.Components.Camera.Effects {
    public abstract class CameraEffectBase: FoCsBehaviour {
        public abstract void OnRenderImage(RenderTexture src, RenderTexture dst);
    }
}