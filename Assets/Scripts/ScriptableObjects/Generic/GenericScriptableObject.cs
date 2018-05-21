using ForestOfChaosLib.Attributes;
using UnityEngine;

namespace ForestOfChaosLib.ScriptableObjects.Generic
{
	public class GenericScriptableObject<T>: ScriptableObject
	{
		[NoFoldout] public T Data;

		public static implicit operator T(GenericScriptableObject<T> col) => col.Data;
	}

	public class GenericFoldoutScriptableObject<T>: ScriptableObject
	{
		public T Data;

		public static implicit operator T(GenericFoldoutScriptableObject<T> col) => col.Data;
	}
}