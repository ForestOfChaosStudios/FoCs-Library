using TMPro;
using UnityEngine;

namespace ForestOfChaosLib.FoCsUI.Image
{
	public class TextEvent_TMP: TextComponentBase
	{
		public TextMeshProUGUI Text;

		public override string TextData
		{
			get { return Text.text; }
			set { Text.text = value; }
		}

		public override GameObject TextGO => Text.gameObject;
	}
}