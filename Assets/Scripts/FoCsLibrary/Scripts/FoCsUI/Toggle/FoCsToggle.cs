using System;
using UnityEngine;
using UToggle = UnityEngine.UI.Toggle;

namespace ForestOfChaosLibrary.FoCsUI.Toggle
{
	public abstract class FoCsToggle: FoCsBehaviour
	{
		public          Action<bool> onValueChanged;
		public          UToggle      Toggle;
		public abstract string       Text   { get; set; }
		public abstract GameObject   TextGO { get; }

		public bool Interactable
		{
			get { return Toggle.interactable; }
			set { Toggle.interactable = value; }
		}

		public bool Toggled
		{
			get { return Toggle.isOn; }
			set { Toggle.isOn = value; }
		}

		private void MouseClick(bool value)
		{
			onValueChanged?.Invoke(value);
		}

		public void OnEnable()
		{
			if(Toggle)
				Toggle.onValueChanged.AddListener(MouseClick);
		}

		public void OnDisable()
		{
			if(Toggle)
				Toggle.onValueChanged.RemoveListener(MouseClick);
		}
	}
}
