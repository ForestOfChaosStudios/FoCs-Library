using TMPro;
using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.Image
{
	public class FoCsImageEventTmp: FoCsImage
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
			Image = GetComponentAdvanced<UnityEngine.UI.Image>();
			TextObj = GetComponentInChildrenAdvanced<TextMeshProUGUI>();
		}
	}
}