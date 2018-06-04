using UnityEngine;

namespace ForestOfChaosLib.Maths
{
	public static class VectorMaths
	{
		public const float ROTATION_MAX = 360f;

		public static Vector3 GetVectorDirection(Vector3 vA, Vector3 vB, bool Normalized = true)
		{
			var output = vA - vB;

			if(Normalized)
				output.Normalize();

			return output;
		}

		public static float ClampAngle(this float angle, float min, float max)
		{
			if(angle < -ROTATION_MAX)
				angle += ROTATION_MAX;

			if(angle > ROTATION_MAX)
				angle -= ROTATION_MAX;

			return Mathf.Clamp(angle, min, max);
		}

		public static float ClampAngle(this float angle)
		{
			if(angle < -ROTATION_MAX)
				angle += ROTATION_MAX * 2;

			if(angle > ROTATION_MAX)
				angle -= ROTATION_MAX * 2;

			return angle;
		}
	}
}
