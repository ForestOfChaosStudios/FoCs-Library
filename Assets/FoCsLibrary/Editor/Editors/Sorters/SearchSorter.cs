#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: SearchSorter.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor {
    [InitializeOnLoad]
    internal class SearchSorter: FoCsEditor.FoCsEditorSorter {
        public static          SearchSorter Instance;
        public static readonly GUIContent   modeName = new GUIContent("Search");

        ///<inheritdoc />
        public override GUIContent ModeName => modeName;

        static SearchSorter() {
            Instance = new SearchSorter();
            FoCsEditor.AddSortingMode(Instance);
        }

        ///<inheritdoc />
        public override List<SerializedProperty> GetPropertyOrder(IEnumerable<SerializedProperty> properties) {
            var list                 = new List<SerializedProperty>();
            var serializedProperties = properties.ToList();

            foreach (var property in serializedProperties) {
                if (property.name.ToLower().Contains(FoCsEditor.Search.ToLower()) && !FoCsEditor.IsDefaultScriptProperty(property))
                    list.Add(property);
            }

            list.InsertRange(0, FoCsEditor.GetDefaultProperties(serializedProperties.First().serializedObject));

            return list;
        }

        public override void DoExtraDraw() {
            FoCsEditor.DrawSearchBox();
        }
    }
}