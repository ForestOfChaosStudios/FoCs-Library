using UnityEngine;

namespace ForestOfChaosLibrary.Attributes
{
	public class NoFoldoutAttribute: PropertyAttribute
	{
		public readonly bool ShowVariableName;

		public NoFoldoutAttribute(bool showName = true)
		{
			ShowVariableName = showName;
		}
	}
}
