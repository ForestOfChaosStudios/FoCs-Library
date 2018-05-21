using ForestOfChaosLib.Maths.Random;
using RAND = UnityEngine.Random;

namespace ForestOfChaosLib.Maths
{
	#region Noise
	public static class Noise
	{
		#region ReturnNoiseInt
		/// <summary>
		/// Randomize value by amount.
		/// </summary>
		/// <param name="value">Value to Randomize.</param>
		/// <param name="amount">Amount to Randomize.</param>
		/// <returns>Value +/- Amount</returns>
		public static int ReturnNoise(int value, int amount)
		{
			var f = RandomMaster.Random.Next(value - amount, value + amount);
			return (f);
		}
		#endregion

		#region ReturnNoiseFloat
		/// <summary>
		/// Randomize value by amount.
		/// </summary>
		/// <param name="value">Value to Randomize.</param>
		/// <param name="amount">Amount to Randomize.</param>
		/// <returns>Value +/- Amount</returns>
		public static float ReturnNoise(float value, float amount)
		{
			var f = RAND.Range(value - amount, value + amount);
			return (f);
		}
		#endregion
	}
	#endregion
}