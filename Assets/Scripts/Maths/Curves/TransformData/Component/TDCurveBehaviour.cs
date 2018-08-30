using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Transform Data Curve Any Length")]
	public class TDCurveBehaviour: ITDCurveComponent<TDCurve>
	{
		private void Reset()
		{
			Curve = new TDCurve();
		}
	}
}
