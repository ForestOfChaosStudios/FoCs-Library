#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: OnCollision2DEvents.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEngine;

namespace ForestOfChaos.Unity.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "On Collision 2D Events")]
    public class OnCollision2DEvents: FoCsBehaviour {
        public event Action<Collision2D> OnCollEnter;

        public event Action<Collision2D> OnCollStay;

        public event Action<Collision2D> OnCollExit;

        public void OnCollisionEnter2D(Collision2D collision2D) {
            OnCollEnter?.Invoke(collision2D);
        }

        public void OnCollisionStay2D(Collision2D collision2D) {
            OnCollStay?.Invoke(collision2D);
        }

        public void OnCollisionExit2D(Collision2D collision2D) {
            OnCollExit?.Invoke(collision2D);
        }
    }
}