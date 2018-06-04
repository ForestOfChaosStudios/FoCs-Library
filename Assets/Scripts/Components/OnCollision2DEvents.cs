using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.Components
{
	public class OnCollision2DEvents: FoCsBehavior
	{
		public event Action<Collision2D> OnCollEnter;
		public event Action<Collision2D> OnCollStay;
		public event Action<Collision2D> OnCollExit;

		public void OnCollisionEnter2D(Collision2D collision2D)
		{
			OnCollEnter.Trigger(collision2D);
		}

		public void OnCollisionStay2D(Collision2D collision2D)
		{
			OnCollStay.Trigger(collision2D);
		}

		public void OnCollisionExit2D(Collision2D collision2D)
		{
			OnCollExit.Trigger(collision2D);
		}
	}
}
