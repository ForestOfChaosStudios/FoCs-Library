using ForestOfChaosLib.Attributes;
using TMPro;
using UnityEngine;
using UButton = UnityEngine.UI.Button;

namespace ForestOfChaosLib.FoCsUI.Button
{
	public class ButtonClickEvent_TMP: ButtonComponentBase
	{
		[NoFoldout] public ButtonText_TMP myButton;

		public override UButton Button => myButton.Btn;

		public override string ButtonText
		{
			get
			{
				return myButton.Text == null?
					"" :
					myButton.Text.text;
			}
			set
			{
				if(myButton.Text != null)
					myButton.Text.text = value;
			}
		}

		public override GameObject ButtonGO => Button.gameObject;

		public override GameObject TextGO => myButton.Text.gameObject;

		private void Reset()
		{
			myButton.Btn = GetComponentAdvanced<UButton>();
			myButton.Text = GetComponentInChildrenAdvanced<TextMeshProUGUI>();
		}
	}
}