using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;
using UToggle = UnityEngine.UI.Toggle;

namespace ForestOfChaosLib.FoCsUI
{
	[RequireComponent(typeof(UToggle))]
	public class ToggleEvents: FoCsBehaviour
	{
		public UToggle Toggle;
		public Action<bool> onValueChanged;
		public bool Value
		{
			get { return Toggle.isOn; }
			set { Toggle.isOn = value; }
		}

		private void OnEnable()
		{
			if(Toggle == null)
				Toggle = GetComponent<UToggle>();

			Toggle.onValueChanged.AddListener(ValueChanged);
		}

		private void OnDisable()
		{
			Toggle.onValueChanged.RemoveListener(ValueChanged);
		}

		private void ValueChanged(bool value)
		{
			onValueChanged.Trigger(value);
		}
	}
}