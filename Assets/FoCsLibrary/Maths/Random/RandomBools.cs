#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: RandomBools.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

namespace ForestOfChaos.Unity.Maths.Random {
    public static class RandomBools {
        public static bool RandomBool() => RandomMaster.Random.NextDouble() >= 0.5;
    }
}