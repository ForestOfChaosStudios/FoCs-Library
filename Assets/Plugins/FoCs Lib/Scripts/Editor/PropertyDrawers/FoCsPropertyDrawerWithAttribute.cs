using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers
{
	public class FoCsPropertyDrawer: PropertyDrawer
	{
		public static float SingleLine { get; } = FoCsEditorUtilities.SingleLine;
		public static float Padding { get; } = FoCsEditorUtilities.Padding;
		public static float SingleLinePlusPadding { get; } = FoCsEditorUtilities.SingleLinePlusPadding;
		public static float IndentSize { get; } = FoCsEditorUtilities.IndentSize;

		public static float PropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUI.GetPropertyHeight(property, label);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return PropertyHeight(property, label);
		}
	}

	public class FoCsPropertyDrawer<T>: FoCsPropertyDrawer
	{
		public T GetOwner(SerializedProperty prop)
		{
			return prop.GetTargetObjectOfProperty<T>();
		}
	}

	public class FoCsPropertyDrawerWithAttribute<A>: FoCsPropertyDrawer where A: PropertyAttribute
	{
		public A GetAttribute
		{
			get { return (A)attribute; }
		}
	}

	public class FoCsPropertyDrawerWithAttribute<T, A>: FoCsPropertyDrawer<T> where A: PropertyAttribute
	{
		public A GetAttribute
		{
			get { return (A)attribute; }
		}
	}
}