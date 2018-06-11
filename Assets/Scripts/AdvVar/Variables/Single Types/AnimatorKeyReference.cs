using System;
using ForestOfChaosLib.AdvVar.Base;
using ForestOfChaosLib.Animation;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameForestOfChaos] public class AnimatorKeyReference: AdvReference<AnimatorKey> { }

	[Serializable]
	public class AnimatorKeyVariable: AdvVariable<AnimatorKey, AnimatorKeyReference>
	{
		public string Key
		{
			get { return Value.Key; }
			set { Value.Key = value; }
		}

		public AnimatorKey.AnimType KeyType
		{
			get { return Value.KeyType; }
			set { Value.KeyType = value; }
		}

		public int IntData
		{
			get { return Value.IntData; }
			set { Value.IntData = value; }
		}

		public float FloatData
		{
			get { return Value.FloatData; }
			set { Value.FloatData = value; }
		}

		public bool BoolData
		{
			get { return Value.BoolData; }
			set { Value.BoolData = value; }
		}

		public bool TriggerData
		{
			get { return Value.TriggerData; }
			set { Value.TriggerData = value; }
		}

		public void CalculateAnimator(Animator animator)
		{
			Value.CalculateAnimator(animator);
		}

		public static implicit operator AnimatorKeyVariable(AnimatorKey input)
		{
			var fR = new AnimatorKeyVariable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
