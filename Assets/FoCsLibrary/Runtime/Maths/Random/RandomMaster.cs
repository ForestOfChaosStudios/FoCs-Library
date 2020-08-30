#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: RandomMaster.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System;
using RAND = System.Random;

namespace ForestOfChaosLibrary.Maths.Random {
    public static class RandomMaster {
        private static RAND p_Random;

        public static RAND Random {
            get => p_Random ?? (p_Random = GetRandomWithNewSeed());
            set => p_Random = value;
        }

        static RandomMaster() {
            GetRandomWithNewSeed();
        }

        public static RAND GetRandomWithNewSeed() => new RAND(DateTime.Now.Millisecond);

        public static RAND GetRandomWithNewSeed(int seed) => new RAND(seed);
    }
}