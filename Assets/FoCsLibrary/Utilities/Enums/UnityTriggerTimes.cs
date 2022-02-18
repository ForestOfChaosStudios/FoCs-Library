#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: UnityTriggerTimes.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;

namespace ForestOfChaos.Unity.Utilities.Enums {
    [Flags]
    public enum UnityTriggerTimes {
        Start    = 1 << 0,
        OnEnable = 1 << 1,
        Awake    = 1 << 2,
        None     = 1 << 3
    }
}