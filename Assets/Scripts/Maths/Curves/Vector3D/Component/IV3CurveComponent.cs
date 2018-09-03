﻿using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Components
{
	public class IV3CurveComponent<T>: ICurveV3DComponent, IV3Curve where T: IV3Curve
	{
		public T Curve;

		public override bool UseGlobalSpace
		{
			get { return Curve.UseGlobalSpace; }
			set { Curve.UseGlobalSpace = value; }
		}

		public override List<Vector3> CurvePositions
		{
			get { return Curve.CurvePositions; }
			set { Curve.CurvePositions = value; }
		}

		public override bool IsFixedLength => Curve.IsFixedLength;
		public override int  Length        => Curve.Length;

		public override Vector3 Lerp(float time)
		{
			if(!UseGlobalSpace)
				return transform.TransformDirection(Curve.Lerp(time) + transform.position);

			return Curve.Lerp(time);
		}
	}

	public abstract class ICurveV3DComponent: MonoBehaviour
	{
		public abstract bool          UseGlobalSpace { get; set; }
		public abstract List<Vector3> CurvePositions { get; set; }
		public abstract bool          IsFixedLength  { get; }
		public abstract int           Length         { get; }
		public abstract Vector3 Lerp(float time);
	}
}
