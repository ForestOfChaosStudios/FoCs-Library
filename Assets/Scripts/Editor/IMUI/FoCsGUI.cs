using System;
using ForestOfChaosLib.Editor.PropertyDrawers;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;
using GUICon = UnityEngine.GUIContent;
using eInt = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<int>;
using eBool = ForestOfChaosLib.Editor.FoCsGUI.GUIEventBool;
using eFloat = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<float>;
using eString = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<string>;
using SerProp = UnityEditor.SerializedProperty;
using eProp = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<UnityEditor.SerializedProperty>;
using eObject = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<UnityEngine.Object>;
using Object = UnityEngine.Object;

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
		public static GUIEvent Label(Rect rect)                                 => LabelMaster(rect, GUICon.none,       LabelStyle);
		public static GUIEvent Label(Rect rect, GUIStyle style)                 => LabelMaster(rect, GUICon.none,       style);
		public static GUIEvent Label(Rect rect, string   label)                 => LabelMaster(rect, new GUICon(label), LabelStyle);
		public static GUIEvent Label(Rect rect, string   label, GUIStyle style) => LabelMaster(rect, new GUICon(label), style);
		public static GUIEvent Label(Rect rect, GUICon   guiCon)                 => LabelMaster(rect, guiCon, LabelStyle);
		public static GUIEvent Label(Rect rect, GUICon   guiCon, GUIStyle style) => LabelMaster(rect, guiCon, style);
		public static GUIEvent Label(Rect rect, Texture  texture)                 => LabelMaster(rect, new GUICon(texture), LabelStyle);
		public static GUIEvent Label(Rect rect, Texture  texture, GUIStyle style) => LabelMaster(rect, new GUICon(texture), style);

		private static GUIEvent LabelMaster(Rect rect, GUICon guiCon, GUIStyle style)
		{
			var data = new GUIEvent {Event = new Event(Event.current), Rect = rect};
			GUI.Label(rect, guiCon, style);

			return data;
		}
#endregion

#region Button
		public static eBool Button(Rect rect)                                 => ButtonMaster(rect, GUICon.none,       ButtonStyle);
		public static eBool Button(Rect rect, GUIStyle style)                 => ButtonMaster(rect, GUICon.none,       style);
		public static eBool Button(Rect rect, string   label)                 => ButtonMaster(rect, new GUICon(label), ButtonStyle);
		public static eBool Button(Rect rect, string   label, GUIStyle style) => ButtonMaster(rect, new GUICon(label), style);
		public static eBool Button(Rect rect, GUICon   guiCon)                 => ButtonMaster(rect, guiCon, ButtonStyle);
		public static eBool Button(Rect rect, GUICon   guiCon, GUIStyle style) => ButtonMaster(rect, guiCon, style);
		public static eBool Button(Rect rect, Texture  texture)                 => ButtonMaster(rect, new GUICon(texture), ButtonStyle);
		public static eBool Button(Rect rect, Texture  texture, GUIStyle style) => ButtonMaster(rect, new GUICon(texture), style);

		private static eBool ButtonMaster(Rect rect, GUICon guiCon, GUIStyle style)
		{
			var data = new eBool {Event = new Event(Event.current), Rect = rect};
			data.Value = GUI.Button(rect, guiCon, style);

			return data;
		}
#endregion

#region Toggle
		public static eBool Toggle(Rect rect, bool toggle)                                 => ToggleMaster(rect, toggle, GUICon.none,       ToggleStyle);
		public static eBool Toggle(Rect rect, bool toggle, GUIStyle style)                 => ToggleMaster(rect, toggle, GUICon.none,       style);
		public static eBool Toggle(Rect rect, bool toggle, string   label)                 => ToggleMaster(rect, toggle, new GUICon(label), ToggleStyle);
		public static eBool Toggle(Rect rect, bool toggle, string   label, GUIStyle style) => ToggleMaster(rect, toggle, new GUICon(label), style);
		public static eBool Toggle(Rect rect, bool toggle, GUICon   guiCon)                 => ToggleMaster(rect, toggle, guiCon, ToggleStyle);
		public static eBool Toggle(Rect rect, bool toggle, GUICon   guiCon, GUIStyle style) => ToggleMaster(rect, toggle, guiCon, style);
		public static eBool Toggle(Rect rect, bool toggle, Texture  texture)                 => ToggleMaster(rect, toggle, new GUICon(texture), ToggleStyle);
		public static eBool Toggle(Rect rect, bool toggle, Texture  texture, GUIStyle style) => ToggleMaster(rect, toggle, new GUICon(texture), style);

		public static eBool ToggleMaster(Rect rect, bool toggle, GUICon guiCon, GUIStyle style)
		{
			var data = new eBool {Event = new Event(Event.current), Rect = rect};
			data.Value = GUI.Toggle(rect, toggle, guiCon, style);

			return data;
		}
