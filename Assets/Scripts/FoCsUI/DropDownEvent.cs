using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace ForestOfChaosLib.FoCsUI
{
	[RequireComponent(typeof(Dropdown))]
	public class DropDownEvent: FoCsBehaviour
	{
		public Dropdown    _DropDown;
		public Action<int> onValueChanged;

		public int Value
		{
			get { return _DropDown.value; }
			set { _DropDown.value = value; }
		}

		private void OnEnable()
		{
			if(_DropDown == null)
				_DropDown = GetComponent<Dropdown>();

			_DropDown.onValueChanged.AddListener(ValueChanged);
		}

		private void OnDisable()
		{
			_DropDown.onValueChanged.RemoveListener(ValueChanged);
		}

		private void ValueChanged(int value)
		{
			onValueChanged.Trigger(value);
		}
	}
}
