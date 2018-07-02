using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace ForestOfChaosLib.FoCsUI
{
	[RequireComponent(typeof(Toggle))]
	public class ToggleEvents: FoCsBehaviour
	{
		public Toggle       _Toggle;
		public Action<bool> onValueChanged;
		public bool Value
		{
			get { return _Toggle.isOn; }
			set { _Toggle.isOn = value; }
		}

		private void OnEnable()
		{
			if(_Toggle == null)
				_Toggle = GetComponent<Toggle>();

			_Toggle.onValueChanged.AddListener(ValueChanged);
		}

		private void OnDisable()
		{
			_Toggle.onValueChanged.RemoveListener(ValueChanged);
		}

		private void ValueChanged(bool value)
		{
			onValueChanged.Trigger(value);
		}
	}
}