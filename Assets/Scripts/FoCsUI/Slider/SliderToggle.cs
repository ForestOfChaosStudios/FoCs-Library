using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PostProcessing;

namespace ForestOfChaosLib.FoCsUI.Slider
{
	public class SliderToggle: FoCsSlider, IPointerClickHandler
	{
		public                                       Action<bool> OnToggle;
		[SerializeField] [GetSet("Toggled")] private bool         toggled;

		public bool Toggled
		{
			get { return toggled; }
			set
			{
				toggled = value;
				Toggle(toggled);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			slider.minValue = 0;
			slider.maxValue = 1;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			Toggle();
			Debug.Log(nameof(OnPointerDown));
		}

		private void Toggle()
		{
			toggled = !toggled;
			OnToggle.Trigger(toggled);
			slider.value = toggled? 1 : 0;
		}

		private void Toggle(bool val)
		{
			OnToggle.Trigger(val);
			slider.value = val? 1 : 0;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			Toggle();
		}
	}
}
