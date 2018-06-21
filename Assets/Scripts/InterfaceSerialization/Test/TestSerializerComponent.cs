using System.Collections.Generic;
using ForestOfChaosLib;
using UnityEngine;

namespace ForestOfChaosLib.InterfaceSerialization
{
	public class TestSerializerComponent: FoCsBehaviour
	{
		public InterfaceSerializer Test;
		public InterfaceSerializer<ISerializationCallbackReceiver> TestInterface;

		private void Reset() { }
	}
}