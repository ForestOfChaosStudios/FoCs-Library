﻿#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: EditorIndent.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEditor;

namespace ForestOfChaos.Unity.Editor.Utilities.Disposable {
    public class EditorIndent: IDisposable {
        private readonly int  _amount;
        private readonly bool _set;

        public EditorIndent(): this(1) { }

        public EditorIndent(int indentLevel, bool set = false) {
            _set = set;

            if (_set) {
                _amount               = EditorGUI.indentLevel;
                EditorGUI.indentLevel = indentLevel;
            }
            else {
                EditorGUI.indentLevel += indentLevel;
                _amount               =  indentLevel;
            }
        }

        public void Dispose() {
            if (_set)
                EditorGUI.indentLevel = _amount;
            else
                EditorGUI.indentLevel -= _amount;
        }
    }
}