#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: SyncComponentActiveWithGameObject.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/RunTime/" + "Sync Component to GameObject State")]
    public class SyncComponentActiveWithGameObject: FoCsBehaviour {
        public MonoBehaviourRunTimeRef MonoBehaviourRunTimeRef;

        private void OnEnable() {
            if (!MonoBehaviourRunTimeRef)
                return;

            if (MonoBehaviourRunTimeRef.Reference)
                MonoBehaviourRunTimeRef.Reference.enabled = true;
        }

        private void OnDisable() {
            if (!MonoBehaviourRunTimeRef)
                return;

            if (MonoBehaviourRunTimeRef.Reference)
                MonoBehaviourRunTimeRef.Reference.enabled = false;
        }
    }
}