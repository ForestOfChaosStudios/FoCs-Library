using UnityEngine;

namespace ForestOfChaosLib.Extensions
{
	public static class Vector2Extensions
	{
		public static Vector2 Randomize(this Vector2 vec, float min = -100, float max = 100)
		{
			return new Vector2(Random.Range(min, max) + vec.x, Random.Range(min, max) + vec.y);
		}

		public static Vector3 ToXZ(this Vector2 vec)
		{
			return new Vector3(vec.x, 0, vec.y);
		}

		public static Vector3 FromX_Y2Z(this Vector2 vec)
		{
			return new Vector3(vec.x, 0, vec.y);
		}

		public static Vector2 NegX(this Vector2 vec)
		{
			return new Vector2(-vec.x, vec.y);
		}

		public static Vector2 NegY(this Vector2 vec)
		{
			return new Vector2(vec.x, -vec.y);
		}

		public static Vector2 SetX(this Vector2 vec, float amount)
		{
			return new Vector2(amount, vec.y);
		}

		public static Vector2 SetY(this Vector2 vec, float amount)
		{
			return new Vector2(vec.x, amount);
		}

		public static Vector2 SetX(this Vector2 vec, Vector2 amount)
		{
			return new Vector2(amount.x, vec.y);
		}

		public static Vector2 SetY(this Vector2 vec, Vector2 amount)
		{
			return new Vector2(vec.x, amount.y);
		}

		public static Vector2 MoveX(this Vector2 vec, float amount)
		{
			return new Vector2(vec.x + amount, vec.y);
		}

		public static Vector2 MoveY(this Vector2 vec, float amount)
		{
			return new Vector2(vec.x, vec.y + amount);
		}

		public static Vector2 MoveX(this Vector2 vec, Vector2 amount)
		{
			return new Vector2(vec.x + amount.x, vec.y);
		}

		public static Vector2 MoveY(this Vector2 vec, Vector2 amount)
		{
			return new Vector2(vec.x, vec.y + amount.y);
		}

		public static Vector2 Move(this Vector2 vec, float amount)
		{
			return new Vector2(vec.x + amount, vec.y + amount);
		}

		public static Vector2 Move(this Vector2 vec, Vector2 amount)
		{
			return new Vector2(vec.x + amount.x, vec.y + amount.y);
		}

		public static Vector2 ToVector3(this Vector2 vec)
		{
			return vec;
		}

		public static Vector3 ToVector3(this Vector2 vec, float z)
		{
			return new Vector3(vec.x, vec.y, z);
		}

		public static float Distance(this Vector2 vec, Vector2 other)
		{
			return Vector2.Distance(vec, other);
		}

		public static Vector2 Copy(this Vector2 vec)
		{
			return vec;
		}

		public static Vector2 Multiply(this Vector2 vec, Vector2 other)
		{
			return new Vector2(vec.x * other.x, vec.y * other.y);
		}

		public static float RandomRange(this Vector2 vec)
		{
			return Random.Range(vec.x, vec.y);
		}
	}
}
