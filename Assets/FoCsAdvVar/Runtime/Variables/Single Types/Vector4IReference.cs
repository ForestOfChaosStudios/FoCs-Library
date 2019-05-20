using System;
using ForestOfChaosAdvVar.Base;
using ForestOfChaosLibrary.Types;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameForestOfChaos] public class Vector4IReference: AdvReference<Vector4I> { }

	[Serializable]
	public class Vector4IVariable: AdvVariable<Vector4I, Vector4IReference>
	{
		public static implicit operator Vector4IVariable(Vector4I input)
		{
			var fR = new Vector4IVariable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
