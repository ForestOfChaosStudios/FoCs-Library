using System;

namespace ForestOfChaosLib.CSharpExtensions
{
	public static class FloatExtensions
	{
		public static bool IsZero(this float f)
		{
			return f == 0;
		}

		public static bool IsZeroOrNegative(this float f)
		{
			return f <= 0;
		}

		public static bool IsNegative(this float f)
		{
			return f < 0;
		}

		public static bool IsZeroOrPositive(this float f)
		{
			return f >= 0;
		}

		public static bool IsPositive(this float f)
		{
			return f > 0;
		}

		public static float Abs(this float f)
		{
			return Math.Abs(f);
		}

		public static float Clamp(this float f, float min = 0, float max = 1)
		{
			if(f < min)
				f = min;
			else if(f > max)
				f = max;
			return f;
		}

		public static int CastToInt(this float f)
		{
			return (int)(f + 0.5f);
		}
	}
}