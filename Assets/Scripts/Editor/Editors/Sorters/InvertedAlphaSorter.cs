using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	[InitializeOnLoad]
	internal class InvertedAlphaSorter: FoCsEditor.FoCsEditorSorter
	{
		public static readonly GUIContent modeName = new GUIContent("Z-A");
		public override        GUIContent ModeName => modeName;

		static InvertedAlphaSorter()
		{
			FoCsEditor.AddSortingMode(new InvertedAlphaSorter());
		}

		public override List<SerializedProperty> GetPropertyOrder(IEnumerable<SerializedProperty> properties)
		{
			var list = properties.ToList();
			list.Sort((a, b) => string.Compare(a.name, b.name, StringComparison.Ordinal));
			list.Reverse();

			return list;
		}
	}
}