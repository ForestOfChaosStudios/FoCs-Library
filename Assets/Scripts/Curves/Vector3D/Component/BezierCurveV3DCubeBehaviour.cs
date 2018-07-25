using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveV3DCubeBehaviour: CurveV3DComponent<BezierCurveV3DCube>
	{
		private void Reset()
		{
			Curve           = new BezierCurveV3DCube();
			Curve.Positions = new List<Vector3>(BezierCurveV3DCube.TOTAL_COUNT);
		}
	}
}