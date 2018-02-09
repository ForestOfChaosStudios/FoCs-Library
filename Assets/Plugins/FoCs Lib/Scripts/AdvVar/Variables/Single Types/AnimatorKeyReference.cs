using System;
using ForestOfChaosLib.AdvVar.Base;
using ForestOfChaosLib.Animation;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable]
	[AdvFolderNameForestOfChaos]
	public class AnimatorKeyReference: AdvReference<AnimatorKey>
	{ }

	[Serializable]
	public class AnimatorKeyVariable: AdvVariable<AnimatorKey, AnimatorKeyReference>
	{
		public static implicit operator AnimatorKeyVariable(AnimatorKey input)
		{
			var fR = new AnimatorKeyVariable
					 {
						 UseConstant = true,
						 Value = input
					 };

			return fR;
		}
	}
}