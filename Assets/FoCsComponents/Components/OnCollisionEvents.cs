#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: OnCollisionEvents.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEngine;

namespace ForestOfChaos.Unity.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "On Collision Events")]
    public class OnCollisionEvents: FoCsBehaviour {
        public event Action<Collision> OnCollEnter;

        public event Action<Collision> OnCollStay;

        public event Action<Collision> OnCollExit;

        public void OnCollisionEnter(Collision collision) {
            OnCollEnter?.Invoke(collision);
        }

        public void OnCollisionStay(Collision collision) {
            OnCollStay?.Invoke(collision);
        }

        public void OnCollisionExit(Collision collision) {
            OnCollExit?.Invoke(collision);
        }
    }
}