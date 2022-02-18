#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: FoCsImageEventTmp.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

#if TMP
using TMPro;
using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.Image
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Image/Image (TextMesh Pro)")]
	public class FoCsImageEventTmp: FoCsImage
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
			Image = GetComponentAdvanced<UnityEngine.UI.Image>();
			TextObj = GetComponentInChildrenAdvanced<TextMeshProUGUI>();
		}
	}
}
#endif