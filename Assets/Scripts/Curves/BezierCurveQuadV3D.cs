using System;
using System.Collections.Generic;
using ForestOfChaosLib.Maths;
using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.Curves
{
	[Serializable]
	public class BezierCurveQuadV3D: ICurve
	{
		public const             int           TOTAL_COUNT    = 3;
		public                   List<Vector3> Positions      = new List<Vector3>(TOTAL_COUNT);
		[SerializeField] private bool          useGlobalSpace = true;
		public                   Vector3       StartPos { get { return Positions[0]; } set { Positions[0] = value; } }
		public                   Vector3       MidPos   { get { return Positions[1]; } set { Positions[1] = value; } }
		public                   Vector3       EndPos   { get { return Positions[2]; } set { Positions[2] = value; } }

		private void PosNullCheck()
		{
			if(Positions == null)
				Positions = new List<Vector3>(3);
		}

		public bool UseGlobalSpace { get { return useGlobalSpace; } set { useGlobalSpace = value; } }

		public List<Vector3> CurvePositions
		{
			get
			{
				PosNullCheck();

				return new List<Vector3>(Positions);
			}
			set
			{
				PosNullCheck();

				if(value.IsNullOrEmpty())
					return;

				switch(value.Count)
				{
					case 0:

						return;
					case 1:
						StartPos = value[0];

						return;
					case 2:
						StartPos = value[0];
						MidPos   = value[1];

						return;
					case 3:
						StartPos = value[0];
						MidPos   = value[1];
						EndPos   = value[2];

						return;
					default:
						StartPos = value[0];
						MidPos   = value[1];
						EndPos   = value[2];

						break;
				}
			}
		}

		public bool    IsFixedLength    => true;
		public int     Length           => TOTAL_COUNT;
		public Vector3 Lerp(float time) => BezierLerp.Lerp(this, time);
	}
}