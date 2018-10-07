using UnityEngine;

namespace ForestOfChaosLibrary.Maths.Curves.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Transform Data Curve Length 4")]
	public class TDCurve4PointsBehaviour: ITDCurveComponent<TDCurve4Points>
	{
		private void Reset()
		{
			Curve = new TDCurve4Points();
		}
	}
}
