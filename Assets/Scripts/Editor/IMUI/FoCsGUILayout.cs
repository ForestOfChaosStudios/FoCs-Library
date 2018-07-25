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
			public static GUILayout.HorizontalScope HorizontalScope()
			{
				return FoCsEditor.Disposables.HorizontalScope();
			}

			public static GUILayout.HorizontalScope HorizontalScope(GUIStyle           skinBox)
			{
				return FoCsEditor.Disposables.HorizontalScope(skinBox);
			}

			public static GUILayout.HorizontalScope HorizontalScope(params GUILayOpt[] options)
			{
				return FoCsEditor.Disposables.HorizontalScope(options);
			}

			public static GUILayout.HorizontalScope HorizontalScope(GUIStyle           skinBox, params GUILayOpt[] options)
			{
				return FoCsEditor.Disposables.HorizontalScope(skinBox, options);
			}
#endregion

#region VerticalScope
			public static GUILayout.VerticalScope VerticalScope()
			{
				return FoCsEditor.Disposables.VerticalScope();
			}

			public static GUILayout.VerticalScope VerticalScope(GUIStyle           skinBox)
			{
				return FoCsEditor.Disposables.VerticalScope(skinBox);
			}

			public static GUILayout.VerticalScope VerticalScope(params GUILayOpt[] options)
			{
				return FoCsEditor.Disposables.VerticalScope(options);
			}

			public static GUILayout.VerticalScope VerticalScope(GUIStyle           skinBox, params GUILayOpt[] options)
			{
				return FoCsEditor.Disposables.VerticalScope(skinBox, options);
			}
#endregion

#region AreaScope
			public static GUILayout.AreaScope AreaScope(Rect rect)
			{
				return FoCsEditor.Disposables.AreaScope(rect);
			}

			public static GUILayout.AreaScope AreaScope(Rect rect, string     content)
			{
				return FoCsEditor.Disposables.AreaScope(rect, content);
			}

			public static GUILayout.AreaScope AreaScope(Rect rect, string     content, GUIStyle style)
			{
				return FoCsEditor.Disposables.AreaScope(rect, content, style);
			}

			public static GUILayout.AreaScope AreaScope(Rect rect, GUIContent content)
			{
				return FoCsEditor.Disposables.AreaScope(rect, content);
			}

			public static GUILayout.AreaScope AreaScope(Rect rect, GUIContent content, GUIStyle style)
			{
				return FoCsEditor.Disposables.AreaScope(rect, content, style);
			}

			public static GUILayout.AreaScope AreaScope(Rect rect, Texture    texture)
			{
				return FoCsEditor.Disposables.AreaScope(rect, texture);
			}

			public static GUILayout.AreaScope AreaScope(Rect rect, Texture    texture, GUIStyle style)
			{
				return FoCsEditor.Disposables.AreaScope(rect, texture, style);
			}
#endregion

#region ScrollViewScope
			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos)
			{
				return FoCsEditor.Disposables.ScrollViewScope(scrollPos, true);
			}

			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, bool               handleScrollWheel)
			{
				return FoCsEditor.Disposables.ScrollViewScope(scrollPos, handleScrollWheel);
			}

			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, params GUILayOpt[] options)
			{
				return FoCsEditor.Disposables.ScrollViewScope(scrollPos, true, options);
			}

			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, bool               handleScrollWheel, params GUILayOpt[] options)
			{
				return FoCsEditor.Disposables.ScrollViewScope(scrollPos, handleScrollWheel, options);
			}

			public static EditorGUILayout.ScrollViewScope ScrollViewScope(Vector2 scrollPos, bool handleScrollWheel, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayOpt[] options)
			{
				return FoCsEditor.Disposables.ScrollViewScope(scrollPos, handleScrollWheel, alwaysShowHorizontal, alwaysShowVertical, options);
			}
#endregion
#endregion

