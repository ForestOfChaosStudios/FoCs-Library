using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Vector 3/Length 3")]
	public class CurveV3DTriBehaviour: ICurveV3DComponent<CurveV3DTri>
	{
		private void Reset()
		{
			Curve = new CurveV3DTri();
		}
	}
}
