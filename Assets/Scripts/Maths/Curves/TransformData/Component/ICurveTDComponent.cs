using System.Collections.Generic;
using ForestOfChaosLib.Types;
using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Components
{
	public class ICurveTDComponent<T>: ICurveTDComponent, ICurveTD where T: ICurveTD
	{
		public T Curve;

		public override bool UseGlobalSpace
		{
			get { return Curve.UseGlobalSpace; }
			set { Curve.UseGlobalSpace = value; }
		}

		public override List<TransformData> CurvePositions
		{
			get { return Curve.CurvePositions; }
			set { Curve.CurvePositions = value; }
		}

		public override bool IsFixedLength
		{
			get { return Curve.IsFixedLength; }
		}

		public override int Length
		{
			get { return Curve.Length; }
		}

		public override TransformData Lerp(float time)
		{
			if(!UseGlobalSpace)
			{
				var lerpTime = Curve.Lerp(time);
				lerpTime.Position = transform.TransformPoint(lerpTime.Position);

				return lerpTime;
			}
			else
			{
				var lerpTime = Curve.Lerp(time);

				return lerpTime;
			}
		}
	}

	public abstract class ICurveTDComponent: MonoBehaviour
	{
		public abstract List<TransformData> CurvePositions { get; set; }
		public abstract bool                IsFixedLength  { get; }
		public abstract bool                UseGlobalSpace { get; set; }
		public abstract int                 Length         { get; }
		public abstract TransformData Lerp(float time);
	}
}
