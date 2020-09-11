#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: TurnOnDepthBuffer.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using UnityEngine;
using UCamera = UnityEngine.Camera;

namespace ForestOfChaosLibrary.Components.Camera {
    [AddComponentMenu(FoCsStrings.COMPONENTS_CAMERA_FOLDER_ + "Turn On Depth Buffer")]
    public class TurnOnDepthBuffer: FoCsBehaviour {
        public void Start() {
            UCamera.main.depthTextureMode = DepthTextureMode.Depth;
        }
    }
}