#region LabelField
			public static GUIEvent LabelField()
			{
				return LabelFieldMaster(GUICon.none, LabelStyle);
			}

			public static GUIEvent LabelField(GUIStyle           style)
			{
				return LabelFieldMaster(GUICon.none, style);
			}

			public static GUIEvent LabelField(params GUILayOpt[] options)
			{
				return LabelFieldMaster(GUICon.none, LabelStyle, options);
			}

			public static GUIEvent LabelField(GUIStyle           style, params GUILayOpt[] options)
			{
				return LabelFieldMaster(GUICon.none, style, options);
			}

			public static GUIEvent LabelField(string             label)
			{
				return LabelFieldMaster(new GUICon(label), LabelStyle);
			}

			public static GUIEvent LabelField(string             label, GUIStyle           style)
			{
				return LabelFieldMaster(new GUICon(label), style);
			}

			public static GUIEvent LabelField(string             label, params GUILayOpt[] options)
			{
				return LabelFieldMaster(new GUICon(label), LabelStyle, options);
			}

			public static GUIEvent LabelField(string             label, GUIStyle           style, params GUILayOpt[] options)
			{
				return LabelFieldMaster(new GUICon(label), style, options);
			}

			public static GUIEvent LabelField(GUICon             guiCon)
			{
				return LabelFieldMaster(guiCon, LabelStyle);
			}

			public static GUIEvent LabelField(GUICon             guiCon, GUIStyle           style)
			{
				return LabelFieldMaster(guiCon, style);
			}

			public static GUIEvent LabelField(GUICon             guiCon, params GUILayOpt[] options)
			{
				return LabelFieldMaster(guiCon, LabelStyle, options);
			}

			public static GUIEvent LabelField(GUICon             guiCon, GUIStyle           style, params GUILayOpt[] options)
			{
				return LabelFieldMaster(guiCon, style, options);
			}

			public static GUIEvent LabelField(Texture            texture)
			{
				return LabelFieldMaster(new GUICon(texture), LabelStyle);
			}

			public static GUIEvent LabelField(Texture            texture, GUIStyle           style)
			{
				return LabelFieldMaster(new GUICon(texture), style);
			}

			public static GUIEvent LabelField(Texture            texture, params GUILayOpt[] options)
			{
				return LabelFieldMaster(new GUICon(texture), LabelStyle, options);
			}

			public static GUIEvent LabelField(Texture            texture, GUIStyle           style, params GUILayOpt[] options)
			{
				return LabelFieldMaster(new GUICon(texture), style, options);
			}

			private static GUIEvent LabelFieldMaster(GUICon      guiCon,  GUIStyle           style)
			{
				return LabelFieldMaster(guiCon, style, null);
			}

			private static GUIEvent LabelFieldMaster(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				EditorGUILayout.LabelField(guiCon, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect());
			}
#endregion

#region Label
			public static GUIEvent Label()
			{
				return LabelMaster(GUICon.none, LabelStyle);
			}

			public static GUIEvent Label(GUIStyle           style)
			{
				return LabelMaster(GUICon.none, style);
			}

			public static GUIEvent Label(params GUILayOpt[] options)
			{
				return LabelMaster(GUICon.none, LabelStyle, options);
			}

			public static GUIEvent Label(GUIStyle           style, params GUILayOpt[] options)
			{
				return LabelMaster(GUICon.none, style, options);
			}

			public static GUIEvent Label(string             label)
			{
				return LabelMaster(new GUICon(label), LabelStyle);
			}

			public static GUIEvent Label(string             label, GUIStyle           style)
			{
				return LabelMaster(new GUICon(label), style);
			}

			public static GUIEvent Label(string             label, params GUILayOpt[] options)
			{
				return LabelMaster(new GUICon(label), LabelStyle, options);
			}

			public static GUIEvent Label(string             label, GUIStyle           style, params GUILayOpt[] options)
			{
				return LabelMaster(new GUICon(label), style, options);
			}

			public static GUIEvent Label(GUICon             guiCon)
			{
				return LabelMaster(guiCon, LabelStyle);
			}

			public static GUIEvent Label(GUICon             guiCon, GUIStyle           style)
			{
				return LabelMaster(guiCon, style);
			}

			public static GUIEvent Label(GUICon             guiCon, params GUILayOpt[] options)
			{
				return LabelMaster(guiCon, LabelStyle, options);
			}

			public static GUIEvent Label(GUICon             guiCon, GUIStyle           style, params GUILayOpt[] options)
			{
				return LabelMaster(guiCon, style, options);
			}

			public static GUIEvent Label(Texture            texture)
			{
				return LabelMaster(new GUICon(texture), LabelStyle);
			}

			public static GUIEvent Label(Texture            texture, GUIStyle           style)
			{
				return LabelMaster(new GUICon(texture), style);
			}

			public static GUIEvent Label(Texture            texture, params GUILayOpt[] options)
			{
				return LabelMaster(new GUICon(texture), LabelStyle, options);
			}

			public static GUIEvent Label(Texture            texture, GUIStyle           style, params GUILayOpt[] options)
			{
				return LabelMaster(new GUICon(texture), style, options);
			}

			private static GUIEvent LabelMaster(GUICon      guiCon,  GUIStyle           style)
			{
				return LabelMaster(guiCon, style, null);
			}

			private static GUIEvent LabelMaster(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				EditorGUILayout.LabelField(guiCon, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect());
			}
#endregion

