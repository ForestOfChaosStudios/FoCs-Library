using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Transform Data/Length 2")]
	public class CurveTDDoubleBehaviour: ICurveTDComponent<CurveTDDouble>
	{
		private void Reset()
		{
			Curve = new CurveTDDouble();
		}
	}
}
