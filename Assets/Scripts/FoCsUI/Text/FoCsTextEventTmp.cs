using TMPro;
using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.Image
{
	public class FoCsTextEventTmp: FoCsText
	{
		public          TextMeshProUGUI TextObj;
		public override string          Text    { get { return TextObj.text; } set { TextObj.text = value; } }
		public override GameObject      TextGO  => TextObj.gameObject;
		private         void            Reset() { TextObj = GetComponentInChildren<TextMeshProUGUI>(); }
	}
}