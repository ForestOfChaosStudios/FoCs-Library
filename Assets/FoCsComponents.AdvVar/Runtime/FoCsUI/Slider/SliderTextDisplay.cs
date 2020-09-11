#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components.AdvVar
//       File: SliderTextDisplay.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


#if TMP
using ForestOfChaosLib.Extensions;
using TMPro;

namespace ForestOfChaosLib.FoCsUI.Slider
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Slider/Toggle GameObjects")]
	public class SliderTextDisplay: FoCsBehaviour
	{
		public FoCsSlider      FoCsSlider;
		public string          NumberFormat = "0%";
		public bool            Percentage = true;
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