#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: RandomList.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System.Collections.Generic;

namespace ForestOfChaosLibrary.Maths.Random {
    public static class RandomList {
        public static void ShuffleList<T>(this IList<T> list) {
            ShuffleList(list, RandomMaster.Random);
        }

        public static void ShuffleList<T>(this IList<T> list, System.Random rng) {
            var n = list.Count;

            while (n > 1) {
                n--;
                var k     = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void ShuffleListUnity<T>(this IList<T> list) {
            var n = list.Count;

            while (n > 1) {
                n--;
                var k     = UnityEngine.Random.Range(0, n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}