#region Button
			public static eBool Button()
			{
				return ButtonMaster(GUICon.none, ButtonStyle);
			}

			public static eBool Button(GUIStyle           style)
			{
				return ButtonMaster(GUICon.none, style);
			}

			public static eBool Button(params GUILayOpt[] options)
			{
				return ButtonMaster(GUICon.none, ButtonStyle, options);
			}

			public static eBool Button(GUIStyle           style, params GUILayOpt[] options)
			{
				return ButtonMaster(GUICon.none, style, options);
			}

			public static eBool Button(string             label)
			{
				return ButtonMaster(new GUICon(label), ButtonStyle);
			}

			public static eBool Button(string             label, GUIStyle           style)
			{
				return ButtonMaster(new GUICon(label), style);
			}

			public static eBool Button(string             label, params GUILayOpt[] options)
			{
				return ButtonMaster(new GUICon(label), ButtonStyle, options);
			}

			public static eBool Button(string             label, GUIStyle           style, params GUILayOpt[] options)
			{
				return ButtonMaster(new GUICon(label), style, options);
			}

			public static eBool Button(GUICon             guiCon)
			{
				return ButtonMaster(guiCon, ButtonStyle);
			}

			public static eBool Button(GUICon             guiCon, GUIStyle           style)
			{
				return ButtonMaster(guiCon, style);
			}

			public static eBool Button(GUICon             guiCon, params GUILayOpt[] options)
			{
				return ButtonMaster(guiCon, ButtonStyle, options);
			}

			public static eBool Button(GUICon             guiCon, GUIStyle           style, params GUILayOpt[] options)
			{
				return ButtonMaster(guiCon, style, options);
			}

			public static eBool Button(Texture            texture)
			{
				return ButtonMaster(new GUICon(texture), ButtonStyle);
			}

			public static eBool Button(Texture            texture, GUIStyle           style)
			{
				return ButtonMaster(new GUICon(texture), style);
			}

			public static eBool Button(Texture            texture, params GUILayOpt[] options)
			{
				return ButtonMaster(new GUICon(texture), ButtonStyle, options);
			}

			public static eBool Button(Texture            texture, GUIStyle           style, params GUILayOpt[] options)
			{
				return ButtonMaster(new GUICon(texture), style, options);
			}

			private static eBool ButtonMaster(GUICon      guiCon,  GUIStyle           style)
			{
				return ButtonMaster(guiCon, style, null);
			}

			private static eBool ButtonMaster(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				var b = GUILayout.Button(guiCon, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), b);
			}
#endregion

