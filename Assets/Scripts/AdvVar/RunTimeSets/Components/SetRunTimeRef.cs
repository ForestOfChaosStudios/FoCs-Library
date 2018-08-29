using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	public class SetRunTimeRef: MonoBehaviour
	{
		public RunTimeRef RunTimeRef;
		public bool       RemoveOnDisable = true;

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
