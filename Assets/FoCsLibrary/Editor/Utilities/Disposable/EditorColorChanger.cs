﻿#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: EditorColorChanger.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.Utilities.Disposable {
    public class EditorColorChanger: IDisposable {
        private readonly EditorColourType _editorColourType;
        private readonly Color            color;

        public EditorColorChanger(Color _color, EditorColourType editorColourType = EditorColourType.Background) {
            _editorColourType = editorColourType;

            switch (_editorColourType) {
                case EditorColourType.Background:
                    color               = GUI.backgroundColor;
                    GUI.backgroundColor = _color;

                    break;
                case EditorColourType.Content:
                    color            = GUI.contentColor;
                    GUI.contentColor = _color;

                    break;
                case EditorColourType.Other:
                    color     = GUI.color;
                    GUI.color = _color;

                    break;
                case EditorColourType.Gizmos:
                    color        = Gizmos.color;
                    Gizmos.color = _color;

                    break;
                case EditorColourType.Handles:
                    color         = Handles.color;
                    Handles.color = _color;

                    break;
            }
        }

        public void Dispose() {
            switch (_editorColourType) {
                case EditorColourType.Background:
                    GUI.backgroundColor = color;

                    break;
                case EditorColourType.Content:
                    GUI.contentColor = color;

                    break;
                case EditorColourType.Other:
                    GUI.color = color;

                    break;
                case EditorColourType.Gizmos:
                    Gizmos.color = color;

                    break;
                case EditorColourType.Handles:
                    Handles.color = color;

                    break;
            }
        }
    }

    public enum EditorColourType {
        Background,
        Content,
        Other,
        Gizmos,
        Handles
    }
}