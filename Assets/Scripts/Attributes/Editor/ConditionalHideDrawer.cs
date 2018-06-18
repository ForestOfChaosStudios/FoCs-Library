using ForestOfChaosLib.Attributes;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers.Attributes
{
	[CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
	public class ConditionalHideDrawer: FoCsPropertyDrawerWithAttribute<ConditionalHideAttribute>
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;
				//check if the property we want to draw should be enabled
				var enabled = GetConditionalHideAttributeResult(GetAttribute, property);

				//Enable/disable the property
				var wasEnabled = GUI.enabled;
				GUI.enabled = enabled;

				//Check if we should draw the property
				if(!GetAttribute.HideInInspector || enabled)
				{
					property.isExpanded   =  true;

					using(FoCsEditor.Disposables.Indent())
					{
						EditorGUI.PropertyField(position, property, label, true);
					}
				}
				else
					property.isExpanded = false;

				//Ensure that the next property that is being drawn uses the correct settings
				GUI.enabled = wasEnabled;
			}
		}

		private static bool GetConditionalHideAttributeResult(ConditionalHideAttribute condHAtt, SerializedProperty property)
		{
			var enabled = true;
			//Look for the sourcefield within the object that the property belongs to
			var propertyPath        = property.propertyPath;                                                //returns the property path of the property we want to apply the attribute to
			var conditionPath       = propertyPath.Replace(property.name, condHAtt.ConditionalSourceField); //changes the path to the conditionalsource property path
			var sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);

			if(sourcePropertyValue != null)
				enabled = sourcePropertyValue.boolValue;
			else
				Debug.LogWarning("Attempting to use a ConditionalHideAttribute but no matching SourcePropertyValue found in object: " + condHAtt.ConditionalSourceField);

			return enabled;
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			var condHAtt = GetAttribute;
			var enabled  = GetConditionalHideAttributeResult(condHAtt, property);

			if(!condHAtt.HideInInspector || enabled)
				return EditorGUI.GetPropertyHeight(property, label);

			return 0;
		}
	}
}
