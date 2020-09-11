#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: DisableAfterTime.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System.Collections;
using UnityEngine;

namespace ForestOfChaosLibrary.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "Disable After Time")]
    public class DisableAfterTime: FoCsBehaviour {
        public float lifeTime = 1f; //My lifetime

        public void OnEnable() {
            StartCoroutine(Disable());
        }

        private IEnumerator Disable() {
            var waiter = new WaitForSeconds(lifeTime);

            yield return waiter;

            gameObject.SetActive(false);
        }
    }
}