using UnityEngine;

namespace ForestOfChaosLib.Attributes
{
	public class GetSetterAttribute: PropertyAttribute
	{
		public readonly string name;
		public bool dirty;
		public bool CallSetter = true;

		public GetSetterAttribute(string name)
		{
			this.name = name;
		}
	}
}