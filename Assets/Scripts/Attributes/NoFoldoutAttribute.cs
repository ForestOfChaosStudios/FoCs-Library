using UnityEngine;

namespace ForestOfChaosLib.Attributes
{
	public class NoFoldoutAttribute: PropertyAttribute
	{
		public bool ShowVariableName { get; }

		public NoFoldoutAttribute(bool showName = true)
		{
			ShowVariableName = showName;
		}
	}
}
