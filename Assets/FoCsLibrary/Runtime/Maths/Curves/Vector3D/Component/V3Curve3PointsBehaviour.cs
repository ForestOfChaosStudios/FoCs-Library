using UnityEngine;

namespace ForestOfChaosLibrary.Maths.Curves.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Vector 3 Curve Length 2")]
	public class V3Curve3PointsBehaviour: IV3CurveComponent<V3Curve3Points>
	{
		private void Reset()
		{
			Curve = new V3Curve3Points();
		}
	}
}
