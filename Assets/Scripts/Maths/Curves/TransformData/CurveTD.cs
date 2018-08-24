using System;
using System.Collections.Generic;
using ForestOfChaosLib.Maths.Lerp;
using ForestOfChaosLib.Types;
using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves
{
	[Serializable]
	public class CurveTD: ICurveTD
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
			return TransformDataLerp.Lerp(Positions, time);
		}
	}
}
