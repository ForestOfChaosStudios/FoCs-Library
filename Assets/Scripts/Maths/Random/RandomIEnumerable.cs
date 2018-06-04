using System.Collections.Generic;
using System.Linq;

namespace ForestOfChaosLib.Maths.Random
{
	public static class RandomIEnumerable
	{
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> iEnumerable) => Shuffle(iEnumerable, RandomMaster.Random);

		public static T[] Shuffle<T>(this IEnumerable<T> iEnumerable, System.Random rng)
		{
			var array = iEnumerable.ToArray();

			for(var i = array.Count() - 1; i > 0; i--)
			{
				var index = rng.Next(i + 1);
				// Simple swap
				var a = array[index];
				array[index] = array[i];
				array[i]     = a;
			}

			return array;
		}

		public static IEnumerable<T> ShuffleUnity<T>(this IEnumerable<T> iEnumerable)
		{
			var array = iEnumerable.ToArray();

			for(var i = array.Length - 1; i > 0; i--)
			{
				var index = UnityEngine.Random.Range(0, i + 1);
				var a     = array[index];
				array[index] = array[i];
				array[i]     = a;
			}

			return array;
		}
	}
}
