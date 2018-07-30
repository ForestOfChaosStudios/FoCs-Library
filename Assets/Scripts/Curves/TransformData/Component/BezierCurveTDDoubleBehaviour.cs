using System.Collections.Generic;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveTDDoubleBehaviour: ICurveTDComponent<BezierCurveTDDouble>
	{
		private void Reset()
		{
			Curve           = new BezierCurveTDDouble();
			Curve.Positions = new List<TransformData>(BezierCurveTDDouble.TOTAL_COUNT);
		}
	}
}