#endregion

#region Foldout
		public static GUIEvent Foldout(Rect rect, bool foldout)                                 => FoldoutMaster(rect, foldout, GUICon.none,       FoldoutStyle);
		public static GUIEvent Foldout(Rect rect, bool foldout, GUIStyle style)                 => FoldoutMaster(rect, foldout, GUICon.none,       style);
		public static GUIEvent Foldout(Rect rect, bool foldout, string   label)                 => FoldoutMaster(rect, foldout, new GUICon(label), FoldoutStyle);
		public static GUIEvent Foldout(Rect rect, bool foldout, string   label, GUIStyle style) => FoldoutMaster(rect, foldout, new GUICon(label), style);
		public static GUIEvent Foldout(Rect rect, bool foldout, GUICon   guiCon)                 => FoldoutMaster(rect, foldout, guiCon, FoldoutStyle);
		public static GUIEvent Foldout(Rect rect, bool foldout, GUICon   guiCon, GUIStyle style) => FoldoutMaster(rect, foldout, guiCon, style);
		public static GUIEvent Foldout(Rect rect, bool foldout, Texture  texture)                 => FoldoutMaster(rect, foldout, new GUICon(texture), FoldoutStyle);
		public static GUIEvent Foldout(Rect rect, bool foldout, Texture  texture, GUIStyle style) => FoldoutMaster(rect, foldout, new GUICon(texture), style);

		public static GUIEvent FoldoutMaster(Rect rect, bool foldout, GUICon guiCon, GUIStyle style)
		{
			var data = new GUIEvent {Rect = rect};
			EditorGUI.Foldout(rect, foldout, guiCon, style);

			return data;
		}
#endregion

