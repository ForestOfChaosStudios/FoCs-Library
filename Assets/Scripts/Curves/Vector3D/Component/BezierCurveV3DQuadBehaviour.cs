namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveV3DQuadBehaviour: ICurveV3DComponent<BezierCurveV3DQuad>
	{
		private void Reset()
		{
			Curve = new BezierCurveV3DQuad();
		}
	}
}
