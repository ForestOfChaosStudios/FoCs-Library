using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveV3DQuadBehaviour: CurveV3DComponent<BezierCurveV3DQuad>
	{
		private void Reset()
		{
			Curve           = new BezierCurveV3DQuad();
			Curve.Positions = new List<Vector3>(BezierCurveV3DQuad.TOTAL_COUNT);
		}
	}
}