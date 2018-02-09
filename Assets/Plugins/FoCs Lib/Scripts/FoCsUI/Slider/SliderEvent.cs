using System;
using ForestOfChaosLib.Components;
using ForestOfChaosLib.CSharpExtensions;
using USlider = UnityEngine.UI.Slider;

namespace ForestOfChaosLib.FoCsUI.Slider
{
	public class SliderEvent: FoCsBehavior
	{
		public USlider slider;

		public float Value
		{
			get { return slider.value; }
			set { slider.value = value; }
		}

		public Action<float> onValueChanged;

		protected virtual void OnEnable()
		{
			if(slider == null)
				slider = GetComponent<USlider>();
			if(slider != null)
			{
				slider.onValueChanged.AddListener(ValueChanged);
			}
		}

		protected virtual void OnDisable()
		{
			if(slider != null)
				slider.onValueChanged.RemoveListener(ValueChanged);
		}

		public void ValueChanged(float value)
		{
			onValueChanged.Trigger(value);
		}

		void Reset()
		{
			slider = GetComponentInChildren<USlider>();
		}
	}
}