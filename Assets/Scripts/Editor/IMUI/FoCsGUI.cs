using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;
using GUICon = UnityEngine.GUIContent;
using eInt = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<int>;
using eBool = ForestOfChaosLib.Editor.FoCsGUI.GUIEventBool;
using eFloat = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<float>;
using eString = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<string>;

namespace ForestOfChaosLib.Editor
{
	public static partial class FoCsGUI
	{
		internal static GUIStyle LabelStyle       { get; } = Styles.Unity.Label;
		internal static GUIStyle ToggleStyle      { get; } = Styles.Unity.Toggle;
		internal static GUIStyle ButtonStyle      { get; } = Styles.Unity.Button;
		internal static GUIStyle FoldoutStyle     { get; } = Styles.Unity.Foldout;
		internal static GUIStyle TextFieldStyle   { get; } = Styles.Unity.TextField_Editor;
		internal static GUIStyle NumberFieldStyle { get; } = Styles.Unity.NumberField;
		internal static GUIStyle TextAreaStyle    { get; } = Styles.Unity.TextArea_Editor;
#region Label
		public static GUIEvent Label(Rect rect) => LabelMaster(rect,                                 GUICon.none,       LabelStyle);
		public static GUIEvent Label(Rect rect, GUIStyle style) => LabelMaster(rect,                 GUICon.none,       style);
		public static GUIEvent Label(Rect rect, string   label) => LabelMaster(rect,                 new GUICon(label), LabelStyle);
		public static GUIEvent Label(Rect rect, string   label, GUIStyle style) => LabelMaster(rect, new GUICon(label), style);
		public static GUIEvent Label(Rect rect, GUICon   guiCon) => LabelMaster(rect,                 guiCon, LabelStyle);
		public static GUIEvent Label(Rect rect, GUICon   guiCon, GUIStyle style) => LabelMaster(rect, guiCon, style);
		public static GUIEvent Label(Rect rect, Texture  texture) => LabelMaster(rect,                 new GUICon(texture), LabelStyle);
		public static GUIEvent Label(Rect rect, Texture  texture, GUIStyle style) => LabelMaster(rect, new GUICon(texture), style);

		private static GUIEvent LabelMaster(Rect rect, GUICon guiCon, GUIStyle style)
		{
			var data = new GUIEvent {Event = new Event(Event.current), Rect = rect};
			GUI.Label(rect, guiCon, style);

			return data;
		}
#endregion
#region Button
		public static eBool Button(Rect rect) => ButtonMaster(rect,                                 GUICon.none,       ButtonStyle);
		public static eBool Button(Rect rect, GUIStyle style) => ButtonMaster(rect,                 GUICon.none,       style);
		public static eBool Button(Rect rect, string   label) => ButtonMaster(rect,                 new GUICon(label), ButtonStyle);
		public static eBool Button(Rect rect, string   label, GUIStyle style) => ButtonMaster(rect, new GUICon(label), style);
		public static eBool Button(Rect rect, GUICon   guiCon) => ButtonMaster(rect,                 guiCon, ButtonStyle);
		public static eBool Button(Rect rect, GUICon   guiCon, GUIStyle style) => ButtonMaster(rect, guiCon, style);
		public static eBool Toggle(Rect rect, Texture  texture) => ButtonMaster(rect,                 new GUICon(texture), ButtonStyle);
		public static eBool Toggle(Rect rect, Texture  texture, GUIStyle style) => ButtonMaster(rect, new GUICon(texture), style);

		private static eBool ButtonMaster(Rect rect, GUICon guiCon, GUIStyle style)
		{
			var data = new eBool {Event = new Event(Event.current), Rect = rect};
			data.Value = GUI.Button(rect, guiCon, style);

			return data;
		}
#endregion
#region Toggle
		public static eBool Toggle(Rect rect, bool toggle) => ToggleMaster(rect,                                 toggle, GUICon.none,       ToggleStyle);
		public static eBool Toggle(Rect rect, bool toggle, GUIStyle style) => ToggleMaster(rect,                 toggle, GUICon.none,       style);
		public static eBool Toggle(Rect rect, bool toggle, string   label) => ToggleMaster(rect,                 toggle, new GUICon(label), ToggleStyle);
		public static eBool Toggle(Rect rect, bool toggle, string   label, GUIStyle style) => ToggleMaster(rect, toggle, new GUICon(label), style);
		public static eBool Toggle(Rect rect, bool toggle, GUICon   guiCon) => ToggleMaster(rect,                 toggle, guiCon, ToggleStyle);
		public static eBool Toggle(Rect rect, bool toggle, GUICon   guiCon, GUIStyle style) => ToggleMaster(rect, toggle, guiCon, style);
		public static eBool Toggle(Rect rect, bool toggle, Texture  texture) => ToggleMaster(rect,                 toggle, new GUICon(texture), ToggleStyle);
		public static eBool Toggle(Rect rect, bool toggle, Texture  texture, GUIStyle style) => ToggleMaster(rect, toggle, new GUICon(texture), style);

