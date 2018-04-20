using ForestOfChaosLib.Components;
using ForestOfChaosLib.CSharpExtensions;
using TMPro;

namespace ForestOfChaosLib.FoCsUI.Slider
{
	public class SliderTextDisplay: FoCsBehavior
	{
		public TextMeshProUGUI Text;
		public SliderEvent SliderEvent;
		public bool Percentage = true;

		public string NumberFormat = "0%";

		private void OnEnable()
		{
			SliderEvent.OnValueChanged += OnValueChanged;
			OnValueChanged(SliderEvent.Value);
		}

		private void OnValueChanged(float f)
		{
			if(Text)
			{
				if(Percentage)
					Text.text = NumberFormat.IsNullOrEmpty()? GetPercentage(f).ToString() : GetPercentage(f).ToString(NumberFormat);
				else
					Text.text = NumberFormat.IsNullOrEmpty()? SliderEvent.Value.ToString() : SliderEvent.Value.ToString(NumberFormat);
			}
		}

		private float GetPercentage(float f)
		{
			return (f - SliderEvent.slider.minValue) / (SliderEvent.slider.maxValue - SliderEvent.slider.minValue);
		}

		private void OnDisable()
		{
			SliderEvent.OnValueChanged -= OnValueChanged;
		}
	}
}