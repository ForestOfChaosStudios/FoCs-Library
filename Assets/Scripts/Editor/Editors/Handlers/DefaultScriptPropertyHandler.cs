using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	public class DefaultScriptPropertyHandler: IPropertyLayoutHandler
	{
		private readonly FoCsEditor owner;

		public DefaultScriptPropertyHandler()
		{
			owner = null;
		}
		public DefaultScriptPropertyHandler(FoCsEditor _owner)
		{
			owner = _owner;
		}

		public void HandleProperty(SerializedProperty property)
		{
			if(owner && owner.HideDefaultProperty)
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
			if(owner && owner.HideDefaultProperty)
				return 0;

			return FoCsGUI.SingleLine;
		}

		public bool IsValidProperty(SerializedProperty property)
		{
			if(FoCsEditor.IsDefaultScriptProperty(property))
				return true;

			var t = FoCsEditor.GetDefaultPropertyType(property);

			switch(t)
			{
				case DefaultPropertyType.NotDefault: return false;
					default:
					return true;
			}
		}

		public void DrawAfterEditor(SerializedProperty serializedProperty)
		{

		}
	}
}
