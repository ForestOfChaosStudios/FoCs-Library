#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: CameraEffectBase.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Components.Camera.Effects {
    public abstract class CameraEffectBase: FoCsBehaviour {
        public abstract void OnRenderImage(RenderTexture src, RenderTexture dst);
    }
}