#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: NoFoldoutAttributeDrawer.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:04 AM
#endregion


using ForestOfChaosLibrary.Attributes;
using ForestOfChaosLibrary.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor.PropertyDrawers.Attributes {
    [CustomPropertyDrawer(typeof(NoFoldoutAttribute), true)]
    public class NoFoldoutAttributeDrawer: FoCsPropertyDrawerWithAttribute<NoFoldoutAttribute> {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            using (var propScope = Disposables.PropertyScope(position, label, property)) {
                var rect = position;
                label               = propScope.content;
                property.isExpanded = true;

                if (GetAttribute.ShowVariableName) {
                    rect.height = SingleLine;
                    EditorGUI.LabelField(rect, label);
                    rect.y += SingleLine;
                }

                property.NextVisible(true);

                using (Disposables.Indent()) {
                    foreach (var child in property.GetChildren()) {
                        FoCsGUI.PropertyField(rect, child, true, FoCsGUI.AttributeCheck.DoCheck);
                        rect.y += FoCsGUI.GetPropertyHeight(child, GUIContent.none, true, FoCsGUI.AttributeCheck.DoCheck);
                    }
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var totalHeight = GetAttribute.ShowVariableName? SingleLinePlusPadding : 2f;
            property.isExpanded = true;
            property.NextVisible(true);

            foreach (var child in property.GetChildren())
                totalHeight += FoCsGUI.GetPropertyHeight(child, GUIContent.none, true, FoCsGUI.AttributeCheck.DoCheck);

            return totalHeight - 2f;
        }
    }
}