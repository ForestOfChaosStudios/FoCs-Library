#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: GameObjectStateEvents.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.Extensions;
using UnityEngine;

namespace ForestOfChaos.Unity.Components.Syncs {
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