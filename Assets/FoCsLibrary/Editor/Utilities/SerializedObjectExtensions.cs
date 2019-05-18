using System;
using System.Collections.Generic;
using UnityEditor;

namespace ForestOfChaosLibrary.Editor.Utilities
{
	public static class SerializedObjectExtensions
	{
		public static IEnumerable<SerializedProperty> Properties(this SerializedObject serializedObject, bool enterChildren = false)
		{
			var iterator = serializedObject.GetIterator();
			var next     = iterator.Next(true);

			if(!next)
				yield break;

			do
				yield return iterator.Copy();
			while(iterator.NextVisible(enterChildren));
		}

		public static int VisibleProperties(this SerializedObject serializedObject, bool enterChildren = false)
		{
			var iterator = serializedObject.GetIterator();
			var next     = iterator.Next(true);

			if(!next)
				return 0;

			var num = 0;

			do
			{
				if(!FoCsEditor.IsPropertyHidden(iterator))
					++num;
			}
			while(iterator.NextVisible(enterChildren));

			return num;
		}

		public static Type GetPropertyType(this SerializedObject property)
		{
			var parentType = property.targetObject.GetType();

			return parentType;
		}
	}
}
