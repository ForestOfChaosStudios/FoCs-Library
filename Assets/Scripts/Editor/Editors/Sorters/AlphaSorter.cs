using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	[InitializeOnLoad]
	internal class AlphaSorter: FoCsEditor.FoCsEditorSorter
	{
		public static readonly GUIContent modeName = new GUIContent("A-Z");
		public override        GUIContent ModeName => modeName;

		static AlphaSorter()
		{
			FoCsEditor.AddSortingMode(new AlphaSorter());
		}

		public override List<SerializedProperty> GetPropertyOrder(IEnumerable<SerializedProperty> properties)
		{
			var list = properties.ToList();
			list.Sort((a, b) => string.Compare(a.name, b.name, StringComparison.Ordinal));

			return list.ToList();
		}
	}
}