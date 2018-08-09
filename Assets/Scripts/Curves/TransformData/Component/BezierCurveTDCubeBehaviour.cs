namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveTDCubeBehaviour: ICurveTDComponent<BezierCurveTDCube>
	{
		private void Reset()
		{
			Curve = new BezierCurveTDCube();
		}
	}
}
