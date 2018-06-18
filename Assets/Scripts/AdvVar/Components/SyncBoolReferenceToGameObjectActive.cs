namespace ForestOfChaosLib.AdvVar.Components
{
	public class SyncBoolReferenceToGameObjectActive: FoCsBehaviour
	{
		public BoolReference Reference;

		private void OnEnable()
		{
			Reference.Value = true;
		}

		private void OnDisable()
		{
			Reference.Value = false;
		}
	}
}
