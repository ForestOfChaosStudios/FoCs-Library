using System.Collections.Generic;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveTDBehaviour: ICurveTDComponent<BezierCurveTD>
	{
		private void Reset()
		{
			Curve           = new BezierCurveTD();
			Curve.Positions = new List<TransformData>();
		}
	}
}
