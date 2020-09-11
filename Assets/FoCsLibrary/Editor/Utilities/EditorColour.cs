#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: EditorColour.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor.Utilities {
    public struct EditorColour {
        public Color Color;
        public Color lightColor;

        public EditorColour(float r, float g, float b) {
            Color        = new Color(r, g, b, 1);
            lightColor   = Color * 0.7f;
            lightColor.a = 1f;
        }

        public EditorColour(float r, float g, float b, float a) {
            Color        = new Color(r, g, b, a);
            lightColor   = Color * 0.7f;
            lightColor.a = 1f;
        }

        public EditorColour(Color color) {
            Color        = color;
            lightColor   = color * 0.7f;
            lightColor.a = 1f;
        }

        public EditorColour(Color color, float lcolor) {
            Color        = color;
            lightColor   = color * lcolor;
            lightColor.a = 1f;
        }

        public EditorColour(Color color, Color lcolor) {
            Color      = color;
            lightColor = lcolor;
        }

        public static implicit operator Color(EditorColour editorColour) => EditorGUIUtility.isProSkin? editorColour.Color : editorColour.lightColor;
    }
}