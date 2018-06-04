using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveQuadV3DBehaviour: ICurveComponent<BezierCurveQuadV3D>
	{
		private void Reset()
		{
			Curve           = new BezierCurveQuadV3D();
			Curve.Positions = new List<Vector3>(BezierCurveQuadV3D.TOTAL_COUNT);
		}
	}
}
