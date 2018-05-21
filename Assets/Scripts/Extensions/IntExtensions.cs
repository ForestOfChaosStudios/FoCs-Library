namespace ForestOfChaosLib.Extensions
{
	public static class IntExtensions
	{
		public static bool IsZero(this int f)
		{
			return f == 0;
		}

		public static bool IsZeroOrNegative(this int f)
		{
			return f <= 0;
		}

		public static bool IsNegative(this int f)
		{
			return f < 0;
		}

		public static bool IsZeroOrPositive(this int f)
		{
			return f >= 0;
		}

		public static bool IsPositive(this int f)
		{
			return f > 0;
		}

		public static float Clamp(this int f, int min = 0, int max = 1)
		{
			if(f < min)
				f = min;
			else if(f > max)
				f = max;
			return f;
		}
	}
}