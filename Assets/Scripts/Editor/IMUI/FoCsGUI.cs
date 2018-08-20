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
using eDouble = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<double>;
using eString = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<string>;
using SerProp = UnityEditor.SerializedProperty;
using eProp = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<UnityEditor.SerializedProperty>;
using eObject = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<UnityEngine.Object>;
using Object = UnityEngine.Object;

namespace ForestOfChaosLib.Editor
{
	public static partial class FoCsGUI
	{

#region Label
		public static GUIEvent Label(Rect rect)
		{
			return LabelMaster(rect, GUICon.none, LabelStyle);
		}

		public static GUIEvent Label(Rect rect, GUIStyle style)
		{
			return LabelMaster(rect, GUICon.none, style);
		}

		public static GUIEvent Label(Rect rect, string label)
		{
			return LabelMaster(rect, new GUICon(label), LabelStyle);
		}

		public static GUIEvent Label(Rect rect, string label, GUIStyle style)
		{
			return LabelMaster(rect, new GUICon(label), style);
		}

		public static GUIEvent Label(Rect rect, GUICon guiCon)
		{
			return LabelMaster(rect, guiCon, LabelStyle);
		}

		public static GUIEvent Label(Rect rect, GUICon guiCon, GUIStyle style)
		{
			return LabelMaster(rect, guiCon, style);
		}

		public static GUIEvent Label(Rect rect, Texture texture)
		{
			return LabelMaster(rect, new GUICon(texture), LabelStyle);
		}

		public static GUIEvent Label(Rect rect, Texture texture, GUIStyle style)
		{
			return LabelMaster(rect, new GUICon(texture), style);
		}

		private static GUIEvent LabelMaster(Rect rect, GUICon guiCon, GUIStyle style)
		{
			var data = new GUIEvent {Event = new Event(Event.current), Rect = rect};
			EditorGUI.LabelField(rect, guiCon, style);

			return data;
		}
#endregion

#region Button
		public static eBool Button(Rect rect)
		{
			return ButtonMaster(rect, GUICon.none, ButtonStyle);
		}

		public static eBool Button(Rect rect, GUIStyle style)
		{
			return ButtonMaster(rect, GUICon.none, style);
		}

		public static eBool Button(Rect rect, string label)
		{
			return ButtonMaster(rect, new GUICon(label), ButtonStyle);
		}

		public static eBool Button(Rect rect, string label, GUIStyle style)
		{
			return ButtonMaster(rect, new GUICon(label), style);
		}

		public static eBool Button(Rect rect, GUICon guiCon)
		{
			return ButtonMaster(rect, guiCon, ButtonStyle);
		}

		public static eBool Button(Rect rect, GUICon guiCon, GUIStyle style)
		{
			return ButtonMaster(rect, guiCon, style);
		}

		public static eBool Button(Rect rect, Texture texture)
		{
			return ButtonMaster(rect, new GUICon(texture), ButtonStyle);
		}

		public static eBool Button(Rect rect, Texture texture, GUIStyle style)
		{
			return ButtonMaster(rect, new GUICon(texture), style);
		}

		private static eBool ButtonMaster(Rect rect, GUICon guiCon, GUIStyle style)
		{
			var data = new eBool {Event = new Event(Event.current), Rect = rect};
			data.Value = GUI.Button(rect, guiCon, style);

			return data;
		}
#endregion

#region Toggle
		public static eBool Toggle(Rect rect, bool toggle)
		{
			return ToggleMaster(rect, toggle, GUICon.none, ToggleStyle);
		}

		public static eBool Toggle(Rect rect, bool toggle, GUIStyle style)
		{
			return ToggleMaster(rect, toggle, GUICon.none, style);
		}

		public static eBool Toggle(Rect rect, bool toggle, string label)
		{
			return ToggleMaster(rect, toggle, new GUICon(label), ToggleStyle);
		}

