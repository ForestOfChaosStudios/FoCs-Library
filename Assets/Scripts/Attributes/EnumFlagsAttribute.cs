using UnityEngine;

namespace ForestOfChaosLib.Attributes
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
