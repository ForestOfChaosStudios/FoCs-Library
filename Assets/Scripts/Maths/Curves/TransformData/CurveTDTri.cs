using System;
using System.Collections.Generic;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Maths.Lerp;
using ForestOfChaosLib.Types;
using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves
{
	[Serializable]
	public class CurveTDTri: ICurveTD
	{
		public const             int                 TOTAL_COUNT = 3;
		[SerializeField] private List<TransformData> Positions   = new List<TransformData>(TOTAL_COUNT);
		[SerializeField] private bool                useGlobalSpace;

		public TransformData StartPos
		{
			get { return Positions[0]; }
			set { Positions[0] = value; }
		}

		public TransformData MidPos
		{
			get { return Positions[1]; }
			set { Positions[1] = value; }
		}

		public TransformData EndPos
		{
			get { return Positions[2]; }
			set { Positions[2] = value; }
		}

		private void PosNullCheck()
		{
			if(Positions == null)
				Positions = new List<TransformData>(TOTAL_COUNT);
		}

		public bool UseGlobalSpace
		{
			get { return useGlobalSpace; }
			set { useGlobalSpace = value; }
		}

		public List<TransformData> CurvePositions
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

		public bool IsFixedLength => true;
		public int  Length        => TOTAL_COUNT;
		public TransformData Lerp(float time) => TransformDataLerp.Lerp(Positions, time);
	}
}
