using System;
using ForestOfChaosLibrary.Extensions;
using ForestOfChaosAdvVar;
using UnityEngine;
using USlider = UnityEngine.UI.Slider;

namespace ForestOfChaosLibrary.FoCsUI.Slider
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Slider/Slider")]
	public class FoCsSlider: FoCsBehaviour
	{
		public Action<float>  OnValueChanged;
		public FloatReference ReferencedFloat;
		public USlider        slider;

		public float Value
		{
			get { return slider.value; }
			set { slider.value = value; }
		}

		protected virtual void OnEnable()
		{
			if(slider == null)
				slider = GetComponent<USlider>();

			if(slider != null)
			{
				slider.onValueChanged.AddListener(ValueChanged);

				if(ReferencedFloat)
					slider.value = ReferencedFloat.Value;
			}
		}

		protected virtual void OnDisable()
		{
			if(slider != null)
				slider.onValueChanged.RemoveListener(ValueChanged);
		}

		public void ValueChanged(float value)
		{
			OnValueChanged.Trigger(value);

			if(ReferencedFloat)
				ReferencedFloat.Value = value;
		}

		private void Reset()
		{
			slider = GetComponentInChildren<USlider>();
		}
	}
}
