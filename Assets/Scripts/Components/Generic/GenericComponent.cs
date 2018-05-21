using ForestOfChaosLib.Attributes;

namespace ForestOfChaosLib.Components.Generic
{
	public class GenericComponent<T>: FoCsBehavior
	{
		[NoFoldout]
		public T Data;

		public static implicit operator T(GenericComponent<T> col)
		{
			return col.Data;
		}
	}
}