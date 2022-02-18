#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: RandomMaster.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using RAND = System.Random;

namespace ForestOfChaos.Unity.Maths.Random {
    public static class RandomMaster {
        private static RAND p_Random;

        public static RAND Random {
            get => p_Random ?? (p_Random = GetRandomWithNewSeed());
            set => p_Random = value;
        }

        static RandomMaster() => GetRandomWithNewSeed();

        public static RAND GetRandomWithNewSeed() => new RAND(DateTime.Now.Millisecond);

        public static RAND GetRandomWithNewSeed(int seed) => new RAND(seed);
    }
}