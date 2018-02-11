using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;

namespace ForestOfChaosLib.Editor.Utilities
{
	public static class SerializedPropertyExtensionMethods
	{
		public static IEnumerable<SerializedProperty> GetChildren(this SerializedProperty property, bool enterChildren = false, bool enterChildrenOnTry = true)
		{
			var iterator = property.Copy();
			var iteratorNext = property.Next(true);
			if(iteratorNext)
			{
				yield return iterator.Copy();
				do
				{
					if(property.depth == iterator.depth)
						yield break;
					yield return iterator.Copy();
				}
				while(iterator.Next(false));
			}
		}

		public static IEnumerable<SerializedProperty> Properties(this SerializedObject serializedObject, bool enterChildren = false)
		{
			var iterator = serializedObject.GetIterator();
			iterator.Next(true);
			do
			{
				yield return iterator.Copy();
			}
			while(iterator.NextVisible(enterChildren));
		}

		public static int GetChildrenCount(this SerializedProperty property) => property.GetChildren().Count();

		public static int GetIndex(string path)
		{
			const string NEEDLE = @"\[[\d]\]";
			var matches = Regex.Matches(path, NEEDLE);
			if(matches.Count == 0)
				return -1;
			var str = matches[0].Value.Replace("[", "").Replace("]", "");
			return int.Parse(str);
		}
	}
}