using System.Collections.Generic;
using ForestOfChaosLib.Types;

namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveTDQuadBehaviour: ICurveTDComponent<BezierCurveTDQuad>
	{
		private void Reset()
		{
			Curve           = new BezierCurveTDQuad();
			Curve.Positions = new List<TransformData>(BezierCurveTDQuad.TOTAL_COUNT);
		}
	}
}