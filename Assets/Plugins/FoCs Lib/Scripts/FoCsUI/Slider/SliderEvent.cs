using System;
using ForestOfChaosLib.AdvVar;
using ForestOfChaosLib.Attributes;
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
		public bool UseFloatReference;
		[ConditionalHide("UseFloatReference", false)]
		public FloatReference ReferencedFloat;

		protected virtual void OnEnable()
		{
			if(slider == null)
				slider = GetComponent<USlider>();
			if(slider != null)
			{
				slider.onValueChanged.AddListener(ValueChanged);
				if(UseFloatReference)
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
			onValueChanged.Trigger(value);
			if(UseFloatReference)
				ReferencedFloat.Value = value;
		}

		void Reset()
		{
			slider = GetComponentInChildren<USlider>();
		}
	}
}