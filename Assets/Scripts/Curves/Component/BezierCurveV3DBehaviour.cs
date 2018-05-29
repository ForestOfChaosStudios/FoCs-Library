using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveV3DBehaviour: ICurveComponent<BezierCurveV3D>
	{
		private void Reset()
		{
			Curve           = new BezierCurveV3D();
			Curve.Positions = new List<Vector3>(BezierCurveQuadV3D.TOTAL_COUNT);
		}
	}
}