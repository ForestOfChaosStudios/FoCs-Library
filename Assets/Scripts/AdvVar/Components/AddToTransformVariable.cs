namespace ForestOfChaosLib.AdvVar.Components
{
	public class AddToTransformVariable: FoCsBehaviour
	{
		public bool               RemoveOnDisable = true;
		public TransformReference TransformReference;

		public void OnEnable()
		{
			if(TransformReference)
				TransformReference.Value = Transform;
		}

		public void OnDisable()
		{
			if(TransformReference && RemoveOnDisable)
				TransformReference.Value = null;
		}

		private void OnDestroy()
		{
			if(TransformReference)
				TransformReference.Value = null;
		}
	}
}
