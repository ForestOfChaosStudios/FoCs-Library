using UnityEngine;

namespace ForestOfChaosLib.Attributes
{
	public class RegexStringAttribute: PropertyAttribute
	{
		public readonly string helpMessage;
		public readonly string pattern;

		public RegexStringAttribute(string _pattern, string _helpMessage)
		{
			pattern     = _pattern;
			helpMessage = _helpMessage;
		}
	}
}
