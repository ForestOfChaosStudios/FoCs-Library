using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ForestOfChaosLib.FoCsUI.Image
{
	public class FoCsTextEvent: FoCsText
	{
		public Text TextObj;

		public override string Text
		{
			get { return TextObj.text; }
			set { TextObj.text = value; }
		}

		public override GameObject TextGO => TextObj.gameObject;

		private void Reset()
		{
			TextObj = GetComponentInChildren<Text>();
		}
	}
}