using System;
using ForestOfChaosLib.AdvVar.Base;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable]
	[AdvFolderNameSystem]
	public class ByteReference: AdvReference<byte>
	{ }

	[Serializable]
	public class ByteVariable: AdvVariable<byte, ByteReference>
	{
		public static implicit operator ByteVariable(byte input)
		{
			var fR = new ByteVariable
					 {
						 UseConstant = true,
						 Value = input
					 };

			return fR;
		}
	}
}