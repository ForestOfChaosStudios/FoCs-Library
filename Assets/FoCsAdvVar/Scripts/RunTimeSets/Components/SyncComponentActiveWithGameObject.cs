using ForestOfChaosLibrary;
using UnityEngine;

namespace ForestOfChaosAdvVar.RuntimeRef.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/RunTime/" + "Sync Component to GameObject State")]
	public class SyncComponentActiveWithGameObject: FoCsBehaviour
	{
		public MonoBehaviourRunTimeRef MonoBehaviourRunTimeRef;

		private void OnEnable()
		{
			if(MonoBehaviourRunTimeRef)
			{
				if(MonoBehaviourRunTimeRef.Reference)
					MonoBehaviourRunTimeRef.Reference.enabled = true;
			}
		}

		private void OnDisable()
		{
			if(MonoBehaviourRunTimeRef)
			{
				if(MonoBehaviourRunTimeRef.Reference)
					MonoBehaviourRunTimeRef.Reference.enabled = false;
			}
		}
	}
}
