namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveTDDoubleBehaviour: ICurveTDComponent<BezierCurveTDDouble>
	{
		private void Reset()
		{
			Curve = new BezierCurveTDDouble();
		}
	}
}
