#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: NoFoldoutAttributeDrawer.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.Attributes;
using ForestOfChaos.Unity.Editor.Utilities;
using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.PropertyDrawers.Attributes {
    [CustomPropertyDrawer(typeof(NoFoldoutAttribute), true)]
    public class NoFoldoutAttributeDrawer: FoCsPropertyDrawerWithAttribute<NoFoldoutAttribute> {
        private UnityReorderableListStorage listStorage = new UnityReorderableListStorage();
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            using (var propScope = Disposables.PropertyScope(position, label, property)) {
                var rect = position;
                label               = propScope.content;
                property.isExpanded = true;

                if (GetAttribute.ShowVariableName) {
                    if (GetAttribute.ArrayElementNameReplacement.IsNotNullOrEmpty()) {
                        label.text = label.text.Replace("Element", GetAttribute.ArrayElementNameReplacement);
                    }
                    rect.height = SingleLine;
                    FoCsGUI.Label(rect, label);
                    rect.y += SingleLine;
                }

                property.NextVisible(true);
                if (GetAttribute.IndentChildItems) {
                    using (Disposables.Indent()) {
                        DrawProperty(property, rect);
                    }
                }
                else {
                    DrawProperty(property, rect);
                }
            }
        }

        private void DrawProperty(SerializedProperty property, Rect rect) {
            var modifiedRect = new Rect(rect);
            foreach (var child in property.GetChildren()) {
                if (child.isArray) {
                    var list = listStorage.GetList(child);
                    using (Disposables.Indent(2))
                        list.HandleDrawing(modifiedRect.GetModifiedRect(RectEdit.Indent()));
                    modifiedRect = modifiedRect.GetModifiedRect(RectEdit.AddY(list.GetTotalHeight()));
                }
                else {
                    FoCsGUI.PropertyField(modifiedRect, child, true, FoCsGUI.AttributeCheck.DoCheck);
                    modifiedRect = modifiedRect.GetModifiedRect(RectEdit.AddY(FoCsGUI.GetPropertyHeight(child, GUIContent.none, true, FoCsGUI.AttributeCheck.DoCheck)));
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var totalHeight = GetAttribute.ShowVariableName? SingleLinePlusPadding : 2f;
            property.isExpanded = true;
            property.NextVisible(true);

            foreach (var child in property.GetChildren()) {
                if (child.isArray) {
                    var list = listStorage.GetList(child);
                    totalHeight += list.GetTotalHeight();
                }
                else {
                    totalHeight += FoCsGUI.GetPropertyHeight(child, GUIContent.none, true, FoCsGUI.AttributeCheck.DoCheck);
                }
            }

            return totalHeight - 2f;
        }
    }
}