#region Toggle
			public static eBool Toggle(bool        toggle)
			{
				return ToggleMaster(toggle, GUICon.none, ToggleStyle);
			}

			public static eBool Toggle(bool        toggle,  GUIStyle           style)
			{
				return ToggleMaster(toggle, GUICon.none, style);
			}

			public static eBool Toggle(bool        toggle,  params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, GUICon.none, ToggleStyle, options);
			}

			public static eBool Toggle(bool        toggle,  GUIStyle           style, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, GUICon.none, style, options);
			}

			public static eBool Toggle(string      label,   bool               toggle)
			{
				return ToggleMaster(toggle, new GUICon(label), ToggleStyle);
			}

			public static eBool Toggle(string      label,   bool               toggle, GUIStyle           style)
			{
				return ToggleMaster(toggle, new GUICon(label), style);
			}

			public static eBool Toggle(string      label,   bool               toggle, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, new GUICon(label), ToggleStyle, options);
			}

			public static eBool Toggle(string      label,   bool               toggle, GUIStyle           style, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, new GUICon(label), style, options);
			}

			public static eBool Toggle(GUICon      guiCon,  bool               toggle)
			{
				return ToggleMaster(toggle, guiCon, ToggleStyle);
			}

			public static eBool Toggle(GUICon      guiCon,  bool               toggle, GUIStyle           style)
			{
				return ToggleMaster(toggle, guiCon, style);
			}

			public static eBool Toggle(GUICon      guiCon,  bool               toggle, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, guiCon, ToggleStyle, options);
			}

			public static eBool Toggle(GUICon      guiCon,  bool               toggle, GUIStyle           style, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, guiCon, style, options);
			}

			public static eBool Toggle(Texture     texture, bool               toggle)
			{
				return ToggleMaster(toggle, new GUICon(texture), ToggleStyle);
			}

			public static eBool Toggle(Texture     texture, bool               toggle, GUIStyle           style)
			{
				return ToggleMaster(toggle, new GUICon(texture), style);
			}

			public static eBool Toggle(Texture     texture, bool               toggle, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, new GUICon(texture), ToggleStyle, options);
			}

			public static eBool Toggle(Texture     texture, bool               toggle, GUIStyle           style, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, new GUICon(texture), style, options);
			}

			private static eBool ToggleMaster(bool toggle,  GUICon             guiCon, GUIStyle           style)
			{
				return ToggleMaster(toggle, guiCon, style, null);
			}

			private static eBool ToggleMaster(bool toggle, GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				var val = GUILayout.Toggle(toggle, guiCon, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region Toggle
			public static eBool ToggleField(bool        toggle)
			{
				return ToggleFieldMaster(toggle, GUICon.none, ToggleStyle);
			}

			public static eBool ToggleField(bool        toggle,  GUIStyle           style)
			{
				return ToggleFieldMaster(toggle, GUICon.none, style);
			}

			public static eBool ToggleField(bool        toggle,  params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, GUICon.none, ToggleStyle, options);
			}

			public static eBool ToggleField(bool        toggle,  GUIStyle           style, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, GUICon.none, style, options);
			}

			public static eBool ToggleField(string      label,   bool               toggle)
			{
				return ToggleFieldMaster(toggle, new GUICon(label), ToggleStyle);
			}

			public static eBool ToggleField(string      label,   bool               toggle, GUIStyle           style)
			{
				return ToggleFieldMaster(toggle, new GUICon(label), style);
			}

			public static eBool ToggleField(string      label,   bool               toggle, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, new GUICon(label), ToggleStyle, options);
			}

			public static eBool ToggleField(string      label,   bool               toggle, GUIStyle           style, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, new GUICon(label), style, options);
			}

			public static eBool ToggleField(GUICon      guiCon,  bool               toggle)
			{
				return ToggleFieldMaster(toggle, guiCon, ToggleStyle);
			}

			public static eBool ToggleField(GUICon      guiCon,  bool               toggle, GUIStyle           style)
			{
				return ToggleFieldMaster(toggle, guiCon, style);
			}

			public static eBool ToggleField(GUICon      guiCon,  bool               toggle, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, guiCon, ToggleStyle, options);
			}

			public static eBool ToggleField(GUICon      guiCon,  bool               toggle, GUIStyle           style, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, guiCon, style, options);
			}

			public static eBool ToggleField(Texture     texture, bool               toggle)
			{
				return ToggleFieldMaster(toggle, new GUICon(texture), ToggleStyle);
			}

			public static eBool ToggleField(Texture     texture, bool               toggle, GUIStyle           style)
			{
				return ToggleFieldMaster(toggle, new GUICon(texture), style);
			}

			public static eBool ToggleField(Texture     texture, bool               toggle, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, new GUICon(texture), ToggleStyle, options);
			}

			public static eBool ToggleField(Texture     texture, bool               toggle, GUIStyle           style, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, new GUICon(texture), style, options);
			}

			private static eBool ToggleFieldMaster(bool toggle,  GUICon             guiCon, GUIStyle           style)
			{
				return ToggleFieldMaster(toggle, guiCon, style, null);
			}

			private static eBool ToggleFieldMaster(bool toggle, GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.Toggle(guiCon, toggle, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region Foldout
			public static eBool Foldout(bool foldout)
			{
				return FoldoutMaster(foldout, GUICon.none, FoldoutStyle);
			}

			public static eBool Foldout(bool foldout, GUIStyle style)
			{
				return FoldoutMaster(foldout, GUICon.none, style);
			}

			public static eBool Foldout(bool foldout, bool     toggleOnLabelClick)
			{
				return FoldoutMaster(foldout, GUICon.none, FoldoutStyle, toggleOnLabelClick);
			}

			public static eBool Foldout(bool foldout, GUIStyle style, bool toggleOnLabelClick)
			{
				return FoldoutMaster(foldout, GUICon.none, style, toggleOnLabelClick);
			}

			public static eBool Foldout(bool foldout, string   label)
			{
				return FoldoutMaster(foldout, new GUICon(label), FoldoutStyle);
			}

			public static eBool Foldout(bool foldout, string   label, GUIStyle style)
			{
				return FoldoutMaster(foldout, new GUICon(label), style);
			}

			public static eBool Foldout(bool foldout, string   label, bool     toggleOnLabelClick)
			{
				return FoldoutMaster(foldout, new GUICon(label), FoldoutStyle, toggleOnLabelClick);
			}

			public static eBool Foldout(bool foldout, string   label, GUIStyle style, bool toggleOnLabelClick)
			{
				return FoldoutMaster(foldout, new GUICon(label), style, toggleOnLabelClick);
			}

			public static eBool Foldout(bool foldout, GUICon   guiCon)
			{
				return FoldoutMaster(foldout, guiCon, FoldoutStyle);
			}

			public static eBool Foldout(bool foldout, GUICon   guiCon, GUIStyle style)
			{
				return FoldoutMaster(foldout, guiCon, style);
			}

			public static eBool Foldout(bool foldout, GUICon   guiCon, bool     toggleOnLabelClick)
			{
				return FoldoutMaster(foldout, guiCon, FoldoutStyle, toggleOnLabelClick);
			}

			public static eBool Foldout(bool foldout, GUICon   guiCon, GUIStyle style, bool toggleOnLabelClick)
			{
				return FoldoutMaster(foldout, guiCon, style, toggleOnLabelClick);
			}

			private static eBool FoldoutMaster(bool foldout, GUICon guiCon, GUIStyle style, bool toggleOnLabelClick = true)
			{
				var val = EditorGUILayout.Foldout(foldout, guiCon, toggleOnLabelClick, style);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region IntField
			public static eInt IntField(int        value)
			{
				return IntFieldMaster(value, NumberFieldStyle);
			}

			public static eInt IntField(int        value,  GUIStyle           style)
			{
				return IntFieldMaster(value, style);
			}

			public static eInt IntField(int        value,  params GUILayOpt[] options)
			{
				return IntFieldMaster(value, NumberFieldStyle, options);
			}

			public static eInt IntField(int        value,  GUIStyle           style, params GUILayOpt[] options)
			{
				return IntFieldMaster(value, style, options);
			}

			public static eInt IntField(string     label,  int                value)
			{
				return IntFieldMaster(new GUICon(label), value, NumberFieldStyle);
			}

			public static eInt IntField(string     label,  int                value, GUIStyle           style)
			{
				return IntFieldMaster(new GUICon(label), value, style);
			}

			public static eInt IntField(string     label,  int                value, params GUILayOpt[] options)
			{
				return IntFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eInt IntField(string     label,  int                value, GUIStyle           style, params GUILayOpt[] options)
			{
				return IntFieldMaster(new GUICon(label), value, style, options);
			}

			public static eInt IntField(GUICon     guiCon, int                value)
			{
				return IntFieldMaster(guiCon, value, NumberFieldStyle);
			}

			public static eInt IntField(GUICon     guiCon, int                value, GUIStyle           style)
			{
				return IntFieldMaster(guiCon, value, style);
			}

			public static eInt IntField(GUICon     guiCon, int                value, params GUILayOpt[] options)
			{
				return IntFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eInt IntField(GUICon     guiCon, int                value, GUIStyle           style, params GUILayOpt[] options)
			{
				return IntFieldMaster(guiCon, value, style, options);
			}

			private static eInt IntFieldMaster(int value,  GUIStyle           style)
			{
				return IntFieldMaster(value, style, null);
			}

			private static eInt IntFieldMaster(int value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.IntField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eInt IntFieldMaster(GUICon guiCon, int value, GUIStyle style)
			{
				return IntFieldMaster(guiCon, value, style, null);
			}

			private static eInt IntFieldMaster(GUICon guiCon, int value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.IntField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region DelayedIntField
			public static eInt DelayedIntField(int        value)
			{
				return DelayedIntFieldMaster(value, NumberFieldStyle);
			}

			public static eInt DelayedIntField(int        value,  GUIStyle           style)
			{
				return DelayedIntFieldMaster(value, style);
			}

			public static eInt DelayedIntField(int        value,  params GUILayOpt[] options)
			{
				return DelayedIntFieldMaster(value, NumberFieldStyle, options);
			}

			public static eInt DelayedIntField(int        value,  GUIStyle           style, params GUILayOpt[] options)
			{
				return DelayedIntFieldMaster(value, style, options);
			}

			public static eInt DelayedIntField(string     label,  int                value)
			{
				return DelayedIntFieldMaster(new GUICon(label), value, NumberFieldStyle);
			}

			public static eInt DelayedIntField(string     label,  int                value, GUIStyle           style)
			{
				return DelayedIntFieldMaster(new GUICon(label), value, style);
			}

			public static eInt DelayedIntField(string     label,  int                value, params GUILayOpt[] options)
			{
				return DelayedIntFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eInt DelayedIntField(string     label,  int                value, GUIStyle           style, params GUILayOpt[] options)
			{
				return IntFieldMaster(new GUICon(label), value, style, options);
			}

			public static eInt DelayedIntField(GUICon     guiCon, int                value)
			{
				return DelayedIntFieldMaster(guiCon, value, NumberFieldStyle);
			}

			public static eInt DelayedIntField(GUICon     guiCon, int                value, GUIStyle           style)
			{
				return DelayedIntFieldMaster(guiCon, value, style);
			}

			public static eInt DelayedIntField(GUICon     guiCon, int                value, params GUILayOpt[] options)
			{
				return DelayedIntFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eInt DelayedIntField(GUICon     guiCon, int                value, GUIStyle           style, params GUILayOpt[] options)
			{
				return DelayedIntFieldMaster(guiCon, value, style, options);
			}

			private static eInt DelayedIntFieldMaster(int value,  GUIStyle           style)
			{
				return DelayedIntFieldMaster(value, style, null);
			}

			private static eInt DelayedIntFieldMaster(int value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.DelayedIntField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eInt DelayedIntFieldMaster(GUICon guiCon, int value, GUIStyle style)
			{
				return DelayedIntFieldMaster(guiCon, value, style, null);
			}

			private static eInt DelayedIntFieldMaster(GUICon guiCon, int value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.DelayedIntField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region FloatField
			public static eFloat FloatField(float        value)
			{
				return FloatFieldMaster(value, NumberFieldStyle);
			}

			public static eFloat FloatField(float        value,  GUIStyle           style)
			{
				return FloatFieldMaster(value, style);
			}

			public static eFloat FloatField(float        value,  params GUILayOpt[] options)
			{
				return FloatFieldMaster(value, NumberFieldStyle, options);
			}

			public static eFloat FloatField(float        value,  GUIStyle           style, params GUILayOpt[] options)
			{
				return FloatFieldMaster(value, style, options);
			}

			public static eFloat FloatField(string       label,  float              value)
			{
				return FloatFieldMaster(new GUICon(label), value, NumberFieldStyle);
			}

			public static eFloat FloatField(string       label,  float              value, GUIStyle           style)
			{
				return FloatFieldMaster(new GUICon(label), value, style);
			}

			public static eFloat FloatField(string       label,  float              value, params GUILayOpt[] options)
			{
				return FloatFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eFloat FloatField(string       label,  float              value, GUIStyle           style, params GUILayOpt[] options)
			{
				return FloatFieldMaster(new GUICon(label), value, style, options);
			}

			public static eFloat FloatField(GUICon       guiCon, float              value)
			{
				return FloatFieldMaster(guiCon, value, NumberFieldStyle);
			}

			public static eFloat FloatField(GUICon       guiCon, float              value, GUIStyle           style)
			{
				return FloatFieldMaster(guiCon, value, style);
			}

			public static eFloat FloatField(GUICon       guiCon, float              value, params GUILayOpt[] options)
			{
				return FloatFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eFloat FloatField(GUICon       guiCon, float              value, GUIStyle           style, params GUILayOpt[] options)
			{
				return FloatFieldMaster(guiCon, value, style, options);
			}

			private static eFloat FloatFieldMaster(float value,  GUIStyle           style)
			{
				return FloatFieldMaster(value, style, null);
			}

			private static eFloat FloatFieldMaster(float value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.FloatField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eFloat FloatFieldMaster(GUICon guiCon, float value, GUIStyle style)
			{
				return FloatFieldMaster(guiCon, value, style, null);
			}

			private static eFloat FloatFieldMaster(GUICon guiCon, float value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.FloatField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region DelayedFloatField
			public static eFloat DelayedFloatField(float        value)
			{
				return DelayedFloatFieldMaster(value, NumberFieldStyle);
			}

			public static eFloat DelayedFloatField(float        value,  GUIStyle           style)
			{
				return DelayedFloatFieldMaster(value, style);
			}

			public static eFloat DelayedFloatField(float        value,  params GUILayOpt[] options)
			{
				return DelayedFloatFieldMaster(value, NumberFieldStyle, options);
			}

			public static eFloat DelayedFloatField(float        value,  GUIStyle           style, params GUILayOpt[] options)
			{
				return DelayedFloatFieldMaster(value, style, options);
			}

			public static eFloat DelayedFloatField(string       label,  float              value)
			{
				return DelayedFloatFieldMaster(new GUICon(label), value, NumberFieldStyle);
			}

			public static eFloat DelayedFloatField(string       label,  float              value, GUIStyle           style)
			{
				return DelayedFloatFieldMaster(new GUICon(label), value, style);
			}

			public static eFloat DelayedFloatField(string       label,  float              value, params GUILayOpt[] options)
			{
				return DelayedFloatFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eFloat DelayedFloatField(string       label,  float              value, GUIStyle           style, params GUILayOpt[] options)
			{
				return DelayedFloatFieldMaster(new GUICon(label), value, style, options);
			}

			public static eFloat DelayedFloatField(GUICon       guiCon, float              value)
			{
				return DelayedFloatFieldMaster(guiCon, value, NumberFieldStyle);
			}

			public static eFloat DelayedFloatField(GUICon       guiCon, float              value, GUIStyle           style)
			{
				return DelayedFloatFieldMaster(guiCon, value, style);
			}

			public static eFloat DelayedFloatField(GUICon       guiCon, float              value, params GUILayOpt[] options)
			{
				return DelayedFloatFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eFloat DelayedFloatField(GUICon       guiCon, float              value, GUIStyle           style, params GUILayOpt[] options)
			{
				return DelayedFloatFieldMaster(guiCon, value, style, options);
			}

			private static eFloat DelayedFloatFieldMaster(float value,  GUIStyle           style)
			{
				return DelayedFloatFieldMaster(value, style, null);
			}

			private static eFloat DelayedFloatFieldMaster(float value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.DelayedFloatField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eFloat DelayedFloatFieldMaster(GUICon guiCon, float value, GUIStyle style)
			{
				return DelayedFloatFieldMaster(guiCon, value, style, null);
			}

			private static eFloat DelayedFloatFieldMaster(GUICon guiCon, float value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.DelayedFloatField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region TextField
			public static eString TextField(string        value)
			{
				return TextFieldMaster(GUICon.none, value, NumberFieldStyle);
			}

			public static eString TextField(string        value,  GUIStyle           style)
			{
				return TextFieldMaster(GUICon.none, value, style);
			}

			public static eString TextField(string        value,  params GUILayOpt[] options)
			{
				return TextFieldMaster(GUICon.none, value, NumberFieldStyle, options);
			}

			public static eString TextField(string        value,  GUIStyle           style, params GUILayOpt[] options)
			{
				return TextFieldMaster(GUICon.none, value, style, options);
			}

			public static eString TextField(string        label,  string             value)
			{
				return TextFieldMaster(new GUICon(label), value, NumberFieldStyle);
			}

			public static eString TextField(string        label,  string             value, GUIStyle           style)
			{
				return TextFieldMaster(new GUICon(label), value, style);
			}

			public static eString TextField(string        label,  string             value, params GUILayOpt[] options)
			{
				return TextFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eString TextField(string        label,  string             value, GUIStyle           style, params GUILayOpt[] options)
			{
				return TextFieldMaster(new GUICon(label), value, style, options);
			}

			public static eString TextField(GUICon        guiCon, string             value)
			{
				return TextFieldMaster(guiCon, value, NumberFieldStyle);
			}

			public static eString TextField(GUICon        guiCon, string             value, GUIStyle           style)
			{
				return TextFieldMaster(guiCon, value, style);
			}

			public static eString TextField(GUICon        guiCon, string             value, params GUILayOpt[] options)
			{
				return TextFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eString TextField(GUICon        guiCon, string             value, GUIStyle           style, params GUILayOpt[] options)
			{
				return TextFieldMaster(guiCon, value, style, options);
			}

			private static eString TextFieldMaster(string value,  GUIStyle           style)
			{
				return TextFieldMaster(value, style, null);
			}

			private static eString TextFieldMaster(string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.TextField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eString TextFieldMaster(GUICon guiCon, string value, GUIStyle style)
			{
				return TextFieldMaster(guiCon, value, style, null);
			}

			private static eString TextFieldMaster(GUICon guiCon, string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.TextField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region DelayedTextField
			public static eString DelayedTextField(string        value)
			{
				return DelayedTextFieldMaster(GUICon.none, value, NumberFieldStyle);
			}

			public static eString DelayedTextField(string        value,  GUIStyle           style)
			{
				return DelayedTextFieldMaster(GUICon.none, value, style);
			}

			public static eString DelayedTextField(string        value,  params GUILayOpt[] options)
			{
				return DelayedTextFieldMaster(GUICon.none, value, NumberFieldStyle, options);
			}

			public static eString DelayedTextField(string        value,  GUIStyle           style, params GUILayOpt[] options)
			{
				return DelayedTextFieldMaster(GUICon.none, value, style, options);
			}

			public static eString DelayedTextField(string        label,  string             value)
			{
				return DelayedTextFieldMaster(new GUICon(label), value, NumberFieldStyle);
			}

			public static eString DelayedTextField(string        label,  string             value, GUIStyle           style)
			{
				return DelayedTextFieldMaster(new GUICon(label), value, style);
			}

			public static eString DelayedTextField(string        label,  string             value, params GUILayOpt[] options)
			{
				return DelayedTextFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eString DelayedTextField(string        label,  string             value, GUIStyle           style, params GUILayOpt[] options)
			{
				return TextFieldMaster(new GUICon(label), value, style, options);
			}

			public static eString DelayedTextField(GUICon        guiCon, string             value)
			{
				return DelayedTextFieldMaster(guiCon, value, NumberFieldStyle);
			}

			public static eString DelayedTextField(GUICon        guiCon, string             value, GUIStyle           style)
			{
				return DelayedTextFieldMaster(guiCon, value, style);
			}

			public static eString DelayedTextField(GUICon        guiCon, string             value, params GUILayOpt[] options)
			{
				return DelayedTextFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eString DelayedTextField(GUICon        guiCon, string             value, GUIStyle           style, params GUILayOpt[] options)
			{
				return DelayedTextFieldMaster(guiCon, value, style, options);
			}

			private static eString DelayedTextFieldMaster(string value,  GUIStyle           style)
			{
				return DelayedTextFieldMaster(value, style, null);
			}

			private static eString DelayedTextFieldMaster(string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.DelayedTextField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eString DelayedTextFieldMaster(GUICon guiCon, string value, GUIStyle style)
			{
				return DelayedTextFieldMaster(guiCon, value, style, null);
			}

			private static eString DelayedTextFieldMaster(GUICon guiCon, string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.DelayedTextField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region TextArea
			public static eString TextArea(string        value)
			{
				return TextAreaMaster(value, NumberFieldStyle);
			}

			public static eString TextArea(string        value, GUIStyle           style)
			{
				return TextAreaMaster(value, style);
			}

			public static eString TextArea(string        value, params GUILayOpt[] options)
			{
				return TextAreaMaster(value, NumberFieldStyle, options);
			}

			public static eString TextArea(string        value, GUIStyle           style, params GUILayOpt[] options)
			{
				return TextAreaMaster(value, style, options);
			}

			private static eString TextAreaMaster(string value, GUIStyle           style)
			{
				return TextAreaMaster(value, style, null);
			}

			private static eString TextAreaMaster(string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.TextArea(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region ObjectField
			public static eObject ObjectField(Object value, Type type, bool allowSceneObjects)
			{
				return ObjectFieldMaster(value, type, allowSceneObjects);
			}

			public static eObject ObjectField(Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options)
			{
				return ObjectFieldMaster(value, type, allowSceneObjects, options);
			}

			public static eObject ObjectField(string guiCon, Object value, Type type, bool allowSceneObjects)
			{
				return ObjectFieldMaster(new GUICon(guiCon), value, type, allowSceneObjects);
			}

			public static eObject ObjectField(string guiCon, Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options)
			{
				return ObjectFieldMaster(new GUICon(guiCon), value, type, allowSceneObjects, options);
			}

			public static eObject ObjectField(GUICon guiCon, Object value, Type type, bool allowSceneObjects)
			{
				return ObjectFieldMaster(guiCon, value, type, allowSceneObjects);
			}

			public static eObject ObjectField(GUICon guiCon, Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options)
			{
				return ObjectFieldMaster(guiCon, value, type, allowSceneObjects, options);
			}

			private static eObject ObjectFieldMaster(Object value, Type type, bool allowSceneObjects)
			{
				return ObjectFieldMaster(value, type, allowSceneObjects, null);
			}

			private static eObject ObjectFieldMaster(Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.ObjectField(value, type, allowSceneObjects, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eObject ObjectFieldMaster(GUICon guiCon, Object value, Type type, bool allowSceneObjects)
			{
				return ObjectFieldMaster(guiCon, value, type, allowSceneObjects, null);
			}

			private static eObject ObjectFieldMaster(GUICon guiCon, Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.ObjectField(guiCon, value, type, allowSceneObjects, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region ObjectFieldGeneric
			public static GUIEvent<T> ObjectField<T>(Object value, bool allowSceneObjects) where T: Object
			{
				return ObjectFieldMaster<T>(value, allowSceneObjects);
			}

			public static GUIEvent<T> ObjectField<T>(Object value, bool allowSceneObjects, params GUILayOpt[] options) where T: Object
			{
				return ObjectFieldMaster<T>(value, allowSceneObjects, options);
			}

			public static GUIEvent<T> ObjectField<T>(string guiCon, Object value, bool allowSceneObjects) where T: Object
			{
				return ObjectFieldMaster<T>(new GUICon(guiCon), value, allowSceneObjects);
			}

			public static GUIEvent<T> ObjectField<T>(string guiCon, Object value, bool allowSceneObjects, params GUILayOpt[] options) where T: Object
			{
				return ObjectFieldMaster<T>(new GUICon(guiCon), value, allowSceneObjects, options);
			}

			public static GUIEvent<T> ObjectField<T>(GUICon guiCon, Object value, bool allowSceneObjects) where T: Object
			{
				return ObjectFieldMaster<T>(guiCon, value, allowSceneObjects);
			}

			public static GUIEvent<T> ObjectField<T>(GUICon guiCon, Object value, bool allowSceneObjects, params GUILayOpt[] options) where T: Object
			{
				return ObjectFieldMaster<T>(guiCon, value, allowSceneObjects, options);
			}

			private static GUIEvent<T> ObjectFieldMaster<T>(Object value, bool allowSceneObjects) where T: Object
			{
				return ObjectFieldMaster<T>(value, allowSceneObjects, null);
			}

			private static GUIEvent<T> ObjectFieldMaster<T>(Object value, bool allowSceneObjects, params GUILayOpt[] options) where T: Object
			{
				var val = (T)EditorGUILayout.ObjectField(value, typeof(T), allowSceneObjects, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static GUIEvent<T> ObjectFieldMaster<T>(GUICon guiCon, Object value, bool allowSceneObjects) where T: Object
			{
				return ObjectFieldMaster<T>(guiCon, value, allowSceneObjects, null);
			}

			private static GUIEvent<T> ObjectFieldMaster<T>(GUICon guiCon, Object value, bool allowSceneObjects, params GUILayOpt[] options) where T: Object
			{
				var val = (T)EditorGUILayout.ObjectField(guiCon, value, typeof(T), allowSceneObjects, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion

#region HelpBox
			public static GUIEvent ErrorBox(string   text)
			{
				return FoCsGUI.ErrorBox(GUILayoutUtility.GetRect(0, SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			}

			public static GUIEvent InfoBox(string    text)
			{
				return FoCsGUI.InfoBox(GUILayoutUtility.GetRect(0, SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			}

			public static GUIEvent WarningBox(string text)
			{
				return FoCsGUI.WarningBox(GUILayoutUtility.GetRect(0, SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			}

			public static GUIEvent HelpBox(string    text)
			{
				return FoCsGUI.HelpBox(GUILayoutUtility.GetRect(0, SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			}
#endregion

#region PropertyField
			public static eBool PropertyField(SerializedProperty property, bool includeChildren)
			{
				return PropertyFieldMaster(property, includeChildren, null);
			}

			public static eBool PropertyField(SerializedProperty property, bool includeChildren, params GUILayOpt[] options)
			{
				return PropertyFieldMaster(property, includeChildren, options);
			}

			public static eBool PropertyField(string label, SerializedProperty property, bool includeChildren)
			{
				return PropertyFieldMaster(new GUICon(label), property, includeChildren, null);
			}

			public static eBool PropertyField(string label, SerializedProperty property, bool includeChildren, params GUILayOpt[] options)
			{
				return PropertyFieldMaster(new GUICon(label), property, includeChildren, options);
			}

			public static eBool PropertyField(GUICon label, SerializedProperty property, bool includeChildren)
			{
				return PropertyFieldMaster(label, property, includeChildren, null);
			}

			public static eBool PropertyField(GUICon label, SerializedProperty property, bool includeChildren, params GUILayOpt[] options)
			{
				return PropertyFieldMaster(label, property, includeChildren, options);
			}

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
			public static Rect GetControlRect(params GUILayOpt[] options)
			{
				return EditorGUILayout.GetControlRect(options);
			}

			public static Rect GetControlRect(bool               hasLabel, params GUILayOpt[] options)
			{
				return EditorGUILayout.GetControlRect(hasLabel, options);
			}

			public static Rect GetControlRect(bool               hasLabel, float              height, params GUILayOpt[] options)
			{
				return EditorGUILayout.GetControlRect(hasLabel, height, options);
			}

			public static Rect GetControlRect(bool               hasLabel, float              height, GUIStyle           style, params GUILayOpt[] options)
			{
				return EditorGUILayout.GetControlRect(hasLabel, height, style, options);
			}
#endregion

		}
	}
}