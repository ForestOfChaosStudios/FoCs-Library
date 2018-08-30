using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.PropertyDrawers.Attributes;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Editor
{
	[InitializeOnLoad]
	public static class AdvRangeDrawer
	{
		static AdvRangeDrawer()
		{
			RangeAttributeDrawer.AddExtraDrawer(new AdvIntRangeDrawer());
			RangeAttributeDrawer.AddExtraDrawer(new AdvFloatRangeDrawer());
			RangeAttributeDrawer.AddExtraDrawer(new AdvStringRangeDrawer());
		}
	}

	public class AdvIntRangeDrawer: RangeAttributeDrawer.IRangeDrawer
	{
		/// <inheritdoc />
		public bool IsThisType(object obj) => obj is IntVariable;

		/// <inheritdoc />
		public bool Draw(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, bool foldout)
		{
			return AdvReferencePropertyDrawerBase.DoDraw(position, property, foldout, label, rect => RangeAttributeDrawer.DoInt(rect, property.FindPropertyRelative("LocalValue"), label, range));
		}

		/// <inheritdoc />
		public float GetHeight(SerializedProperty property, GUIContent label, bool foldout) => foldout? FoCsGUI.SingleLine : FoCsGUI.SingleLine * 2;
	}

	public class AdvFloatRangeDrawer: RangeAttributeDrawer.IRangeDrawer
	{
		/// <inheritdoc />
		public bool IsThisType(object obj) => obj is FloatVariable;

		/// <inheritdoc />
		public bool Draw(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, bool foldout)
		{
			return AdvReferencePropertyDrawerBase.DoDraw(position, property, foldout, label, rect => RangeAttributeDrawer.DoFloat(rect, property.FindPropertyRelative("LocalValue"), label, range));
		}

		/// <inheritdoc />
		public float GetHeight(SerializedProperty property, GUIContent label, bool foldout) => foldout? FoCsGUI.SingleLine : FoCsGUI.SingleLine * 2;
	}

	public class AdvStringRangeDrawer: RangeAttributeDrawer.IRangeDrawer
	{
		/// <inheritdoc />
		public bool IsThisType(object obj) => obj is StringVariable;

		/// <inheritdoc />
		public bool Draw(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, bool foldout)
		{
			return AdvReferencePropertyDrawerBase.DoDraw(position, property, foldout, label, rect => RangeAttributeDrawer.DoString(rect, property.FindPropertyRelative("LocalValue"), label, range));
		}

		/// <inheritdoc />
		public float GetHeight(SerializedProperty property, GUIContent label, bool foldout) => foldout? FoCsGUI.SingleLine : FoCsGUI.SingleLine * 2;
	}
}
