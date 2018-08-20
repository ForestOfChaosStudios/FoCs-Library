using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	[InitializeOnLoad]
	internal class SearchSorter: FoCsEditor.FoCsEditorSorter
	{
		public static readonly GUIContent modeName = new GUIContent("Search");
		public override        GUIContent ModeName => modeName;

		static SearchSorter()
		{
			FoCsEditor.AddSortingMode(new SearchSorter());
		}

		public override List<SerializedProperty> GetPropertyOrder(IEnumerable<SerializedProperty> properties)
		{
			var list = new List<SerializedProperty>();

			foreach(var property in properties)
			{
				if(property.name.ToLower().Contains(FoCsEditor.Search.ToLower()) && !FoCsEditor.IsDefaultScriptProperty(property))
					list.Add(property);
			}

			return list;
		}

		public override void DoExtraDraw()
		{
			FoCsEditor.DrawSearchBox();
		}
	}
}