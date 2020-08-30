#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library.Editor
//       File: MultiInLineAttributeDrawer.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:49 AM
#endregion


using ForestOfChaosLibrary.Attributes;
using ForestOfChaosLibrary.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor.PropertyDrawers.Attributes {
    [CustomPropertyDrawer(typeof(MultiInLineAttribute), true)]
    public class MultiInLineAttributeDrawer: FoCsPropertyDrawerWithAttribute<MultiInLineAttribute> {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            using (var propScope = Disposables.PropertyScope(position, label, property)) {
                label = propScope.content;

                using (Disposables.LabelFieldSetWidth((position.width / GetAttribute.totalAmount) * 0.5f)) {
                    using (var scope = Disposables.RectHorizontalScope(GetAttribute.totalAmount, position)) {
                        for (var i = 0; i < GetAttribute.index; i++)
                            scope.GetNext();

                        FoCsGUI.PropertyField(scope.GetNext(RectEdit.SubtractY(SingleLinePlusPadding * GetAttribute.index), RectEdit.SetHeight(SingleLine)), property, label);
                    }
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty prop, GUIContent label) => GetAttribute.index == 0? SingleLinePlusPadding : 0;
    }
}