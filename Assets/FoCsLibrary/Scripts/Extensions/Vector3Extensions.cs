using UnityEngine;

namespace ForestOfChaosLibrary.Extensions
{
	public static class Vector3Extensions
	{
		public static Vector3    Randomize(this     Vector3 vec, float min = -100, float max = 100) => new Vector3(Random.Range(min, max) + vec.x, Random.Range(min, max) + vec.y, Random.Range(min, max) + vec.z);
		public static Vector3    ToXZ(this          Vector3 vec)                 => new Vector3(vec.x,          vec.z,          vec.y);
		public static Vector3    FromX_Y2Z(this     Vector3 vec)                 => new Vector3(vec.x,          0,              vec.y);
		public static Vector3    NegX(this          Vector3 vec)                 => new Vector3(-vec.x,         vec.y,          vec.z);
		public static Vector3    NegY(this          Vector3 vec)                 => new Vector3(vec.x,          -vec.y,         vec.z);
		public static Vector3    NegZ(this          Vector3 vec)                 => new Vector3(vec.x,          vec.y,          -vec.z);
		public static Vector3    SetX(this          Vector3 vec, float   amount) => new Vector3(amount,         vec.y,          vec.z);
		public static Vector3    SetY(this          Vector3 vec, float   amount) => new Vector3(vec.x,          amount,         vec.z);
		public static Vector3    SetZ(this          Vector3 vec, float   amount) => new Vector3(vec.x,          vec.y,          amount);
		public static Vector3    SetX(this          Vector3 vec, Vector3 amount) => new Vector3(amount.x,       vec.y,          vec.x);
		public static Vector3    SetY(this          Vector3 vec, Vector3 amount) => new Vector3(vec.x,          amount.y,       vec.z);
		public static Vector3    SetZ(this          Vector3 vec, Vector3 amount) => new Vector3(vec.x,          vec.y,          amount.z);
		public static Vector3    MoveX(this         Vector3 vec, float   amount) => new Vector3(vec.x + amount, vec.y,          vec.z);
		public static Vector3    MoveY(this         Vector3 vec, float   amount) => new Vector3(vec.x,          vec.y + amount, vec.z);
		public static Vector3    MoveZ(this         Vector3 vec, float   amount) => new Vector3(vec.x,          vec.y,          vec.z + amount);
		public static Vector3    MoveX(this         Vector3 vec, Vector3 amount) => new Vector3(vec.x                                 + amount.x, vec.y,            vec.z);
		public static Vector3    MoveY(this         Vector3 vec, Vector3 amount) => new Vector3(vec.x,                                            vec.y + amount.y, vec.z);
		public static Vector3    MoveZ(this         Vector3 vec, Vector3 amount) => new Vector3(vec.x,                                            vec.y,            vec.z + amount.z);
		public static Vector3    Move(this          Vector3 vec, float   amount) => new Vector3(vec.x                                                                     + amount,   vec.y + amount,   vec.z + amount);
		public static Vector3    Move(this          Vector3 vec, Vector3 amount) => new Vector3(vec.x                                                                     + amount.x, vec.y + amount.y, vec.z + amount.z);
		public static Vector2    ToVector2(this     Vector3 vec)                  => vec;
		public static float      Distance(this      Vector3 vec,  Vector3 other)  => Vector3.Distance(vec, other);
		public static Vector3    Direction(this     Vector3 from, Vector3 target) => (target - from).normalized;
		public static Vector3    Copy(this          Vector3 vec)                            => vec;
		public static Vector3    Lerp(this          Vector3 start, Vector3 end, float time) => Vector3.Lerp(start, end, time);
		public static Quaternion GetQuaternion(this Vector3 v3) => Quaternion.Euler(v3);
	}
}