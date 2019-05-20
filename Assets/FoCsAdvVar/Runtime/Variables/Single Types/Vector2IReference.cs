using System;
using ForestOfChaosAdvVar.Base;
using ForestOfChaosLibrary.Types;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameForestOfChaos] public class Vector2IReference: AdvReference<Vector2I> { }

	[Serializable]
	public class Vector2IVariable: AdvVariable<Vector2I, Vector2IReference>
	{
		public static implicit operator Vector2IVariable(Vector2I input)
		{
			var fR = new Vector2IVariable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
