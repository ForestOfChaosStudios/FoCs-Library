using System.Collections;
using UnityEngine;

namespace ForestOfChaosLib.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "Destroy After Time")]
	public class DestroyAfterTime: FoCsBehaviour
	{
		public float lifeTime = 10f; //My lifetime

		private void Start()
		{
			StartCoroutine(Kill());
		}

		private IEnumerator Kill()
		{
			var waiter = new WaitForSeconds(lifeTime);

			yield return waiter;

			Destroy(gameObject); //Destroy object
		}
	}
}
