using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CURVES_FOLDER_ + "Transform Data/Any Length")]
	public class CurveTDBehaviour: ICurveTDComponent<CurveTD>
	{
		private void Reset()
		{
			Curve = new CurveTD();
		}
	}
}
