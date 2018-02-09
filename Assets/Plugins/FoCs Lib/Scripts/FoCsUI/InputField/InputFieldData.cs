using UnityEngine;
using UInputField = UnityEngine.UI.InputField;
using TMPInputField = TMPro.TMP_InputField;

namespace ForestOfChaosLib.FoCsUI.InputField
{
	[System.Serializable]
	public struct InputFieldData
	{
		public UInputField InputField;

		public string Text
		{
			get { return InputField.text; }
			set { InputField.text = value; }
		}

		public void OnEnable(GameObject gO)
		{
			if(InputField == null)
				InputField = gO.GetComponent<UInputField>();
		}

		/// <summary>
		/// Set Text in Text.
		/// </summary>
		/// <param name="t">Value to set text</param>
		public void SetText(string t = "")
		{
			InputField.text = t;
		}

		/// <summary>
		/// Returns Text from Text.
		/// </summary>
		/// <returns>The current text in Text</returns>
		public string GetText()
		{
			return (InputField.text);
		}
	}

	[System.Serializable]
	public struct InputFieldData_TMP
	{
		public TMPInputField InputField;

		public string Text
		{
			get { return InputField.text; }
			set { InputField.text = value; }
		}

		public void OnEnable(GameObject gO)
		{
			if(InputField == null)
				InputField = gO.GetComponent<TMPInputField>();
		}

		/// <summary>
		/// Set Text in Text.
		/// </summary>
		/// <param name="t">Value to set text</param>
		public void SetText(string t = "")
		{
			InputField.text = t;
		}

		/// <summary>
		/// Returns Text from Text.
		/// </summary>
		/// <returns>The current text in Text</returns>
		public string GetText()
		{
			return (InputField.text);
		}
	}
}