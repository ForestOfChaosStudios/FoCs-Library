using ForestOfChaosLib.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UButton = UnityEngine.UI.Button;

namespace ForestOfChaosLib.FoCsUI.Button
{
	/// <summary>
	/// This struct contains the refferance for the button and its text.
	/// </summary>
	[System.Serializable]
	public struct ButtonText
	{
		[Half10Line]
		public UButton Btn; //Button

		[Half01Line]
		public Text Text; //Buttons text

		/// <summary>
		/// Get text in children.
		/// </summary>
		public void GetTextObj()
		{
			if(Text)
				return;
			Text = Btn.GetComponentInChildren<Text>();
		}

		public void OnEnable(GameObject gO)
		{
			if(Btn == null)
				Btn = gO.GetComponent<UButton>();
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

		public static implicit operator UButton(ButtonText bt)
		{
			return bt.Btn;
		}

		public static implicit operator Text(ButtonText bt)
		{
			return bt.Text;
		}
	}

	[System.Serializable]
	public struct ButtonText_TMP
	{
		[Half10Line]
		public UButton Btn; //Button

		[Half01Line]
		public TextMeshProUGUI Text; //Buttons text

		/// <summary>
		/// Get text in children.
		/// </summary>
		public void GetTextObj()
		{
			if(Text)
				return;
			Text = Btn.GetComponentInChildren<TextMeshProUGUI>();
		}

		public void OnEnable(GameObject gO)
		{
			if(Btn == null)
				Btn = gO.GetComponent<UButton>();
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

		public static implicit operator UButton(ButtonText_TMP bt)
		{
			return bt.Btn;
		}

		public static implicit operator TextMeshProUGUI(ButtonText_TMP bt)
		{
			return bt.Text;
		}
	}
}