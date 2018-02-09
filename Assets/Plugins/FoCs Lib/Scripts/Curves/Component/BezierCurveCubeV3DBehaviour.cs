using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveCubeV3DBehaviour: ICurveComponent<BezierCurveCubeV3D>
	{
		private void Reset()
		{
			Curve = new BezierCurveCubeV3D();
			Curve.Positions = new List<Vector3>(BezierCurveCubeV3D.TOTAL_COUNT);
		}
	}
}