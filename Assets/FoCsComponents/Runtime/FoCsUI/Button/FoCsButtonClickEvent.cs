using UnityEngine;
using UText = UnityEngine.UI.Text;
using UButton = UnityEngine.UI.Button;

namespace ForestOfChaosLibrary.FoCsUI.Button
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Button/Button (Unity Text)")]
	public class FoCsButtonClickEvent: FoCsButton
	{
		public UText TextObj;

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
			Button  = GetComponent<UButton>();
			TextObj = GetComponentInChildren<UText>();
		}
	}
}
