namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveV3DCubeBehaviour: ICurveV3DComponent<BezierCurveV3DCube>
	{
		private void Reset()
		{
			Curve = new BezierCurveV3DCube();
		}
	}
}
