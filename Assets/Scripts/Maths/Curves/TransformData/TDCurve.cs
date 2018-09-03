using System;
using System.Collections.Generic;
using ForestOfChaosLib.Maths.Lerp;
using ForestOfChaosLib.Types;
using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves
{
	[Serializable]
	public class TDCurve: ITDCurve
	{
		[SerializeField] private List<TransformData> Positions;
		[SerializeField] private bool                useGlobalSpace;

		public bool UseGlobalSpace
		{
			get { return useGlobalSpace; }
			set { useGlobalSpace = value; }
		}

		public List<TransformData> CurvePositions
		{
			get { return Positions; }
			set { Positions = value; }
		}

		public bool IsFixedLength => false;
		public int  Length        => Positions.Count;
		public TransformData Lerp(float time) => TransformDataLerp.Lerp(Positions, time);
	}
}
