using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	internal class ObjectReferenceHandler: IPropertyLayoutHandler
	{
		private readonly FoCsEditor owner;

		public ObjectReferenceHandler(FoCsEditor _owner)
		{
			owner = _owner;
		}

		public void HandleProperty(SerializedProperty property)
		{
			var drawer  = owner.GetObjectDrawers(property);
			var GuiCont = new GUIContent(property.displayName);
			var height  = drawer.GetPropertyHeight(property, GuiCont);
			var rect    = FoCsGUI.Layout.GetControlRect(true, height);
			drawer.OnGUI(rect, property, GuiCont);
		}

		public float PropertyHeight(SerializedProperty property)
		{
			var drawer  = owner.GetObjectDrawers(property);
			var GuiCont = new GUIContent(property.displayName);
			var height  = drawer.GetPropertyHeight(property, GuiCont);

			return height;
		}

		public bool IsValidProperty(SerializedProperty property)
		{
			return (property.propertyType == SerializedPropertyType.ObjectReference) && !FoCsEditor.IsDefaultScriptProperty(property);
		}
	}
}
