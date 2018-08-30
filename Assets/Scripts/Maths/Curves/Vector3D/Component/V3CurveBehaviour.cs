using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Vector 3 Curve Any Length")]
	public class V3CurveBehaviour: IV3CurveComponent<V3Curve>
	{
		private void Reset()
		{
			Curve = new V3Curve();
		}
	}
}
