using System;
using System.Collections.Generic;
using ForestOfChaosLib.Maths.Lerp;
using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves
{
	[Serializable]
	public class CurveV3D: ICurveV3D
	{
		[SerializeField] private List<Vector3> Positions = new List<Vector3>();
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
			return Vector3Lerp.Lerp(Positions, time);
		}
	}
}
