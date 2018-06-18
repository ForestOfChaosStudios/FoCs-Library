namespace ForestOfChaosLib.AdvVar.Components
{
	public class AddToTransformListVariable: FoCsBehaviour
	{
		public TransformListReference TransformListReference;

		public void OnEnable()
		{
			if(TransformListReference)
				TransformListReference.Add(transform);
		}

		public void OnDisable()
		{
			if(TransformListReference)
				TransformListReference.Remove(transform);
		}
	}
}
