using ForestOfChaosLib.FoCsUI.Button;

namespace ForestOfChaosLib.AdvVar.Components
{
	public class ToggleBoolReferenceToButtonEvents: FoCsBehavior
	{
		public BoolReference BoolReference;
		public FoCsButton FoCsButton;

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