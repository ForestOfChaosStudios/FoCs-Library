using ForestOfChaos.Unity.Editor.PropertyDrawers;
using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Maths.Curves;
using ForestOfChaos.Unity.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.Maths.Curves {

    public class CurvePropertyDrawer: FoCsPropertyDrawer {
        private UnityReorderableListProperty list;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            ListNullCheck(property);

            return SingleLine + list.GetTotalHeight();
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            using (var propScope = Disposables.PropertyScope(position, label, property)) {
                label = propScope.content;
                var useGlobalSpaceProp = property.FindPropertyRelative("useGlobalSpace");
                var positionsProp      = property.FindPropertyRelative("Positions");
                var useGlobalBoolRect  = position.GetModifiedRect(RectEdit.SetHeight(SingleLine));
                position = position.GetModifiedRect(RectEdit.ChangeY(SingleLine));
                EditorGUI.PropertyField(useGlobalBoolRect, useGlobalSpaceProp);
                var targ = property.GetTargetObjectOfProperty<IV3Curve>();

                if (targ.IsFixedLength) {
                    if (positionsProp.arraySize != targ.Length)
                        positionsProp.arraySize = targ.Length;
                }

                ListNullCheck(property);
                list.HandleDrawing(position.GetModifiedRect(RectEdit.ChangeX(16)));
            }
        }

        private void ListNullCheck(SerializedProperty property) {
            var targ = property.GetTargetObjectOfProperty<IV3Curve>();

            if (list == null) {
                list                       = new UnityReorderableListProperty(property.FindPropertyRelative("Positions"));
                list.List.onCanAddCallback = reorderableList => !targ.IsFixedLength;
            }
            else
                list.Property = property.FindPropertyRelative("Positions");
        }
    }
}
