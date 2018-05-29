using System;

namespace ForestOfChaosLib.Types.EventVariable
{
	[Serializable]
	public class IntEventVariable: GenericEventVariable<int>
	{
		public IntEventVariable(): this(0) { }
		public IntEventVariable(int                          data): base(data) { }
		public static implicit operator IntEventVariable(int input) => new IntEventVariable(input);
	}
}