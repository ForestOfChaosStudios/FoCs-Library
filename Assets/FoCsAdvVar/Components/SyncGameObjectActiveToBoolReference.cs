#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: SyncGameObjectActiveToBoolReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/" + "Sync GameObject Active to Bool Reference")]
    public class SyncGameObjectActiveToBoolReference: FoCsBehaviour {
        public BoolReference Reference;

        private void OnEnable() {
            if (Reference)
                Reference.OnValueChange += ChangeState;
        }

        private void ChangeState(bool before, bool after) {
            gameObject.SetActive(Reference.Value);
        }

        private void OnDestroy() {
            if (Reference)
                Reference.OnValueChange -= ChangeState;
        }
    }
}