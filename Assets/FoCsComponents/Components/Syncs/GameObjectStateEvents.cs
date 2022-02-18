#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: GameObjectStateEvents.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEngine;

namespace ForestOfChaos.Unity.Components.Syncs {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "GameObject State Events")]
    public class GameObjectStateEvents: FoCsBehaviour {
        public Action OnDestroyed;
        public Action OnDisabled;
        public Action OnEnabled;

        private void OnEnable() {
            OnEnabled?.Invoke();
        }

        private void OnDisable() {
            OnDisabled?.Invoke();
        }

        private void OnDestroy() {
            OnDestroyed?.Invoke();
        }
    }
}