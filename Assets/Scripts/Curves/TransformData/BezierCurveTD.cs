using System;
using System.Collections.Generic;
using ForestOfChaosLib.Maths;
using ForestOfChaosLib.Types;
using UnityEngine;

namespace ForestOfChaosLib.Curves
{
	[Serializable]
	public class BezierCurveTD: ICurveTD
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
			return TransformDataBezierLerp.Lerp(Positions, time);
		}
	}
}
