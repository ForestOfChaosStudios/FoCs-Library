using UnityEngine;
using UnityEngine.UI;

namespace ForestOfChaosLib.FoCsUI.Image
{
	public class TextEvent: TextComponentBase
	{
		public Text Text;

		public override string TextData
		{
			get { return Text.text; }
			set { Text.text = value; }
		}

		public override GameObject TextGO => Text.gameObject;
	}
}