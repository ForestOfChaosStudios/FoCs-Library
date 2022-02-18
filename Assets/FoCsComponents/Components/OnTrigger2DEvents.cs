#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: OnTrigger2DEvents.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEngine;

namespace ForestOfChaos.Unity.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "On Trigger 2D Events")]
    public class OnTrigger2DEvents: FoCsBehaviour {
        public event Action<Collider2D> OnTrigEnter;

        public event Action<Collider2D> OnTrigStay;

        public event Action<Collider2D> OnTrigExit;

        public void OnTriggerEnter2D(Collider2D collision2D) {
            OnTrigEnter?.Invoke(collision2D);
        }

        public void OnTriggerStay2D(Collider2D collision2D) {
            OnTrigStay?.Invoke(collision2D);
        }

        public void OnTriggerExit2D(Collider2D collision2D) {
            OnTrigExit?.Invoke(collision2D);
        }
    }
}