using ForestOfChaosAdvVar;
using ForestOfChaosLibraryEditor;
using ForestOfChaosLibraryEditor.PropertyDrawers.Attributes;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosAdvVarEditor
{
	[InitializeOnLoad]
	public static class AdvCustomRangeDrawer
	{
		static AdvCustomRangeDrawer()
		{
			RangeAttributeDrawer.AddCustomRangeDrawer(new AdvIntCustomRangeDrawer());
			RangeAttributeDrawer.AddCustomRangeDrawer(new AdvFloatCustomRangeDrawer());
			RangeAttributeDrawer.AddCustomRangeDrawer(new AdvStringCustomRangeDrawer());
		}
	}

	public class AdvIntCustomRangeDrawer: RangeAttributeDrawer.ICustomRangeDrawer
	{
		/// <inheritdoc />
		public bool IsThisType(object obj) => obj is IntVariable;

		/// <inheritdoc />
		public bool Draw(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, bool foldout) => AdvReferencePropertyDrawerBase.DoDraw(position, property, foldout, label, GetIntAction(property, range));

		private static System.Action<Rect> GetIntAction(SerializedProperty property, RangeAttribute range)
		{
			return rect =>
			{
				using(Disposables.Indent(-1))
					RangeAttributeDrawer.DoInt(rect, property.FindPropertyRelative("LocalValue"), GUIContent.none, range);
			};
		}

		/// <inheritdoc />
		public float GetHeight(SerializedProperty property, GUIContent label, bool foldout) => foldout? FoCsGUI.SingleLine * 2 : FoCsGUI.SingleLine;

		/// <inheritdoc />
		public GUIContent ChangeLabel(GUIContent label, RangeAttribute range) => label;
	}

	public class AdvFloatCustomRangeDrawer: RangeAttributeDrawer.ICustomRangeDrawer
	{
		/// <inheritdoc />
		public bool IsThisType(object obj) => obj is FloatVariable;

		/// <inheritdoc />
		public bool Draw(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, bool foldout) => AdvReferencePropertyDrawerBase.DoDraw(position, property, foldout, label, GetFloatAction(property, range));

		private static System.Action<Rect> GetFloatAction(SerializedProperty property, RangeAttribute range)
		{
			return rect =>
			{
				using(Disposables.Indent(-1))
					RangeAttributeDrawer.DoFloat(rect, property.FindPropertyRelative("LocalValue"), GUIContent.none, range);
			};
		}

		/// <inheritdoc />
		public float GetHeight(SerializedProperty property, GUIContent label, bool foldout) => foldout? FoCsGUI.SingleLine * 2 : FoCsGUI.SingleLine;

		/// <inheritdoc />
		public GUIContent ChangeLabel(GUIContent label, RangeAttribute range) => label;
	}

	public class AdvStringCustomRangeDrawer: RangeAttributeDrawer.ICustomRangeDrawer
	{
		/// <inheritdoc />
		public bool IsThisType(object obj) => obj is StringVariable;

		/// <inheritdoc />
		public bool Draw(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, bool foldout) => AdvReferencePropertyDrawerBase.DoDraw(position, property, foldout, label, GetStringAction(property, range));

		private static System.Action<Rect> GetStringAction(SerializedProperty property, RangeAttribute range)
		{
			return rect =>
			{
				using(Disposables.Indent(-1))
					RangeAttributeDrawer.DoString(rect, property.FindPropertyRelative("LocalValue"), GUIContent.none, range);
			};
		}

		/// <inheritdoc />
		public float GetHeight(SerializedProperty property, GUIContent label, bool foldout) => foldout? FoCsGUI.SingleLine * 2 : FoCsGUI.SingleLine;

		/// <inheritdoc />
		public GUIContent ChangeLabel(GUIContent label, RangeAttribute range)
		{
			label.text += label.text += string.Format("  (Total Length:{0})", (int)range.max);
			return label;
		}
	}
}
