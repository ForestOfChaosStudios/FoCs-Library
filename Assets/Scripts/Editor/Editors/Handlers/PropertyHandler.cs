using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	public class PropertyHandler: IPropertyLayoutHandler
	{
		public void HandleProperty(SerializedProperty property)
		{
			FoCsGUI.Layout.PropertyField(new GUIContent(property.displayName), property, property.isExpanded);
		}

		public float PropertyHeight(SerializedProperty property)
		{
			return FoCsGUI.GetPropertyHeight(property);
		}

		public bool IsValidProperty(SerializedProperty property)
		{
			return true;
		}

		public void DrawAfterEditor(SerializedProperty serializedProperty)
		{

		}
	}
}