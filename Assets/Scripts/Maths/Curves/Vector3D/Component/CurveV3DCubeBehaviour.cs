using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Vector 3/Length 4")]
	public class CurveV3DCubeBehaviour: ICurveV3DComponent<CurveV3DCube>
	{
		private void Reset()
		{
			Curve = new CurveV3DCube();
		}
	}
}
