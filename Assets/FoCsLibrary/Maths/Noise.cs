#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: Noise.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.Maths.Random;
using RAND = UnityEngine.Random;

namespace ForestOfChaos.Unity.Maths {
    public static class Noise {

        /// <summary>
        ///     Randomize value by amount.
        /// </summary>
        /// <param name="value">Value to Randomize.</param>
        /// <param name="amount">Amount to Randomize.</param>
        /// <returns>Value +/- Amount</returns>
        public static int ReturnNoise(int value, int amount) => RandomMaster.Random.Next(value - amount, value + amount);

        /// <summary>
        ///     Randomize value by amount.
        /// </summary>
        /// <param name="value">Value to Randomize.</param>
        /// <param name="amount">Amount to Randomize.</param>
        /// <returns>Value +/- Amount</returns>
        public static float ReturnNoise(float value, float amount) => RAND.Range(value - amount, value + amount);
    }
}