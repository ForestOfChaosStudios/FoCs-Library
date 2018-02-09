using ForestOfChaosLib.Maths.Random;
using UnityEngine;

namespace ForestOfChaosLib.ScriptableObjects.Generic
{
	public abstract class ArrayScriptableObject<T>: ScriptableObject
	{
		public const string ATTRIBUTE_PATH = "JMiles42/Scriptable Object/";
		public T[] Data;

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

		public T GetRandomEntry()
		{
			return Data[RandomMaster.Random.Next(0, Data.Length)];
		}

		public static implicit operator T[](ArrayScriptableObject<T> col)
		{
			return col.Data;
		}
	}
}