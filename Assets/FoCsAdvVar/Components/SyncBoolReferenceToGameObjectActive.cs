#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: SyncBoolReferenceToGameObjectActive.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/" + "Sync Bool Reference to GameObject Active")]
    public class SyncBoolReferenceToGameObjectActive: FoCsBehaviour {
        public BoolReference Reference;

        private void OnEnable() {
            Reference.Value = true;
        }

        private void OnDisable() {
            Reference.Value = false;
        }
    }
}