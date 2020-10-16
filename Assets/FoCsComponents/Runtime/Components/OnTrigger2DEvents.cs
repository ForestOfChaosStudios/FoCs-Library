#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: OnTrigger2DEvents.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.Extensions;
using UnityEngine;

namespace ForestOfChaos.Unity.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "On Trigger 2D Events")]
    public class OnTrigger2DEvents: FoCsBehaviour {
        public event Action<Collider2D> OnTrigEnter;

        public event Action<Collider2D> OnTrigStay;

        public event Action<Collider2D> OnTrigExit;

        public void OnTriggerEnter2D(Collider2D collision2D) {
            OnTrigEnter.Trigger(collision2D);
        }

        public void OnTriggerStay2D(Collider2D collision2D) {
            OnTrigStay.Trigger(collision2D);
        }

        public void OnTriggerExit2D(Collider2D collision2D) {
            OnTrigExit.Trigger(collision2D);
        }
    }
}