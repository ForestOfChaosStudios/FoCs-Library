using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.Curves.Components
{
	public class ICurveComponent<T>: FoCsBehaviour, ICurve where T: ICurve
	{
		public T Curve;

		public bool UseGlobalSpace
		{
			get { return Curve.UseGlobalSpace; }
			set { Curve.UseGlobalSpace = value; }
		}

		public List<Vector3> CurvePositions
		{
			get { return Curve.CurvePositions; }
			set { Curve.CurvePositions = value; }
		}

		public bool IsFixedLength => Curve.IsFixedLength;
		public int  Length        => Curve.Length;

		public Vector3 Lerp(float time)
		{
			if(!UseGlobalSpace)
				return Transform.TransformDirection(Curve.Lerp(time));

			return Curve.Lerp(time);
		}
	}
}
