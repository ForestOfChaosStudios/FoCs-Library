using System;
using System.Collections.Generic;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Maths;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.Curves
{
	[Serializable]
	public class BezierCurveTDCube: ICurveTD
	{
		public const int                 TOTAL_COUNT = 4;
		public       List<TransformData> Positions   = new List<TransformData>(TOTAL_COUNT);

		public TransformData StartPos
		{
			get { return Positions[0]; }
			set { Positions[0] = value; }
		}

		public TransformData MidPosOne
		{
			get { return Positions[1]; }
			set { Positions[1] = value; }
		}

		public TransformData MidPosTwo
		{
			get { return Positions[2]; }
			set { Positions[2] = value; }
		}

		public TransformData EndPos
		{
			get { return Positions[3]; }
			set { Positions[3] = value; }
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

		public bool IsFixedLength
		{
			get { return true; }
		}

		private bool useGlobalSpace;

		/// <inheritdoc />
		public bool UseGlobalSpace
		{
			get { return useGlobalSpace; }
			set { useGlobalSpace = value; }
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
