#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: QuaternionPropertyDrawer.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:10 PM
#endregion

using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.PropertyDrawers {
    [CustomPropertyDrawer(typeof(Quaternion))]
    public class QuaternionPropertyDrawer: VectorPropEditor {
        public static readonly GUIContent[] Options = {new GUIContent("Euler Angles"), new GUIContent("Quaternion")};
        private static         bool         ShowAngles;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            Draw(position, property, label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => SingleLine;

        public static void Draw(Rect position, SerializedProperty property, GUIContent label) {
            using (var propScope = Disposables.PropertyScope(position, label, property)) {
                label           = propScope.content;
                position.height = SingleLine;
                ShowAngles      = FoCsGUI.DrawActionWithMenu(position, rect => DoDraw(rect, property), label, Options, ShowAngles? 0 : 1) == 0;
            }
        }

        private static void DoDraw(Rect position, SerializedProperty property) {
            if (ShowAngles)
                DrawExpanded(position, property);
            else
                DrawNormal(position, property);
        }

        private static void DrawExpanded(Rect position, SerializedProperty property) {
            var val = property.quaternionValue;

            using (var cc = Disposables.ChangeCheck()) {
                using (Disposables.SetIndent(0))
                    val.eulerAngles = EditorGUI.Vector3Field(position.Edit(RectEdit.SetHeight(SingleLine), RectEdit.SubtractWidth(2)), GUIContent.none, val.eulerAngles);

                if (cc.changed)
                    property.quaternionValue = val;
            }
        }

        private static void DrawNormal(Rect position, SerializedProperty property) {
            using (Disposables.SetIndent(0)) {
                using (Disposables.LabelSetWidth(LABEL_WIDTH)) {
                    using (var scope = Disposables.RectHorizontalScope(4, position)) {
                        property.Next(true);
                        EditorGUI.PropertyField(scope.GetNext(RectEdit.SubtractWidth(2)), property, X_Content);
                        property.Next(true);
                        EditorGUI.PropertyField(scope.GetNext(RectEdit.SubtractWidth(2)), property, Y_Content);
                        property.Next(true);
                        EditorGUI.PropertyField(scope.GetNext(RectEdit.SubtractWidth(2)), property, Z_Content);
                        property.Next(true);
                        EditorGUI.PropertyField(scope.GetNext(RectEdit.SubtractWidth(2)), property, W_Content);
                    }
                }
            }
        }
    }
}