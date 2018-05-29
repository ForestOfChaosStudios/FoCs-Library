using System;
using RAND = System.Random;

namespace ForestOfChaosLib.Maths.Random
{
	public static class RandomMaster
	{
		private static RAND p_Random;
		public static  RAND Random { get { return p_Random ?? (p_Random = GetRandomWithNewSeed()); } set { p_Random = value; } }
		static RandomMaster() { GetRandomWithNewSeed(); }
		public static RAND GetRandomWithNewSeed()         { return new RAND(DateTime.Now.Millisecond); }
		public static RAND GetRandomWithNewSeed(int seed) { return new RAND(seed); }
	}
}