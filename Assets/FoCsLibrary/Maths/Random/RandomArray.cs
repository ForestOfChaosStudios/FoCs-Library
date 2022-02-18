#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: RandomArray.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

namespace ForestOfChaos.Unity.Maths.Random {
    public static class RandomArray {
        public static T[] ShuffleArray<T>(this T[] array) => ShuffleArray(array, RandomMaster.Random);

        public static T[] ShuffleArray<T>(this T[] array, System.Random rng) {
            for (var i = array.Length - 1; i > 0; i--) {
                var index = rng.Next(i + 1);
                // Simple swap
                var a = array[index];
                array[index] = array[i];
                array[i]     = a;
            }

            return array;
        }

        public static T[] ShuffleArrayUnity<T>(this T[] array) {
            for (var i = array.Length - 1; i > 0; i--) {
                var index = UnityEngine.Random.Range(0, i + 1);
                var a     = array[index];
                array[index] = array[i];
                array[i]     = a;
            }

            return array;
        }
    }
}