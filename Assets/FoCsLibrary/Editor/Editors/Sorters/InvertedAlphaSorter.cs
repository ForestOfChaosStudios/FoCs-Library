using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor
{
	internal class InvertedAlphaSorter: FoCsEditor.FoCsEditorSorter
	{
		public static          InvertedAlphaSorter Instance;
		public static readonly GUIContent          modeName = new GUIContent("Z-A");

		///<inheritdoc />
		public override GUIContent ModeName => modeName;

		///<inheritdoc />
		public override List<SerializedProperty> GetPropertyOrder(IEnumerable<SerializedProperty> properties)
		{
			var serializedProperties = properties.ToList();
			var list                 = serializedProperties.ToList();
			FoCsEditor.RemoveDefaultProperties(list);
			list.Sort((a, b) => string.Compare(a.name, b.name, StringComparison.Ordinal));
			list.Reverse();
			list.InsertRange(0, FoCsEditor.GetDefaultProperties(serializedProperties.First().serializedObject));

			return list;
		}
	}
}
