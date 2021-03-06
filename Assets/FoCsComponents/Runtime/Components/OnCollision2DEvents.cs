﻿#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: OnCollision2DEvents.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.Extensions;
using UnityEngine;

namespace ForestOfChaos.Unity.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "On Collision 2D Events")]
    public class OnCollision2DEvents: FoCsBehaviour {
        public event Action<Collision2D> OnCollEnter;

        public event Action<Collision2D> OnCollStay;

        public event Action<Collision2D> OnCollExit;

        public void OnCollisionEnter2D(Collision2D collision2D) {
            OnCollEnter.Trigger(collision2D);
        }

        public void OnCollisionStay2D(Collision2D collision2D) {
            OnCollStay.Trigger(collision2D);
        }

        public void OnCollisionExit2D(Collision2D collision2D) {
            OnCollExit.Trigger(collision2D);
        }
    }
}