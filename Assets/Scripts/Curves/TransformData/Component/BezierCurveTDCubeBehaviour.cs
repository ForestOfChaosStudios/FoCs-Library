using System.Collections.Generic;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveTDCubeBehaviour: ICurveTDComponent<BezierCurveTDCube>
	{
		private void Reset()
		{
			Curve           = new BezierCurveTDCube();
			Curve.Positions = new List<TransformData>(BezierCurveTDCube.TOTAL_COUNT);
		}
	}
}