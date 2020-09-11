#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar.Editor
//       File: AdvCustomRangeDrawer.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:04 AM
#endregion


using System;
using ForestOfChaosLibrary.Editor;
using ForestOfChaosLibrary.Editor.PropertyDrawers.Attributes;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Editor {
    [InitializeOnLoad]
    public static class AdvCustomRangeDrawer {
        static AdvCustomRangeDrawer() {
            RangeAttributeDrawer.AddCustomRangeDrawer(new AdvIntCustomRangeDrawer());
            RangeAttributeDrawer.AddCustomRangeDrawer(new AdvFloatCustomRangeDrawer());
            RangeAttributeDrawer.AddCustomRangeDrawer(new AdvStringCustomRangeDrawer());
        }
    }

    public class AdvIntCustomRangeDrawer: RangeAttributeDrawer.ICustomRangeDrawer {

        private static Action<Rect> GetIntAction(SerializedProperty property, RangeAttribute range) {
            return rect => {
                using (Disposables.Indent(-1))
                    RangeAttributeDrawer.DoInt(rect, property.FindPropertyRelative("LocalValue"), GUIContent.none, range);
            };
        }

        /// <inheritdoc />
        public bool IsThisType(object obj) => obj is IntVariable;

        /// <inheritdoc />
        public bool Draw(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, bool foldout) =>
                AdvReferencePropertyDrawerBase.DoDraw(position, property, foldout, label, GetIntAction(property, range));

        /// <inheritdoc />
        public float GetHeight(SerializedProperty property, GUIContent label, bool foldout) => foldout? FoCsGUI.SingleLine * 2 : FoCsGUI.SingleLine;

        /// <inheritdoc />
        public GUIContent ChangeLabel(GUIContent label, RangeAttribute range) => label;
    }

    public class AdvFloatCustomRangeDrawer: RangeAttributeDrawer.ICustomRangeDrawer {

        private static Action<Rect> GetFloatAction(SerializedProperty property, RangeAttribute range) {
            return rect => {
                using (Disposables.Indent(-1))
                    RangeAttributeDrawer.DoFloat(rect, property.FindPropertyRelative("LocalValue"), GUIContent.none, range);
            };
        }

        /// <inheritdoc />
        public bool IsThisType(object obj) => obj is FloatVariable;

        /// <inheritdoc />
        public bool Draw(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, bool foldout) =>
                AdvReferencePropertyDrawerBase.DoDraw(position, property, foldout, label, GetFloatAction(property, range));

        /// <inheritdoc />
        public float GetHeight(SerializedProperty property, GUIContent label, bool foldout) => foldout? FoCsGUI.SingleLine * 2 : FoCsGUI.SingleLine;

        /// <inheritdoc />
        public GUIContent ChangeLabel(GUIContent label, RangeAttribute range) => label;
    }

    public class AdvStringCustomRangeDrawer: RangeAttributeDrawer.ICustomRangeDrawer {

        private static Action<Rect> GetStringAction(SerializedProperty property, RangeAttribute range) {
            return rect => {
                using (Disposables.Indent(-1))
                    RangeAttributeDrawer.DoString(rect, property.FindPropertyRelative("LocalValue"), GUIContent.none, range);
            };
        }

        /// <inheritdoc />
        public bool IsThisType(object obj) => obj is StringVariable;

        /// <inheritdoc />
        public bool Draw(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, bool foldout) =>
                AdvReferencePropertyDrawerBase.DoDraw(position, property, foldout, label, GetStringAction(property, range));

        /// <inheritdoc />
        public float GetHeight(SerializedProperty property, GUIContent label, bool foldout) => foldout? FoCsGUI.SingleLine * 2 : FoCsGUI.SingleLine;

        /// <inheritdoc />
        public GUIContent ChangeLabel(GUIContent label, RangeAttribute range) {
            label.text += label.text += string.Format("  (Total Length:{0})", (int)range.max);

            return label;
        }
    }
}