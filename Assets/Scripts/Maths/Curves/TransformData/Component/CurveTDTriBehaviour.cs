using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Transform Data/Length 3")]
	public class CurveTDTriBehaviour: ICurveTDComponent<CurveTDTri>
	{
		private void Reset()
		{
			Curve = new CurveTDTri();
		}
	}
}
