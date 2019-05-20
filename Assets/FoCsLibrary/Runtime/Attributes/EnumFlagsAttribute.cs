using UnityEngine;

namespace ForestOfChaosLibrary.Attributes
{
	public class EnumFlagsAttribute: PropertyAttribute
	{
		public readonly bool DrawButtons;

		public EnumFlagsAttribute(bool drawButtons = false)
		{
			DrawButtons = drawButtons;
		}
	}
}
