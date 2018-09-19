using UnityEngine;

namespace ForestOfChaosLibrary.Maths.Curves.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Transform Data Curve Length 3")]
	public class TDCurve3PointsBehaviour: ITDCurveComponent<TDCurve3Points>
	{
		private void Reset()
		{
			Curve = new TDCurve3Points();
		}
	}
}
