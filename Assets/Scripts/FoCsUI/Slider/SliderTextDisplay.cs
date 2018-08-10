#if TMP
using ForestOfChaosLib.Extensions;
using TMPro;

namespace ForestOfChaosLib.FoCsUI.Slider
{
	public class SliderTextDisplay: FoCsBehaviour
	{
		public FoCsSlider      FoCsSlider;
		public string          NumberFormat = "0%";
		public bool            Percentage   = true;
		public TextMeshProUGUI Text;

		private void OnEnable()
		{
			FoCsSlider.OnValueChanged += OnValueChanged;
			OnValueChanged(FoCsSlider.Value);
		}

		private void OnValueChanged(float f)
		{
			if(Text)
			{
				if(Percentage)
					Text.text = NumberFormat.IsNullOrEmpty()? GetPercentage(f).ToString() : GetPercentage(f).ToString(NumberFormat);
				else
					Text.text = NumberFormat.IsNullOrEmpty()? FoCsSlider.Value.ToString() : FoCsSlider.Value.ToString(NumberFormat);
			}
		}

		private float GetPercentage(float f) => (f - FoCsSlider.slider.minValue) / (FoCsSlider.slider.maxValue - FoCsSlider.slider.minValue);

		private void OnDisable()
		{
			FoCsSlider.OnValueChanged -= OnValueChanged;
		}
	}
}
#endif