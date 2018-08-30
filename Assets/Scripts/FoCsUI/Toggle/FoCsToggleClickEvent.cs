using UnityEngine;
using UText = UnityEngine.UI.Text;
using UToggle = UnityEngine.UI.Toggle;

namespace ForestOfChaosLib.FoCsUI.Toggle
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Toggle/Events (Unity Text)")]
	public class FoCsToggleClickEvent: FoCsToggle
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
			Toggle  = GetComponentAdvanced<UToggle>();
			TextObj = GetComponentInChildrenAdvanced<UText>();
		}
	}
}
