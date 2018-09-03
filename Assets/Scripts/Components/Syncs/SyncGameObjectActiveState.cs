using UnityEngine;

namespace ForestOfChaosLib.Components.Syncs
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_SYNC_FOLDER_ + "GameObject Sync")]
	public class SyncGameObjectActiveState: FoCsBehaviour
	{
		private GameObject            GameObject;
		public  GameObjectStateEvents GameObjectToSync;

		private void OnEnable()
		{
			GameObject                   =  gameObject;
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
