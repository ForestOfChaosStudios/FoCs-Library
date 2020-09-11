#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: GetSetterAttributeDrawer.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


using ForestOfChaos.Unity.Attributes;
using ForestOfChaos.Unity.Editor.PropertyDrawers;
using ForestOfChaos.Unity.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.Attributes {
    /// <summary>
    ///     This is based off of the Unity Post Processing version
    /// </summary>
    [CustomPropertyDrawer(typeof(GetSetterAttribute))]
    public class GetSetterAttributeDrawer: FoCsPropertyDrawerWithAttribute<GetSetterAttribute> {
        internal const           string       Tooltip       = "Persists until recompile";
        internal static readonly GUIContent[] OPTIONS_ARRAY = {new GUIContent("Call Setter", Tooltip), new GUIContent("Don't Call Setter", Tooltip)};

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            using (var propScope = Disposables.PropertyScope(position, label, property)) {
                label = propScope.content;

                using (var cc = Disposables.ChangeCheck()) {
                    GetAttribute.CallSetter = FoCsGUI.DrawPropertyWithMenu(position, property, label, OPTIONS_ARRAY, GetAttribute.CallSetter? 0 : 1).Value == 0;

                    if (cc.changed)
                        GetAttribute.dirty = true;
                }

                if (GetAttribute.dirty)
                    ElseLogic(property);
            }
        }

        internal void ElseLogic(SerializedProperty property) {
            if (!GetAttribute.CallSetter)
                return;

            var parent = ReflectionUtilities.GetParentObject(property.propertyPath, property.serializedObject.targetObject);
            var type   = parent.GetType();
            var info   = type.GetProperty(GetAttribute.name);

            if (info == null)
                Debug.LogError(string.Format("Invalid property name \"{0}\"", GetAttribute.name));
            else
                info.SetValue(parent, fieldInfo.GetValue(parent), null);

            GetAttribute.dirty = false;
        }
    }
}