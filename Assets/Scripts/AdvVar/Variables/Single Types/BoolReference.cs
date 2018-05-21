using System;
using ForestOfChaosLib.AdvVar.Base;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable]
	[AdvFolderNameSystem]
	public class BoolReference: AdvReference<bool>
	{ }

	[Serializable]
	public class BoolVariable: AdvVariable<bool, BoolReference>
	{
		public static implicit operator BoolVariable(bool input)
		{
			var fR = new BoolVariable
					 {
						 UseConstant = true,
						 Value = input
					 };

			return fR;
		}
	}
}