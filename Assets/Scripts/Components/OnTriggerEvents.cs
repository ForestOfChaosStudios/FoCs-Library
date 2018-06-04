﻿using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.Components
{
	public class OnTriggerEvents: FoCsBehavior
	{
		public event Action<Collider> OnTrigEnter;
		public event Action<Collider> OnTrigStay;
		public event Action<Collider> OnTrigExit;

		public void OnTriggerEnter(Collider collision)
		{
			OnTrigEnter.Trigger(collision);
		}

		public void OnTriggerStay(Collider collision)
		{
			OnTrigStay.Trigger(collision);
		}

		public void OnTriggerExit(Collider collision)
		{
			OnTrigExit.Trigger(collision);
		}
	}
}
