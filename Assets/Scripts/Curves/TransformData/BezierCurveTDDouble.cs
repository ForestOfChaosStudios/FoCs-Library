using System;
using System.Collections.Generic;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Maths;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.Curves
{
	[Serializable]
	public class BezierCurveTDDouble: ICurveTD
	{
		public const int                 TOTAL_COUNT = 2;
		public       List<TransformData> Positions   = new List<TransformData>(TOTAL_COUNT);

		public TransformData StartPos
		{
			get { return Positions[0]; }
			set { Positions[0] = value; }
		}

		public TransformData EndPos
		{
			get { return Positions[1]; }
			set { Positions[1] = value; }
		}

		private void PosNullCheck()
		{
			if(Positions == null)
				Positions = new List<TransformData>(TOTAL_COUNT);
		}

		public List<TransformData> CurvePositions
		{
			get
			{
				PosNullCheck();

				return new List<TransformData>(Positions);
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
					default:
						StartPos = value[0];
						EndPos   = value[1];

						break;
				}
			}
		}

		public bool IsFixedLength
		{
			get { return true; }
		}

		public int Length
		{
			get { return TOTAL_COUNT; }
		}

		public TransformData Lerp(float time)
		{
			return TransformDataBezierLerp.Lerp(this, time);
		}
	}
}
