using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;

namespace ForestOfChaosLib.Editor.Utilities
{
	public static class SerializedPropertyExtensions
	{
		private const string INDEX_NEEDLE = @"\[[\d]\]";

		public static IEnumerable<SerializedProperty> GetChildren(this SerializedProperty property, bool enterChildren = true)
		{
			var iterator = property.Copy();
			var iteratorNext = property.Next(true);

			if(!iteratorNext)
				yield break;

			yield return iterator.Copy();
			do
			{
				if(property.depth >= iterator.depth)
					yield break;
				yield return iterator.Copy();
			}
			while(iterator.Next(enterChildren));
		}

		public static int GetChildrenCount(this SerializedProperty property) => property.GetChildren().Count();

		public static int GetIndex(SerializedProperty property)
		{
			var matches = Regex.Matches(property.propertyPath, INDEX_NEEDLE);
			if(matches.Count == 0)
				return -1;
			var str = matches[0].Value.Replace("[", "").Replace("]", "");
			return int.Parse(str);
		}

		public static int GetIndex(string path)
		{
			var matches = Regex.Matches(path, INDEX_NEEDLE);
			if(matches.Count == 0)
				return -1;
			var str = matches[0].Value.Replace("[", "").Replace("]", "");
			return int.Parse(str);
		}
	}
}