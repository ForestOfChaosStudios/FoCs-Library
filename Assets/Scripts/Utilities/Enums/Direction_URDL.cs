using UnityEngine;

namespace ForestOfChaosLib.Utilities.Enums
{
	public enum URDL
	{
		Up,
		Right,
		Down,
		Left
	}

	public static class URDLHelper
	{
		public const URDL FIRST = URDL.Up;
		public const URDL LAST  = URDL.Left;

		public static URDL Next(this URDL val)
		{
			switch(val)
			{
				case LAST: return FIRST;
				default:   return ++val;
			}
		}

		public static URDL Previous(this URDL val)
		{
			switch(val)
			{
				case FIRST: return LAST;
				default:    return --val;
			}
		}

		public static float GetAngle(this URDL val)
		{
			switch(val)
			{
				case URDL.Up:    return 0;
				case URDL.Right: return 90;
				case URDL.Down:  return 180;
				case URDL.Left:  return -90;
			}

			return 0;
		}

		public static Vector3 GetDirection(this URDL val)
		{
			switch(val)
			{
				case URDL.Up:    return Vector3.up;
				case URDL.Right: return Vector3.right;
				case URDL.Down:  return Vector3.down;
				case URDL.Left:  return Vector3.left;
			}

			return Vector3.zero;
		}

		public static Vector3 GetDirection(this URDL val, Transform transform)
		{
			Vector3 dir;
			GetDirection(val, transform, out dir);

			return dir;
		}

		public static Vector3 GetDirection(this Transform transform, URDL val)
		{
			Vector3 dir;
			GetDirection(val, transform, out dir);

			return dir;
		}

		private static void GetDirection(URDL val, Transform transform, out Vector3 dir)
		{
			dir = Vector3.zero;

			switch(val)
			{
				case URDL.Up:
					dir = transform.up;

					return;
				case URDL.Right:
					dir = transform.right;

					return;
				case URDL.Down:
					dir = -transform.up;

					return;
				case URDL.Left:
					dir = -transform.right;

					return;
			}
		}
	}
}