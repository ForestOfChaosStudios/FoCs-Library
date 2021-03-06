﻿#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: NormalSorter.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:10 PM
#endregion

using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor {
    [InitializeOnLoad]
    internal class NormalSorter: FoCsEditor.FoCsEditorSorter {
        public static          NormalSorter Instance;
        public static readonly GUIContent   modeName = new GUIContent("Normal");

        ///<inheritdoc />
        public override GUIContent ModeName => modeName;

        static NormalSorter() {
            Instance = new NormalSorter();
            FoCsEditor.AddSortingMode(Instance);
        }

        ///<inheritdoc />
        public override List<SerializedProperty> GetPropertyOrder(IEnumerable<SerializedProperty> properties) => properties.ToList();
    }
}