using System.Collections;
using UnityEngine;

namespace ForestOfChaosLib.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "Disable After Time")]
	public class DisableAfterTime: FoCsBehaviour
	{
		public float lifeTime = 1f; //My lifetime

		public void OnEnable()
		{
			StartCoroutine(Disable());
		}

		private IEnumerator Disable()
		{
			var waiter = new WaitForSeconds(lifeTime);

			yield return waiter;

			gameObject.SetActive(false);
		}
	}
}