#region IntField
		public static eInt IntField(Rect rect, int    value)                             => IntFieldMaster(rect, GUICon.none,       value, NumberFieldStyle);
		public static eInt IntField(Rect rect, string label,  int value)                 => IntFieldMaster(rect, new GUICon(label), value, NumberFieldStyle);
		public static eInt IntField(Rect rect, string label,  int value, GUIStyle style) => IntFieldMaster(rect, new GUICon(label), value, style);
		public static eInt IntField(Rect rect, GUICon guiCon, int value)                 => IntFieldMaster(rect, guiCon, value, NumberFieldStyle);
		public static eInt IntField(Rect rect, GUICon guiCon, int value, GUIStyle style) => IntFieldMaster(rect, guiCon, value, style);

		private static eInt IntFieldMaster(Rect rect, GUICon guiCon, int value, GUIStyle style)
		{
			var data = new eInt {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.IntField(rect, guiCon, value, style);

			return data;
		}
#endregion

#region FloatField
		public static eFloat FloatField(Rect rect, float  value)                                  => FloatFieldMaster(rect, GUICon.none,       value, NumberFieldStyle);
		public static eFloat FloatField(Rect rect, float  value,  GUIStyle style)                 => FloatFieldMaster(rect, GUICon.none,       value, style);
		public static eFloat FloatField(Rect rect, string label,  float    value)                 => FloatFieldMaster(rect, new GUICon(label), value, NumberFieldStyle);
		public static eFloat FloatField(Rect rect, string label,  float    value, GUIStyle style) => FloatFieldMaster(rect, new GUICon(label), value, style);
		public static eFloat FloatField(Rect rect, GUICon guiCon, float    value)                 => FloatFieldMaster(rect, guiCon, value, NumberFieldStyle);
		public static eFloat FloatField(Rect rect, GUICon guiCon, float    value, GUIStyle style) => FloatFieldMaster(rect, guiCon, value, style);

		private static eFloat FloatFieldMaster(Rect rect, GUICon guiCon, float value, GUIStyle style)
		{
			var data = new eFloat {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.FloatField(rect, guiCon, value, style);

			return data;
		}
#endregion

#region TextField
		public static eString TextField(Rect rect, string value)                                  => TextFieldMaster(rect, GUICon.none,       value, TextFieldStyle);
		public static eString TextField(Rect rect, string value,  GUIStyle style)                 => TextFieldMaster(rect, GUICon.none,       value, style);
		public static eString TextField(Rect rect, string label,  string   value)                 => TextFieldMaster(rect, new GUICon(label), value, TextFieldStyle);
		public static eString TextField(Rect rect, string label,  string   value, GUIStyle style) => TextFieldMaster(rect, new GUICon(label), value, style);
		public static eString TextField(Rect rect, GUICon guiCon, string   value)                 => TextFieldMaster(rect, guiCon, value, TextFieldStyle);
		public static eString TextField(Rect rect, GUICon guiCon, string   value, GUIStyle style) => TextFieldMaster(rect, guiCon, value, style);

		private static eString TextFieldMaster(Rect rect, GUICon guiCon, string value, GUIStyle style)
		{
			var data = new eString {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.TextField(rect, guiCon, value, style);

			return data;
		}
#endregion

#region TextArea
		public static eString TextArea(Rect rect, string value)                 => TextAreaMaster(rect, value, TextAreaStyle);
		public static eString TextArea(Rect rect, string value, GUIStyle style) => TextAreaMaster(rect, value, style);

		private static eString TextAreaMaster(Rect rect, string value, GUIStyle style)
		{
			var data = new eString {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.TextArea(rect, value, style);

			return data;
		}
#endregion

#region ObjectField
		public static eObject ObjectField(Rect rect, Object value,  Type   type,  bool allowSceneObjects)            => ObjectFieldMaster(rect, GUICon.none,       value, type, allowSceneObjects);
		public static eObject ObjectField(Rect rect, string label,  Object value, Type type, bool allowSceneObjects) => ObjectFieldMaster(rect, new GUICon(label), value, type, allowSceneObjects);
		public static eObject ObjectField(Rect rect, GUICon guiCon, Object value, Type type, bool allowSceneObjects) => ObjectFieldMaster(rect, guiCon,            value, type, allowSceneObjects);

		private static eObject ObjectFieldMaster(Rect rect, GUICon guiCon, Object value, Type type, bool allowSceneObjects)
		{
			var data = new eObject {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.ObjectField(rect, guiCon, value, type, allowSceneObjects);

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

#region PropertyField
		private static eProp PropFieldMaster(Rect pos, SerProp prop, GUICon cont, bool includeChildren, AttributeCheck ignoreCheck, bool autoLabelField = false)
		{
			if(!autoLabelField)
				return PropDraw(pos, prop, cont, includeChildren, ignoreCheck);

			using(FoCsEditor.Disposables.LabelFieldSetWidth(pos.width * 0.4f))
				return PropDraw(pos, prop, cont, includeChildren, ignoreCheck);
		}

		private static eProp PropDraw(Rect pos, SerProp prop, GUICon cont, bool includeChildren, AttributeCheck ignoreCheck)
		{
			var data = new eProp {Event = new Event(Event.current), Rect = pos, Value = prop};

			if(ignoreCheck == AttributeCheck.DontCheck)
				return DoPropSwitchDraw(pos, prop, cont, includeChildren, data);

			var attributes = prop.GetSerializedPropertyAttributes();

			if(attributes.Length == 0)
				return DoPropSwitchDraw(pos, prop, cont, includeChildren, data);

			EditorGUI.PropertyField(pos, prop, cont, includeChildren);

			return data;
		}

		private static eProp DoPropSwitchDraw(Rect pos, SerProp prop, GUICon cont, bool includeChildren, eProp data)
		{
			switch(prop.propertyType)
			{
				case SerializedPropertyType.Quaternion:
					Vector4PropEditor.Draw(pos, prop, cont);

					return data;
				default:
					EditorGUI.PropertyField(pos, prop, cont, includeChildren);

					return data;
			}
		}

		public enum AttributeCheck
		{
			DontCheck,
			DoCheck
		}

		public static eProp PropertyField(Rect pos, SerProp prop, bool autoLabelField = false) =>
				PropFieldMaster(pos, prop, new GUICon(prop.displayName), true, AttributeCheck.DontCheck, autoLabelField);

		public static eProp PropertyField(Rect pos, SerProp prop, bool includeChildren, bool autoLabelField) =>
				PropFieldMaster(pos, prop, new GUICon(prop.displayName), includeChildren, AttributeCheck.DontCheck, autoLabelField);

		public static eProp PropertyField(Rect pos, SerProp prop, AttributeCheck ignoreCheck, bool autoLabelField = false) =>
				PropFieldMaster(pos, prop, new GUICon(prop.displayName), true, ignoreCheck, autoLabelField);

		public static eProp PropertyField(Rect pos, SerProp prop, bool includeChildren, AttributeCheck ignoreCheck, bool autoLabelField = false) =>
				PropFieldMaster(pos, prop, new GUICon(prop.displayName), includeChildren, ignoreCheck, autoLabelField);

		public static eProp PropertyField(Rect pos, SerProp prop, GUICon cont, bool autoLabelField = false)               => PropFieldMaster(pos, prop, cont, true,            AttributeCheck.DontCheck, autoLabelField);
		public static eProp PropertyField(Rect pos, SerProp prop, GUICon cont, bool includeChildren, bool autoLabelField) => PropFieldMaster(pos, prop, cont, includeChildren, AttributeCheck.DontCheck, autoLabelField);

		public static eProp PropertyField(Rect pos, SerProp prop, GUICon cont, bool includeChildren, AttributeCheck ignoreAttributeCheck, bool autoLabelField = false) =>
				PropFieldMaster(pos, prop, cont, includeChildren, ignoreAttributeCheck, autoLabelField);

		public static eProp PropertyField(Rect pos, SerProp prop, GUICon cont, AttributeCheck ignoreCheck, bool autoLabelField = false) => PropFieldMaster(pos, prop, cont, true, ignoreCheck, autoLabelField);

		private static float GetPropertyHeightMaster(SerProp prop, GUICon cont, bool includeChildren, AttributeCheck ignoreAttributeCheck)
		{
			if(ignoreAttributeCheck == AttributeCheck.DontCheck)
				return DoPropSwitchHeight(prop, cont, includeChildren);

			var attributes = prop.GetSerializedPropertyAttributes();

			if(attributes.Length == 0)
				return DoPropSwitchHeight(prop, cont, includeChildren);

			return EditorGUI.GetPropertyHeight(prop, cont, includeChildren);
		}

		private static float DoPropSwitchHeight(SerProp prop, GUICon cont, bool includeChildren)
		{
			switch(prop.propertyType)
			{
				case SerializedPropertyType.Quaternion: return FoCsPropertyDrawer.PropertyHeight(prop, cont);
				default:                                return EditorGUI.GetPropertyHeight(prop, cont, includeChildren);
			}
		}

		public static float GetPropertyHeight(SerProp prop)                                    => GetPropertyHeightMaster(prop, new GUICon(prop.displayName), true,            AttributeCheck.DoCheck);
		public static float GetPropertyHeight(SerProp prop, bool   includeChildren)            => GetPropertyHeightMaster(prop, new GUICon(prop.displayName), includeChildren, AttributeCheck.DoCheck);
		public static float GetPropertyHeight(SerProp prop, GUICon cont, bool includeChildren) => GetPropertyHeightMaster(prop, cont,                         includeChildren, AttributeCheck.DoCheck);

		public static float GetPropertyHeight(SerProp prop, GUICon cont) =>
				GetPropertyHeightMaster(prop, cont, true, AttributeCheck.DoCheck);

		public static float GetPropertyHeight(SerProp prop, AttributeCheck ignoreCheck) =>
				GetPropertyHeightMaster(prop, new GUICon(prop.displayName), true, ignoreCheck);

		public static float GetPropertyHeight(SerProp prop, bool includeChildren, AttributeCheck ignoreCheck) =>
				GetPropertyHeightMaster(prop, new GUICon(prop.displayName), includeChildren, ignoreCheck);

		public static float GetPropertyHeight(SerProp prop, GUICon cont, bool includeChildren, AttributeCheck ignoreCheck) =>
				GetPropertyHeightMaster(prop, cont, includeChildren, ignoreCheck);

		public static float GetPropertyHeight(SerProp prop, GUICon cont, AttributeCheck ignoreCheck) => GetPropertyHeightMaster(prop, cont, true, ignoreCheck);
#endregion

#region Other
		public static GUIEvent ProgressBar(Rect rect, float fillAmount, string label = "")
		{
			var data = new GUIEvent {Event = new Event(Event.current), Rect = rect};
			EditorGUI.ProgressBar(rect, fillAmount, label);

			return data;
		}

		public static void ProgressBarSplit(Rect pos, float value, string name = "", bool isPositiveLeft = true)
		{
			//TODO: add label
			var leftPos = pos;
			leftPos.width *= 0.5f;
			var rightPos = leftPos;
			rightPos.x    += leftPos.width;
			leftPos.x     += leftPos.width;
			leftPos.width *= -1;
			float leftValue  = 0;
			float rightValue = 0;

			if(isPositiveLeft)
			{
				if(value >= 0)
				{
					leftValue  = value;
					rightValue = 0;
				}
				else
				{
					leftValue  = 0;
					rightValue = -value;
				}
			}
			else
			{
				if(value <= 0)
				{
					leftValue  = -value;
					rightValue = 0;
				}
				else
				{
					leftValue  = 0;
					rightValue = value;
				}
			}

			EditorGUI.ProgressBar(leftPos,  +leftValue,  "");
			EditorGUI.ProgressBar(rightPos, +rightValue, "");
		}

		private const float MENU_BUTTON_SIZE = 16f;
		public static eInt  DrawPropertyWithMenu(Rect position, SerProp property, GUICon label, GUICon[] Options, int active) => DrawDisabledPropertyWithMenu(false, position, property, label, Options, active);

		public static eInt DrawDisabledPropertyWithMenu(bool disabled, Rect position, SerProp property, GUICon label, GUICon[] Options, int active)
		{
			var propRect  = position.Edit(RectEdit.SetWidth(position.width - MENU_BUTTON_SIZE         - 2), RectEdit.SubtractHeight(2));
			var rectWidth = position.x + (position.width - (MENU_BUTTON_SIZE * (EditorGUI.indentLevel + 1)));
			var menuRect  = new Rect(rectWidth, position.y, position.width - rectWidth, position.height);

			if(property.hasVisibleChildren)
			{
				using(FoCsEditor.Disposables.DisabledScope(disabled))
					PropertyField(propRect, property, label, true);
			}
			else
			{
				using(FoCsEditor.Disposables.DisabledScope(disabled))
					PropertyField(propRect, property, label);
			}

			var index = EditorGUI.Popup(menuRect, GUICon.none, active, Options, Styles.InLineOptionsMenu);

			return GUIEvent.Create(position, index);
		}

		public static eInt DrawActionWithMenu(Rect position, Action<Rect> draw, GUICon label, GUICon[] Options, int active) => DrawActionWithMenu(false, position, draw, label, Options, active);

		public static eInt DrawActionWithMenu(bool disabled, Rect position, Action<Rect> draw, GUICon label, GUICon[] Options, int active)
		{
			var propRect  = position.Edit(RectEdit.SetWidth(position.width - MENU_BUTTON_SIZE         - 2), RectEdit.SubtractHeight(2));
			var rectWidth = position.x + (position.width - (MENU_BUTTON_SIZE * (EditorGUI.indentLevel + 1)));
			var menuRect  = new Rect(rectWidth, position.y, position.width - rectWidth, position.height);

			using(FoCsEditor.Disposables.DisabledScope(disabled))
				draw.Trigger(propRect);

			var index = EditorGUI.Popup(menuRect, GUICon.none, active, Options, Styles.InLineOptionsMenu);

			return GUIEvent.Create(position, index);
		}
#endregion

	}
}