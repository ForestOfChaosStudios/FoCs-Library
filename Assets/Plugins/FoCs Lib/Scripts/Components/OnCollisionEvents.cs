using System;
using ForestOfChaosLib.Interfaces;
using ForestOfChaosLib.CSharpExtensions;
using UnityEngine;

namespace ForestOfChaosLib.Components
{
	public class OnCollisionEvents: FoCsBehavior, IOnCollision
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