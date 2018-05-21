using System;
using ForestOfChaosLib.AdvVar.Base;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable]
	[AdvFolderNameSystem]
	public class IntReference: AdvReference<int>
	{ }

	[Serializable]
	public class IntVariable: AdvVariable<int, IntReference>
	{
		public static implicit operator IntVariable(int input)
		{
			var fR = new IntVariable
					 {
						 UseConstant = true,
						 Value = input
					 };

			return fR;
		}
	}
}