using ForestOfChaosLib.Attributes;
using ForestOfChaosLib.Maths.Random;

namespace ForestOfChaosLib.Components.Generic
{
	public abstract class GenericArrayComponent<T>: FoCsBehavior
	{
		[NoFoldout(true)] public T[] Data;

		public T First
		{
			get { return Data.Length == 0? default(T) : Data[0]; }
			set
			{
				if(Data.Length == 0)
					Data = new[] {value};
				else
					Data[0] = value;
			}
		}

		public T GetRandomEntry() => Data[RandomMaster.Random.Next(0, Data.Length)];
		public static implicit operator T[](GenericArrayComponent<T> col) => col.Data;
	}
}
