using ForestOfChaosLib.Editor.PropertyDrawers;
using ForestOfChaosLib.Grid;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	[CustomPropertyDrawer(typeof(GridPosition))]
	internal class GridPositionPropertyDrawer: FoCsPropertyDrawer
	{
		public override void  OnGUI(Rect                           position, SerializedProperty property, GUIContent label) => Vector2PropEditor.Draw(position, property.FindPropertyRelative("Position"), label);
		public override float GetPropertyHeight(SerializedProperty property, GUIContent         label) => SingleLine;
	}
}