#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Features.Grid.Editor
//       File: GridPositionPropertyDrawer.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:11 PM
#endregion

using ForestOfChaos.Unity.Editor.PropertyDrawers;
using ForestOfChaos.Unity.Features.Grid;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor {
    [CustomPropertyDrawer(typeof(GridPosition))]
    internal class GridPositionPropertyDrawer: FoCsPropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) =>
                Vector2PropEditor.Draw(position, property.FindPropertyRelative("Position"), label);

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => SingleLine;
    }
}