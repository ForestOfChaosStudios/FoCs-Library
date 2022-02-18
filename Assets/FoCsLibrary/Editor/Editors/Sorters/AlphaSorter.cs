#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: AlphaSorter.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor {
    [InitializeOnLoad]
    internal class AlphaSorter: FoCsEditor.FoCsEditorSorter {
        public static          AlphaSorter Instance;
        public static readonly GUIContent  modeName = new GUIContent("A-Z");

        ///<inheritdoc />
        public override GUIContent ModeName => modeName;

        static AlphaSorter() {
            Instance = new AlphaSorter();
            FoCsEditor.AddSortingMode(Instance);
        }

        ///<inheritdoc />
        public override List<SerializedProperty> GetPropertyOrder(IEnumerable<SerializedProperty> properties) {
            var serializedProperties = properties.ToList();
            var list                 = serializedProperties.ToList();
            FoCsEditor.RemoveDefaultProperties(list);
            list.Sort((a, b) => string.Compare(a.name, b.name, StringComparison.Ordinal));
            list.InsertRange(0, FoCsEditor.GetDefaultProperties(serializedProperties.First().serializedObject));

            return list.ToList();
        }
    }
}