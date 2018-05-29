using ForestOfChaosLib.AdvVar;
using UnityEngine;

namespace ForestOfChaosLib.Components
{
	public class SetParent: FoCsBehavior
	{
		public enum Mode
		{
			OnEnable,
			Start,
			Awake
		}

		public Mode         CallMode = Mode.OnEnable;
		public Transform    ChildTransform;
		public Transform    ParentTransform;
		public BoolVariable DestroyComponentAfterCall = true;

		private void OnEnable()
		{
			if(CallMode == Mode.OnEnable)
				DoParent();
		}

		private void Awake()
		{
			if(CallMode == Mode.Awake)
				DoParent();
		}

		private void Start()
		{
			if(CallMode == Mode.Start)
				DoParent();
		}

		private void DoParent()
		{
			ChildTransform.SetParent(ParentTransform);

			if(DestroyComponentAfterCall.Value)
				Destroy(this);
		}

		private void Reset() { ChildTransform = transform; }
	}
}