using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Transform Data Curve Length 2")]
	public class TDCurve2PointsBehaviour: ITDCurveComponent<TDCurve2Points>
	{
		private void Reset()
		{
			Curve = new TDCurve2Points();
		}
	}
}
