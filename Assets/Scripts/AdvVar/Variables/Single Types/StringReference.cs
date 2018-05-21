using System;
using ForestOfChaosLib.AdvVar.Base;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable]
	[AdvFolderNameSystem]
	public class StringReference: AdvReference<string>
	{ }

	[Serializable]
	public class StringVariable: AdvVariable<string, StringReference>
	{
		public static implicit operator StringVariable(string input)
		{
			var fR = new StringVariable
					 {
						 UseConstant = true,
						 Value = input
					 };

			return fR;
		}
	}
}