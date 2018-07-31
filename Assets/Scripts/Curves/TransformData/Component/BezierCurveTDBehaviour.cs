namespace ForestOfChaosLib.Curves.Components
{
	public class BezierCurveTDBehaviour: ICurveTDComponent<BezierCurveTD>
	{
		private void Reset()
		{
			Curve = new BezierCurveTD();
		}
	}
}
