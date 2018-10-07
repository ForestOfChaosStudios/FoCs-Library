using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor
{
	public class PropertyHandler: IPropertyLayoutHandler
	{
		public void HandleProperty(SerializedProperty property)
		{
			FoCsGUI.Layout.PropertyField(new GUIContent(property.displayName), property, property.isExpanded);
		}

		public float PropertyHeight(SerializedProperty property) => FoCsGUI.GetPropertyHeight(property);
		public bool IsValidProperty(SerializedProperty property) => true;
		public void DrawAfterEditor(SerializedProperty serializedProperty) { }
	}
}
