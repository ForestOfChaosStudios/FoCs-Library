using System;
using System.Collections.Generic;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Maths.Lerp;
using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves
{
	[Serializable]
	public class V3Curve4Points: IV3Curve
	{
		public const             int           TOTAL_COUNT    = 4;
		[SerializeField] private List<Vector3> Positions      = new List<Vector3>(TOTAL_COUNT);
		[SerializeField] private bool          useGlobalSpace = true;

		public Vector3 StartPos
		{
			get { return Positions[0]; }
			set { Positions[0] = value; }
		}

		public Vector3 MidPosOne
		{
			get { return Positions[1]; }
			set { Positions[1] = value; }
		}

		public Vector3 MidPosTwo
		{
			get { return Positions[2]; }
			set { Positions[2] = value; }
		}

		public Vector3 EndPos
		{
			get { return Positions[3]; }
			set { Positions[3] = value; }
		}

		private void PosNullCheck()
		{
			if(Positions == null)
				Positions = new List<Vector3>(TOTAL_COUNT);
		}

		public bool UseGlobalSpace
		{
			get { return useGlobalSpace; }
			set { useGlobalSpace = value; }
		}

		public List<Vector3> CurvePositions
		{
			get
			{
				PosNullCheck();

				return Positions;
			}
			set
			{
				PosNullCheck();

				if(value.IsNullOrEmpty())
					return;

				switch(value.Count)
				{
					case 0: return;
					case 1:
						StartPos = value[0];

						return;
					case 2:
						StartPos  = value[0];
						MidPosOne = value[1];

						return;
					case 3:
						StartPos  = value[0];
						MidPosOne = value[1];
						MidPosTwo = value[2];

						return;
					case 4:
						StartPos  = value[0];
						MidPosOne = value[1];
						MidPosTwo = value[2];
						EndPos    = value[3];

						return;
					default:
						StartPos  = value[0];
						MidPosOne = value[1];
						MidPosTwo = value[2];
						EndPos    = value[3];

						break;
				}
			}
		}

		public bool IsFixedLength => true;
		public int  Length        => TOTAL_COUNT;
		public Vector3 Lerp(float time) => Vector3Lerp.Lerp(Positions, time);
	}
}
