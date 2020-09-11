#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: ScreenCap.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.ScreenCap {
    public static class ScreenCap {
        public static void TakeScreenShot() {
            TakeScreenShot(ScreenShotArgs.GetUnityCap());
        }

        public static void TakeScreenShot(ScreenShotArgs screenShotArgs) {
            ScreenCapture.CaptureScreenshot(screenShotArgs.GetFileNameAndPath(), screenShotArgs.ResolutionMultiplier);
        }
    }
}