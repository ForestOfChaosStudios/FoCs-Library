using ForestOfChaosLibrary;
using UnityEngine;

namespace ForestOfChaosAdvVar.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/" + "Sync Bool Reference to GameObject Active")]
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
