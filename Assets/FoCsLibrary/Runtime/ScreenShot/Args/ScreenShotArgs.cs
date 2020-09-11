#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: ScreenShotArgs.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using UnityEngine;

namespace ForestOfChaos.Unity.ScreenCap {
    public class ScreenShotArgs {
        public int    ResolutionMultiplier = 2;
        public string fileName             = "";
#if UNITY_EDITOR
        public string Path = Application.streamingAssetsPath + @"/../../../";
#else
		public string Path = Application.persistentDataPath + @"/Screenshots";
#endif
        public ScreenShotArgs() { }

        public ScreenShotArgs(ScreenShotArgs other) {
            ResolutionMultiplier = other.ResolutionMultiplier;
            fileName             = other.fileName;
            Path                 = other.Path;
        }

        public static ScreenShotArgs GetUnityCap() {
            var screenShotArgs = new ScreenShotArgs {ResolutionMultiplier = 2};

            return screenShotArgs;
        }

        public virtual string GetFileName() {
            if (string.IsNullOrEmpty(fileName)) {
                var strPath = $"/Screenshot[{DateTime.Now:yyyy-MM-dd(hh-mm-ss)}].png";

                return strPath;
            }

            return $"{fileName}.png";
        }

        public virtual string GetFileNameAndPath() {
            if (string.IsNullOrEmpty(fileName)) {
                var strPath = $"{Path}/Screenshot[{DateTime.Now:yyyy-MM-dd(hh-mm-ss)}].png";

                return strPath;
            }

            return $"{Path}/{fileName}.png";
        }
    }
}