#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: DisableAfterTime.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections;
using UnityEngine;

namespace ForestOfChaos.Unity.Components {
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