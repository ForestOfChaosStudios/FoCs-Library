namespace ForestOfChaosLib.Maths.Random
{
	public static class RandomBools
	{
		public static bool RandomBool()
		{
			return RandomMaster.Random.NextDouble() >= 0.5;
		}
	}
}