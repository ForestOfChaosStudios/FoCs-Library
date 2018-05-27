using UnityEditor;
using UnityEngine;
using GUICon = UnityEngine.GUIContent;
using GUILayOpt = UnityEngine.GUILayoutOption;
using eInt = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<int>;
using eBool = ForestOfChaosLib.Editor.FoCsGUI.GUIEventBool;
using eFloat = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<float>;
using eString = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<string>;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public static partial class FoCsGUI
	{
		public static class Layout
		{
			#region LabelField
			private static GUIEvent LabelFieldMaster(GUICon guiCon, GUIStyle style) => LabelFieldMaster(guiCon, style, null);
			private static GUIEvent LabelFieldMaster(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				EditorGUILayout.LabelField(guiCon, style, options);
				return GUIEvent.Create(GUILayoutUtility.GetLastRect());
			}
			#region NoLabel
			public static GUIEvent LabelField() => LabelFieldMaster(GUICon.none, LabelStyle);
			public static GUIEvent LabelField(GUIStyle style) => LabelFieldMaster(GUICon.none, style);
			public static GUIEvent LabelField(params GUILayOpt[] options) => LabelFieldMaster(GUICon.none, LabelStyle, options);
			public static GUIEvent LabelField(GUIStyle style, params GUILayOpt[] options) => LabelFieldMaster(GUICon.none, style, options);
			#endregion
			#region StringLabel
			public static GUIEvent LabelField(string label) => LabelFieldMaster(new GUICon(label), LabelStyle);
			public static GUIEvent LabelField(string label, GUIStyle style) => LabelFieldMaster(new GUICon(label), style);
			public static GUIEvent LabelField(string label, params GUILayOpt[] options) => LabelFieldMaster(new GUICon(label), LabelStyle, options);
			public static GUIEvent LabelField(string label, GUIStyle style, params GUILayOpt[] options) => LabelFieldMaster(new GUICon(label), style, options);
			#endregion
			#region GUIConLabel
			public static GUIEvent LabelField(GUICon guiCon) => LabelFieldMaster(guiCon, LabelStyle);
			public static GUIEvent LabelField(GUICon guiCon, GUIStyle style) => LabelFieldMaster(guiCon, style);
			public static GUIEvent LabelField(GUICon guiCon, params GUILayOpt[] options) => LabelFieldMaster(guiCon, LabelStyle, options);
			public static GUIEvent LabelField(GUICon guiCon, GUIStyle style, params GUILayOpt[] options) => LabelFieldMaster(guiCon, style, options);
			#endregion
			#region Texture
			public static GUIEvent LabelField(Texture texture) => LabelFieldMaster(new GUICon(texture), LabelStyle);
			public static GUIEvent LabelField(Texture texture, GUIStyle style) => LabelFieldMaster(new GUICon(texture), style);
			public static GUIEvent LabelField(Texture texture, params GUILayOpt[] options) => LabelFieldMaster(new GUICon(texture), LabelStyle, options);
			public static GUIEvent LabelField(Texture texture, GUIStyle style, params GUILayOpt[] options) => LabelFieldMaster(new GUICon(texture), style, options);
			#endregion
			#endregion
			#region Label
			private static GUIEvent LabelMaster(GUICon guiCon, GUIStyle style) => LabelMaster(guiCon, style, null);
			private static GUIEvent LabelMaster(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				GUILayout.Label(guiCon, style, options);
				return GUIEvent.Create(GUILayoutUtility.GetLastRect());
			}
			#region NoLabel
			public static GUIEvent Label() => LabelMaster(GUICon.none, LabelStyle);
			public static GUIEvent Label(GUIStyle style) => LabelMaster(GUICon.none, style);
			public static GUIEvent Label(params GUILayOpt[] options) => LabelMaster(GUICon.none, LabelStyle, options);
			public static GUIEvent Label(GUIStyle style, params GUILayOpt[] options) => LabelMaster(GUICon.none, style, options);
			#endregion
			#region StringLabel
			public static GUIEvent Label(string label) => LabelMaster(new GUICon(label), LabelStyle);
			public static GUIEvent Label(string label, GUIStyle style) => LabelMaster(new GUICon(label), style);
			public static GUIEvent Label(string label, params GUILayOpt[] options) => LabelMaster(new GUICon(label), LabelStyle, options);
			public static GUIEvent Label(string label, GUIStyle style, params GUILayOpt[] options) => LabelMaster(new GUICon(label), style, options);
			#endregion
			#region GUIConLabel
			public static GUIEvent Label(GUICon guiCon) => LabelMaster(guiCon, LabelStyle);
			public static GUIEvent Label(GUICon guiCon, GUIStyle style) => LabelMaster(guiCon, style);
			public static GUIEvent Label(GUICon guiCon, params GUILayOpt[] options) => LabelMaster(guiCon, LabelStyle, options);
			public static GUIEvent Label(GUICon guiCon, GUIStyle style, params GUILayOpt[] options) => LabelMaster(guiCon, style, options);
			#endregion
			#region Texture
			public static GUIEvent Label(Texture texture) => LabelMaster(new GUICon(texture), LabelStyle);
			public static GUIEvent Label(Texture texture, GUIStyle style) => LabelMaster(new GUICon(texture), style);
			public static GUIEvent Label(Texture texture, params GUILayOpt[] options) => LabelMaster(new GUICon(texture), LabelStyle, options);
			public static GUIEvent Label(Texture texture, GUIStyle style, params GUILayOpt[] options) => LabelMaster(new GUICon(texture), style, options);
			#endregion
			#endregion
			#region Button
			private static eBool ButtonMaster(GUICon guiCon, GUIStyle style) => ButtonMaster(guiCon, style, null);
			private static eBool ButtonMaster(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				var b = GUILayout.Button(guiCon, style, options);
				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), b);
			}
			#region NoLabel
			public static eBool Button() => ButtonMaster(GUICon.none, ButtonStyle);
			public static eBool Button(GUIStyle style) => ButtonMaster(GUICon.none, style);
			public static eBool Button(params GUILayOpt[] options) => ButtonMaster(GUICon.none, ButtonStyle, options);
			public static eBool Button(GUIStyle style, params GUILayOpt[] options) => ButtonMaster(GUICon.none, style, options);
			#endregion
			#region StringLabel
			public static eBool Button(string label) => ButtonMaster(new GUICon(label), ButtonStyle);
			public static eBool Button(string label, GUIStyle style) => ButtonMaster(new GUICon(label), style);
			public static eBool Button(string label, params GUILayOpt[] options) => ButtonMaster(new GUICon(label), ButtonStyle, options);
			public static eBool Button(string label, GUIStyle style, params GUILayOpt[] options) => ButtonMaster(new GUICon(label), style, options);
			#endregion
			#region GUIConLabel
			public static eBool Button(GUICon guiCon) => ButtonMaster(guiCon, ButtonStyle);
			public static eBool Button(GUICon guiCon, GUIStyle style) => ButtonMaster(guiCon, style);
			public static eBool Button(GUICon guiCon, params GUILayOpt[] options) => ButtonMaster(guiCon, ButtonStyle, options);
			public static eBool Button(GUICon guiCon, GUIStyle style, params GUILayOpt[] options) => ButtonMaster(guiCon, style, options);
			#endregion
			#region Texture
			public static eBool Button(Texture texture) => ButtonMaster(new GUICon(texture), ButtonStyle);
			public static eBool Button(Texture texture, GUIStyle style) => ButtonMaster(new GUICon(texture), style);
			public static eBool Button(Texture texture, params GUILayOpt[] options) => ButtonMaster(new GUICon(texture), ButtonStyle, options);
			public static eBool Button(Texture texture, GUIStyle style, params GUILayOpt[] options) => ButtonMaster(new GUICon(texture), style, options);
			#endregion
			#endregion
			#region Toggle
			private static eBool ToggleMaster(bool toggle, GUICon guiCon, GUIStyle style) => ToggleMaster(toggle, guiCon, style, null);
			private static eBool ToggleMaster(bool toggle, GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				var val = GUILayout.Toggle(toggle, guiCon, style, options);
				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
			#region NoLabel
			public static eBool Toggle(bool toggle) => ToggleMaster(toggle, GUICon.none, ToggleStyle);
			public static eBool Toggle(bool toggle, GUIStyle style) => ToggleMaster(toggle, GUICon.none, style);
			public static eBool Toggle(bool toggle, params GUILayOpt[] options) => ToggleMaster(toggle, GUICon.none, ToggleStyle, options);
			public static eBool Toggle(bool toggle, GUIStyle style, params GUILayOpt[] options) => ToggleMaster(toggle, GUICon.none, style, options);
			#endregion
			#region StringLabel
			public static eBool Toggle(bool toggle, string label) => ToggleMaster(toggle, new GUICon(label), ToggleStyle);
			public static eBool Toggle(bool toggle, string label, GUIStyle style) => ToggleMaster(toggle, new GUICon(label), style);
			public static eBool Toggle(bool toggle, string label, params GUILayOpt[] options) => ToggleMaster(toggle, new GUICon(label), ToggleStyle, options);
			public static eBool Toggle(bool toggle, string label, GUIStyle style, params GUILayOpt[] options) => ToggleMaster(toggle, new GUICon(label), style, options);
			#endregion
			#region GUIConLabel
			public static eBool Toggle(bool toggle, GUICon guiCon) => ToggleMaster(toggle, guiCon, ToggleStyle);
			public static eBool Toggle(bool toggle, GUICon guiCon, GUIStyle style) => ToggleMaster(toggle, guiCon, style);
			public static eBool Toggle(bool toggle, GUICon guiCon, params GUILayOpt[] options) => ToggleMaster(toggle, guiCon, ToggleStyle, options);
			public static eBool Toggle(bool toggle, GUICon guiCon, GUIStyle style, params GUILayOpt[] options) => ToggleMaster(toggle, guiCon, style, options);
			#endregion
			#region Texture
			public static eBool Toggle(bool toggle, Texture texture) => ToggleMaster(toggle, new GUICon(texture), ToggleStyle);
			public static eBool Toggle(bool toggle, Texture texture, GUIStyle style) => ToggleMaster(toggle, new GUICon(texture), style);
			public static eBool Toggle(bool toggle, Texture texture, params GUILayOpt[] options) => ToggleMaster(toggle, new GUICon(texture), ToggleStyle, options);
			public static eBool Toggle(bool toggle, Texture texture, GUIStyle style, params GUILayOpt[] options) => ToggleMaster(toggle, new GUICon(texture), style, options);
			#endregion
			#endregion
			#region Foldout
			private static eBool FoldoutMaster(bool foldout, GUICon guiCon, GUIStyle style, bool toggleOnLabelClick = true)
			{
				var val = EditorGUILayout.Foldout(foldout, guiCon, toggleOnLabelClick, style);
				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
			#region NoLabel
			public static eBool Foldout(bool foldout) => FoldoutMaster(foldout, GUICon.none, FoldoutStyle);
			public static eBool Foldout(bool foldout, GUIStyle style) => FoldoutMaster(foldout, GUICon.none, style);
			public static eBool Foldout(bool foldout, bool toggleOnLabelClick) => FoldoutMaster(foldout, GUICon.none, FoldoutStyle, toggleOnLabelClick);
			public static eBool Foldout(bool foldout, GUIStyle style, bool toggleOnLabelClick) => FoldoutMaster(foldout, GUICon.none, style, toggleOnLabelClick);
			#endregion
			#region StringLabel
			public static eBool Foldout(bool foldout, string label) => FoldoutMaster(foldout, new GUICon(label), FoldoutStyle);
			public static eBool Foldout(bool foldout, string label, GUIStyle style) => FoldoutMaster(foldout, new GUICon(label), style);
			public static eBool Foldout(bool foldout, string label, bool toggleOnLabelClick) => FoldoutMaster(foldout, new GUICon(label), FoldoutStyle, toggleOnLabelClick);
			public static eBool Foldout(bool foldout, string label, GUIStyle style, bool toggleOnLabelClick) => FoldoutMaster(foldout, new GUICon(label), style, toggleOnLabelClick);
			#endregion
			#region GUIConLabel
			public static eBool Foldout(bool foldout, GUICon guiCon) => FoldoutMaster(foldout, guiCon, FoldoutStyle);
			public static eBool Foldout(bool foldout, GUICon guiCon, GUIStyle style) => FoldoutMaster(foldout, guiCon, style);
			public static eBool Foldout(bool foldout, GUICon guiCon, bool toggleOnLabelClick) => FoldoutMaster(foldout, guiCon, FoldoutStyle, toggleOnLabelClick);
			public static eBool Foldout(bool foldout, GUICon guiCon, GUIStyle style, bool toggleOnLabelClick) => FoldoutMaster(foldout, guiCon, style, toggleOnLabelClick);
			#endregion
			#endregion
			#region IntField
			private static eInt IntFieldMaster(GUICon guiCon, int value, GUIStyle style) => IntFieldMaster(guiCon, value, style, null);
			private static eInt IntFieldMaster(GUICon guiCon, int value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.IntField(guiCon, value, style, options);
				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
			#region NoLabel
			public static eInt IntField(int value) => IntFieldMaster(GUICon.none, value, NumberFieldStyle);
			public static eInt IntField(int value, GUIStyle style) => IntFieldMaster(GUICon.none, value, style);
			public static eInt IntField(int value, params GUILayOpt[] options) => IntFieldMaster(GUICon.none, value, NumberFieldStyle, options);
			public static eInt IntField(int value, GUIStyle style, params GUILayOpt[] options) => IntFieldMaster(GUICon.none, value, style, options);
			#endregion
			#region StringLabel
			public static eInt IntField(string label, int value) => IntFieldMaster(new GUICon(label), value, NumberFieldStyle);
			public static eInt IntField(string label, int value, GUIStyle style) => IntFieldMaster(new GUICon(label), value, style);
			public static eInt IntField(string label, int value, params GUILayOpt[] options) => IntFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			public static eInt IntField(string label, int value, GUIStyle style, params GUILayOpt[] options) => IntFieldMaster(new GUICon(label), value, style, options);
			#endregion
			#region GUIConLabel
			public static eInt IntField(GUICon guiCon, int value) => IntFieldMaster(guiCon, value, NumberFieldStyle);
			public static eInt IntField(GUICon guiCon, int value, GUIStyle style) => IntFieldMaster(guiCon, value, style);
			public static eInt IntField(GUICon guiCon, int value, params GUILayOpt[] options) => IntFieldMaster(guiCon, value, NumberFieldStyle, options);
			public static eInt IntField(GUICon guiCon, int value, GUIStyle style, params GUILayOpt[] options) => IntFieldMaster(guiCon, value, style, options);
			#endregion
			#endregion
			#region FloatField
			private static eFloat FloatFieldMaster(GUICon guiCon, float value, GUIStyle style) => FloatFieldMaster(guiCon, value, style, null);
			private static eFloat FloatFieldMaster(GUICon guiCon, float value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.FloatField(guiCon, value, style, options);
				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
			#region NoLabel
			public static eFloat FloatField(float value) => FloatFieldMaster(GUICon.none, value, NumberFieldStyle);
			public static eFloat FloatField(float value, GUIStyle style) => FloatFieldMaster(GUICon.none, value, style);
			public static eFloat FloatField(float value, params GUILayOpt[] options) => FloatFieldMaster(GUICon.none, value, NumberFieldStyle, options);
			public static eFloat FloatField(float value, GUIStyle style, params GUILayOpt[] options) => FloatFieldMaster(GUICon.none, value, style, options);
			#endregion
			#region StringLabel
			public static eFloat FloatField(string label, float value) => FloatFieldMaster(new GUICon(label), value, NumberFieldStyle);
			public static eFloat FloatField(string label, float value, GUIStyle style) => FloatFieldMaster(new GUICon(label), value, style);
			public static eFloat FloatField(string label, float value, params GUILayOpt[] options) => FloatFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			public static eFloat FloatField(string label, float value, GUIStyle style, params GUILayOpt[] options) => FloatFieldMaster(new GUICon(label), value, style, options);
			#endregion
			#region GUIConLabel
			public static eFloat FloatField(GUICon guiCon, float value) => FloatFieldMaster(guiCon, value, NumberFieldStyle);
			public static eFloat FloatField(GUICon guiCon, float value, GUIStyle style) => FloatFieldMaster(guiCon, value, style);
			public static eFloat FloatField(GUICon guiCon, float value, params GUILayOpt[] options) => FloatFieldMaster(guiCon, value, NumberFieldStyle, options);
			public static eFloat FloatField(GUICon guiCon, float value, GUIStyle style, params GUILayOpt[] options) => FloatFieldMaster(guiCon, value, style, options);
			#endregion
			#endregion
			#region TextField
			private static eString TextFieldMaster(GUICon guiCon, string value, GUIStyle style) => TextFieldMaster(guiCon, value, style, null);
			private static eString TextFieldMaster(GUICon guiCon, string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.TextField(guiCon, value, style, options);
				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
			#region NoLabel
			public static eString TextField(string value) => TextFieldMaster(GUICon.none, value, NumberFieldStyle);
			public static eString TextField(string value, GUIStyle style) => TextFieldMaster(GUICon.none, value, style);
			public static eString TextField(string value, params GUILayOpt[] options) => TextFieldMaster(GUICon.none, value, NumberFieldStyle, options);
			public static eString TextField(string value, GUIStyle style, params GUILayOpt[] options) => TextFieldMaster(GUICon.none, value, style, options);
			#endregion
			#region StringLabel
			public static eString TextField(string label, string value) => TextFieldMaster(new GUICon(label), value, NumberFieldStyle);
			public static eString TextField(string label, string value, GUIStyle style) => TextFieldMaster(new GUICon(label), value, style);
			public static eString TextField(string label, string value, params GUILayOpt[] options) => TextFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			public static eString TextField(string label, string value, GUIStyle style, params GUILayOpt[] options) => TextFieldMaster(new GUICon(label), value, style, options);
			#endregion
			#region GUIConLabel
			public static eString TextField(GUICon guiCon, string value) => TextFieldMaster(guiCon, value, NumberFieldStyle);
			public static eString TextField(GUICon guiCon, string value, GUIStyle style) => TextFieldMaster(guiCon, value, style);
			public static eString TextField(GUICon guiCon, string value, params GUILayOpt[] options) => TextFieldMaster(guiCon, value, NumberFieldStyle, options);
			public static eString TextField(GUICon guiCon, string value, GUIStyle style, params GUILayOpt[] options) => TextFieldMaster(guiCon, value, style, options);
			#endregion
			#endregion
			#region TextArea
			private static eString TextAreaMaster(string value, GUIStyle style) => TextAreaMaster(value, style, null);
			private static eString TextAreaMaster(string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EditorGUILayout.TextArea(value, style,options);
				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
			#region NoLabel
			public static eString TextArea(string value) => TextAreaMaster(value, NumberFieldStyle);
			public static eString TextArea(string value, GUIStyle style) => TextAreaMaster(value, style);
			public static eString TextArea(string value, params GUILayOpt[] options) => TextAreaMaster(value, NumberFieldStyle, options);
			public static eString TextArea(string value, GUIStyle style, params GUILayOpt[] options) => TextAreaMaster(value, style, options);
			#endregion
			#endregion
			#region HelpBox
			public static GUIEvent ErrorBox(string text) => FoCsGUI.ErrorBox(GUILayoutUtility.GetRect(0, Utilities.SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			public static GUIEvent InfoBox(string text) => FoCsGUI.InfoBox(GUILayoutUtility.GetRect(0, Utilities.SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			public static GUIEvent WarningBox(string text) => FoCsGUI.WarningBox(GUILayoutUtility.GetRect(0, Utilities.SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			public static GUIEvent HelpBox(string text) => FoCsGUI.HelpBox(GUILayoutUtility.GetRect(0, Utilities.SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			#endregion
		}
	}
}