using ForestOfChaosLib.AdvVar;
using UnityEngine;

namespace ForestOfChaosLib.Components
{
	public class SetParent: FoCsBehaviour
	{
		public enum Mode
		{
			OnEnable,
			Start,
			Awake
		}

		public Mode         CallMode = Mode.OnEnable;
		public Transform    ChildTransform;
		public BoolVariable DestroyComponentAfterCall = true;
		public Transform    ParentTransform;

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

		private void Reset()
		{
			ChildTransform = transform;
		}
	}
}