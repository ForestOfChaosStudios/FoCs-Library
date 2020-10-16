#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: TimelapseTab.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:10 PM
#endregion

using ForestOfChaos.Unity.ScreenCap;
using UnityEditor;

namespace ForestOfChaos.Unity.Editor.ScreenCap {
    public class TimelapseTab: ScreenshotTab {
        private Timelapse Timelapse;
        public  int       times    = 20;
        public  float     waitTime = 1;

        public override string TabName => "Timelapse";

        public override void DrawOtherVars() {
            times    = EditorGUILayout.IntField("How many Captures", times);
            waitTime = EditorGUILayout.FloatField("Time Between Captures", waitTime);
        }

        protected override void TakeScreenShot() {
            var args = new ScreenShotArgs {fileName = Owner.filename, Path = Owner.path, ResolutionMultiplier = Owner.scale};
            Timelapse?.Stop();
            Timelapse = new Timelapse(waitTime, times, args);
        }
    }
}