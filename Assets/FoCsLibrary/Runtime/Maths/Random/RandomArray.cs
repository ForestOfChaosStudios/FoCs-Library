namespace ForestOfChaosLibrary.Maths.Random
{
	public static class RandomArray
	{
		public static T[] ShuffleArray<T>(this T[] array) => ShuffleArray(array, RandomMaster.Random);

		public static T[] ShuffleArray<T>(this T[] array, System.Random rng)
		{
			for(var i = array.Length - 1; i > 0; i--)
			{
				var index = rng.Next(i + 1);
				// Simple swap
				var a = array[index];
				array[index] = array[i];
				array[i]     = a;
			}

			return array;
		}

		public static T[] ShuffleArrayUnity<T>(this T[] array)
		{
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
