namespace ForestOfChaosLib.AdvVar.Components
{
	public class SyncGameObjectActiveToBoolReference: FoCsBehaviour
	{
		public BoolReference Reference;

		private void OnEnable()
		{
			if(Reference)
				Reference.OnValueChange += ChangeState;
		}

		private void ChangeState()
		{
			gameObject.SetActive(Reference.Value);
		}

		private void OnDestroy()
		{
			if(Reference)
				Reference.OnValueChange -= ChangeState;
		}
	}
}