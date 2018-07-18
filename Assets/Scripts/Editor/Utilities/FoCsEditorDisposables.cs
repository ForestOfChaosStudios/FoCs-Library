using System;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Editor.Utilities.Disposable;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsEditor
	{
		/// <summary>
		///     Every public method returns a IDisposable implementing object, most of them are for editor layout formatting
		/// </summary>
		public static class Disposables
		{
			public static ActionOnDispose Action(Action action)
			{
				return new ActionOnDispose(action);
			}

#region FadeGroup
			public static EditorGUILayout.FadeGroupScope FadeGroupScope(float value)
			{
				return new EditorGUILayout.FadeGroupScope(value);
			}
#endregion

#region PropertyScope
			public static EditorGUI.PropertyScope PropertyScope(Rect rect, GUIContent label, SerializedProperty prop)
			{
				return new EditorGUI.PropertyScope(rect, label, prop);
			}
#endregion

#region Indent
			public static EditorIndent Indent()
			{
				return new EditorIndent();
			}

			public static EditorIndent Indent(int    indentLevel)
			{
				return new EditorIndent(indentLevel);
			}

			public static EditorIndent IndentSet(int indentLevel)
			{
				return new EditorIndent(indentLevel, true);
			}

			public static EditorIndent SetIndent(int indentLevel)
			{
				return IndentSet(indentLevel);
			}

			public static EditorIndent IndentZeroed()
			{
				return new EditorIndent(0, true);
			}
#endregion

#region ColorChanger
			public static EditorColorChanger ColorChanger(Color col)
			{
				return new EditorColorChanger(col);
			}

			public static EditorColorChanger ColorChanger(Color col, EditorColourType type)
			{
				return new EditorColorChanger(col, type);
			}
#endregion

#region LabelField
			public static EditorWidth LabelSetWidth(float      size)
			{
				return new EditorWidth(size, EditorWidth.WidthType.Label, EditorWidth.ChangeType.Set);
			}

			public static EditorWidth FieldSetWidth(float      size)
			{
				return new EditorWidth(size, EditorWidth.WidthType.Field, EditorWidth.ChangeType.Set);
			}

			public static EditorWidth LabelAddWidth(float      size)
			{
				return new EditorWidth(size, EditorWidth.WidthType.Label, EditorWidth.ChangeType.Add);
			}

			public static EditorWidth FieldAddWidth(float      size)
			{
				return new EditorWidth(size, EditorWidth.WidthType.Field, EditorWidth.ChangeType.Add);
			}

			public static EditorWidth LabelFieldAddWidth(float size)
			{
				return new EditorWidth(size, EditorWidth.WidthType.Both, EditorWidth.ChangeType.Add);
			}

			public static EditorWidth LabelFieldSetWidth(float size)
			{
				return new EditorWidth(size, EditorWidth.WidthType.Both, EditorWidth.ChangeType.Set);
			}
#endregion

#region UnityDisposables
			public static EditorGUI.DisabledGroupScope     DisabledScope(bool      val = true)
			{
				return new EditorGUI.DisabledGroupScope(val);
			}

			public static EditorGUILayout.ToggleGroupScope ToggleGroupScope(string label, bool toggle)
			{
				return new EditorGUILayout.ToggleGroupScope(label, toggle);
			}

			public static EditorGUI.ChangeCheckScope       ChangeCheck()
			{
				return new EditorGUI.ChangeCheckScope();
			}

#region LayoutScopes
#region HorizontalScope
			public static GUILayout.HorizontalScope HorizontalScope()
			{
				return new GUILayout.HorizontalScope();
			}

			public static GUILayout.HorizontalScope HorizontalScope(GUIStyle                 skinBox)
			{
				return new GUILayout.HorizontalScope(skinBox);
			}

			public static GUILayout.HorizontalScope HorizontalScope(params GUILayoutOption[] options)
			{
				return new GUILayout.HorizontalScope(options);
			}

			public static GUILayout.HorizontalScope HorizontalScope(GUIStyle                 skinBox, params GUILayoutOption[] options)
			{
				return new GUILayout.HorizontalScope(skinBox, options);
			}
#endregion

#region VerticalScope
			public static GUILayout.VerticalScope VerticalScope()
			{
				return new GUILayout.VerticalScope();
			}

			public static GUILayout.VerticalScope VerticalScope(GUIStyle                 skinBox)
			{
				return new GUILayout.VerticalScope(skinBox);
			}

			public static GUILayout.VerticalScope VerticalScope(params GUILayoutOption[] options)
			{
				return new GUILayout.VerticalScope(options);
			}

			public static GUILayout.VerticalScope VerticalScope(GUIStyle                 skinBox, params GUILayoutOption[] options)
			{
				return new GUILayout.VerticalScope(skinBox, options);
			}
#endregion

#region AreaScope
			public static GUILayout.AreaScope AreaScope(Rect rect)
			{
				return new GUILayout.AreaScope(rect);
			}

			public static GUILayout.AreaScope AreaScope(Rect rect, string     content)
			{
				return new GUILayout.AreaScope(rect, content);
			}

			public static GUILayout.AreaScope AreaScope(Rect rect, string     content, GUIStyle style)
			{
				return new GUILayout.AreaScope(rect, content, style);
			}

			public static GUILayout.AreaScope AreaScope(Rect rect, GUIContent content)
			{
				return new GUILayout.AreaScope(rect, content);
			}

			public static GUILayout.AreaScope AreaScope(Rect rect, GUIContent content, GUIStyle style)
			{
				return new GUILayout.AreaScope(rect, content, style);
			}

			public static GUILayout.AreaScope AreaScope(Rect rect, Texture    texture)
			{
				return new GUILayout.AreaScope(rect, texture);
			}

			public static GUILayout.AreaScope AreaScope(Rect rect, Texture    texture, GUIStyle style)
			{
				return new GUILayout.AreaScope(rect, texture, style);
			}
#endregion

#region ScrollViewScope
			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos)
			{
				return new EditorGUILayout.ScrollViewScope(scrollPos);
			}

			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, bool                     handleScrollWheel)
			{
				return new EditorGUILayout.ScrollViewScope(scrollPos) {handleScrollWheel = handleScrollWheel};
			}

			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, params GUILayoutOption[] options)
			{
				return new EditorGUILayout.ScrollViewScope(scrollPos, options);
			}

			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, bool handleScrollWheel, params GUILayoutOption[] options)
			{
				return new EditorGUILayout.ScrollViewScope(scrollPos, options) {handleScrollWheel = handleScrollWheel};
			}

			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, bool handleScrollWheel, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options)
			{
				return new EditorGUILayout.ScrollViewScope(scrollPos, alwaysShowHorizontal, alwaysShowVertical, options) {handleScrollWheel = handleScrollWheel};
			}
#endregion
#endregion
#endregion

#region RectLayout
			public static RectHorizontalScope RectHorizontalScope(int count, Rect rect)
			{
				return new RectHorizontalScope(count, rect);
			}

			public static RectVerticalScope   RectVerticalScope(int   count, Rect rect)
			{
				return new RectVerticalScope(count, rect);
			}
#endregion

		}
	}
}