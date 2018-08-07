using System.Collections.Generic;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.Maths
{
	public static class TransformDataBezierLerp
	{
		public static TransformData Lerp(TransformData value1, TransformData value2, float time)
		{
			var output = TransformData.Empty;
			output.Position = Vector3BezierLerp.Lerp(value1.Position, value2.Position, time);
			output.Rotation = QuaternionBezierLerp.Lerp(value1.Rotation, value2.Rotation, time);
			output.Scale    = Vector3BezierLerp.Lerp(value1.Scale, value2.Scale, time);

			return output;
		}

		public static TransformData Lerp(TransformData value1, TransformData value2, TransformData value3, float time)
		{
			var output = TransformData.Empty;
			output.Position = Vector3BezierLerp.Lerp(value1.Position, value2.Position, value3.Position, time);
			output.Rotation = QuaternionBezierLerp.Lerp(value1.Rotation, value2.Rotation, value3.Rotation, time);
			output.Scale    = Vector3BezierLerp.Lerp(value1.Scale, value2.Scale, value3.Scale, time);

			return output;
		}

		public static TransformData Lerp(TransformData value1, TransformData value2, TransformData value3, TransformData value4, float time)
		{
			var output = TransformData.Empty;
			output.Position = Vector3BezierLerp.Lerp(value1.Position, value2.Position, value3.Position, value4.Position, time);
			output.Rotation = QuaternionBezierLerp.Lerp(value1.Rotation, value2.Rotation, value3.Rotation, value4.Rotation, time);
			output.Scale    = Vector3BezierLerp.Lerp(value1.Scale, value2.Scale, value3.Scale, value4.Scale, time);

			return output;
		}

		public static TransformData Lerp(List<TransformData> curve, float time)
		{
			var count = curve.Count;

			switch(count)
			{
				case 0: return new TransformData();
				case 1: return curve[0];
				case 2: return Lerp(curve[0], curve[1], time);
				case 3: return Lerp(curve[0], curve[1], curve[2], time);
				case 4: return Lerp(curve[0], curve[1], curve[2], curve[3],                       time);
				case 5: return Lerp(curve[0], curve[1], curve[2], Lerp(curve[3], curve[4], time), time);
			}

			//FROM HERE IS IS SAFE
			//For there to be at leat 5 hard coded positions
			var posOne   = Lerp(curve[0], curve[1], time);
			var posTwo   = Lerp(curve[1], curve[2], time);
			var posThree = Lerp(curve[2], curve[3], time);

			for(var i = 4; i < count - 1; i++)
			{
				posOne   = Lerp(posOne,   posTwo,       time);
				posTwo   = Lerp(posTwo,   posThree,     time);
				posThree = Lerp(curve[i], curve[i + 1], time);
			}

			posOne = Lerp(posOne, posTwo,   time);
			posTwo = Lerp(posTwo, posThree, time);

			return Lerp(posOne, posTwo, time);
		}

		public static TransformData Lerp(TransformData[] curve, float time)
		{
			var count = curve.Length;

			switch(count)
			{
				case 0: return new TransformData();
				case 1: return curve[0];
				case 2: return Lerp(curve[0], curve[1], time);
				case 3: return Lerp(curve[0], curve[1], curve[2], time);
				case 4: return Lerp(curve[0], curve[1], curve[2], curve[3],                       time);
				case 5: return Lerp(curve[0], curve[1], curve[2], Lerp(curve[3], curve[4], time), time);
			}

			//FROM HERE IS IS SAFE
			//For there to be at leat 5 hard coded positions
			var posOne   = Lerp(curve[0], curve[1], time);
			var posTwo   = Lerp(curve[1], curve[2], time);
			var posThree = Lerp(curve[2], curve[3], time);

			for(var i = 4; i < count - 1; i++)
			{
				posOne   = Lerp(posOne,   posTwo,       time);
				posTwo   = Lerp(posTwo,   posThree,     time);
				posThree = Lerp(curve[i], curve[i + 1], time);
			}

			posOne = Lerp(posOne, posTwo,   time);
			posTwo = Lerp(posTwo, posThree, time);

			return Lerp(posOne, posTwo, time);
		}
	}
}
