#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: TurnOnDepthBuffer.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using UnityEngine;
using UCamera = UnityEngine.Camera;

namespace ForestOfChaos.Unity.Components.Camera {
    [AddComponentMenu(FoCsStrings.COMPONENTS_CAMERA_FOLDER_ + "Turn On Depth Buffer")]
    public class TurnOnDepthBuffer: FoCsBehaviour {
        public void Start() {
            if (UCamera.main != null)
                UCamera.main.depthTextureMode = DepthTextureMode.Depth;
        }
    }
}