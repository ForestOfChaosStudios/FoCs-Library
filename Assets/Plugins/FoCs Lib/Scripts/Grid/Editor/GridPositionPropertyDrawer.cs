using ForestOfChaosLib.Editor.PropertyDrawers;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Grid.Editor
{
	[CustomPropertyDrawer(typeof(GridPosition))]
	public class GridPositionPropertyDrawer: FoCsPropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) =>
				Vector2PropEditor.Draw(position, property.FindPropertyRelative("Position"), label);

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => SingleLine;
	}
}