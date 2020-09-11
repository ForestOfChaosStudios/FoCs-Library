#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: SyncGameObjectActiveState.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using UnityEngine;

namespace ForestOfChaos.Unity.Components.Syncs {
    [AddComponentMenu(FoCsStrings.COMPONENTS_SYNC_FOLDER_ + "GameObject Sync")]
    public class SyncGameObjectActiveState: FoCsBehaviour {
        private GameObject            GameObject;
        public  GameObjectStateEvents GameObjectToSync;

        private void OnEnable() {
            GameObject                   =  gameObject;
            GameObjectToSync.OnDisabled  += OnDisabled;
            GameObjectToSync.OnEnabled   += OnEnabled;
            GameObjectToSync.OnDestroyed += OnDestroy;
        }

        private void OnEnabled() {
            if (GameObject != null)
                GameObject.SetActive(true);
        }

        private void OnDisabled() {
            if (GameObject != null)
                GameObject.SetActive(false);
        }

        private void OnDestroy() {
            GameObjectToSync.OnDisabled  -= OnDisabled;
            GameObjectToSync.OnEnabled   -= OnEnabled;
            GameObjectToSync.OnDestroyed -= OnDestroy;
        }
    }
}