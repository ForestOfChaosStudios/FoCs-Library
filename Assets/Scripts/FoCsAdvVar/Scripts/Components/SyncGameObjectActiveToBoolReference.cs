using ForestOfChaosLibrary;
using UnityEngine;

namespace ForestOfChaosAdvVar.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/" + "Sync GameObject Active to Bool Reference")]
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
