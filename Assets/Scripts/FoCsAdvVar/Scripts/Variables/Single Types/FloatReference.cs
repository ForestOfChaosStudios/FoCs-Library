using System;
using ForestOfChaosAdvVar.Base;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameSystem] public class FloatReference: AdvReference<float> { }

	[Serializable]
	public class FloatVariable: AdvVariable<float, FloatReference>
	{
		public static implicit operator FloatVariable(float input)
		{
			var fR = new FloatVariable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
