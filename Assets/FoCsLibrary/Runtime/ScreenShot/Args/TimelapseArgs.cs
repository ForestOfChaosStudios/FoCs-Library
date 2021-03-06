﻿#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: TimelapseArgs.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;

namespace ForestOfChaos.Unity.ScreenCap {
    public class TimelapseArgs: ScreenShotArgs {
        private readonly DateTime Start;
        public           int      LoopCount = 0;

        public TimelapseArgs(ScreenShotArgs args, DateTime start): base(args) => Start = start;

        public override string GetFileName() {
            if (string.IsNullOrEmpty(fileName))
                return $"{Path}/Timelapse[{Start:yyyy-MM-dd(hh-mm-ss)}]Frame_{LoopCount}.png";


            return $"{fileName}_Frame_{LoopCount}.png";
        }

        public override string GetFileNameAndPath() {
            if (string.IsNullOrEmpty(fileName))
                return $"{Path}/Screenshot[{DateTime.Now:yyyy-MM-dd(hh-mm-ss)}].png";

            return $"{Path}/{fileName}_Frame_{LoopCount}.png";
        }
    }
}