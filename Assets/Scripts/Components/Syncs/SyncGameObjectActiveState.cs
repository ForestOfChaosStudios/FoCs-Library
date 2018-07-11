namespace ForestOfChaosLib.Components.Syncs
{
	public class SyncGameObjectActiveState: FoCsBehaviour
	{
		public GameObjectStateEvents GameObjectToSync;

		private void OnEnable()
		{
			GameObjectToSync.OnDisabled += OnDisabled;
			GameObjectToSync.OnEnabled  += OnEnabled;
			GameObjectToSync.OnDestroyed  += OnDestroy;
        }

		private void OnEnabled()
		{
			gameObject.SetActive(true);
		}

		private void OnDisabled()
		{
			gameObject.SetActive(false);
		}

		private void OnDestroy()
		{
			GameObjectToSync.OnDisabled  -= OnDisabled;
			GameObjectToSync.OnEnabled   -= OnEnabled;
			GameObjectToSync.OnDestroyed -= OnDestroy;
        }
	}
}