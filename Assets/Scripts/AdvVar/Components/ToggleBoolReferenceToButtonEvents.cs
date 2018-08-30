using ForestOfChaosLib.FoCsUI.Button;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/" + "Toggle Bool Reference To Button")]
	public class ToggleBoolReferenceToButtonEvents: FoCsBehaviour
	{
		public BoolReference BoolReference;
		public FoCsButton    FoCsButton;

		private void OnEnable()
		{
			if(FoCsButton)
				FoCsButton.onMouseClick += OnMouseClick;
		}

		private void OnMouseClick()
		{
			if(BoolReference)
				BoolReference.Value = !BoolReference.Value;
		}

		private void OnDisable()
		{
			if(FoCsButton)
				FoCsButton.onMouseClick += OnMouseClick;
		}

		private void Reset()
		{
			FoCsButton = GetComponentInChildren<FoCsButton>();
		}
	}
}
