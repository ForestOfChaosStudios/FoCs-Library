namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveV3DBehaviour: ICurveV3DComponent<BezierCurveV3D>
	{
		private void Reset()
		{
			Curve = new BezierCurveV3D();
		}
	}
}
