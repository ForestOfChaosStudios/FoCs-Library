namespace ForestOfChaosLib.Utilities.Enums
{
	public enum Direction_NSEW
	{
		North,
		South,
		East,
		West
	}

	public static class Direction_NSEW_Helper
	{
		public const Direction_NSEW FIRST = Direction_NSEW.North;
		public const Direction_NSEW LAST  = Direction_NSEW.West;

		public static Direction_NSEW Next(this Direction_NSEW val)
		{
			switch(val)
			{
				case LAST:

					return FIRST;
				default:

					return (++val);
			}
		}

		public static Direction_NSEW Previous(this Direction_NSEW val)
		{
			switch(val)
			{
				case FIRST:

					return LAST;
				default:

					return (--val);
			}
		}
	}
}