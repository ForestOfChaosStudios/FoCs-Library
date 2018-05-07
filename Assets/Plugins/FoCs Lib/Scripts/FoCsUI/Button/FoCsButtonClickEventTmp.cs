using TMPro;
using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.Button
{
	public class FoCsButtonClickEventTmp: FoCsButton
	{
		public TextMeshProUGUI TextObj;

		public override string Text
		{
			get
			{
				return TextObj == null?
					"" :
					TextObj.text;
			}
			set
			{
				if(TextObj != null)
					TextObj.text = value;
			}
		}

		public override GameObject TextGO => TextObj.gameObject;

		private void Reset()
		{
			Button = GetComponentAdvanced<UnityEngine.UI.Button>();
			TextObj = GetComponentInChildrenAdvanced<TextMeshProUGUI>();
		}
	}
}