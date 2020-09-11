#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: RandomBools.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


namespace ForestOfChaos.Unity.Maths.Random {
    public static class RandomBools {
        public static bool RandomBool() => RandomMaster.Random.NextDouble() >= 0.5;
    }
}