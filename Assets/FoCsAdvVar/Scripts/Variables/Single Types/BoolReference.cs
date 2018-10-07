using System;
using ForestOfChaosAdvVar.Base;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameSystem] public class BoolReference: AdvReference<bool> { }

	[Serializable]
	public class BoolVariable: AdvVariable<bool, BoolReference>
	{
		public static implicit operator BoolVariable(bool input)
		{
			var fR = new BoolVariable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
