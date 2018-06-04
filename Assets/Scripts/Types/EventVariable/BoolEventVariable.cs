using System;

namespace ForestOfChaosLib.Types.EventVariable
{
	[Serializable]
	public class BoolEventVariable: GenericEventVariable<bool>
	{
		public BoolEventVariable(): this(false) { }
		public BoolEventVariable(bool                          data): base(data) { }
		public static implicit operator BoolEventVariable(bool input) => new BoolEventVariable(input);
	}
}
