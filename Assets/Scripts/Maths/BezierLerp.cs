using System.Collections.Generic;
using ForestOfChaosLib.Curves;
using UnityEngine;

namespace ForestOfChaosLib.Maths
{
	public static class BezierLerp
	{
		public static Vector3 Lerp(Vector3 value1, Vector3 value2, Vector3 value3, float time)
		{
			var posOne = Lerps.Lerp(value1, value2, time);
			var posTwo = Lerps.Lerp(value2, value3, time);

			return posOne + ((posTwo - posOne) * time);
		}

		public static Vector3 Lerp(Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, float time)
		{
			var posOne   = Lerps.Lerp(value1, value2, time);
			var posTwo   = Lerps.Lerp(value2, value3, time);
			var posThree = Lerps.Lerp(value3, value4, time);
			posOne = Lerps.Lerp(posOne, posTwo,   time);
			posTwo = Lerps.Lerp(posOne, posThree, time);

			return posOne + ((posTwo - posOne) * time);
		}

		public static Vector2 Lerp(Vector2 value1, Vector2 value2, Vector2 value3, float time)
		{
			var posOne = Lerps.Lerp(value1, value2, time);
			var posTwo = Lerps.Lerp(value2, value3, time);

			return posOne + ((posTwo - posOne) * time);
		}

		public static Vector3 Lerp(BezierCurveV3DQuad curve, float time) => Lerp(curve.CurvePositions.ToArray(), time);
		public static Vector3 Lerp(BezierCurveV3DCube curve, float time) => Lerp(curve.CurvePositions.ToArray(), time);
		public static Vector3 Lerp(BezierCurveV3D     curve, float time) => Lerp(curve.CurvePositions.ToArray(),      time);
		public static Vector3 Lerp(ICurveV3D             curve, float time) => Lerp(curve.CurvePositions.ToArray(), time);
		public static Vector3 Lerp(List<Vector3>      curve, float time) => Lerp(curve.ToArray(),                time);

		public static Vector3 Lerp(Vector3[] curve, float time)
		{
			var count = curve.Length;

			switch(count)
			{
				case 0: return Vector3.zero;
				case 1: return curve[0];
				case 2: return Lerps.Lerp(curve[0], curve[1], time);
				case 3: return Lerp(curve[0], curve[1], curve[2], time);
				case 4: return Lerp(curve[0], curve[1], curve[2], curve[3],                             time);
				case 5: return Lerp(curve[0], curve[1], curve[2], Lerps.Lerp(curve[3], curve[4], time), time);
			}

			//FROM HERE IS IS SAFE
			//For there to be at leat 5 hard coded positions
			var posOne   = Lerps.Lerp(curve[0], curve[1], time);
			var posTwo   = Lerps.Lerp(curve[1], curve[2], time);
			var posThree = Lerps.Lerp(curve[2], curve[3], time);

			for(var i = 4; i < count - 1; i++)
			{
				posOne   = Lerps.Lerp(posOne,   posTwo,       time);
				posTwo   = Lerps.Lerp(posTwo,   posThree,     time);
				posThree = Lerps.Lerp(curve[i], curve[i + 1], time);
			}

			posOne = Lerps.Lerp(posOne, posTwo,   time);
			posTwo = Lerps.Lerp(posTwo, posThree, time);

			return posOne + ((posTwo - posOne) * time);
		}
	}
}