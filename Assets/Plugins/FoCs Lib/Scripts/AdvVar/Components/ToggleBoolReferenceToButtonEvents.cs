using ForestOfChaosLib.FoCsUI.Button;

namespace ForestOfChaosLib.AdvVar.Components
{
	public class ToggleBoolReferenceToButtonEvents: FoCsBehavior
	{
		public BoolReference BoolReference;
		public ButtonComponentBase Button;

		private void OnEnable()
		{
			if(Button)
				Button.onMouseClick += OnMouseClick;
		}

		private void OnMouseClick()
		{
			if(BoolReference)
				BoolReference.Value = !BoolReference.Value;
		}

		private void OnDisable()
		{
			if(Button)
				Button.onMouseClick += OnMouseClick;
		}

		private void Reset()
		{
			Button = GetComponentInChildren<ButtonComponentBase>();
		}
	}
}