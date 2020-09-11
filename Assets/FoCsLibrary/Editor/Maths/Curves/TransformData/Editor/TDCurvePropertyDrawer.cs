#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: TDCurvePropertyDrawer.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:04 AM
#endregion


using ForestOfChaos.Unity.Maths.Curves;
using ForestOfChaos.Unity.Utilities;
using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Editor.PropertyDrawers;
using UnityEditor;
using UnityEngine;
using URLP = ForestOfChaos.Unity.Editor.UnityReorderableListProperty;

namespace ForestOfChaos.Unity.Editor.Maths.Curves {
    public class TDCurvePropertyDrawer: FoCsPropertyDrawer {
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
                var targ = property.GetTargetObjectOfProperty<ITDCurve>();

                if (targ.IsFixedLength) {
                    if (positionsProp.arraySize != targ.Length)
                        positionsProp.arraySize = targ.Length;
                }

                ListNullCheck(property);
                list.HandleDrawing(position.Edit(RectEdit.ChangeX(16)));
            }
        }

        private void ListNullCheck(SerializedProperty property) {
            var targ = property.GetTargetObjectOfProperty<ITDCurve>();

            if (list == null) {
                list                       = new UnityReorderableListProperty(property.FindPropertyRelative("Positions"));
                list.List.onCanAddCallback = reorderableList => !targ.IsFixedLength;
            }
            else
                list.Property = property.FindPropertyRelative("Positions");
        }
    }

    [CustomPropertyDrawer(typeof(TDCurve))]
    public class TDCurveArrayPropertyDrawer: TDCurvePropertyDrawer { }

    [CustomPropertyDrawer(typeof(TDCurve2Points))]
    public class TDCurve2PointsPropertyDrawer: TDCurvePropertyDrawer { }

    [CustomPropertyDrawer(typeof(TDCurve3Points))]
    public class TDCurve3PointsPropertyDrawer: TDCurvePropertyDrawer { }

    [CustomPropertyDrawer(typeof(TDCurve4Points))]
    public class TDCurve4PointsPropertyDrawer: TDCurvePropertyDrawer { }
}