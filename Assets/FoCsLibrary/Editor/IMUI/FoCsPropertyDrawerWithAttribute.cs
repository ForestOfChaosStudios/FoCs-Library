#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsPropertyDrawerWithAttribute.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:10 PM
#endregion

using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.PropertyDrawers {
    public class FoCsPropertyDrawer: PropertyDrawer {
        public static float SingleLine => FoCsGUI.SingleLine;

        public static float Padding => FoCsGUI.Padding;

        public static float SingleLinePlusPadding => FoCsGUI.SingleLinePlusPadding;

        public static float IndentSize => FoCsGUI.IndentSize;

        public static float PropertyHeight(SerializedProperty property, GUIContent label) => EditorGUI.GetPropertyHeight(property, label);

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => PropertyHeight(property, label);
    }

    public class FoCsPropertyDrawer<T>: FoCsPropertyDrawer {
        public T GetTargetObject(SerializedProperty prop) => prop.GetTargetObjectOfProperty<T>();
    }

    public class FoCsPropertyDrawerWithAttribute<A>: FoCsPropertyDrawer where A: PropertyAttribute {
        public A GetAttribute => (A)attribute;
    }

    public class FoCsPropertyDrawerWithAttribute<T, A>: FoCsPropertyDrawer<T> where A: PropertyAttribute {
        public A GetAttribute => (A)attribute;
    }
}