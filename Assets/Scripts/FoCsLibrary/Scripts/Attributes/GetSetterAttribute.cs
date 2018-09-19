using UnityEngine;

namespace ForestOfChaosLibrary.Attributes
{
	public class GetSetterAttribute: PropertyAttribute
	{
		public readonly string name;
		public          bool   CallSetter = true;
		public          bool   dirty      = false;

		public GetSetterAttribute(string name)
		{
			this.name = name;
		}
	}
}
