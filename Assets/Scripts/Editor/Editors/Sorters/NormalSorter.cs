using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	[InitializeOnLoad]
	internal class NormalSorter: FoCsEditor.FoCsEditorSorter
	{
		public static readonly GUIContent modeName = new GUIContent("Normal");
		public override        GUIContent ModeName => modeName;

		static NormalSorter()
		{
			FoCsEditor.AddSortingMode(new NormalSorter());
		}

		public override List<SerializedProperty> GetPropertyOrder(IEnumerable<SerializedProperty> properties) => properties.ToList();
	}
}