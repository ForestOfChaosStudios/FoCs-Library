namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	public class SyncComponentActiveWithGameObject: FoCsBehavior
	{
		public MonoBehaviourRTRef MonoBehaviourRTRef;

		private void OnEnable()
		{
			if(MonoBehaviourRTRef)
			{
				if(MonoBehaviourRTRef.Reference)
					MonoBehaviourRTRef.Reference.enabled = true;
			}
		}

		private void OnDisable()
		{
			if(MonoBehaviourRTRef)
			{
				if(MonoBehaviourRTRef.Reference)
					MonoBehaviourRTRef.Reference.enabled = false;
			}
		}
	}
}