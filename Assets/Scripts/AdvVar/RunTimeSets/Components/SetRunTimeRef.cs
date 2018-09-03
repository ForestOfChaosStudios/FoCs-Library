using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/RunTime/" + "Set RunTime Ref")]
	public class SetRunTimeRef: MonoBehaviour
	{
		public bool       RemoveOnDisable = true;
		public RunTimeRef RunTimeRef;

		public void OnEnable()
		{
			RunTimeRef?.FillReference(this);
		}

		public void OnDisable()
		{
			if(RemoveOnDisable)
				RunTimeRef?.EmptyReference();
		}

		private void OnDestroy()
		{
			RunTimeRef?.EmptyReference();
		}
	}
}
