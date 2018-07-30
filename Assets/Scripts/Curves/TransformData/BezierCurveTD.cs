using System;
using System.Collections.Generic;
using ForestOfChaosLib.Maths;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.Curves
{
	[Serializable]
	public class BezierCurveTD: ICurveTD
	{
		public List<TransformData> Positions;

		public List<TransformData> CurvePositions
		{
			get { return Positions; }
			set { Positions = value; }
		}

		public bool IsFixedLength
		{
			get { return false; }
		}

		public int Length
		{
			get { return Positions.Count; }
		}

		public TransformData Lerp(float time)
		{
			return TransformDataBezierLerp.Lerp(this, time);
		}
	}
}
