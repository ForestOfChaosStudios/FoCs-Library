using System;
using System.Collections.Generic;
using ForestOfChaosLib.Maths;
using UnityEngine;

namespace ForestOfChaosLib.Curves
{
	[Serializable]
	public class BezierCurveV3D: ICurveV3D
	{
		public                   List<Vector3> Positions;
		[SerializeField] private bool          useGlobalSpace = true;

		public bool UseGlobalSpace
		{
			get { return useGlobalSpace; }
			set { useGlobalSpace = value; }
		}

		public List<Vector3> CurvePositions
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

		public Vector3 Lerp(float time)
		{
			return Vector3BezierLerp.Lerp(this, time);
		}
	}
}