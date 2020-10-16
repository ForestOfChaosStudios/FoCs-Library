#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: FoCsButtonClickEventTmp.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

#if TMP
using TMPro;
using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.Button
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Button/Button (TextMesh Pro)")]
	public class FoCsButtonClickEventTmp: FoCsButton
	{
		public TextMeshProUGUI TextObj;
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
			Button = GetComponentAdvanced<UnityEngine.UI.Button>();
			TextObj = GetComponentInChildrenAdvanced<TextMeshProUGUI>();
		}
	}
}
#endif