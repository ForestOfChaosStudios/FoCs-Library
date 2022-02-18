#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: ScreenCap.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.ScreenCap {
    public static class ScreenCap {
        public static void TakeScreenShot() => TakeScreenShot(ScreenShotArgs.GetUnityCap());

        public static void TakeScreenShot(ScreenShotArgs screenShotArgs) =>
                ScreenCapture.CaptureScreenshot(screenShotArgs.GetFileNameAndPath(), screenShotArgs.ResolutionMultiplier);
    }
}