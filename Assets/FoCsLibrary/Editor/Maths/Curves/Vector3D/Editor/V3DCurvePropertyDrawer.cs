#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: V3DCurvePropertyDrawer.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:04 AM
#endregion


using ForestOfChaosLibrary.Editor.PropertyDrawers;
using ForestOfChaosLibrary.Extensions;
using ForestOfChaosLibrary.Maths.Curves;
using ForestOfChaosLibrary.Utilities;
using UnityEditor;
using UnityEngine;
using URLP = ForestOfChaosLibrary.Editor.UnityReorderableListProperty;

namespace ForestOfChaosLibrary.Editor.Maths.Curves {
    public class V3DCurvePropertyDrawer: FoCsPropertyDrawer {
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
                var useGlobalBoolRect  = position.Edit(RectEdit.SetHeight(SingleLine));
                position = position.Edit(RectEdit.ChangeY(SingleLine));
                EditorGUI.PropertyField(useGlobalBoolRect, useGlobalSpaceProp);
                var targ = property.GetTargetObjectOfProperty<IV3Curve>();

                if (targ.IsFixedLength) {
                    if (positionsProp.arraySize != targ.Length)
                        positionsProp.arraySize = targ.Length;
                }

                ListNullCheck(property);
                list.HandleDrawing(position.Edit(RectEdit.ChangeX(16)));
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

    [CustomPropertyDrawer(typeof(V3Curve))]
    public class V3DCurveArrayPropertyDrawer: V3DCurvePropertyDrawer { }

    [CustomPropertyDrawer(typeof(V3Curve3Points))]
    public class V3DCurve3PointsPropertyDrawer: V3DCurvePropertyDrawer { }

    [CustomPropertyDrawer(typeof(V3Curve4Points))]
    public class V3DCurve4PointsPropertyDrawer: V3DCurvePropertyDrawer { }
}