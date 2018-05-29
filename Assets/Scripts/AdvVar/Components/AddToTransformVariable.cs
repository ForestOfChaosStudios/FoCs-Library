namespace ForestOfChaosLib.AdvVar.Components
{
	public class AddToTransformVariable: FoCsBehavior
	{
		public TransformReference TransformReference;
		public bool               RemoveOnDisable = true;

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