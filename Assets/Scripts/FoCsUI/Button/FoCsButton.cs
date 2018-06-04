using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;
using UButton = UnityEngine.UI.Button;

namespace ForestOfChaosLib.FoCsUI.Button
{
	public abstract class FoCsButton: FoCsBehavior
	{
		public          UButton    Button;
		public          Action     onMouseClick = () => { };
		public abstract string     Text   { get; set; }
		public abstract GameObject TextGO { get; }

		public bool Interactable
		{
			get { return Button.interactable; }
			set { Button.interactable = value; }
		}

		private void MouseClick()
		{
			onMouseClick.Trigger();
		}

		public void OnEnable()
		{
			if(Button)
				Button.onClick.AddListener(MouseClick);
		}

		public void OnDisable()
		{
			if(Button)
				Button.onClick.RemoveListener(MouseClick);
		}
	}
}
