using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor
{
	[InitializeOnLoad]
	internal class NormalSorter: FoCsEditor.FoCsEditorSorter
	{
		public static          NormalSorter Instance;
		public static readonly GUIContent   modeName = new GUIContent("Normal");

		///<inheritdoc />
		public override GUIContent ModeName => modeName;

		static NormalSorter()
		{
			Instance                     = new NormalSorter();
			AlphaSorter.Instance         = new AlphaSorter();
			InvertedAlphaSorter.Instance = new InvertedAlphaSorter();
			SearchSorter.Instance        = new SearchSorter();
			FoCsEditor.AddSortingMode(Instance);
			FoCsEditor.AddSortingMode(AlphaSorter.Instance);
			FoCsEditor.AddSortingMode(InvertedAlphaSorter.Instance);
			FoCsEditor.AddSortingMode(SearchSorter.Instance);
		}

		///<inheritdoc />
		public override List<SerializedProperty> GetPropertyOrder(IEnumerable<SerializedProperty> properties) => properties.ToList();
	}
}
