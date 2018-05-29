using System;
using ForestOfChaosLib.AdvVar;
using ForestOfChaosLib.Extensions;
using USlider = UnityEngine.UI.Slider;

namespace ForestOfChaosLib.FoCsUI.Slider
{
	public class FoCsSlider: FoCsBehavior
	{
		public USlider        slider;
		public float          Value { get { return slider.value; } set { slider.value = value; } }
		public Action<float>  OnValueChanged;
		public FloatReference ReferencedFloat;

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

		void Reset() { slider = GetComponentInChildren<USlider>(); }
	}
}