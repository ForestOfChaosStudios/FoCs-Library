#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: CameraEffectBase.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Components.Camera.Effects {
    public abstract class CameraEffectBase: FoCsBehaviour {
        public abstract void OnRenderImage(RenderTexture src, RenderTexture dst);
    }
}