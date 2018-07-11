using UnityEngine;

namespace ForestOfChaosLib.Components.Syncs
{
	public class SyncGameObjectActiveState: FoCsBehaviour
	{
		public GameObjectStateEvents GameObjectToSync;
		private GameObject GameObject;

        private void OnEnable()
        {
	        GameObject = gameObject;

            GameObjectToSync.OnDisabled  += OnDisabled;
			GameObjectToSync.OnEnabled   += OnEnabled;
			GameObjectToSync.OnDestroyed += OnDestroy;
		}

		private void OnEnabled()
		{
			if(GameObject != null)
				GameObject.SetActive(true);
		}

		private void OnDisabled()
		{
			if(GameObject != null)
				GameObject.SetActive(false);
		}

		private void OnDestroy()
		{
			GameObjectToSync.OnDisabled  -= OnDisabled;
			GameObjectToSync.OnEnabled   -= OnEnabled;
			GameObjectToSync.OnDestroyed -= OnDestroy;
		}
	}
}