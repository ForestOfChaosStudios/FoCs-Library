#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: DestroyAfterTime.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections;
using UnityEngine;

namespace ForestOfChaos.Unity.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "Destroy After Time")]
    public class DestroyAfterTime: FoCsBehaviour {
        public float lifeTime = 10f; //My lifetime

        private void Start() {
            StartCoroutine(Kill());
        }

        private IEnumerator Kill() {
            var waiter = new WaitForSeconds(lifeTime);

            yield return waiter;

            Destroy(gameObject); //Destroy object
        }
    }
}