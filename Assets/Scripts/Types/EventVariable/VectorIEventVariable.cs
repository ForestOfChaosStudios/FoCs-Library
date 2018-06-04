using System;

namespace ForestOfChaosLib.Types.EventVariable
{
	[Serializable]
	public class Vector2IEventVariable: GenericEventVariable<Vector2I>
	{
		public Vector2IEventVariable(): this(Vector2I.Zero) { }
		public Vector2IEventVariable(Vector2I                          data): base(data) { }
		public static implicit operator Vector2IEventVariable(Vector2I input) => new Vector2IEventVariable(input);
	}

	[Serializable]
	public class Vector3IEventVariable: GenericEventVariable<Vector3I>
	{
		public Vector3IEventVariable(): this(Vector3I.Zero) { }
		public Vector3IEventVariable(Vector3I                          data): base(data) { }
		public static implicit operator Vector3IEventVariable(Vector3I input) => new Vector3IEventVariable(input);
	}

	[Serializable]
	public class Vector4IEventVariable: GenericEventVariable<Vector4I>
	{
		public Vector4IEventVariable(): this(Vector4I.Zero) { }
		public Vector4IEventVariable(Vector4I                          data): base(data) { }
		public static implicit operator Vector4IEventVariable(Vector4I input) => new Vector4IEventVariable(input);
	}
}
