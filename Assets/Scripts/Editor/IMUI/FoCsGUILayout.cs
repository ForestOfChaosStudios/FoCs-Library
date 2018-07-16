using System;
using UnityEditor;
using UnityEngine;
using GUICon = UnityEngine.GUIContent;
using GUILayOpt = UnityEngine.GUILayoutOption;
using eInt = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<int>;
using eBool = ForestOfChaosLib.Editor.FoCsGUI.GUIEventBool;
using eFloat = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<float>;
using eString = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<string>;
using eObject = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<UnityEngine.Object>;
using Object = UnityEngine.Object;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public static partial class FoCsGUI
	{
		public static class Layout
		{

#region LayoutScopes
#region HorizontalScope
			public static GUILayout.HorizontalScope HorizontalScope() => FoCsEditor.Disposables.HorizontalScope();
			public static GUILayout.HorizontalScope HorizontalScope(GUIStyle           skinBox) => FoCsEditor.Disposables.HorizontalScope(skinBox);
			public static GUILayout.HorizontalScope HorizontalScope(params GUILayOpt[] options) => FoCsEditor.Disposables.HorizontalScope(options);
			public static GUILayout.HorizontalScope HorizontalScope(GUIStyle           skinBox, params GUILayOpt[] options) => FoCsEditor.Disposables.HorizontalScope(skinBox, options);
#endregion

#region VerticalScope
			public static GUILayout.VerticalScope VerticalScope() => FoCsEditor.Disposables.VerticalScope();
			public static GUILayout.VerticalScope VerticalScope(GUIStyle           skinBox) => FoCsEditor.Disposables.VerticalScope(skinBox);
			public static GUILayout.VerticalScope VerticalScope(params GUILayOpt[] options) => FoCsEditor.Disposables.VerticalScope(options);
			public static GUILayout.VerticalScope VerticalScope(GUIStyle           skinBox, params GUILayOpt[] options) => FoCsEditor.Disposables.VerticalScope(skinBox, options);
#endregion

#region AreaScope
			public static GUILayout.AreaScope AreaScope(Rect rect) => FoCsEditor.Disposables.AreaScope(rect);
			public static GUILayout.AreaScope AreaScope(Rect rect, string     content) => FoCsEditor.Disposables.AreaScope(rect,                 content);
			public static GUILayout.AreaScope AreaScope(Rect rect, string     content, GUIStyle style) => FoCsEditor.Disposables.AreaScope(rect, content, style);
			public static GUILayout.AreaScope AreaScope(Rect rect, GUIContent content) => FoCsEditor.Disposables.AreaScope(rect,                 content);
			public static GUILayout.AreaScope AreaScope(Rect rect, GUIContent content, GUIStyle style) => FoCsEditor.Disposables.AreaScope(rect, content, style);
			public static GUILayout.AreaScope AreaScope(Rect rect, Texture    texture) => FoCsEditor.Disposables.AreaScope(rect,                 texture);
			public static GUILayout.AreaScope AreaScope(Rect rect, Texture    texture, GUIStyle style) => FoCsEditor.Disposables.AreaScope(rect, texture, style);
#endregion

#region ScrollViewScope
			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos) => FoCsEditor.Disposables.ScrollViewScope(scrollPos,                                                                   true);
			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, bool               handleScrollWheel) => FoCsEditor.Disposables.ScrollViewScope(scrollPos,                             handleScrollWheel);
			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, params GUILayOpt[] options) => FoCsEditor.Disposables.ScrollViewScope(scrollPos,                                       true,              options);
			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, bool               handleScrollWheel, params GUILayOpt[] options) => FoCsEditor.Disposables.ScrollViewScope(scrollPos, handleScrollWheel, options);

			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, bool handleScrollWheel, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayOpt[] options) =>
					FoCsEditor.Disposables.ScrollViewScope(scrollPos, handleScrollWheel, alwaysShowHorizontal, alwaysShowVertical, options);
#endregion
#endregion

