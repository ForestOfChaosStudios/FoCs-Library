#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: FoCsTextEventTmp.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

#if TMP
using TMPro;
using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.Text
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_UI_FOLDER_ + "Text/Events (TextMesh Pro)")]
	public class FoCsTextEventTmp: FoCsText
	{
		public TextMeshProUGUI TextObj;
		public override string Text
		{
			get { return TextObj.text; }
			set { TextObj.text = value; }
		}
		public override GameObject TextGO => TextObj.gameObject;

		private void Reset()
		{
			TextObj = GetComponentInChildren<TextMeshProUGUI>();
		}
	}
}
#endif