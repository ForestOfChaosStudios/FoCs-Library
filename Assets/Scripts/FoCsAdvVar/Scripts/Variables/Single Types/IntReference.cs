using System;
using ForestOfChaosAdvVar.Base;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameSystem] public class IntReference: AdvReference<int> { }

	[Serializable]
	public class IntVariable: AdvVariable<int, IntReference>
	{
		public static implicit operator IntVariable(int input)
		{
			var fR = new IntVariable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
