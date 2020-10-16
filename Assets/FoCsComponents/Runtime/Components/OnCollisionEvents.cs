#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: OnCollisionEvents.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.Extensions;
using UnityEngine;

namespace ForestOfChaos.Unity.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "On Collision Events")]
    public class OnCollisionEvents: FoCsBehaviour {
        public event Action<Collision> OnCollEnter;

        public event Action<Collision> OnCollStay;

        public event Action<Collision> OnCollExit;

        public void OnCollisionEnter(Collision collision) {
            OnCollEnter.Trigger(collision);
        }

        public void OnCollisionStay(Collision collision) {
            OnCollStay.Trigger(collision);
        }

        public void OnCollisionExit(Collision collision) {
            OnCollExit.Trigger(collision);
        }
    }
}