using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	internal class SearchSorter: FoCsEditor.FoCsEditorSorter
	{
		public static          SearchSorter Instance;
		public static readonly GUIContent   modeName = new GUIContent("Search");

		///<inheritdoc />
		public override GUIContent ModeName => modeName;

		///<inheritdoc />
		public override List<SerializedProperty> GetPropertyOrder(IEnumerable<SerializedProperty> properties)
		{
			var list                 = new List<SerializedProperty>();
			var serializedProperties = properties.ToList();

			foreach(var property in serializedProperties)
			{
				if(property.name.ToLower().Contains(FoCsEditor.Search.ToLower()) && !FoCsEditor.IsDefaultScriptProperty(property))
					list.Add(property);
			}

			list.InsertRange(0, FoCsEditor.GetDefaultProperties(serializedProperties.First().serializedObject));

			return list;
		}

		public override void DoExtraDraw()
		{
			FoCsEditor.DrawSearchBox();
		}
	}
}
