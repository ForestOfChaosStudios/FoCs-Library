#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: OnTriggerEvents.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEngine;

namespace ForestOfChaos.Unity.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "On Trigger Events")]
    public class OnTriggerEvents: FoCsBehaviour {
        public event Action<Collider> OnTrigEnter;

        public event Action<Collider> OnTrigStay;

        public event Action<Collider> OnTrigExit;

        public void OnTriggerEnter(Collider collision) {
            OnTrigEnter?.Invoke(collision);
        }

        public void OnTriggerStay(Collider collision) {
            OnTrigStay?.Invoke(collision);
        }

        public void OnTriggerExit(Collider collision) {
            OnTrigExit?.Invoke(collision);
        }
    }
}