		public static eBool ToggleMaster(Rect rect, bool toggle, GUICon guiCon, GUIStyle style)
		{
			var data = new eBool {Event = new Event(Event.current), Rect = rect};
			data.Value = GUI.Toggle(rect, toggle, guiCon, style);

			return data;
		}
#endregion
#region Foldout
		public static GUIEvent Foldout(Rect rect, bool foldout) => FoldoutMaster(rect,                                 foldout, GUICon.none,       FoldoutStyle);
		public static GUIEvent Foldout(Rect rect, bool foldout, GUIStyle style) => FoldoutMaster(rect,                 foldout, GUICon.none,       style);
		public static GUIEvent Foldout(Rect rect, bool foldout, string   label) => FoldoutMaster(rect,                 foldout, new GUICon(label), FoldoutStyle);
		public static GUIEvent Foldout(Rect rect, bool foldout, string   label, GUIStyle style) => FoldoutMaster(rect, foldout, new GUICon(label), style);
		public static GUIEvent Foldout(Rect rect, bool foldout, GUICon   guiCon) => FoldoutMaster(rect,                 foldout, guiCon, FoldoutStyle);
		public static GUIEvent Foldout(Rect rect, bool foldout, GUICon   guiCon, GUIStyle style) => FoldoutMaster(rect, foldout, guiCon, style);
		public static GUIEvent Foldout(Rect rect, bool foldout, Texture  texture) => FoldoutMaster(rect,                 foldout, new GUICon(texture), FoldoutStyle);
		public static GUIEvent Foldout(Rect rect, bool foldout, Texture  texture, GUIStyle style) => FoldoutMaster(rect, foldout, new GUICon(texture), style);

		public static GUIEvent FoldoutMaster(Rect rect, bool foldout, GUICon guiCon, GUIStyle style)
		{
			var data = new GUIEvent {Rect = rect};
			EditorGUI.Foldout(rect, foldout, guiCon, style);

			return data;
		}
#endregion
#region IntField
		public static eInt IntField(Rect rect, int    value) => IntFieldMaster(rect,                             GUICon.none,       value, NumberFieldStyle);
		public static eInt IntField(Rect rect, string label,  int value) => IntFieldMaster(rect,                 new GUICon(label), value, NumberFieldStyle);
		public static eInt IntField(Rect rect, string label,  int value, GUIStyle style) => IntFieldMaster(rect, new GUICon(label), value, style);
		public static eInt IntField(Rect rect, GUICon guiCon, int value) => IntFieldMaster(rect,                 guiCon, value, NumberFieldStyle);
		public static eInt IntField(Rect rect, GUICon guiCon, int value, GUIStyle style) => IntFieldMaster(rect, guiCon, value, style);

