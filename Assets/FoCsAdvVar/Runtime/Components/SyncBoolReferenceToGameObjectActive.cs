#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: SyncBoolReferenceToGameObjectActive.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
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