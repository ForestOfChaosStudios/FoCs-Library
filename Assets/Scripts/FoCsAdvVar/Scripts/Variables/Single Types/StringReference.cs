using System;
using ForestOfChaosAdvVar.Base;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameSystem] public class StringReference: AdvReference<string> { }

	[Serializable]
	public class StringVariable: AdvVariable<string, StringReference>
	{
		public static implicit operator StringVariable(string input)
		{
			var fR = new StringVariable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