		private static eInt IntFieldMaster(Rect rect, GUICon guiCon, int value, GUIStyle style)
		{
			var data = new eInt {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.IntField(rect, guiCon, value, style);

			return data;
		}
#endregion
#region FloatField
		public static eFloat FloatField(Rect rect, float  value) => FloatFieldMaster(rect,                                  GUICon.none,       value, NumberFieldStyle);
		public static eFloat FloatField(Rect rect, float  value,  GUIStyle style) => FloatFieldMaster(rect,                 GUICon.none,       value, style);
		public static eFloat FloatField(Rect rect, string label,  float    value) => FloatFieldMaster(rect,                 new GUICon(label), value, NumberFieldStyle);
		public static eFloat FloatField(Rect rect, string label,  float    value, GUIStyle style) => FloatFieldMaster(rect, new GUICon(label), value, style);
		public static eFloat FloatField(Rect rect, GUICon guiCon, float    value) => FloatFieldMaster(rect,                 guiCon, value, NumberFieldStyle);
		public static eFloat FloatField(Rect rect, GUICon guiCon, float    value, GUIStyle style) => FloatFieldMaster(rect, guiCon, value, style);

		private static eFloat FloatFieldMaster(Rect rect, GUICon guiCon, float value, GUIStyle style)
		{
			var data = new eFloat {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.FloatField(rect, guiCon, value, style);

			return data;
		}
#endregion
#region TextField
		public static eString TextField(Rect rect, string value) => TextFieldMaster(rect,                                  GUICon.none,       value, TextFieldStyle);
		public static eString TextField(Rect rect, string value,  GUIStyle style) => TextFieldMaster(rect,                 GUICon.none,       value, style);
		public static eString TextField(Rect rect, string label,  string   value) => TextFieldMaster(rect,                 new GUICon(label), value, TextFieldStyle);
		public static eString TextField(Rect rect, string label,  string   value, GUIStyle style) => TextFieldMaster(rect, new GUICon(label), value, style);
		public static eString TextField(Rect rect, GUICon guiCon, string   value) => TextFieldMaster(rect,                 guiCon, value, TextFieldStyle);
		public static eString TextField(Rect rect, GUICon guiCon, string   value, GUIStyle style) => TextFieldMaster(rect, guiCon, value, style);

		private static eString TextFieldMaster(Rect rect, GUICon guiCon, string value, GUIStyle style)
		{
			var data = new eString {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.TextField(rect, guiCon, value, style);

			return data;
		}
#endregion
#region TextArea
		public static eString TextArea(Rect rect, string value) => TextAreaMaster(rect,                 value, TextAreaStyle);
		public static eString TextArea(Rect rect, string value, GUIStyle style) => TextAreaMaster(rect, value, style);

		private static eString TextAreaMaster(Rect rect, string value, GUIStyle style)
		{
			var data = new eString {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.TextArea(rect, value, style);

			return data;
		}
#endregion
#region HelpBox
		public static GUIEvent ErrorBox(Rect   rect, string text) => HelpBoxMaster(rect, text, MessageType.Error);
		public static GUIEvent InfoBox(Rect    rect, string text) => HelpBoxMaster(rect, text, MessageType.Info);
		public static GUIEvent WarningBox(Rect rect, string text) => HelpBoxMaster(rect, text, MessageType.Warning);
		public static GUIEvent HelpBox(Rect    rect, string text) => HelpBoxMaster(rect, text, MessageType.None);

		private static GUIEvent HelpBoxMaster(Rect rect, string text, MessageType type)
		{
			var data = new GUIEvent {Event = new Event(Event.current), Rect = rect};
			EditorGUI.HelpBox(rect, text, type);

			return data;
		}
#endregion
#region Other
		private const float MENU_BUTTON_SIZE = 16f;
		public static eInt DrawPropertyWithMenu(Rect position, SerializedProperty property, GUICon label, GUICon[] Options, int active) => DrawDisabledPropertyWithMenu(false, position, property, label, Options, active);

		public static eInt DrawDisabledPropertyWithMenu(bool disabled, Rect position, SerializedProperty property, GUICon label, GUICon[] Options, int active)
		{
			var propRect  = position.SetWidth(position.width - MENU_BUTTON_SIZE - 2).MoveHeight(-2);
			var rectWidth = position.x + (position.width - (MENU_BUTTON_SIZE * (EditorGUI.indentLevel + 1)));
			var menuRect  = new Rect(rectWidth, position.y, position.width - rectWidth, position.height);

			if(property.hasVisibleChildren)
			{
				using(FoCsEditor.Disposables.DisabledScope(disabled))
					EditorGUI.PropertyField(propRect, property, label, true);
			}
			else
			{
				using(FoCsEditor.Disposables.DisabledScope(disabled))
					EditorGUI.PropertyField(propRect, property, label);
			}

			var index = EditorGUI.Popup(menuRect, GUICon.none, active, Options, Styles.InLineOptionsMenu);

			return GUIEvent.Create(position, index);
		}
#endregion
	}
}
