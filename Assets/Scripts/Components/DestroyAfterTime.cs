using System.Collections;
using UnityEngine;

namespace ForestOfChaosLib.Components
{
	public class DestroyAfterTime: FoCsBehavior
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
