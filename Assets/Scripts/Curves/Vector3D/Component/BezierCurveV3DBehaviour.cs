using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveV3DBehaviour: CurveV3DComponent<BezierCurveV3D>
	{
		private void Reset()
		{
			Curve           = new BezierCurveV3D();
			Curve.Positions = new List<Vector3>(BezierCurveV3DQuad.TOTAL_COUNT);
		}
	}
}
