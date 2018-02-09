using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UImage = UnityEngine.UI.Image;

namespace ForestOfChaosLib.FoCsUI.Image
{
	[System.Serializable]
	public struct ImageText
	{
		public UImage Image; //Image
		public Text Text; //Buttons text

		/// <summary>
		/// Get text in children.
		/// </summary>
		public void GetTextObj()
		{
			if(Text)
				return;
			Text = Image.GetComponentInChildren<Text>();
		}

		public void OnEnable(GameObject gO)
		{
			if(Image == null)
				Image = gO.GetComponent<UImage>();
			GetTextObj();
		}

		/// <summary>
		/// Set Text in Text.
		/// </summary>
		/// <param name="t">Value to set text</param>
		public void SetText(string t = "")
		{
			Text.text = t;
		}

		/// <summary>
		/// Returns Text from Text.
		/// </summary>
		/// <returns>The current text in Text</returns>
		public string GetText()
		{
			return (Text.text.ToString());
		}

		public static implicit operator UImage(ImageText it)
		{
			return it.Image;
		}

		public static implicit operator Text(ImageText it)
		{
			return it.Text;
		}
	}

	//#if TextMeshPro_DEFINE
	[System.Serializable]
	public struct ImageText_TMP
	{
		public UImage Image; //Image
		public TextMeshProUGUI Text; //Buttons text

		/// <summary>
		/// Get text in children.
		/// </summary>
		public void GetTextObj()
		{
			if(Text)
				return;
			Text = Image.GetComponentInChildren<TextMeshProUGUI>();
		}

		public void OnEnable(GameObject gO)
		{
			if(Image == null)
				Image = gO.GetComponent<UImage>();
			GetTextObj();
		}

		/// <summary>
		/// Set Text in Text.
		/// </summary>
		/// <param name="t">Value to set text</param>
		public void SetText(string t = "")
		{
			Text.text = t;
		}

		/// <summary>
		/// Returns Text from Text.
		/// </summary>
		/// <returns>The current text in Text</returns>
		public string GetText()
		{
			return (Text.text.ToString());
		}

		public static implicit operator UImage(ImageText_TMP it)
		{
			return it.Image;
		}

		public static implicit operator TextMeshProUGUI(ImageText_TMP it)
		{
			return it.Text;
		}
	}

	//#endif
}