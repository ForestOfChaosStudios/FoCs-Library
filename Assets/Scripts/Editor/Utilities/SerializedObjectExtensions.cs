using System.Collections.Generic;
using UnityEditor;

namespace ForestOfChaosLib.Editor.Utilities
{
	public static class SerializedObjectExtensions
	{
		public static IEnumerable<SerializedProperty> Properties(this SerializedObject serializedObject, bool enterChildren = false)
		{
			var iterator = serializedObject.GetIterator();
			iterator.Next(true);

			do
				yield return iterator.Copy();
			while(iterator.NextVisible(enterChildren));
		}

		public static int VisibleProperties(this SerializedObject serializedObject, bool enterChildren = false)
		{
			var iterator = serializedObject.GetIterator();
			iterator.Next(true);
			var num = 0;

			do
			{
				if(!FoCsEditor.IsPropertyHidden(iterator))
					++num;
			}
			while(iterator.NextVisible(enterChildren));

			return num;
		}
	}
}