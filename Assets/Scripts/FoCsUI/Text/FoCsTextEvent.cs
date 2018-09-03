using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.Text
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Toggle/Events (Unity Text)")]
	public class FoCsTextEvent: FoCsText
	{
		public UnityEngine.UI.Text TextObj;

		public override string Text
		{
			get { return TextObj.text; }
			set { TextObj.text = value; }
		}

		public override GameObject TextGO => TextObj.gameObject;

		private void Reset()
		{
			TextObj = GetComponentInChildren<UnityEngine.UI.Text>();
		}
	}
}
