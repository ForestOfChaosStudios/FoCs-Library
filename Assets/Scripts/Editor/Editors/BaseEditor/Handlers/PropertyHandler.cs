using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	public enum DefaultPropertyType
	{
		NotDefault,
		Disabled,
		Hidden
	}

	internal class PropertyHandler: IPropertyLayoutHandler
	{
		private readonly FoCsEditor owner;

		public PropertyHandler(FoCsEditor _owner)
		{
			owner = _owner;
		}

		public void HandleProperty(SerializedProperty property)
		{
			if(owner.HideDefaultProperty)
			{
				var isDefaultScriptProperty = FoCsEditor.GetDefaultPropertyType(property);

				if(isDefaultScriptProperty == DefaultPropertyType.Hidden)
					return;

				var cachedGUIEnabled = GUI.enabled;

				if(isDefaultScriptProperty != DefaultPropertyType.NotDefault)
					GUI.enabled = false;

				FoCsGUI.Layout.PropertyField(property, property.isExpanded);

				if(isDefaultScriptProperty != DefaultPropertyType.NotDefault)
					GUI.enabled = cachedGUIEnabled;
			}
			else
				FoCsGUI.Layout.PropertyField(property, property.isExpanded);
		}

		public float PropertyHeight(SerializedProperty property)
		{
			return FoCsGUI.GetPropertyHeight(property);
		}
	}
}