		public static eBool Toggle(Rect rect, bool toggle, string label, GUIStyle style)
		{
			return ToggleMaster(rect, toggle, new GUICon(label), style);
		}

		public static eBool Toggle(Rect rect, bool toggle, GUICon guiCon)
		{
			return ToggleMaster(rect, toggle, guiCon, ToggleStyle);
		}

		public static eBool Toggle(Rect rect, bool toggle, GUICon guiCon, GUIStyle style)
		{
			return ToggleMaster(rect, toggle, guiCon, style);
		}

		public static eBool Toggle(Rect rect, bool toggle, Texture texture)
		{
			return ToggleMaster(rect, toggle, new GUICon(texture), ToggleStyle);
		}

		public static eBool Toggle(Rect rect, bool toggle, Texture texture, GUIStyle style)
		{
			return ToggleMaster(rect, toggle, new GUICon(texture), style);
		}

		public static eBool ToggleMaster(Rect rect, bool toggle, GUICon guiCon, GUIStyle style)
		{
			var data = new eBool {Event = new Event(Event.current), Rect = rect};
			data.Value = GUI.Toggle(rect, toggle, guiCon, style);

			return data;
		}
#endregion

#region Toggle
		public static eBool ToggleLeft(Rect rect, bool toggle)
		{
			return ToggleLeftMaster(rect, toggle, GUICon.none, ToggleStyle);
		}

		public static eBool ToggleLeft(Rect rect, bool toggle, GUIStyle style)
		{
			return ToggleLeftMaster(rect, toggle, GUICon.none, style);
		}

		public static eBool ToggleLeft(Rect rect, bool toggle, string label)
		{
			return ToggleLeftMaster(rect, toggle, new GUICon(label), ToggleStyle);
		}

		public static eBool ToggleLeft(Rect rect, bool toggle, string label, GUIStyle style)
		{
			return ToggleLeftMaster(rect, toggle, new GUICon(label), style);
		}

		public static eBool ToggleLeft(Rect rect, bool toggle, GUICon guiCon)
		{
			return ToggleLeftMaster(rect, toggle, guiCon, ToggleStyle);
		}

		public static eBool ToggleLeft(Rect rect, bool toggle, GUICon guiCon, GUIStyle style)
		{
			return ToggleLeftMaster(rect, toggle, guiCon, style);
		}

		public static eBool ToggleLeft(Rect rect, bool toggle, Texture texture)
		{
			return ToggleLeftMaster(rect, toggle, new GUICon(texture), ToggleStyle);
		}

		public static eBool ToggleLeft(Rect rect, bool toggle, Texture texture, GUIStyle style)
		{
			return ToggleLeftMaster(rect, toggle, new GUICon(texture), style);
		}