#region LabelField
			public static GUIEvent LabelField() => LabelFieldMaster(GUICon.none,                                                     LabelStyle);
			public static GUIEvent LabelField(GUIStyle           style) => LabelFieldMaster(GUICon.none,                             style);
			public static GUIEvent LabelField(params GUILayOpt[] options) => LabelFieldMaster(GUICon.none,                           LabelStyle, options);
			public static GUIEvent LabelField(GUIStyle           style, params GUILayOpt[] options) => LabelFieldMaster(GUICon.none, style,      options);
			public static GUIEvent LabelField(string             label) => LabelFieldMaster(new GUICon(label),                                                       LabelStyle);
			public static GUIEvent LabelField(string             label, GUIStyle           style) => LabelFieldMaster(new GUICon(label),                             style);
			public static GUIEvent LabelField(string             label, params GUILayOpt[] options) => LabelFieldMaster(new GUICon(label),                           LabelStyle, options);
			public static GUIEvent LabelField(string             label, GUIStyle           style, params GUILayOpt[] options) => LabelFieldMaster(new GUICon(label), style,      options);
			public static GUIEvent LabelField(GUICon             guiCon) => LabelFieldMaster(guiCon,                                                       LabelStyle);
			public static GUIEvent LabelField(GUICon             guiCon, GUIStyle           style) => LabelFieldMaster(guiCon,                             style);
			public static GUIEvent LabelField(GUICon             guiCon, params GUILayOpt[] options) => LabelFieldMaster(guiCon,                           LabelStyle, options);
			public static GUIEvent LabelField(GUICon             guiCon, GUIStyle           style, params GUILayOpt[] options) => LabelFieldMaster(guiCon, style,      options);
			public static GUIEvent LabelField(Texture            texture) => LabelFieldMaster(new GUICon(texture),                                                       LabelStyle);
			public static GUIEvent LabelField(Texture            texture, GUIStyle           style) => LabelFieldMaster(new GUICon(texture),                             style);
			public static GUIEvent LabelField(Texture            texture, params GUILayOpt[] options) => LabelFieldMaster(new GUICon(texture),                           LabelStyle, options);
			public static GUIEvent LabelField(Texture            texture, GUIStyle           style, params GUILayOpt[] options) => LabelFieldMaster(new GUICon(texture), style,      options);
			private static GUIEvent LabelFieldMaster(GUICon      guiCon,  GUIStyle           style) => LabelFieldMaster(guiCon, style, null);

			private static GUIEvent LabelFieldMaster(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				EditorGUILayout.LabelField(guiCon, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect());
			}
#endregion

#region Label
			public static GUIEvent Label() => LabelMaster(GUICon.none,                                                     LabelStyle);
			public static GUIEvent Label(GUIStyle           style) => LabelMaster(GUICon.none,                             style);
			public static GUIEvent Label(params GUILayOpt[] options) => LabelMaster(GUICon.none,                           LabelStyle, options);
			public static GUIEvent Label(GUIStyle           style, params GUILayOpt[] options) => LabelMaster(GUICon.none, style,      options);
			public static GUIEvent Label(string             label) => LabelMaster(new GUICon(label),                                                       LabelStyle);
			public static GUIEvent Label(string             label, GUIStyle           style) => LabelMaster(new GUICon(label),                             style);
			public static GUIEvent Label(string             label, params GUILayOpt[] options) => LabelMaster(new GUICon(label),                           LabelStyle, options);
			public static GUIEvent Label(string             label, GUIStyle           style, params GUILayOpt[] options) => LabelMaster(new GUICon(label), style,      options);
			public static GUIEvent Label(GUICon             guiCon) => LabelMaster(guiCon,                                                       LabelStyle);
			public static GUIEvent Label(GUICon             guiCon, GUIStyle           style) => LabelMaster(guiCon,                             style);
			public static GUIEvent Label(GUICon             guiCon, params GUILayOpt[] options) => LabelMaster(guiCon,                           LabelStyle, options);
			public static GUIEvent Label(GUICon             guiCon, GUIStyle           style, params GUILayOpt[] options) => LabelMaster(guiCon, style,      options);
			public static GUIEvent Label(Texture            texture) => LabelMaster(new GUICon(texture),                                                       LabelStyle);
			public static GUIEvent Label(Texture            texture, GUIStyle           style) => LabelMaster(new GUICon(texture),                             style);
			public static GUIEvent Label(Texture            texture, params GUILayOpt[] options) => LabelMaster(new GUICon(texture),                           LabelStyle, options);
			public static GUIEvent Label(Texture            texture, GUIStyle           style, params GUILayOpt[] options) => LabelMaster(new GUICon(texture), style,      options);
			private static GUIEvent LabelMaster(GUICon      guiCon,  GUIStyle           style) => LabelMaster(guiCon, style, null);

			private static GUIEvent LabelMaster(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				GUILayout.Label(guiCon, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect());
			}
#endregion

