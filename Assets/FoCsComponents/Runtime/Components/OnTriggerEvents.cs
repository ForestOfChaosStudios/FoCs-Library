#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: OnTriggerEvents.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.Extensions;
using UnityEngine;

namespace ForestOfChaos.Unity.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "On Trigger Events")]
    public class OnTriggerEvents: FoCsBehaviour {
        public event Action<Collider> OnTrigEnter;

        public event Action<Collider> OnTrigStay;

        public event Action<Collider> OnTrigExit;

        public void OnTriggerEnter(Collider collision) {
            OnTrigEnter.Trigger(collision);
        }

        public void OnTriggerStay(Collider collision) {
            OnTrigStay.Trigger(collision);
        }

        public void OnTriggerExit(Collider collision) {
            OnTrigExit.Trigger(collision);
        }
    }
}