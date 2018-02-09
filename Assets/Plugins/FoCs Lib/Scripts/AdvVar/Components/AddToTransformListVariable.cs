namespace ForestOfChaosLib.AdvVar.Components
{
	public class AddToTransformListVariable: FoCsBehavior
	{
		public TransformListReference TransformListReference;

		public void OnEnable()
		{
			TransformListReference?.Add(transform);
		}

		public void OnDisable()
		{
			TransformListReference?.Remove(transform);
		}
	}
}