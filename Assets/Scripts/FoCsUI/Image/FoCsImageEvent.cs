using UnityEngine;
using UnityEngine.UI;

namespace ForestOfChaosLib.FoCsUI.Image
{
	public class FoCsImageEvent: FoCsImage
	{
		public Text TextObj;
		public override string Text
		{
			get { return TextObj == null? "" : TextObj.text; }
			set
			{
				if(TextObj != null)
					TextObj.text = value;
			}
		}
		public override GameObject TextGO => TextObj.gameObject;

		private void Reset()
		{
			Image   = GetComponentAdvanced<UnityEngine.UI.Image>();
			TextObj = GetComponentInChildrenAdvanced<Text>();
		}
	}
}