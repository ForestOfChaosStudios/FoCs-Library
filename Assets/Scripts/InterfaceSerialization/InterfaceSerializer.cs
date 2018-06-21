using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ForestOfChaosLib.InterfaceSerialization
{
	[Serializable]
	public class InterfaceSerializer
	{
		[SerializeField]
		protected Object reference;

		/// <summary>
		/// Returns the "reference as T"
		/// </summary>
		/// <typeparam name="T">Interface Type</typeparam>
		/// <returns>Interface reference or null</returns>
		public T GetInterfaceFromType<T>() where T: class => reference as T;
	}

	public class InterfaceSerializer<T>: InterfaceSerializer where T: class
	{
		public T GetInterfaceFromType() => reference as T;
	}
}