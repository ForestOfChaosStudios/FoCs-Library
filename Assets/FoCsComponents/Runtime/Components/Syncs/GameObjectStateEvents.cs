#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Components
//       File: GameObjectStateEvents.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System;
using ForestOfChaosLibrary.Extensions;
using UnityEngine;

namespace ForestOfChaosLibrary.Components.Syncs {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "GameObject State Events")]
    public class GameObjectStateEvents: FoCsBehaviour {
        public Action OnDestroyed;
        public Action OnDisabled;
        public Action OnEnabled;

        private void OnEnable() {
            OnEnabled.Trigger();
        }

        private void OnDisable() {
            OnDisabled.Trigger();
        }

        private void OnDestroy() {
            OnDestroyed.Trigger();
        }
    }
}