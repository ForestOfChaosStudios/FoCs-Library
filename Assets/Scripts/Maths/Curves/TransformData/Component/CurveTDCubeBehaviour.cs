using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Transform Data/Length 4")]
	public class CurveTDCubeBehaviour: ICurveTDComponent<CurveTDCube>
	{
		private void Reset()
		{
			Curve = new CurveTDCube();
		}
	}
}
