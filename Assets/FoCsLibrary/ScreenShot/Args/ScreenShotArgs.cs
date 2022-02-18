#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: ScreenShotArgs.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
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

        public static ScreenShotArgs GetUnityCap() => new ScreenShotArgs { ResolutionMultiplier = 2 };

        public virtual string GetFileName() {
            if (string.IsNullOrEmpty(fileName))
                return $"/Screenshot[{DateTime.Now:yyyy-MM-dd(hh-mm-ss)}].png";

            return $"{fileName}.png";
        }

        public virtual string GetFileNameAndPath() {
            if (string.IsNullOrEmpty(fileName))
                return $"{Path}/Screenshot[{DateTime.Now:yyyy-MM-dd(hh-mm-ss)}].png";

            return $"{Path}/{fileName}.png";
        }
    }
}