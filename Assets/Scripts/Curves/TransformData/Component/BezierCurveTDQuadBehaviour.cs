namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveTDQuadBehaviour: ICurveTDComponent<BezierCurveTDQuad>
	{
		private void Reset()
		{
			Curve = new BezierCurveTDQuad();
		}
	}
}
