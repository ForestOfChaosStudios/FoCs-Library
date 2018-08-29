using UnityEngine;

namespace ForestOfChaosLib.Extensions
{
	public static class Vector3Extensions
	{
		public static Vector3 Randomize(this Vector3 vec, float min = -100, float max = 100)
		{
			return new Vector3(Random.Range(min, max) + vec.x, Random.Range(min, max) + vec.y, Random.Range(min, max) + vec.z);
		}

		public static Vector3 ToXZ(this Vector3 vec)
		{
			return new Vector3(vec.x, vec.z, vec.y);
		}

		public static Vector3 FromX_Y2Z(this Vector3 vec)
		{
			return new Vector3(vec.x, 0, vec.y);
		}

		public static Vector3 NegX(this Vector3 vec)
		{
			return new Vector3(-vec.x, vec.y, vec.z);
		}

		public static Vector3 NegY(this Vector3 vec)
		{
			return new Vector3(vec.x, -vec.y, vec.z);
		}

		public static Vector3 NegZ(this Vector3 vec)
		{
			return new Vector3(vec.x, vec.y, -vec.z);
		}

		public static Vector3 SetX(this Vector3 vec, float amount)
		{
			return new Vector3(amount, vec.y, vec.z);
		}

		public static Vector3 SetY(this Vector3 vec, float amount)
		{
			return new Vector3(vec.x, amount, vec.z);
		}

		public static Vector3 SetZ(this Vector3 vec, float amount)
		{
			return new Vector3(vec.x, vec.y, amount);
		}

		public static Vector3 SetX(this Vector3 vec, Vector3 amount)
		{
			return new Vector3(amount.x, vec.y, vec.x);
		}

		public static Vector3 SetY(this Vector3 vec, Vector3 amount)
		{
			return new Vector3(vec.x, amount.y, vec.z);
		}

		public static Vector3 SetZ(this Vector3 vec, Vector3 amount)
		{
			return new Vector3(vec.x, vec.y, amount.z);
		}

		public static Vector3 MoveX(this Vector3 vec, float amount)
		{
			return new Vector3(vec.x + amount, vec.y, vec.z);
		}

		public static Vector3 MoveY(this Vector3 vec, float amount)
		{
			return new Vector3(vec.x, vec.y + amount, vec.z);
		}

		public static Vector3 MoveZ(this Vector3 vec, float amount)
		{
			return new Vector3(vec.x, vec.y, vec.z + amount);
		}

		public static Vector3 MoveX(this Vector3 vec, Vector3 amount)
		{
			return new Vector3(vec.x + amount.x, vec.y, vec.z);
		}

		public static Vector3 MoveY(this Vector3 vec, Vector3 amount)
		{
			return new Vector3(vec.x, vec.y + amount.y, vec.z);
		}

		public static Vector3 MoveZ(this Vector3 vec, Vector3 amount)
		{
			return new Vector3(vec.x, vec.y, vec.z + amount.z);
		}

		public static Vector3 Move(this Vector3 vec, float amount)
		{
			return new Vector3(vec.x + amount, vec.y + amount, vec.z + amount);
		}

		public static Vector3 Move(this Vector3 vec, Vector3 amount)
		{
			return new Vector3(vec.x + amount.x, vec.y + amount.y, vec.z + amount.z);
		}

		public static Vector2 ToVector2(this Vector3 vec)
		{
			return vec;
		}

		public static float Distance(this Vector3 vec, Vector3 other)
		{
			return Vector3.Distance(vec, other);
		}

		public static Vector3 Direction(this Vector3 from, Vector3 target)
		{
			return (target - from).normalized;
		}

		public static Vector3 Copy(this Vector3 vec)
		{
			return vec;
		}

		public static Quaternion GetQuaternion(this Vector3 v3)
		{
			return Quaternion.Euler(v3);
		}
	}
}
