using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "On Trigger 2D Events")]
	public class OnTrigger2DEvents: FoCsBehaviour
	{
		public event Action<Collider2D> OnTrigEnter;
		public event Action<Collider2D> OnTrigStay;
		public event Action<Collider2D> OnTrigExit;

		public void OnTriggerEnter2D(Collider2D collision2D)
		{
			OnTrigEnter.Trigger(collision2D);
		}

		public void OnTriggerStay2D(Collider2D collision2D)
		{
			OnTrigStay.Trigger(collision2D);
		}

		public void OnTriggerExit2D(Collider2D collision2D)
		{
			OnTrigExit.Trigger(collision2D);
		}
	}
}