#region Button
			public static eBool Button() => ButtonMaster(GUICon.none,                                                     ButtonStyle);
			public static eBool Button(GUIStyle           style) => ButtonMaster(GUICon.none,                             style);
			public static eBool Button(params GUILayOpt[] options) => ButtonMaster(GUICon.none,                           ButtonStyle, options);
			public static eBool Button(GUIStyle           style, params GUILayOpt[] options) => ButtonMaster(GUICon.none, style,       options);
			public static eBool Button(string             label) => ButtonMaster(new GUICon(label),                                                       ButtonStyle);
			public static eBool Button(string             label, GUIStyle           style) => ButtonMaster(new GUICon(label),                             style);
			public static eBool Button(string             label, params GUILayOpt[] options) => ButtonMaster(new GUICon(label),                           ButtonStyle, options);
			public static eBool Button(string             label, GUIStyle           style, params GUILayOpt[] options) => ButtonMaster(new GUICon(label), style,       options);
			public static eBool Button(GUICon             guiCon) => ButtonMaster(guiCon,                                                       ButtonStyle);
			public static eBool Button(GUICon             guiCon, GUIStyle           style) => ButtonMaster(guiCon,                             style);
			public static eBool Button(GUICon             guiCon, params GUILayOpt[] options) => ButtonMaster(guiCon,                           ButtonStyle, options);
			public static eBool Button(GUICon             guiCon, GUIStyle           style, params GUILayOpt[] options) => ButtonMaster(guiCon, style,       options);
			public static eBool Button(Texture            texture) => ButtonMaster(new GUICon(texture),                                                       ButtonStyle);
			public static eBool Button(Texture            texture, GUIStyle           style) => ButtonMaster(new GUICon(texture),                             style);
			public static eBool Button(Texture            texture, params GUILayOpt[] options) => ButtonMaster(new GUICon(texture),                           ButtonStyle, options);
			public static eBool Button(Texture            texture, GUIStyle           style, params GUILayOpt[] options) => ButtonMaster(new GUICon(texture), style,       options);
			private static eBool ButtonMaster(GUICon      guiCon,  GUIStyle           style) => ButtonMaster(guiCon, style, null);

			private static eBool ButtonMaster(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				var b = GUILayout.Button(guiCon, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), b);
			}
#endregion

