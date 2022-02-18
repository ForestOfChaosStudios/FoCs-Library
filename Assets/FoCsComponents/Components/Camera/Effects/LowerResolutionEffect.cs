#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: LowerResolutionEffect.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Components.Camera.Effects {
    [ExecuteInEditMode]
    [AddComponentMenu(FoCsStrings.COMPONENTS_CAMERA_FOLDER_ + "Effects/LowerResolutionEffect")]
    public class LowerResolutionEffect: CameraEffectBase {
        [Range(0, 8)]
        public int DownResAmount;

        public FilterMode FilterMode;

        public override void OnRenderImage(RenderTexture src, RenderTexture dst) {
            var width  = src.width  >> DownResAmount;
            var height = src.height >> DownResAmount;
            var outRT  = RenderTexture.GetTemporary(width, height);
            outRT.filterMode = FilterMode;
            Graphics.Blit(src,   outRT);
            Graphics.Blit(outRT, dst);
        }
    }
}