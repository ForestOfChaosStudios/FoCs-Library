#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: OnCollisionEvents.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaosLibrary.Extensions;
using UnityEngine;

namespace ForestOfChaosLibrary.Components {
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

        public void Sub(IOnCollisionEvents eventHandler) {
            OnCollEnter += eventHandler.CollisionEnter;
            OnCollStay  += eventHandler.CollisionStay;
            OnCollExit  += eventHandler.CollisionExit;
        }

        public void UnSub(IOnCollisionEvents eventHandler) {
            OnCollEnter -= eventHandler.CollisionEnter;
            OnCollStay  -= eventHandler.CollisionStay;
            OnCollExit  -= eventHandler.CollisionExit;
        }
    }

    public interface IOnCollisionEvents {
        void CollisionEnter(Collision collision);

        void CollisionStay(Collision collision);

        void CollisionExit(Collision collision);
    }
}