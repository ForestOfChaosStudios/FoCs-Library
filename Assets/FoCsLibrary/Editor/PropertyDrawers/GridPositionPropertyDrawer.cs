using ForestOfChaosLibrary.Editor.PropertyDrawers;
using ForestOfChaosLibrary.Grid;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor
{
	[CustomPropertyDrawer(typeof(GridPosition))]
	internal class GridPositionPropertyDrawer: FoCsPropertyDrawer
	{
		public override void OnGUI(Rect                            position, SerializedProperty property, GUIContent label) => Vector2PropEditor.Draw(position, property.FindPropertyRelative("Position"), label);
		public override float GetPropertyHeight(SerializedProperty property, GUIContent         label) => SingleLine;
	}
}
