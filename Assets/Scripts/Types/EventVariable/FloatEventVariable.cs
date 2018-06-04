using System;

namespace ForestOfChaosLib.Types.EventVariable
{
	[Serializable]
	public class FloatEventVariable: GenericEventVariable<float>
	{
		public FloatEventVariable(): this(0f) { }
		public FloatEventVariable(float                          data): base(data) { }
		public static implicit operator FloatEventVariable(float input) => new FloatEventVariable(input);
	}
}
