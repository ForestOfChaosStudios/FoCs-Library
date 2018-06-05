using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers
{
	public class FoCsPropertyDrawer: PropertyDrawer
	{
		public static float SingleLine            { get; } = FoCsGUI.SingleLine;
		public static float Padding               { get; } = FoCsGUI.Padding;
		public static float SingleLinePlusPadding { get; } = FoCsGUI.SingleLinePlusPadding;
		public static float IndentSize            { get; } = FoCsGUI.IndentSize;
		public static float PropertyHeight(SerializedProperty      property, GUIContent label) => EditorGUI.GetPropertyHeight(property, label);
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => PropertyHeight(property, label);
	}

	public class FoCsPropertyDrawer<T>: FoCsPropertyDrawer
	{
		public T GetOwner(SerializedProperty prop) => prop.GetTargetObjectOfProperty<T>();
	}

	public class FoCsPropertyDrawerWithAttribute<A>: FoCsPropertyDrawer where A: PropertyAttribute
	{
		public A GetAttribute => (A)attribute;
	}

	public class FoCsPropertyDrawerWithAttribute<T, A>: FoCsPropertyDrawer<T> where A: PropertyAttribute
	{
		public A GetAttribute => (A)attribute;
	}
}
