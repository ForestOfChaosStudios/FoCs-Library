using UnityEngine;

namespace ForestOfChaosLibrary.Maths.Curves.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Vector 3 Curve Length 4")]
	public class V3Curve4PointsBehaviour: IV3CurveComponent<V3Curve4Points>
	{
		private void Reset()
		{
			Curve = new V3Curve4Points();
		}
	}
}
