using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.Components
{
	public class OnCollisionEvents: FoCsBehaviour
	{
		public event Action<Collision> OnCollEnter;
		public event Action<Collision> OnCollStay;
		public event Action<Collision> OnCollExit;

		public void OnCollisionEnter(Collision collision)
		{
			OnCollEnter.Trigger(collision);
		}

		public void OnCollisionStay(Collision collision)
		{
			OnCollStay.Trigger(collision);
		}

		public void OnCollisionExit(Collision collision)
		{
			OnCollExit.Trigger(collision);
		}
	}
}