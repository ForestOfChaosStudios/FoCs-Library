#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library.Editor
//       File: ConditionalHideDrawer.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:49 AM
#endregion


using ForestOfChaosLibrary.Attributes;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor.PropertyDrawers.Attributes {
    [CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
    public class ConditionalHideDrawer: FoCsPropertyDrawerWithAttribute<ConditionalHideAttribute> {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            using (var propScope = Disposables.PropertyScope(position, label, property)) {
                label = propScope.content;
                //check if the property we want to draw should be enabled
                var enabled = GetConditionalHideAttributeResult(GetAttribute, property);

                //Enable/disable the property
                var wasEnabled = GUI.enabled;
                GUI.enabled = enabled;

                //Check if we should draw the property
                if (!GetAttribute.HideInInspector || enabled) {
                    property.isExpanded = true;

                    using (Disposables.Indent())
                        EditorGUI.PropertyField(position, property, label, true);
                }
                else
                    property.isExpanded = false;

                //Ensure that the next property that is being drawn uses the correct settings
                GUI.enabled = wasEnabled;
            }
        }

        private static bool GetConditionalHideAttributeResult(ConditionalHideAttribute condHAtt, SerializedProperty property) {
            var enabled = true;
            //Look for the source field within the object that the property belongs to
            var propertyPath        = property.propertyPath; //returns the property path of the property we want to apply the attribute to
            var conditionPath       = propertyPath.Replace(property.name, condHAtt.ConditionalSourceField); //changes the path to the conditional source property path
            var sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);

            if (sourcePropertyValue != null)
                enabled = sourcePropertyValue.boolValue;
            else
                Debug.LogWarning("Attempting to use a ConditionalHideAttribute but no matching SourcePropertyValue found in object: " + condHAtt.ConditionalSourceField);

            return enabled;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var condHAtt = GetAttribute;
            var enabled  = GetConditionalHideAttributeResult(condHAtt, property);

            if (!condHAtt.HideInInspector || enabled)
                return EditorGUI.GetPropertyHeight(property, label);

            return 0;
        }
    }
}