#region Toggle
			public static eBool Toggle(bool        toggle) => ToggleMaster(toggle,                                                        GUICon.none, ToggleStyle);
			public static eBool Toggle(bool        toggle,  GUIStyle           style) => ToggleMaster(toggle,                             GUICon.none, style);
			public static eBool Toggle(bool        toggle,  params GUILayOpt[] options) => ToggleMaster(toggle,                           GUICon.none, ToggleStyle, options);
			public static eBool Toggle(bool        toggle,  GUIStyle           style, params GUILayOpt[] options) => ToggleMaster(toggle, GUICon.none, style,       options);
			public static eBool Toggle(string      label,   bool               toggle) => ToggleMaster(toggle,                                                       new GUICon(label), ToggleStyle);
			public static eBool Toggle(string      label,   bool               toggle, GUIStyle           style) => ToggleMaster(toggle,                             new GUICon(label), style);
			public static eBool Toggle(string      label,   bool               toggle, params GUILayOpt[] options) => ToggleMaster(toggle,                           new GUICon(label), ToggleStyle, options);
			public static eBool Toggle(string      label,   bool               toggle, GUIStyle           style, params GUILayOpt[] options) => ToggleMaster(toggle, new GUICon(label), style,       options);
			public static eBool Toggle(GUICon      guiCon,  bool               toggle) => ToggleMaster(toggle,                                                       guiCon, ToggleStyle);
			public static eBool Toggle(GUICon      guiCon,  bool               toggle, GUIStyle           style) => ToggleMaster(toggle,                             guiCon, style);
			public static eBool Toggle(GUICon      guiCon,  bool               toggle, params GUILayOpt[] options) => ToggleMaster(toggle,                           guiCon, ToggleStyle, options);
			public static eBool Toggle(GUICon      guiCon,  bool               toggle, GUIStyle           style, params GUILayOpt[] options) => ToggleMaster(toggle, guiCon, style,       options);
			public static eBool Toggle(Texture     texture, bool               toggle) => ToggleMaster(toggle,                                                       new GUICon(texture), ToggleStyle);
			public static eBool Toggle(Texture     texture, bool               toggle, GUIStyle           style) => ToggleMaster(toggle,                             new GUICon(texture), style);
			public static eBool Toggle(Texture     texture, bool               toggle, params GUILayOpt[] options) => ToggleMaster(toggle,                           new GUICon(texture), ToggleStyle, options);
			public static eBool Toggle(Texture     texture, bool               toggle, GUIStyle           style, params GUILayOpt[] options) => ToggleMaster(toggle, new GUICon(texture), style,       options);
			private static eBool ToggleMaster(bool toggle,  GUICon             guiCon, GUIStyle           style) => ToggleMaster(toggle, guiCon, style, null);

			private static eBool ToggleMaster(bool toggle, GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				var val = GUILayout.Toggle(toggle, guiCon, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region Toggle
			public static eBool ToggleField(bool        toggle) => ToggleFieldMaster(toggle,                                                        GUICon.none, ToggleStyle);
			public static eBool ToggleField(bool        toggle,  GUIStyle           style) => ToggleFieldMaster(toggle,                             GUICon.none, style);
			public static eBool ToggleField(bool        toggle,  params GUILayOpt[] options) => ToggleFieldMaster(toggle,                           GUICon.none, ToggleStyle, options);
			public static eBool ToggleField(bool        toggle,  GUIStyle           style, params GUILayOpt[] options) => ToggleFieldMaster(toggle, GUICon.none, style,       options);
			public static eBool ToggleField(string      label,   bool               toggle) => ToggleFieldMaster(toggle,                                                       new GUICon(label), ToggleStyle);
			public static eBool ToggleField(string      label,   bool               toggle, GUIStyle           style) => ToggleFieldMaster(toggle,                             new GUICon(label), style);
			public static eBool ToggleField(string      label,   bool               toggle, params GUILayOpt[] options) => ToggleFieldMaster(toggle,                           new GUICon(label), ToggleStyle, options);
			public static eBool ToggleField(string      label,   bool               toggle, GUIStyle           style, params GUILayOpt[] options) => ToggleFieldMaster(toggle, new GUICon(label), style,       options);
			public static eBool ToggleField(GUICon      guiCon,  bool               toggle) => ToggleFieldMaster(toggle,                                                       guiCon, ToggleStyle);
			public static eBool ToggleField(GUICon      guiCon,  bool               toggle, GUIStyle           style) => ToggleFieldMaster(toggle,                             guiCon, style);
			public static eBool ToggleField(GUICon      guiCon,  bool               toggle, params GUILayOpt[] options) => ToggleFieldMaster(toggle,                           guiCon, ToggleStyle, options);
			public static eBool ToggleField(GUICon      guiCon,  bool               toggle, GUIStyle           style, params GUILayOpt[] options) => ToggleFieldMaster(toggle, guiCon, style,       options);
			public static eBool ToggleField(Texture     texture, bool               toggle) => ToggleFieldMaster(toggle,                                                       new GUICon(texture), ToggleStyle);
			public static eBool ToggleField(Texture     texture, bool               toggle, GUIStyle           style) => ToggleFieldMaster(toggle,                             new GUICon(texture), style);
			public static eBool ToggleField(Texture     texture, bool               toggle, params GUILayOpt[] options) => ToggleFieldMaster(toggle,                           new GUICon(texture), ToggleStyle, options);
			public static eBool ToggleField(Texture     texture, bool               toggle, GUIStyle           style, params GUILayOpt[] options) => ToggleFieldMaster(toggle, new GUICon(texture), style,       options);
			private static eBool ToggleFieldMaster(bool toggle,  GUICon             guiCon, GUIStyle           style) => ToggleFieldMaster(toggle, guiCon, style, null);

			private static eBool ToggleFieldMaster(bool toggle, GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.Toggle(guiCon, toggle, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region Foldout
			public static eBool Foldout(bool foldout) => FoldoutMaster(foldout,                                          GUICon.none, FoldoutStyle);
			public static eBool Foldout(bool foldout, GUIStyle style) => FoldoutMaster(foldout,                          GUICon.none, style);
			public static eBool Foldout(bool foldout, bool     toggleOnLabelClick) => FoldoutMaster(foldout,             GUICon.none, FoldoutStyle, toggleOnLabelClick);
			public static eBool Foldout(bool foldout, GUIStyle style, bool toggleOnLabelClick) => FoldoutMaster(foldout, GUICon.none, style,        toggleOnLabelClick);
			public static eBool Foldout(bool foldout, string   label) => FoldoutMaster(foldout,                                          new GUICon(label), FoldoutStyle);
			public static eBool Foldout(bool foldout, string   label, GUIStyle style) => FoldoutMaster(foldout,                          new GUICon(label), style);
			public static eBool Foldout(bool foldout, string   label, bool     toggleOnLabelClick) => FoldoutMaster(foldout,             new GUICon(label), FoldoutStyle, toggleOnLabelClick);
			public static eBool Foldout(bool foldout, string   label, GUIStyle style, bool toggleOnLabelClick) => FoldoutMaster(foldout, new GUICon(label), style,        toggleOnLabelClick);
			public static eBool Foldout(bool foldout, GUICon   guiCon) => FoldoutMaster(foldout,                                          guiCon, FoldoutStyle);
			public static eBool Foldout(bool foldout, GUICon   guiCon, GUIStyle style) => FoldoutMaster(foldout,                          guiCon, style);
			public static eBool Foldout(bool foldout, GUICon   guiCon, bool     toggleOnLabelClick) => FoldoutMaster(foldout,             guiCon, FoldoutStyle, toggleOnLabelClick);
			public static eBool Foldout(bool foldout, GUICon   guiCon, GUIStyle style, bool toggleOnLabelClick) => FoldoutMaster(foldout, guiCon, style,        toggleOnLabelClick);

			private static eBool FoldoutMaster(bool foldout, GUICon guiCon, GUIStyle style, bool toggleOnLabelClick = true)
			{
				var val = EditorGUILayout.Foldout(foldout, guiCon, toggleOnLabelClick, style);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region IntField
			public static eInt IntField(int        value) => IntFieldMaster(value,                                                        NumberFieldStyle);
			public static eInt IntField(int        value,  GUIStyle           style) => IntFieldMaster(value,                             style);
			public static eInt IntField(int        value,  params GUILayOpt[] options) => IntFieldMaster(value,                           NumberFieldStyle, options);
			public static eInt IntField(int        value,  GUIStyle           style, params GUILayOpt[] options) => IntFieldMaster(value, style,            options);
			public static eInt IntField(string     label,  int                value) => IntFieldMaster(new GUICon(label),                                                       value, NumberFieldStyle);
			public static eInt IntField(string     label,  int                value, GUIStyle           style) => IntFieldMaster(new GUICon(label),                             value, style);
			public static eInt IntField(string     label,  int                value, params GUILayOpt[] options) => IntFieldMaster(new GUICon(label),                           value, NumberFieldStyle, options);
			public static eInt IntField(string     label,  int                value, GUIStyle           style, params GUILayOpt[] options) => IntFieldMaster(new GUICon(label), value, style,            options);
			public static eInt IntField(GUICon     guiCon, int                value) => IntFieldMaster(guiCon,                                                       value, NumberFieldStyle);
			public static eInt IntField(GUICon     guiCon, int                value, GUIStyle           style) => IntFieldMaster(guiCon,                             value, style);
			public static eInt IntField(GUICon     guiCon, int                value, params GUILayOpt[] options) => IntFieldMaster(guiCon,                           value, NumberFieldStyle, options);
			public static eInt IntField(GUICon     guiCon, int                value, GUIStyle           style, params GUILayOpt[] options) => IntFieldMaster(guiCon, value, style,            options);
			private static eInt IntFieldMaster(int value,  GUIStyle           style) => IntFieldMaster(value, style, null);

			private static eInt IntFieldMaster(int value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.IntField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eInt IntFieldMaster(GUICon guiCon, int value, GUIStyle style) => IntFieldMaster(guiCon, value, style, null);

			private static eInt IntFieldMaster(GUICon guiCon, int value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.IntField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region DelayedIntField
			public static eInt DelayedIntField(int        value) => DelayedIntFieldMaster(value,                                                        NumberFieldStyle);
			public static eInt DelayedIntField(int        value,  GUIStyle           style) => DelayedIntFieldMaster(value,                             style);
			public static eInt DelayedIntField(int        value,  params GUILayOpt[] options) => DelayedIntFieldMaster(value,                           NumberFieldStyle, options);
			public static eInt DelayedIntField(int        value,  GUIStyle           style, params GUILayOpt[] options) => DelayedIntFieldMaster(value, style,            options);
			public static eInt DelayedIntField(string     label,  int                value) => DelayedIntFieldMaster(new GUICon(label),                             value, NumberFieldStyle);
			public static eInt DelayedIntField(string     label,  int                value, GUIStyle           style) => DelayedIntFieldMaster(new GUICon(label),   value, style);
			public static eInt DelayedIntField(string     label,  int                value, params GUILayOpt[] options) => DelayedIntFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			public static eInt DelayedIntField(string     label,  int                value, GUIStyle           style, params GUILayOpt[] options) => IntFieldMaster(new GUICon(label), value, style, options);
			public static eInt DelayedIntField(GUICon     guiCon, int                value) => DelayedIntFieldMaster(guiCon,                                                       value, NumberFieldStyle);
			public static eInt DelayedIntField(GUICon     guiCon, int                value, GUIStyle           style) => DelayedIntFieldMaster(guiCon,                             value, style);
			public static eInt DelayedIntField(GUICon     guiCon, int                value, params GUILayOpt[] options) => DelayedIntFieldMaster(guiCon,                           value, NumberFieldStyle, options);
			public static eInt DelayedIntField(GUICon     guiCon, int                value, GUIStyle           style, params GUILayOpt[] options) => DelayedIntFieldMaster(guiCon, value, style,            options);
			private static eInt DelayedIntFieldMaster(int value,  GUIStyle           style) => DelayedIntFieldMaster(value, style, null);

			private static eInt DelayedIntFieldMaster(int value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.DelayedIntField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eInt DelayedIntFieldMaster(GUICon guiCon, int value, GUIStyle style) => DelayedIntFieldMaster(guiCon, value, style, null);

			private static eInt DelayedIntFieldMaster(GUICon guiCon, int value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.DelayedIntField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region FloatField
			public static eFloat FloatField(float        value) => FloatFieldMaster(value,                                                        NumberFieldStyle);
			public static eFloat FloatField(float        value,  GUIStyle           style) => FloatFieldMaster(value,                             style);
			public static eFloat FloatField(float        value,  params GUILayOpt[] options) => FloatFieldMaster(value,                           NumberFieldStyle, options);
			public static eFloat FloatField(float        value,  GUIStyle           style, params GUILayOpt[] options) => FloatFieldMaster(value, style,            options);
			public static eFloat FloatField(string       label,  float              value) => FloatFieldMaster(new GUICon(label),                                                       value, NumberFieldStyle);
			public static eFloat FloatField(string       label,  float              value, GUIStyle           style) => FloatFieldMaster(new GUICon(label),                             value, style);
			public static eFloat FloatField(string       label,  float              value, params GUILayOpt[] options) => FloatFieldMaster(new GUICon(label),                           value, NumberFieldStyle, options);
			public static eFloat FloatField(string       label,  float              value, GUIStyle           style, params GUILayOpt[] options) => FloatFieldMaster(new GUICon(label), value, style,            options);
			public static eFloat FloatField(GUICon       guiCon, float              value) => FloatFieldMaster(guiCon,                                                       value, NumberFieldStyle);
			public static eFloat FloatField(GUICon       guiCon, float              value, GUIStyle           style) => FloatFieldMaster(guiCon,                             value, style);
			public static eFloat FloatField(GUICon       guiCon, float              value, params GUILayOpt[] options) => FloatFieldMaster(guiCon,                           value, NumberFieldStyle, options);
			public static eFloat FloatField(GUICon       guiCon, float              value, GUIStyle           style, params GUILayOpt[] options) => FloatFieldMaster(guiCon, value, style,            options);
			private static eFloat FloatFieldMaster(float value,  GUIStyle           style) => FloatFieldMaster(value, style, null);

			private static eFloat FloatFieldMaster(float value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.FloatField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eFloat FloatFieldMaster(GUICon guiCon, float value, GUIStyle style) => FloatFieldMaster(guiCon, value, style, null);

			private static eFloat FloatFieldMaster(GUICon guiCon, float value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.FloatField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region DelayedFloatField
			public static eFloat DelayedFloatField(float        value) => DelayedFloatFieldMaster(value,                                                        NumberFieldStyle);
			public static eFloat DelayedFloatField(float        value,  GUIStyle           style) => DelayedFloatFieldMaster(value,                             style);
			public static eFloat DelayedFloatField(float        value,  params GUILayOpt[] options) => DelayedFloatFieldMaster(value,                           NumberFieldStyle, options);
			public static eFloat DelayedFloatField(float        value,  GUIStyle           style, params GUILayOpt[] options) => DelayedFloatFieldMaster(value, style,            options);
			public static eFloat DelayedFloatField(string       label,  float              value) => DelayedFloatFieldMaster(new GUICon(label),                                                       value, NumberFieldStyle);
			public static eFloat DelayedFloatField(string       label,  float              value, GUIStyle           style) => DelayedFloatFieldMaster(new GUICon(label),                             value, style);
			public static eFloat DelayedFloatField(string       label,  float              value, params GUILayOpt[] options) => DelayedFloatFieldMaster(new GUICon(label),                           value, NumberFieldStyle, options);
			public static eFloat DelayedFloatField(string       label,  float              value, GUIStyle           style, params GUILayOpt[] options) => DelayedFloatFieldMaster(new GUICon(label), value, style,            options);
			public static eFloat DelayedFloatField(GUICon       guiCon, float              value) => DelayedFloatFieldMaster(guiCon,                                                       value, NumberFieldStyle);
			public static eFloat DelayedFloatField(GUICon       guiCon, float              value, GUIStyle           style) => DelayedFloatFieldMaster(guiCon,                             value, style);
			public static eFloat DelayedFloatField(GUICon       guiCon, float              value, params GUILayOpt[] options) => DelayedFloatFieldMaster(guiCon,                           value, NumberFieldStyle, options);
			public static eFloat DelayedFloatField(GUICon       guiCon, float              value, GUIStyle           style, params GUILayOpt[] options) => DelayedFloatFieldMaster(guiCon, value, style,            options);
			private static eFloat DelayedFloatFieldMaster(float value,  GUIStyle           style) => DelayedFloatFieldMaster(value, style, null);

			private static eFloat DelayedFloatFieldMaster(float value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.DelayedFloatField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eFloat DelayedFloatFieldMaster(GUICon guiCon, float value, GUIStyle style) => DelayedFloatFieldMaster(guiCon, value, style, null);

			private static eFloat DelayedFloatFieldMaster(GUICon guiCon, float value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.DelayedFloatField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region TextField
			public static eString TextField(string        value) => TextFieldMaster(GUICon.none,                                                        value, NumberFieldStyle);
			public static eString TextField(string        value,  GUIStyle           style) => TextFieldMaster(GUICon.none,                             value, style);
			public static eString TextField(string        value,  params GUILayOpt[] options) => TextFieldMaster(GUICon.none,                           value, NumberFieldStyle, options);
			public static eString TextField(string        value,  GUIStyle           style, params GUILayOpt[] options) => TextFieldMaster(GUICon.none, value, style,            options);
			public static eString TextField(string        label,  string             value) => TextFieldMaster(new GUICon(label),                                                       value, NumberFieldStyle);
			public static eString TextField(string        label,  string             value, GUIStyle           style) => TextFieldMaster(new GUICon(label),                             value, style);
			public static eString TextField(string        label,  string             value, params GUILayOpt[] options) => TextFieldMaster(new GUICon(label),                           value, NumberFieldStyle, options);
			public static eString TextField(string        label,  string             value, GUIStyle           style, params GUILayOpt[] options) => TextFieldMaster(new GUICon(label), value, style,            options);
			public static eString TextField(GUICon        guiCon, string             value) => TextFieldMaster(guiCon,                                                       value, NumberFieldStyle);
			public static eString TextField(GUICon        guiCon, string             value, GUIStyle           style) => TextFieldMaster(guiCon,                             value, style);
			public static eString TextField(GUICon        guiCon, string             value, params GUILayOpt[] options) => TextFieldMaster(guiCon,                           value, NumberFieldStyle, options);
			public static eString TextField(GUICon        guiCon, string             value, GUIStyle           style, params GUILayOpt[] options) => TextFieldMaster(guiCon, value, style,            options);
			private static eString TextFieldMaster(string value,  GUIStyle           style) => TextFieldMaster(value, style, null);

			private static eString TextFieldMaster(string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.TextField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eString TextFieldMaster(GUICon guiCon, string value, GUIStyle style) => TextFieldMaster(guiCon, value, style, null);

			private static eString TextFieldMaster(GUICon guiCon, string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.TextField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region DelayedTextField
			public static eString DelayedTextField(string        value) => DelayedTextFieldMaster(GUICon.none,                                                        value, NumberFieldStyle);
			public static eString DelayedTextField(string        value,  GUIStyle           style) => DelayedTextFieldMaster(GUICon.none,                             value, style);
			public static eString DelayedTextField(string        value,  params GUILayOpt[] options) => DelayedTextFieldMaster(GUICon.none,                           value, NumberFieldStyle, options);
			public static eString DelayedTextField(string        value,  GUIStyle           style, params GUILayOpt[] options) => DelayedTextFieldMaster(GUICon.none, value, style,            options);
			public static eString DelayedTextField(string        label,  string             value) => DelayedTextFieldMaster(new GUICon(label),                             value, NumberFieldStyle);
			public static eString DelayedTextField(string        label,  string             value, GUIStyle           style) => DelayedTextFieldMaster(new GUICon(label),   value, style);
			public static eString DelayedTextField(string        label,  string             value, params GUILayOpt[] options) => DelayedTextFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			public static eString DelayedTextField(string        label,  string             value, GUIStyle           style, params GUILayOpt[] options) => TextFieldMaster(new GUICon(label), value, style, options);
			public static eString DelayedTextField(GUICon        guiCon, string             value) => DelayedTextFieldMaster(guiCon,                                                       value, NumberFieldStyle);
			public static eString DelayedTextField(GUICon        guiCon, string             value, GUIStyle           style) => DelayedTextFieldMaster(guiCon,                             value, style);
			public static eString DelayedTextField(GUICon        guiCon, string             value, params GUILayOpt[] options) => DelayedTextFieldMaster(guiCon,                           value, NumberFieldStyle, options);
			public static eString DelayedTextField(GUICon        guiCon, string             value, GUIStyle           style, params GUILayOpt[] options) => DelayedTextFieldMaster(guiCon, value, style,            options);
			private static eString DelayedTextFieldMaster(string value,  GUIStyle           style) => DelayedTextFieldMaster(value, style, null);

			private static eString DelayedTextFieldMaster(string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.DelayedTextField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eString DelayedTextFieldMaster(GUICon guiCon, string value, GUIStyle style) => DelayedTextFieldMaster(guiCon, value, style, null);

			private static eString DelayedTextFieldMaster(GUICon guiCon, string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.DelayedTextField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region TextArea
			public static eString TextArea(string        value) => TextAreaMaster(value,                                                       NumberFieldStyle);
			public static eString TextArea(string        value, GUIStyle           style) => TextAreaMaster(value,                             style);
			public static eString TextArea(string        value, params GUILayOpt[] options) => TextAreaMaster(value,                           NumberFieldStyle, options);
			public static eString TextArea(string        value, GUIStyle           style, params GUILayOpt[] options) => TextAreaMaster(value, style,            options);
			private static eString TextAreaMaster(string value, GUIStyle           style) => TextAreaMaster(value, style, null);

			private static eString TextAreaMaster(string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.TextArea(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region ObjectField
			public static eObject ObjectField(Object value, Type type, bool allowSceneObjects) => ObjectFieldMaster(value, type, allowSceneObjects);
			public static eObject ObjectField(Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options) => ObjectFieldMaster(value, type, allowSceneObjects, options);
			public static eObject ObjectField(string guiCon, Object value, Type type, bool allowSceneObjects) => ObjectFieldMaster(new GUICon(guiCon), value, type, allowSceneObjects);
			public static eObject ObjectField(string guiCon, Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options) => ObjectFieldMaster(new GUICon(guiCon), value, type, allowSceneObjects, options);
			public static eObject ObjectField(GUICon guiCon, Object value, Type type, bool allowSceneObjects) => ObjectFieldMaster(guiCon, value, type, allowSceneObjects);
			public static eObject ObjectField(GUICon guiCon, Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options) => ObjectFieldMaster(guiCon, value, type, allowSceneObjects, options);

			private static eObject ObjectFieldMaster(Object value, Type type, bool allowSceneObjects) => ObjectFieldMaster(value, type, allowSceneObjects, null);
			private static eObject ObjectFieldMaster(Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.ObjectField(value, type, allowSceneObjects, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eObject ObjectFieldMaster(GUICon guiCon, Object value, Type type, bool allowSceneObjects) => ObjectFieldMaster(guiCon, value, type, allowSceneObjects, null);

			private static eObject ObjectFieldMaster(GUICon guiCon, Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.ObjectField(guiCon, value, type, allowSceneObjects, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region ObjectFieldGeneric
			public static GUIEvent<T> ObjectField<T>(Object value, bool allowSceneObjects) where T: Object => ObjectFieldMaster<T>(value, allowSceneObjects);
			public static GUIEvent<T> ObjectField<T>(Object value, bool allowSceneObjects, params GUILayOpt[] options) where T: Object => ObjectFieldMaster<T>(value, allowSceneObjects, options);
			public static GUIEvent<T> ObjectField<T>(string guiCon, Object value, bool allowSceneObjects) where T: Object => ObjectFieldMaster<T>(new GUICon(guiCon), value, allowSceneObjects);
			public static GUIEvent<T> ObjectField<T>(string guiCon, Object value, bool allowSceneObjects, params GUILayOpt[] options) where T: Object => ObjectFieldMaster<T>(new GUICon(guiCon), value, allowSceneObjects, options);
			public static GUIEvent<T> ObjectField<T>(GUICon guiCon, Object value, bool allowSceneObjects) where T: Object => ObjectFieldMaster<T>(guiCon, value, allowSceneObjects);
			public static GUIEvent<T> ObjectField<T>(GUICon guiCon, Object value, bool allowSceneObjects, params GUILayOpt[] options) where T: Object => ObjectFieldMaster<T>(guiCon, value, allowSceneObjects, options);

			private static GUIEvent<T> ObjectFieldMaster<T>(Object value, bool allowSceneObjects) where T: Object => ObjectFieldMaster<T>(value, allowSceneObjects, null);

			private static GUIEvent<T> ObjectFieldMaster<T>(Object value, bool allowSceneObjects, params GUILayOpt[] options) where T: Object
			{
				var val = (T)EditorGUILayout.ObjectField(value, typeof(T), allowSceneObjects, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static GUIEvent<T> ObjectFieldMaster<T>(GUICon guiCon, Object value, bool allowSceneObjects) where T: Object => ObjectFieldMaster<T>(guiCon, value, allowSceneObjects, null);

			private static GUIEvent<T> ObjectFieldMaster<T>(GUICon guiCon, Object value, bool allowSceneObjects, params GUILayOpt[] options) where T: Object
			{
				var val = (T)EditorGUILayout.ObjectField(guiCon, value, typeof(T), allowSceneObjects, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region HelpBox
			public static GUIEvent ErrorBox(string   text) => FoCsGUI.ErrorBox(GUILayoutUtility.GetRect(0,   SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			public static GUIEvent InfoBox(string    text) => FoCsGUI.InfoBox(GUILayoutUtility.GetRect(0,    SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			public static GUIEvent WarningBox(string text) => FoCsGUI.WarningBox(GUILayoutUtility.GetRect(0, SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			public static GUIEvent HelpBox(string    text) => FoCsGUI.HelpBox(GUILayoutUtility.GetRect(0,    SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
#endregion

#region PropertyField
			public static eBool PropertyField(SerializedProperty property, bool includeChildren) => PropertyFieldMaster(property, includeChildren, null);
			public static eBool PropertyField(SerializedProperty property, bool includeChildren, params GUILayOpt[] options) => PropertyFieldMaster(property, includeChildren, options);
			public static eBool PropertyField(string label, SerializedProperty property, bool includeChildren) => PropertyFieldMaster(new GUICon(label),                             property, includeChildren, null);
			public static eBool PropertyField(string label, SerializedProperty property, bool includeChildren, params GUILayOpt[] options) => PropertyFieldMaster(new GUICon(label), property, includeChildren, options);
			public static eBool PropertyField(GUICon label, SerializedProperty property, bool includeChildren) => PropertyFieldMaster(label,                             property, includeChildren, null);
			public static eBool PropertyField(GUICon label, SerializedProperty property, bool includeChildren, params GUILayOpt[] options) => PropertyFieldMaster(label, property, includeChildren, options);

			private static eBool PropertyFieldMaster(SerializedProperty property, bool includeChildren, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.PropertyField(property, includeChildren, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
			private static eBool PropertyFieldMaster(GUICon label, SerializedProperty property, bool includeChildren, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.PropertyField(property, label, includeChildren, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region GetControlRect
			public static Rect GetControlRect(params GUILayOpt[] options) => EditorGUILayout.GetControlRect(options);
			public static Rect GetControlRect(bool               hasLabel, params GUILayOpt[] options) => EditorGUILayout.GetControlRect(hasLabel,                                                      options);
			public static Rect GetControlRect(bool               hasLabel, float              height, params GUILayOpt[] options) => EditorGUILayout.GetControlRect(hasLabel,                           height, options);
			public static Rect GetControlRect(bool               hasLabel, float              height, GUIStyle           style, params GUILayOpt[] options) => EditorGUILayout.GetControlRect(hasLabel, height, style, options);
#endregion

		}
	}
}