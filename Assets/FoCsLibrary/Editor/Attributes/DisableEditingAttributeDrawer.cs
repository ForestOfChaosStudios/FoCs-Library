#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: DisableEditingAttributeDrawer.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.Attributes;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.PropertyDrawers.Attributes {
    [CustomPropertyDrawer(typeof(DisableEditingAttribute), true)]
    public class DisableEditingAttributeDrawer: FoCsPropertyDrawerWithAttribute<DisableEditingAttribute> {
        private const            float        WIDTH         = 16f;
        internal static readonly GUIContent[] OPTIONS_ARRAY = { new GUIContent("Enable Editing"), new GUIContent("Disable Editing") };

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            using (var propScope = Disposables.PropertyScope(position, label, property)) {
                label = propScope.content;

                if (GetAttribute.AllowConfirmedEdit) {
                    GetAttribute.CurrentlyEditable =
                            FoCsGUI.DrawDisabledPropertyWithMenu(!GetAttribute.CurrentlyEditable, position, property, label, OPTIONS_ARRAY, GetAttribute.CurrentlyEditable? 0 : 1)
                                   .Value ==
                            0;
                }
                else {
                    using (Disposables.DisabledScope())
                        FoCsGUI.PropertyField(position, property, label, true, false);
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty prop, GUIContent label) => FoCsGUI.GetPropertyHeight(prop, label, true);
    }
}