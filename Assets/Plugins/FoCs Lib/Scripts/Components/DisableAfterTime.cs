using System.Collections;
using ForestOfChaosLib.Interfaces;
using UnityEngine;

namespace ForestOfChaosLib.Components
{
	public class DisableAfterTime: FoCsBehavior, IOnEnable
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