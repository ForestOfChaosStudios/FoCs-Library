using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Vector 3/Any Length")]
	public class CurveV3DBehaviour: ICurveV3DComponent<CurveV3D>
	{
		private void Reset()
		{
			Curve = new CurveV3D();
		}
	}
}
