namespace ForestOfChaosLib.AdvVar.Components
{
	public class AddToGameObjectVariable: FoCsBehaviour
	{
		public GameObjectReference GameObjectReference;
		public bool                RemoveOnDisable = true;

		public void OnEnable()
		{
			if(GameObjectReference)
				GameObjectReference.Value = gameObject;
		}

		public void OnDisable()
		{
			if(GameObjectReference && RemoveOnDisable)
				GameObjectReference.Value = null;
		}

		private void OnDestroy()
		{
			if(GameObjectReference)
				GameObjectReference.Value = null;
		}
	}
}
