#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: TimelapseTab.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
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
            var args = new ScreenShotArgs { fileName = Owner.filename, Path = Owner.path, ResolutionMultiplier = Owner.scale };
            Timelapse?.Stop();
            Timelapse = new Timelapse(waitTime, times, args);
        }
    }
}