using System;

namespace ForestOfChaosLib.Maths.Random
{
	public static class RandomStrings
	{
		public const string ALPHA           = "abcdefghijklmnopqrstuvwxyz";
		public const string NUMERIC         = "1234567890";
		public const string SYMBOLS         = "!@#$%^&*()-_=+`~,<.>/?;:'";
		public const string ALL_CHARS       = ALPHA + NUMERIC + SYMBOLS;
		public const string ALPHA_SYMBOLS   = ALPHA           + SYMBOLS;
		public const string NUMERIC_SYMBOLS = NUMERIC         + SYMBOLS;

		public static string GetRandomString(int length)
		{
			return GetRandomString(ALL_CHARS, length, DateTime.UtcNow.Millisecond);
		}

		public static string GetRandomString(int length, int seed)
		{
			return GetRandomString(ALL_CHARS, length, seed);
		}

		public static string GetRandomString(string characters, int length, int seed)
		{
			var s    = "";
			var rand = new System.Random(seed);

			for(var i = 0; i < length; i++)
			{
				if(MiscMaths.IsOdd(i))
					s += characters[rand.Next(characters.Length)];
				else
					s += characters[rand.Next(characters.Length)];
			}

			return s;
		}

		public static string GetRandomAltString(int length)
		{
			return GetRandomAltString(length, DateTime.UtcNow.Millisecond);
		}

		public static string GetRandomAltString(int length, int seed)
		{
			var s    = "";
			var rand = new System.Random(seed);

			for(var i = 0; i < length; i++)
			{
				if(MiscMaths.IsOdd(i))
					s += NUMERIC[rand.Next(NUMERIC.Length)];
				else
					s += ALPHA[rand.Next(ALPHA.Length)];
			}

			return s;
		}
	}
}
