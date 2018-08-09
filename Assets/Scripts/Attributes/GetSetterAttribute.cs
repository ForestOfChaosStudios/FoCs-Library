using UnityEngine;

namespace ForestOfChaosLib.Attributes
{
	public class GetSetterAttribute: PropertyAttribute
	{
		public readonly string name;
		public          bool   CallSetter = true;
		public          bool   dirty;

		public GetSetterAttribute(string name)
		{
			this.name = name;
		}
	}
}
