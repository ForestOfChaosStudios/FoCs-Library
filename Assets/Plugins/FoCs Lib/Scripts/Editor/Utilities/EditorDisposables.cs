using System;
using ForestOfChaosLib.Editor.Utilities.Disposable;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.Utilities
{
	/// <summary>
	///     Every public method returns a IDisposable implementing object, most of them are for editor layout formatting
	/// </summary>
	public class EditorDisposables
	{
		public static ActionOnDispose Action(Action action) => new ActionOnDispose(action);

		#region Indent
		public static EditorIndent Indent() => new EditorIndent();
		public static EditorIndent Indent(int indentLevel) => new EditorIndent(indentLevel);
		public static EditorIndent IndentSet(int indentLevel) => new EditorIndent(indentLevel, true);
		#endregion

		#region ColorChanger
		public static EditorColorChanger ColorChanger(Color col) => new EditorColorChanger(col);
		public static EditorColorChanger ColorChanger(Color col, EditorColourType type) => new EditorColorChanger(col, type);
		#endregion

		#region LabelField
		public static EditorWidth LabelSetWidth(float size) => new EditorWidth(size, EditorWidth.WidthType.Label, EditorWidth.ChangeType.Set);
		public static EditorWidth FieldSetWidth(float size) => new EditorWidth(size, EditorWidth.WidthType.Field, EditorWidth.ChangeType.Set);
		public static EditorWidth LabelAddWidth(float size) => new EditorWidth(size, EditorWidth.WidthType.Label, EditorWidth.ChangeType.Add);
		public static EditorWidth FieldAddWidth(float size) => new EditorWidth(size, EditorWidth.WidthType.Field, EditorWidth.ChangeType.Add);
		public static EditorWidth LabelFieldAddWidth(float size) => new EditorWidth(size, EditorWidth.WidthType.Both, EditorWidth.ChangeType.Add);
		public static EditorWidth LabelFieldSetWidth(float size) => new EditorWidth(size, EditorWidth.WidthType.Both, EditorWidth.ChangeType.Set);
		#endregion

		#region UnityDisposables
		public static EditorGUI.DisabledGroupScope DisabledScope(bool val) => new EditorGUI.DisabledGroupScope(val);
		public static EditorGUI.ChangeCheckScope ChangeCheck() => new EditorGUI.ChangeCheckScope();

		#region LayoutScopes
		#region HorizontalScope
		public static GUILayout.HorizontalScope HorizontalScope() => new GUILayout.HorizontalScope();
		public static GUILayout.HorizontalScope HorizontalScope(GUIStyle skinBox) => new GUILayout.HorizontalScope(skinBox);
		public static GUILayout.HorizontalScope HorizontalScope(params GUILayoutOption[] options) => new GUILayout.HorizontalScope(options);

		public static GUILayout.HorizontalScope HorizontalScope(GUIStyle skinBox, params GUILayoutOption[] options) =>
				new GUILayout.HorizontalScope(skinBox, options);
		#endregion

		#region VerticalScope
		public static GUILayout.VerticalScope VerticalScope() => new GUILayout.VerticalScope();
		public static GUILayout.VerticalScope VerticalScope(GUIStyle skinBox) => new GUILayout.VerticalScope(skinBox);
		public static GUILayout.VerticalScope VerticalScope(params GUILayoutOption[] options) => new GUILayout.VerticalScope(options);
		public static GUILayout.VerticalScope VerticalScope(GUIStyle skinBox, params GUILayoutOption[] options) => new GUILayout.VerticalScope(skinBox, options);
		#endregion

		#region ScrollViewScope
		public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos) => new EditorGUILayout.ScrollViewScope(scrollPos);

		public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, bool handleScrollWheel) => new EditorGUILayout.ScrollViewScope(scrollPos)
																													{
																														handleScrollWheel = handleScrollWheel
																													};

		public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, params GUILayoutOption[] options) =>
				new EditorGUILayout.ScrollViewScope(scrollPos, options);

		public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, bool handleScrollWheel, params GUILayoutOption[] options) =>
				new EditorGUILayout.ScrollViewScope(scrollPos, options)
				{
					handleScrollWheel = handleScrollWheel
				};
		#endregion
		#endregion
		#endregion

		#region RectLayout
		public static RectHorizontalScope RectHorizontalScope(int count, Rect rect) => new RectHorizontalScope(count, rect);
		public static RectVerticalScope RectVerticalScope(int count, Rect rect) => new RectVerticalScope(count, rect);
		#endregion
	}
}