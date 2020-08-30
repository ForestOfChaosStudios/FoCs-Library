#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.AdvVar
//       File: SyncComponentActiveWithGameObject.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:47 AM
#endregion


using ForestOfChaosLibrary;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/RunTime/" + "Sync Component to GameObject State")]
    public class SyncComponentActiveWithGameObject: FoCsBehaviour {
        public MonoBehaviourRunTimeRef MonoBehaviourRunTimeRef;

        private void OnEnable() {
            if (MonoBehaviourRunTimeRef) {
                if (MonoBehaviourRunTimeRef.Reference)
                    MonoBehaviourRunTimeRef.Reference.enabled = true;
            }
        }

        private void OnDisable() {
            if (MonoBehaviourRunTimeRef) {
                if (MonoBehaviourRunTimeRef.Reference)
                    MonoBehaviourRunTimeRef.Reference.enabled = false;
            }
        }
    }
}