		public static eBool ToggleLeftMaster(Rect rect, bool toggle, GUICon guiCon, GUIStyle style)
		{
			var data = new eBool {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.ToggleLeft(rect, guiCon, toggle, style);

			return data;
		}
#endregion

#region Foldout
		public static eBool Foldout(Rect rect, bool foldout)
		{
			return FoldoutMaster(rect, foldout, GUICon.none, FoldoutStyle);
		}

		public static eBool Foldout(Rect rect, bool foldout, GUIStyle style)
		{
			return FoldoutMaster(rect, foldout, GUICon.none, style);
		}

		public static eBool Foldout(Rect rect, bool foldout, string label)
		{
			return FoldoutMaster(rect, foldout, new GUICon(label), FoldoutStyle);
		}

		public static eBool Foldout(Rect rect, bool foldout, string label, GUIStyle style)
		{
			return FoldoutMaster(rect, foldout, new GUICon(label), style);
		}

		public static eBool Foldout(Rect rect, bool foldout, GUICon guiCon)
		{
			return FoldoutMaster(rect, foldout, guiCon, FoldoutStyle);
		}

		public static eBool Foldout(Rect rect, bool foldout, GUICon guiCon, GUIStyle style)
		{
			return FoldoutMaster(rect, foldout, guiCon, style);
		}

		public static eBool Foldout(Rect rect, bool foldout, Texture texture)
		{
			return FoldoutMaster(rect, foldout, new GUICon(texture), FoldoutStyle);
		}

		public static eBool Foldout(Rect rect, bool foldout, Texture texture, GUIStyle style)
		{
			return FoldoutMaster(rect, foldout, new GUICon(texture), style);
		}

		public static eBool FoldoutMaster(Rect rect, bool foldout, GUICon guiCon, GUIStyle style)
		{
			var val  = EditorGUI.Foldout(rect, foldout, guiCon, style);
			var data = GUIEvent.Create(val);

			return data;
		}
#endregion

#region IntField
		public static eInt IntField(Rect rect, int value)
		{
			return IntFieldMaster(rect, GUICon.none, value, NumberFieldStyle);
		}

		public static eInt IntField(Rect rect, string label, int value)
		{
			return IntFieldMaster(rect, new GUICon(label), value, NumberFieldStyle);
		}

		public static eInt IntField(Rect rect, string label, int value, GUIStyle style)
		{
			return IntFieldMaster(rect, new GUICon(label), value, style);
		}

		public static eInt IntField(Rect rect, GUICon guiCon, int value)
		{
			return IntFieldMaster(rect, guiCon, value, NumberFieldStyle);
		}

		public static eInt IntField(Rect rect, GUICon guiCon, int value, GUIStyle style)
		{
			return IntFieldMaster(rect, guiCon, value, style);
		}

		private static eInt IntFieldMaster(Rect rect, GUICon guiCon, int value, GUIStyle style)
		{
			var data = new eInt {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.IntField(rect, guiCon, value, style);

			return data;
		}
#endregion

#region DelayedIntField
		public static eInt DelayedIntField(Rect rect, int value)
		{
			return DelayedIntFieldMaster(rect, GUICon.none, value, NumberFieldStyle);
		}

		public static eInt DelayedIntField(Rect rect, string label, int value)
		{
			return DelayedIntFieldMaster(rect, new GUICon(label), value, NumberFieldStyle);
		}

		public static eInt DelayedIntField(Rect rect, string label, int value, GUIStyle style)
		{
			return DelayedIntFieldMaster(rect, new GUICon(label), value, style);
		}

		public static eInt DelayedIntField(Rect rect, GUICon guiCon, int value)
		{
			return DelayedIntFieldMaster(rect, guiCon, value, NumberFieldStyle);
		}

		public static eInt DelayedIntField(Rect rect, GUICon guiCon, int value, GUIStyle style)
		{
			return DelayedIntFieldMaster(rect, guiCon, value, style);
		}

		private static eInt DelayedIntFieldMaster(Rect rect, GUICon guiCon, int value, GUIStyle style)
		{
			var data = new eInt {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.DelayedIntField(rect, guiCon, value, style);

			return data;
		}
#endregion

#region FloatField
		public static eFloat FloatField(Rect rect, float value)
		{
			return FloatFieldMaster(rect, GUICon.none, value, NumberFieldStyle);
		}

		public static eFloat FloatField(Rect rect, float value, GUIStyle style)
		{
			return FloatFieldMaster(rect, GUICon.none, value, style);
		}

		public static eFloat FloatField(Rect rect, string label, float value)
		{
			return FloatFieldMaster(rect, new GUICon(label), value, NumberFieldStyle);
		}

		public static eFloat FloatField(Rect rect, string label, float value, GUIStyle style)
		{
			return FloatFieldMaster(rect, new GUICon(label), value, style);
		}

		public static eFloat FloatField(Rect rect, GUICon guiCon, float value)
		{
			return FloatFieldMaster(rect, guiCon, value, NumberFieldStyle);
		}

		public static eFloat FloatField(Rect rect, GUICon guiCon, float value, GUIStyle style)
		{
			return FloatFieldMaster(rect, guiCon, value, style);
		}

		private static eFloat FloatFieldMaster(Rect rect, GUICon guiCon, float value, GUIStyle style)
		{
			var data = new eFloat {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.FloatField(rect, guiCon, value, style);

			return data;
		}
#endregion

#region DelayedFloatField
		public static eFloat DelayedFloatField(Rect rect, float value)
		{
			return DelayedFloatFieldMaster(rect, GUICon.none, value, NumberFieldStyle);
		}

		public static eFloat DelayedFloatField(Rect rect, float value, GUIStyle style)
		{
			return DelayedFloatFieldMaster(rect, GUICon.none, value, style);
		}

		public static eFloat DelayedFloatField(Rect rect, string label, float value)
		{
			return DelayedFloatFieldMaster(rect, new GUICon(label), value, NumberFieldStyle);
		}

		public static eFloat DelayedFloatField(Rect rect, string label, float value, GUIStyle style)
		{
			return DelayedFloatFieldMaster(rect, new GUICon(label), value, style);
		}

		public static eFloat DelayedFloatField(Rect rect, GUICon guiCon, float value)
		{
			return DelayedFloatFieldMaster(rect, guiCon, value, NumberFieldStyle);
		}

		public static eFloat DelayedFloatField(Rect rect, GUICon guiCon, float value, GUIStyle style)
		{
			return DelayedFloatFieldMaster(rect, guiCon, value, style);
		}

		private static eFloat DelayedFloatFieldMaster(Rect rect, GUICon guiCon, float value, GUIStyle style)
		{
			var data = new eFloat {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.DelayedFloatField(rect, guiCon, value, style);

			return data;
		}
#endregion

#region DoubleField
		public static eDouble DoubleField(Rect rect, double value)
		{
			return DoubleFieldMaster(rect, GUICon.none, value, NumberFieldStyle);
		}

		public static eDouble DoubleField(Rect rect, double value, GUIStyle style)
		{
			return DoubleFieldMaster(rect, GUICon.none, value, style);
		}

		public static eDouble DoubleField(Rect rect, string label, double value)
		{
			return DoubleFieldMaster(rect, new GUICon(label), value, NumberFieldStyle);
		}

		public static eDouble DoubleField(Rect rect, string label, double value, GUIStyle style)
		{
			return DoubleFieldMaster(rect, new GUICon(label), value, style);
		}

		public static eDouble DoubleField(Rect rect, GUICon guiCon, double value)
		{
			return DoubleFieldMaster(rect, guiCon, value, NumberFieldStyle);
		}

		public static eDouble DoubleField(Rect rect, GUICon guiCon, double value, GUIStyle style)
		{
			return DoubleFieldMaster(rect, guiCon, value, style);
		}

		private static eDouble DoubleFieldMaster(Rect rect, GUICon guiCon, double value, GUIStyle style)
		{
			var data = new eDouble {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.DoubleField(rect, guiCon, value, style);

			return data;
		}
#endregion

#region DelayedDoubleField
		public static eDouble DelayedDoubleField(Rect rect, double value)
		{
			return DelayedDoubleFieldMaster(rect, GUICon.none, value, NumberFieldStyle);
		}

		public static eDouble DelayedDoubleField(Rect rect, double value, GUIStyle style)
		{
			return DelayedDoubleFieldMaster(rect, GUICon.none, value, style);
		}

		public static eDouble DelayedDoubleField(Rect rect, string label, double value)
		{
			return DelayedDoubleFieldMaster(rect, new GUICon(label), value, NumberFieldStyle);
		}

		public static eDouble DelayedDoubleField(Rect rect, string label, double value, GUIStyle style)
		{
			return DelayedDoubleFieldMaster(rect, new GUICon(label), value, style);
		}

		public static eDouble DelayedDoubleField(Rect rect, GUICon guiCon, double value)
		{
			return DelayedDoubleFieldMaster(rect, guiCon, value, NumberFieldStyle);
		}

		public static eDouble DelayedDoubleField(Rect rect, GUICon guiCon, double value, GUIStyle style)
		{
			return DelayedDoubleFieldMaster(rect, guiCon, value, style);
		}

		private static eDouble DelayedDoubleFieldMaster(Rect rect, GUICon guiCon, double value, GUIStyle style)
		{
			var data = new eDouble {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.DelayedDoubleField(rect, guiCon, value, style);

			return data;
		}
#endregion

#region TextField
		public static eString TextField(Rect rect, string value)
		{
			return TextFieldMaster(rect, GUICon.none, value, TextFieldStyle);
		}

		public static eString TextField(Rect rect, string value, GUIStyle style)
		{
			return TextFieldMaster(rect, GUICon.none, value, style);
		}

		public static eString TextField(Rect rect, string label, string value)
		{
			return TextFieldMaster(rect, new GUICon(label), value, TextFieldStyle);
		}

		public static eString TextField(Rect rect, string label, string value, GUIStyle style)
		{
			return TextFieldMaster(rect, new GUICon(label), value, style);
		}

		public static eString TextField(Rect rect, GUICon guiCon, string value)
		{
			return TextFieldMaster(rect, guiCon, value, TextFieldStyle);
		}

		public static eString TextField(Rect rect, GUICon guiCon, string value, GUIStyle style)
		{
			return TextFieldMaster(rect, guiCon, value, style);
		}

		private static eString TextFieldMaster(Rect rect, GUICon guiCon, string value, GUIStyle style)
		{
			var data = new eString {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.TextField(rect, guiCon, value, style);

			return data;
		}
#endregion

#region DelayedTextField
		public static eString DelayedTextField(Rect rect, string value)
		{
			return DelayedTextFieldMaster(rect, GUICon.none, value, TextFieldStyle);
		}

		public static eString DelayedTextField(Rect rect, string value, GUIStyle style)
		{
			return DelayedTextFieldMaster(rect, GUICon.none, value, style);
		}

		public static eString DelayedTextField(Rect rect, string label, string value)
		{
			return DelayedTextFieldMaster(rect, new GUICon(label), value, TextFieldStyle);
		}

		public static eString DelayedTextField(Rect rect, string label, string value, GUIStyle style)
		{
			return DelayedTextFieldMaster(rect, new GUICon(label), value, style);
		}

		public static eString DelayedTextField(Rect rect, GUICon guiCon, string value)
		{
			return DelayedTextFieldMaster(rect, guiCon, value, TextFieldStyle);
		}

		public static eString DelayedTextField(Rect rect, GUICon guiCon, string value, GUIStyle style)
		{
			return DelayedTextFieldMaster(rect, guiCon, value, style);
		}

		private static eString DelayedTextFieldMaster(Rect rect, GUICon guiCon, string value, GUIStyle style)
		{
			var data = new eString {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.DelayedTextField(rect, guiCon, value, style);

			return data;
		}
#endregion

#region TextArea
		public static eString TextArea(Rect rect, string value)
		{
			return TextAreaMaster(rect, value, TextAreaStyle);
		}

		public static eString TextArea(Rect rect, string value, GUIStyle style)
		{
			return TextAreaMaster(rect, value, style);
		}

		private static eString TextAreaMaster(Rect rect, string value, GUIStyle style)
		{
			var data = new eString {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.TextArea(rect, value, style);

			return data;
		}
#endregion

#region RawObjectField
		public static eObject RawObjectField(Rect rect, Object value, Type type, bool allowSceneObjects)
		{
			return RawObjectFieldMaster(rect, GUICon.none, value, type, allowSceneObjects);
		}

		public static eObject RawObjectField(Rect rect, string label, Object value, Type type, bool allowSceneObjects)
		{
			return RawObjectFieldMaster(rect, new GUICon(label), value, type, allowSceneObjects);
		}

		public static eObject RawObjectField(Rect rect, GUICon guiCon, Object value, Type type, bool allowSceneObjects)
		{
			return RawObjectFieldMaster(rect, guiCon, value, type, allowSceneObjects);
		}

		private static eObject RawObjectFieldMaster(Rect rect, GUICon guiCon, Object value, Type type, bool allowSceneObjects)
		{
			var data = new eObject {Event = new Event(Event.current), Rect = rect};
			data.Value = EditorGUI.ObjectField(rect, guiCon, value, type, allowSceneObjects);

			return data;
		}
#endregion

#region ObjectFieldGeneric
		public static GUIEvent<T> ObjectField<T>(Rect rect, T value, Type type, bool allowSceneObjects) where T: Object
		{
			return ObjectFieldMaster(rect, GUICon.none, value, type, allowSceneObjects);
		}

		public static GUIEvent<T> ObjectField<T>(Rect rect, string label, T value, Type type, bool allowSceneObjects) where T: Object
		{
			return ObjectFieldMaster(rect, new GUICon(label), value, type, allowSceneObjects);
		}

		public static GUIEvent<T> ObjectField<T>(Rect rect, GUICon guiCon, T value, Type type, bool allowSceneObjects) where T: Object
		{
			return ObjectFieldMaster(rect, guiCon, value, type, allowSceneObjects);
		}

		private static GUIEvent<T> ObjectFieldMaster<T>(Rect rect, GUICon guiCon, T value, Type type, bool allowSceneObjects) where T: Object
		{
			var data = new GUIEvent<T> {Event = new Event(Event.current), Rect = rect};
			data.Value = (T)EditorGUI.ObjectField(rect, guiCon, value, type, allowSceneObjects);

			return data;
		}
#endregion

#region HelpBox
		public static GUIEvent ErrorBox(Rect rect, string text)
		{
			return HelpBoxMaster(rect, text, MessageType.Error);
		}

		public static GUIEvent InfoBox(Rect rect, string text)
		{
			return HelpBoxMaster(rect, text, MessageType.Info);
		}

		public static GUIEvent WarningBox(Rect rect, string text)
		{
			return HelpBoxMaster(rect, text, MessageType.Warning);
		}

		public static GUIEvent HelpBox(Rect rect, string text)
		{
			return HelpBoxMaster(rect, text, MessageType.None);
		}

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

		public static eProp PropertyField(Rect pos, SerProp prop)
		{
			return PropFieldMaster(pos, prop, new GUICon(prop.displayName), prop.isExpanded, AttributeCheck.DontCheck, false);
		}

		public static eProp PropertyField(Rect pos, SerProp prop, bool autoLabelField)
		{
			return PropFieldMaster(pos, prop, new GUICon(prop.displayName), true, AttributeCheck.DontCheck, autoLabelField);
		}

		public static eProp PropertyField(Rect pos, SerProp prop, bool includeChildren, bool autoLabelField)
		{
			return PropFieldMaster(pos, prop, new GUICon(prop.displayName), includeChildren, AttributeCheck.DontCheck, autoLabelField);
		}

		public static eProp PropertyField(Rect pos, SerProp prop, AttributeCheck ignoreCheck, bool autoLabelField = false)
		{
			return PropFieldMaster(pos, prop, new GUICon(prop.displayName), true, ignoreCheck, autoLabelField);
		}

		public static eProp PropertyField(Rect pos, SerProp prop, bool includeChildren, AttributeCheck ignoreCheck, bool autoLabelField = false)
		{
			return PropFieldMaster(pos, prop, new GUICon(prop.displayName), includeChildren, ignoreCheck, autoLabelField);
		}

		public static eProp PropertyField(Rect pos, SerProp prop, GUICon cont, bool autoLabelField = false)
		{
			return PropFieldMaster(pos, prop, cont, true, AttributeCheck.DontCheck, autoLabelField);
		}

		public static eProp PropertyField(Rect pos, SerProp prop, GUICon cont, bool includeChildren, bool autoLabelField)
		{
			return PropFieldMaster(pos, prop, cont, includeChildren, AttributeCheck.DontCheck, autoLabelField);
		}

		public static eProp PropertyField(Rect pos, SerProp prop, GUICon cont, bool includeChildren, AttributeCheck ignoreAttributeCheck, bool autoLabelField = false)
		{
			return PropFieldMaster(pos, prop, cont, includeChildren, ignoreAttributeCheck, autoLabelField);
		}

		public static eProp PropertyField(Rect pos, SerProp prop, GUICon cont, AttributeCheck ignoreCheck, bool autoLabelField = false)
		{
			return PropFieldMaster(pos, prop, cont, true, ignoreCheck, autoLabelField);
		}

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

		public static float GetPropertyHeight(SerProp prop)
		{
			return GetPropertyHeightMaster(prop, new GUICon(prop.displayName), true, AttributeCheck.DoCheck);
		}

		public static float GetPropertyHeight(SerProp prop, bool includeChildren)
		{
			return GetPropertyHeightMaster(prop, new GUICon(prop.displayName), includeChildren, AttributeCheck.DoCheck);
		}

		public static float GetPropertyHeight(SerProp prop, GUICon cont, bool includeChildren)
		{
			return GetPropertyHeightMaster(prop, cont, includeChildren, AttributeCheck.DoCheck);
		}

		public static float GetPropertyHeight(SerProp prop, GUICon cont)
		{
			return GetPropertyHeightMaster(prop, cont, true, AttributeCheck.DoCheck);
		}

		public static float GetPropertyHeight(SerProp prop, AttributeCheck ignoreCheck)
		{
			return GetPropertyHeightMaster(prop, new GUICon(prop.displayName), true, ignoreCheck);
		}

		public static float GetPropertyHeight(SerProp prop, bool includeChildren, AttributeCheck ignoreCheck)
		{
			return GetPropertyHeightMaster(prop, new GUICon(prop.displayName), includeChildren, ignoreCheck);
		}

		public static float GetPropertyHeight(SerProp prop, GUICon cont, bool includeChildren, AttributeCheck ignoreCheck)
		{
			return GetPropertyHeightMaster(prop, cont, includeChildren, ignoreCheck);
		}

		public static float GetPropertyHeight(SerProp prop, GUICon cont, AttributeCheck ignoreCheck)
		{
			return GetPropertyHeightMaster(prop, cont, true, ignoreCheck);
		}
#endregion

#region Popup
		public static eInt Popup(Rect pos, int selected, GUICon[] Options)
		{
			var val = EditorGUI.Popup(pos, selected, Options);

			return GUIEvent.Create(pos, val);
		}

		public static eInt Popup(Rect pos, int selected, GUICon[] Options, GUIStyle style)
		{
			var val = EditorGUI.Popup(pos, selected, Options, style);

			return GUIEvent.Create(pos, val);
		}

		public static eInt Popup(Rect pos, string label, int selected, GUICon[] Options)
		{
			var val = EditorGUI.Popup(pos, selected, Options, label);

			return GUIEvent.Create(pos, val);
		}

		public static eInt Popup(Rect pos, string label, int selected, string[] Options, GUIStyle style)
		{
			var val = EditorGUI.Popup(pos, label, selected, Options, style);

			return GUIEvent.Create(pos, val);
		}

		public static eInt Popup(Rect pos, GUICon label, int selected, GUICon[] Options)
		{
			var val = EditorGUI.Popup(pos, label, selected, Options);

			return GUIEvent.Create(pos, val);
		}

		public static eInt Popup(Rect pos, GUICon label, int selected, GUICon[] Options, GUIStyle style)
		{
			var val = EditorGUI.Popup(pos, label, selected, Options, style);

			return GUIEvent.Create(pos, val);
		}
#endregion

#region EnumPopup
		public static GUIEvent<Enum> EnumPopup(Rect pos, Enum selected)
		{
			var val = EditorGUI.EnumPopup(pos, selected);

			return GUIEvent.Create(pos, val);
		}

		public static GUIEvent<Enum> EnumPopup(Rect pos, Enum selected, GUIStyle style)
		{
			var val = EditorGUI.EnumPopup(pos, selected, style);

			return GUIEvent.Create(pos, val);
		}

		public static GUIEvent<Enum> EnumPopup(Rect pos, string label, Enum selected)
		{
			var val = EditorGUI.EnumPopup(pos, label, selected);

			return GUIEvent.Create(pos, val);
		}

		public static GUIEvent<Enum> EnumPopup(Rect pos, string label, Enum selected, GUIStyle style)
		{
			var val = EditorGUI.EnumPopup(pos, label, selected, style);

			return GUIEvent.Create(pos, val);
		}

		public static GUIEvent<Enum> EnumPopup(Rect pos, GUICon label, Enum selected)
		{
			var val = EditorGUI.EnumPopup(pos, label, selected);

			return GUIEvent.Create(pos, val);
		}

		public static GUIEvent<Enum> EnumPopup(Rect pos, GUICon label, Enum selected, GUIStyle style)
		{
			var val = EditorGUI.EnumPopup(pos, label, selected, style);

			return GUIEvent.Create(pos, val);
		}
#endregion

#region ProgressBar
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
#endregion

#region WithMenus
		private const float MENU_BUTTON_SIZE = 16f;

		public static eInt DrawPropertyWithMenu(Rect position, SerProp property, GUICon label, GUICon[] Options, int active, bool autoLabelField = false)
		{
			return DrawDisabledPropertyWithMenu(false, position, property, label, Options, active, autoLabelField);
		}

		public static eInt DrawDisabledPropertyWithMenu(bool disabled, Rect position, SerProp property, GUICon label, GUICon[] Options, int active, bool autoLabelField = false)
		{
			Action<Rect> draw = (rect) =>
			{
				using(FoCsEditor.Disposables.SetIndent(0))
				{
					PropertyField(rect.Edit(RectEdit.SetHeight(GetPropertyHeight(property))), property, GUICon.none, property.hasVisibleChildren, autoLabelField);
				}
			};

			return DrawActionWithMenu(disabled, position, draw, label, Options, active);
		}

		public static eInt DrawActionWithMenu(Rect position, Action<Rect> draw, GUICon label, GUICon[] Options, int active)
		{
			return DrawActionWithMenu(false, position, draw, label, Options, active);
		}

		public static eInt DrawActionWithMenu(bool disabled, Rect position, Action<Rect> draw, GUICon label, GUICon[] Options, int active)
		{
			var propRect  = new Rect(position);
			var labelRect = new Rect(position);
			var menuRect  = new Rect(position);

			labelRect = labelRect.Edit(RectEdit.SetWidth(EditorGUIUtility.labelWidth));

			menuRect.xMin = menuRect.xMax - (MENU_BUTTON_SIZE);
			menuRect.xMax = position.xMax;


			propRect.xMin = labelRect.xMax;
			propRect.xMax = menuRect.xMin - 2;

			Label(labelRect, label);

			using(FoCsEditor.Disposables.DisabledScope(disabled))
				draw.Trigger(propRect);

			using(FoCsEditor.Disposables.SetIndent(0))
			{
				var index = EditorGUI.Popup(menuRect, GUICon.none, active, Options, Styles.InLineOptionsMenu);

				return GUIEvent.Create(position, index);
			}
		}
#endregion

	}
}