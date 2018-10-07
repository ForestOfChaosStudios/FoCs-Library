using UnityEngine;

namespace ForestOfChaosLibrary.FoCsUI.Image
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Image/Image (Unity Text)")]
	public class FoCsImageEvent: FoCsImage
	{
		public UnityEngine.UI.Text TextObj;

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
			Image   = GetComponent<UnityEngine.UI.Image>();
			TextObj = GetComponentInChildren<UnityEngine.UI.Text>();
		}
	}
}
