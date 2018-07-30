using System;
using UnityEditor;
using UnityEngine;
using GUICon = UnityEngine.GUIContent;
using GUILayOpt = UnityEngine.GUILayoutOption;
using eInt = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<int>;
using eBool = ForestOfChaosLib.Editor.FoCsGUI.GUIEventBool;
using eFloat = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<float>;
using eDouble = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<double>;
using eLong = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<long>;
using eString = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<string>;
using Object = UnityEngine.Object;
using eObject = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<UnityEngine.Object>;
using EGuiLay = UnityEditor.EditorGUILayout;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public static partial class FoCsGUI
	{
		public static class Layout
		{
#region Label
			public static GUIEvent Label(params GUILayOpt[] options)
			{
				return LabelMaster(GUICon.none, LabelStyle, options);
			}

			public static GUIEvent Label(GUIStyle style, params GUILayOpt[] options)
			{
				return LabelMaster(GUICon.none, style, options);
			}

			public static GUIEvent Label(string label, params GUILayOpt[] options)
			{
				return LabelMaster(new GUICon(label), LabelStyle, options);
			}

			public static GUIEvent Label(string label, GUIStyle style, params GUILayOpt[] options)
			{
				return LabelMaster(new GUICon(label), style, options);
			}

			public static GUIEvent Label(GUICon guiCon, params GUILayOpt[] options)
			{
				return LabelMaster(guiCon, LabelStyle, options);
			}

			public static GUIEvent Label(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				return LabelMaster(guiCon, style, options);
			}

			public static GUIEvent Label(Texture texture, params GUILayOpt[] options)
			{
				return LabelMaster(new GUICon(texture), LabelStyle, options);
			}

			public static GUIEvent Label(Texture texture, GUIStyle style, params GUILayOpt[] options)
			{
				return LabelMaster(new GUICon(texture), style, options);
			}

			private static GUIEvent LabelMaster(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				EGuiLay.LabelField(guiCon, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect());
			}
#endregion
#region LabelField
			public static GUIEvent LabelField(params GUILayOpt[] options)
			{
				return LabelFieldMaster(GUICon.none, LabelStyle, options);
			}

			public static GUIEvent LabelField(GUIStyle style, params GUILayOpt[] options)
			{
				return LabelFieldMaster(GUICon.none, style, options);
			}

			public static GUIEvent LabelField(string label, params GUILayOpt[] options)
			{
				return LabelFieldMaster(new GUICon(label), LabelStyle, options);
			}

			public static GUIEvent LabelField(string label, GUIStyle style, params GUILayOpt[] options)
			{
				return LabelFieldMaster(new GUICon(label), style, options);
			}

			public static GUIEvent LabelField(GUICon guiCon, params GUILayOpt[] options)
			{
				return LabelFieldMaster(guiCon, LabelStyle, options);
			}

			public static GUIEvent LabelField(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				return LabelFieldMaster(guiCon, style, options);
			}

			public static GUIEvent LabelField(Texture texture, params GUILayOpt[] options)
			{
				return LabelFieldMaster(new GUICon(texture), LabelStyle, options);
			}

			public static GUIEvent LabelField(Texture texture, GUIStyle style, params GUILayOpt[] options)
			{
				return LabelFieldMaster(new GUICon(texture), style, options);
			}

			private static GUIEvent LabelFieldMaster(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				EGuiLay.LabelField(guiCon, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect());
			}
#endregion
#region Button
			public static eBool Button(params GUILayOpt[] options)
			{
				return ButtonMaster(GUICon.none, ButtonStyle, options);
			}

			public static eBool Button(GUIStyle style, params GUILayOpt[] options)
			{
				return ButtonMaster(GUICon.none, style, options);
			}

			public static eBool Button(string label, params GUILayOpt[] options)
			{
				return ButtonMaster(new GUICon(label), ButtonStyle, options);
			}

			public static eBool Button(string label, GUIStyle style, params GUILayOpt[] options)
			{
				return ButtonMaster(new GUICon(label), style, options);
			}

			public static eBool Button(GUICon guiCon, params GUILayOpt[] options)
			{
				return ButtonMaster(guiCon, ButtonStyle, options);
			}

			public static eBool Button(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				return ButtonMaster(guiCon, style, options);
			}

			public static eBool Button(Texture texture, params GUILayOpt[] options)
			{
				return ButtonMaster(new GUICon(texture), ButtonStyle, options);
			}

			public static eBool Button(Texture texture, GUIStyle style, params GUILayOpt[] options)
			{
				return ButtonMaster(new GUICon(texture), style, options);
			}

			private static eBool ButtonMaster(GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				var b = GUILayout.Button(guiCon, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), b);
			}
#endregion
#region Toggle
			public static eBool Toggle(bool toggle, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, GUICon.none, ToggleStyle, options);
			}

			public static eBool Toggle(bool toggle, GUIStyle style, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, GUICon.none, style, options);
			}

			public static eBool Toggle(string label, bool toggle, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, new GUICon(label), ToggleStyle, options);
			}

			public static eBool Toggle(string label, bool toggle, GUIStyle style, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, new GUICon(label), style, options);
			}

			public static eBool Toggle(GUICon guiCon, bool toggle, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, guiCon, ToggleStyle, options);
			}

			public static eBool Toggle(GUICon guiCon, bool toggle, GUIStyle style, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, guiCon, style, options);
			}

			public static eBool Toggle(Texture texture, bool toggle, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, new GUICon(texture), ToggleStyle, options);
			}

			public static eBool Toggle(Texture texture, bool toggle, GUIStyle style, params GUILayOpt[] options)
			{
				return ToggleMaster(toggle, new GUICon(texture), style, options);
			}

			private static eBool ToggleMaster(bool toggle, GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				var val = GUILayout.Toggle(toggle, guiCon, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region ToggleField
			public static eBool ToggleField(bool toggle, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, GUICon.none, ToggleStyle, options);
			}

			public static eBool ToggleField(bool toggle, GUIStyle style, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, GUICon.none, style, options);
			}

			public static eBool ToggleField(string label, bool toggle, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, new GUICon(label), ToggleStyle, options);
			}

			public static eBool ToggleField(string label, bool toggle, GUIStyle style, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, new GUICon(label), style, options);
			}

			public static eBool ToggleField(GUICon guiCon, bool toggle, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, guiCon, ToggleStyle, options);
			}

			public static eBool ToggleField(GUICon guiCon, bool toggle, GUIStyle style, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, guiCon, style, options);
			}

			public static eBool ToggleField(Texture texture, bool toggle, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, new GUICon(texture), ToggleStyle, options);
			}

			public static eBool ToggleField(Texture texture, bool toggle, GUIStyle style, params GUILayOpt[] options)
			{
				return ToggleFieldMaster(toggle, new GUICon(texture), style, options);
			}

			private static eBool ToggleFieldMaster(bool toggle, GUICon guiCon, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.Toggle(guiCon, toggle, style, options);

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

			public static eBool Foldout(bool foldout, bool toggleOnLabelClick)
			{
				return FoldoutMaster(foldout, GUICon.none, FoldoutStyle, toggleOnLabelClick);
			}

			public static eBool Foldout(bool foldout, GUIStyle style, bool toggleOnLabelClick)
			{
				return FoldoutMaster(foldout, GUICon.none, style, toggleOnLabelClick);
			}

			public static eBool Foldout(bool foldout, string label)
			{
				return FoldoutMaster(foldout, new GUICon(label), FoldoutStyle);
			}

			public static eBool Foldout(bool foldout, string label, GUIStyle style)
			{
				return FoldoutMaster(foldout, new GUICon(label), style);
			}

			public static eBool Foldout(bool foldout, string label, bool toggleOnLabelClick)
			{
				return FoldoutMaster(foldout, new GUICon(label), FoldoutStyle, toggleOnLabelClick);
			}

			public static eBool Foldout(bool foldout, string label, GUIStyle style, bool toggleOnLabelClick)
			{
				return FoldoutMaster(foldout, new GUICon(label), style, toggleOnLabelClick);
			}

			public static eBool Foldout(bool foldout, GUICon guiCon)
			{
				return FoldoutMaster(foldout, guiCon, FoldoutStyle);
			}

			public static eBool Foldout(bool foldout, GUICon guiCon, GUIStyle style)
			{
				return FoldoutMaster(foldout, guiCon, style);
			}

			public static eBool Foldout(bool foldout, GUICon guiCon, bool toggleOnLabelClick)
			{
				return FoldoutMaster(foldout, guiCon, FoldoutStyle, toggleOnLabelClick);
			}

			public static eBool Foldout(bool foldout, GUICon guiCon, GUIStyle style, bool toggleOnLabelClick)
			{
				return FoldoutMaster(foldout, guiCon, style, toggleOnLabelClick);
			}

			private static eBool FoldoutMaster(bool foldout, GUICon guiCon, GUIStyle style, bool toggleOnLabelClick = true)
			{
				var val = EGuiLay.Foldout(foldout, guiCon, toggleOnLabelClick, style);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region IntField
			public static eInt IntField(int value, params GUILayOpt[] options)
			{
				return IntFieldMaster(value, NumberFieldStyle, options);
			}

			public static eInt IntField(int value, GUIStyle style, params GUILayOpt[] options)
			{
				return IntFieldMaster(value, style, options);
			}

			public static eInt IntField(string label, int value, params GUILayOpt[] options)
			{
				return IntFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eInt IntField(string label, int value, GUIStyle style, params GUILayOpt[] options)
			{
				return IntFieldMaster(new GUICon(label), value, style, options);
			}

			public static eInt IntField(GUICon guiCon, int value, params GUILayOpt[] options)
			{
				return IntFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eInt IntField(GUICon guiCon, int value, GUIStyle style, params GUILayOpt[] options)
			{
				return IntFieldMaster(guiCon, value, style, options);
			}

			private static eInt IntFieldMaster(int value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.IntField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eInt IntFieldMaster(GUICon guiCon, int value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.IntField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region DelayedIntField
			public static eInt DelayedIntField(int value, params GUILayOpt[] options)
			{
				return DelayedIntFieldMaster(value, NumberFieldStyle, options);
			}

			public static eInt DelayedIntField(int value, GUIStyle style, params GUILayOpt[] options)
			{
				return DelayedIntFieldMaster(value, style, options);
			}

			public static eInt DelayedIntField(string label, int value, params GUILayOpt[] options)
			{
				return DelayedIntFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eInt DelayedIntField(string label, int value, GUIStyle style, params GUILayOpt[] options)
			{
				return IntFieldMaster(new GUICon(label), value, style, options);
			}

			public static eInt DelayedIntField(GUICon guiCon, int value, params GUILayOpt[] options)
			{
				return DelayedIntFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eInt DelayedIntField(GUICon guiCon, int value, GUIStyle style, params GUILayOpt[] options)
			{
				return DelayedIntFieldMaster(guiCon, value, style, options);
			}

			private static eInt DelayedIntFieldMaster(int value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.DelayedIntField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eInt DelayedIntFieldMaster(GUICon guiCon, int value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.DelayedIntField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region FloatField
			public static eFloat FloatField(float value, params GUILayOpt[] options)
			{
				return FloatFieldMaster(value, NumberFieldStyle, options);
			}

			public static eFloat FloatField(float value, GUIStyle style, params GUILayOpt[] options)
			{
				return FloatFieldMaster(value, style, options);
			}

			public static eFloat FloatField(string label, float value, params GUILayOpt[] options)
			{
				return FloatFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eFloat FloatField(string label, float value, GUIStyle style, params GUILayOpt[] options)
			{
				return FloatFieldMaster(new GUICon(label), value, style, options);
			}

			public static eFloat FloatField(GUICon guiCon, float value, params GUILayOpt[] options)
			{
				return FloatFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eFloat FloatField(GUICon guiCon, float value, GUIStyle style, params GUILayOpt[] options)
			{
				return FloatFieldMaster(guiCon, value, style, options);
			}

			private static eFloat FloatFieldMaster(float value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.FloatField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eFloat FloatFieldMaster(GUICon guiCon, float value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.FloatField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region DelayedFloatField
			public static eFloat DelayedFloatField(float value, params GUILayOpt[] options)
			{
				return DelayedFloatFieldMaster(value, NumberFieldStyle, options);
			}

			public static eFloat DelayedFloatField(float value, GUIStyle style, params GUILayOpt[] options)
			{
				return DelayedFloatFieldMaster(value, style, options);
			}

			public static eFloat DelayedFloatField(string label, float value, params GUILayOpt[] options)
			{
				return DelayedFloatFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eFloat DelayedFloatField(string label, float value, GUIStyle style, params GUILayOpt[] options)
			{
				return DelayedFloatFieldMaster(new GUICon(label), value, style, options);
			}

			public static eFloat DelayedFloatField(GUICon guiCon, float value, params GUILayOpt[] options)
			{
				return DelayedFloatFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eFloat DelayedFloatField(GUICon guiCon, float value, GUIStyle style, params GUILayOpt[] options)
			{
				return DelayedFloatFieldMaster(guiCon, value, style, options);
			}

			private static eFloat DelayedFloatFieldMaster(float value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.DelayedFloatField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eFloat DelayedFloatFieldMaster(GUICon guiCon, float value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.DelayedFloatField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region DoubleField
			public static eDouble DoubleField(double value, params GUILayOpt[] options)
			{
				return DoubleFieldMaster(value, NumberFieldStyle, options);
			}

			public static eDouble DoubleField(double value, GUIStyle style, params GUILayOpt[] options)
			{
				return DoubleFieldMaster(value, style, options);
			}

			public static eDouble DoubleField(string label, double value, params GUILayOpt[] options)
			{
				return DoubleFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eDouble DoubleField(string label, double value, GUIStyle style, params GUILayOpt[] options)
			{
				return DoubleFieldMaster(new GUICon(label), value, style, options);
			}

			public static eDouble DoubleField(GUICon guiCon, double value, params GUILayOpt[] options)
			{
				return DoubleFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eDouble DoubleField(GUICon guiCon, double value, GUIStyle style, params GUILayOpt[] options)
			{
				return DoubleFieldMaster(guiCon, value, style, options);
			}

			private static eDouble DoubleFieldMaster(double value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.DoubleField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eDouble DoubleFieldMaster(GUICon guiCon, double value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.DoubleField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region DelayedDoubleField
			public static eDouble DelayedDoubleField(double value, params GUILayOpt[] options)
			{
				return DelayedDoubleFieldMaster(value, NumberFieldStyle, options);
			}

			public static eDouble DelayedDoubleField(double value, GUIStyle style, params GUILayOpt[] options)
			{
				return DelayedDoubleFieldMaster(value, style, options);
			}

			public static eDouble DelayedDoubleField(string label, double value, params GUILayOpt[] options)
			{
				return DelayedDoubleFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eDouble DelayedDoubleField(string label, double value, GUIStyle style, params GUILayOpt[] options)
			{
				return DelayedDoubleFieldMaster(new GUICon(label), value, style, options);
			}

			public static eDouble DelayedDoubleField(GUICon guiCon, double value, params GUILayOpt[] options)
			{
				return DelayedDoubleFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eDouble DelayedDoubleField(GUICon guiCon, double value, GUIStyle style, params GUILayOpt[] options)
			{
				return DelayedDoubleFieldMaster(guiCon, value, style, options);
			}

			private static eDouble DelayedDoubleFieldMaster(double value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.DelayedDoubleField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eDouble DelayedDoubleFieldMaster(GUICon guiCon, double value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.DelayedDoubleField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region LongField
			public static eLong LongField(long value, params GUILayOpt[] options)
			{
				return LongFieldMaster(value, NumberFieldStyle, options);
			}

			public static eLong LongField(long value, GUIStyle style, params GUILayOpt[] options)
			{
				return LongFieldMaster(value, style, options);
			}

			public static eLong LongField(string label, long value, params GUILayOpt[] options)
			{
				return LongFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eLong LongField(string label, long value, GUIStyle style, params GUILayOpt[] options)
			{
				return LongFieldMaster(new GUICon(label), value, style, options);
			}

			public static eLong LongField(GUICon guiCon, long value, params GUILayOpt[] options)
			{
				return LongFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eLong LongField(GUICon guiCon, long value, GUIStyle style, params GUILayOpt[] options)
			{
				return LongFieldMaster(guiCon, value, style, options);
			}

			private static eLong LongFieldMaster(long value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.LongField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eLong LongFieldMaster(GUICon guiCon, long value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.LongField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region TextField
			public static eString TextField(string value, params GUILayOpt[] options)
			{
				return TextFieldMaster(GUICon.none, value, NumberFieldStyle, options);
			}

			public static eString TextField(string value, GUIStyle style, params GUILayOpt[] options)
			{
				return TextFieldMaster(GUICon.none, value, style, options);
			}

			public static eString TextField(string label, string value, params GUILayOpt[] options)
			{
				return TextFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eString TextField(string label, string value, GUIStyle style, params GUILayOpt[] options)
			{
				return TextFieldMaster(new GUICon(label), value, style, options);
			}

			public static eString TextField(GUICon guiCon, string value, params GUILayOpt[] options)
			{
				return TextFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eString TextField(GUICon guiCon, string value, GUIStyle style, params GUILayOpt[] options)
			{
				return TextFieldMaster(guiCon, value, style, options);
			}

			private static eString TextFieldMaster(string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.TextField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eString TextFieldMaster(GUICon guiCon, string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.TextField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region DelayedTextField
			public static eString DelayedTextField(string value, params GUILayOpt[] options)
			{
				return DelayedTextFieldMaster(GUICon.none, value, NumberFieldStyle, options);
			}

			public static eString DelayedTextField(string value, GUIStyle style, params GUILayOpt[] options)
			{
				return DelayedTextFieldMaster(GUICon.none, value, style, options);
			}

			public static eString DelayedTextField(string label, string value, params GUILayOpt[] options)
			{
				return DelayedTextFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			}

			public static eString DelayedTextField(string label, string value, GUIStyle style, params GUILayOpt[] options)
			{
				return TextFieldMaster(new GUICon(label), value, style, options);
			}

			public static eString DelayedTextField(GUICon guiCon, string value, params GUILayOpt[] options)
			{
				return DelayedTextFieldMaster(guiCon, value, NumberFieldStyle, options);
			}

			public static eString DelayedTextField(GUICon guiCon, string value, GUIStyle style, params GUILayOpt[] options)
			{
				return DelayedTextFieldMaster(guiCon, value, style, options);
			}

			private static eString DelayedTextFieldMaster(string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.DelayedTextField(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eString DelayedTextFieldMaster(GUICon guiCon, string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.DelayedTextField(guiCon, value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region TextArea
			public static eString TextArea(string value, params GUILayOpt[] options)
			{
				return TextAreaMaster(value, NumberFieldStyle, options);
			}

			public static eString TextArea(string value, GUIStyle style, params GUILayOpt[] options)
			{
				return TextAreaMaster(value, style, options);
			}

			private static eString TextAreaMaster(string value, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.TextArea(value, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region RawObjectField
			public static eObject RawObjectField(Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options)
			{
				return RawObjectFieldMaster(value, type, allowSceneObjects, options);
			}

			public static eObject RawObjectField(string guiCon, Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options)
			{
				return RawObjectFieldMaster(new GUICon(guiCon), value, type, allowSceneObjects, options);
			}

			public static eObject RawObjectField(GUICon guiCon, Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options)
			{
				return RawObjectFieldMaster(guiCon, value, type, allowSceneObjects, options);
			}

			private static eObject RawObjectFieldMaster(Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options)
			{
				var val = EGuiLay.ObjectField(value, type, allowSceneObjects, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eObject RawObjectFieldMaster(GUICon guiCon, Object value, Type type, bool allowSceneObjects, params GUILayOpt[] options)
			{
				var val = EGuiLay.ObjectField(guiCon, value, type, allowSceneObjects, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region ObjectFieldGeneric
			public static GUIEvent<T> ObjectField<T>(T value, bool allowSceneObjects, params GUILayOpt[] options) where T: Object
			{
				return ObjectFieldMaster(value, allowSceneObjects, options);
			}

			public static GUIEvent<T> ObjectField<T>(T value, string guiCon, bool allowSceneObjects, params GUILayOpt[] options) where T: Object
			{
				return ObjectFieldMaster(new GUICon(guiCon), value, allowSceneObjects, options);
			}

			public static GUIEvent<T> ObjectField<T>(T value, GUICon guiCon, bool allowSceneObjects, params GUILayOpt[] options) where T: Object
			{
				return ObjectFieldMaster(guiCon, value, allowSceneObjects, options);
			}

			private static GUIEvent<T> ObjectFieldMaster<T>(T value, bool allowSceneObjects, params GUILayOpt[] options) where T: Object
			{
				var val = (T)EGuiLay.ObjectField(value, typeof(T), allowSceneObjects, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static GUIEvent<T> ObjectFieldMaster<T>(GUICon guiCon, T value, bool allowSceneObjects, params GUILayOpt[] options) where T: Object
			{
				var val = (T)EGuiLay.ObjectField(guiCon, value, typeof(T), allowSceneObjects, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region HelpBox
			public static GUIEvent ErrorBox(string text)
			{
				return FoCsGUI.ErrorBox(GUILayoutUtility.GetRect(0, SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			}

			public static GUIEvent InfoBox(string text)
			{
				return FoCsGUI.InfoBox(GUILayoutUtility.GetRect(0, SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			}

			public static GUIEvent WarningBox(string text)
			{
				return FoCsGUI.WarningBox(GUILayoutUtility.GetRect(0, SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			}

			public static GUIEvent HelpBox(string text)
			{
				return FoCsGUI.HelpBox(GUILayoutUtility.GetRect(0, SingleLine * 2.5f, Styles.Unity.HelpBox, null), text);
			}
#endregion
#region PropertyField
			public static eBool PropertyField(SerializedProperty property, bool includeChildren, params GUILayOpt[] options)
			{
				return PropertyFieldMaster(property, includeChildren, options);
			}

			public static eBool PropertyField(string label, SerializedProperty property, bool includeChildren, params GUILayOpt[] options)
			{
				return PropertyFieldMaster(new GUICon(label), property, includeChildren, options);
			}

			public static eBool PropertyField(GUICon label, SerializedProperty property, bool includeChildren, params GUILayOpt[] options)
			{
				return PropertyFieldMaster(label, property, includeChildren, options);
			}

			private static eBool PropertyFieldMaster(SerializedProperty property, bool includeChildren, params GUILayOpt[] options)
			{
				var val = EGuiLay.PropertyField(property, includeChildren, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			private static eBool PropertyFieldMaster(GUICon label, SerializedProperty property, bool includeChildren, params GUILayOpt[] options)
			{
				var val = EGuiLay.PropertyField(property, label, includeChildren, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region GetControlRect
			public static Rect GetControlRect(params GUILayOpt[] options)
			{
				return EGuiLay.GetControlRect(options);
			}

			public static Rect GetControlRect(bool hasLabel, params GUILayOpt[] options)
			{
				return EGuiLay.GetControlRect(hasLabel, options);
			}

			public static Rect GetControlRect(bool hasLabel, float height, params GUILayOpt[] options)
			{
				return EGuiLay.GetControlRect(hasLabel, height, options);
			}

			public static Rect GetControlRect(bool hasLabel, float height, GUIStyle style, params GUILayOpt[] options)
			{
				return EGuiLay.GetControlRect(hasLabel, height, style, options);
			}
#endregion
#region SelectableLabel
			public static GUIEvent SelectableLabel(string text, params GUILayOpt[] options)
			{
				EGuiLay.SelectableLabel(text, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect());
			}

			public static GUIEvent SelectableLabel(string text, GUIStyle style, params GUILayOpt[] options)
			{
				EGuiLay.SelectableLabel(text, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect());
			}
#endregion
#region PasswordField
			public static eString PasswordField(string password, params GUILayOpt[] options)
			{
				return PasswordFieldMaster(password, options);
			}

			public static eString PasswordField(string password, GUIStyle style, params GUILayOpt[] options)
			{
				return PasswordFieldMaster(password, style, options);
			}

			public static eString PasswordField(string label, string password, params GUILayOpt[] options)
			{
				return PasswordFieldMaster(new GUICon(label), password, options);
			}

			public static eString PasswordField(string label, string password, GUIStyle style, params GUILayOpt[] options)
			{
				return PasswordFieldMaster(new GUICon(label), password, style, options);
			}

			public static eString PasswordField(GUICon label, string password, params GUILayOpt[] options)
			{
				return PasswordFieldMaster(label, password, options);
			}

			public static eString PasswordField(GUICon label, string password, GUIStyle style, params GUILayOpt[] options)
			{
				return PasswordFieldMaster(label, password, style, options);
			}

			public static eString PasswordFieldMaster(GUICon label, string password, params GUILayOpt[] options)
			{
				return PasswordFieldMaster(label, password, Styles.Unity.TextField_Editor, options);
			}

			public static eString PasswordFieldMaster(string password, params GUILayOpt[] options)
			{
				return PasswordFieldMaster(GUICon.none, password, Styles.Unity.TextField_Editor, options);
			}

			public static eString PasswordFieldMaster(string password, GUIStyle style, params GUILayOpt[] options)
			{
				return PasswordFieldMaster(GUICon.none, password, style, options);
			}

			public static eString PasswordFieldMaster(GUICon label, string password, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.PasswordField(label, password, style, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}
#endregion
#region Slider
			public static eFloat Slider(float value, float leftValue, float rightValue, params GUILayOpt[] options)
			{
				var val = EGuiLay.Slider(value, leftValue, rightValue, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			public static eFloat Slider(string label, float value, float leftValue, float rightValue, params GUILayOpt[] options)
			{
				var val = EGuiLay.Slider(value, leftValue, rightValue, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			public static eFloat Slider(GUICon label, float value, float leftValue, float rightValue, params GUILayOpt[] options)
			{
				var val = EGuiLay.Slider(value, leftValue, rightValue, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			public static GUIEvent Slider(SerializedProperty property, float leftValue, float rightValue, params GUILayOpt[] options)
			{
				EGuiLay.Slider(property, leftValue, rightValue, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect());
			}
#endregion
#region IntSlider
			public static eInt Slider(int value, int leftValue, int rightValue, params GUILayOpt[] options)
			{
				var val = EGuiLay.IntSlider(value, leftValue, rightValue, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			public static eInt Slider(string label, int value, int leftValue, int rightValue, params GUILayOpt[] options)
			{
				var val = EGuiLay.IntSlider(value, leftValue, rightValue, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			public static eInt Slider(GUICon label, int value, int leftValue, int rightValue, params GUILayOpt[] options)
			{
				var val = EGuiLay.IntSlider(value, leftValue, rightValue, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect(), val);
			}

			public static GUIEvent IntSlider(SerializedProperty property, int leftValue, int rightValue, params GUILayOpt[] options)
			{
				EGuiLay.Slider(property, leftValue, rightValue, options);

				return GUIEvent.Create(GUILayoutUtility.GetLastRect());
			}
#endregion
#region Popup
			public static eInt Popup(int selectedIndex, string[] displayedOptions, params GUILayOpt[] options)
			{
				var val = EGuiLay.Popup(selectedIndex, displayedOptions, options);

				return GUIEvent.Create(val);
			}

			public static eInt Popup(int selectedIndex, string[] displayedOptions, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.Popup(selectedIndex, displayedOptions, style, options);

				return GUIEvent.Create(val);
			}

			public static eInt Popup(int selectedIndex, GUICon[] displayedOptions, params GUILayOpt[] options)
			{
				var val = EGuiLay.Popup(selectedIndex, displayedOptions, options);

				return GUIEvent.Create(val);
			}

			public static eInt Popup(int selectedIndex, GUICon[] displayedOptions, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.Popup(selectedIndex, displayedOptions, style, options);

				return GUIEvent.Create(val);
			}

			public static eInt Popup(string label, int selectedIndex, string[] displayedOptions, params GUILayOpt[] options)
			{
				var val = EGuiLay.Popup(label, selectedIndex, displayedOptions, options);

				return GUIEvent.Create(val);
			}

			public static eInt Popup(string label, int selectedIndex, string[] displayedOptions, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.Popup(label, selectedIndex, displayedOptions, style, options);

				return GUIEvent.Create(val);
			}

			public static eInt Popup(GUICon label, int selectedIndex, GUICon[] displayedOptions, params GUILayOpt[] options)
			{
				var val = EGuiLay.Popup(label, selectedIndex, displayedOptions, options);

				return GUIEvent.Create(val);
			}

			public static eInt Popup(GUICon label, int selectedIndex, GUICon[] displayedOptions, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.Popup(label, selectedIndex, displayedOptions, style, options);

				return GUIEvent.Create(val);
			}
#endregion
#region EnumPopup
			public static GUIEvent<Enum> EnumPopup(Enum selected, params GUILayOpt[] options)
			{
				var val = EGuiLay.EnumPopup(selected, options);

				return GUIEvent.Create(val);
			}

			public static GUIEvent<Enum> EnumPopup(Enum selected, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.EnumPopup(selected, style, options);

				return GUIEvent.Create(val);
			}

			public static GUIEvent<Enum> EnumPopup(string label, Enum selected, params GUILayOpt[] options)
			{
				var val = EGuiLay.EnumPopup(label, selected, options);

				return GUIEvent.Create(val);
			}

			public static GUIEvent<Enum> EnumPopup(string label, Enum selected, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.EnumPopup(label, selected, style, options);

				return GUIEvent.Create(val);
			}

			public static GUIEvent<Enum> EnumPopup(GUICon label, Enum selected, params GUILayOpt[] options)
			{
				var val = EGuiLay.EnumPopup(label, selected, options);

				return GUIEvent.Create(val);
			}

			public static GUIEvent<Enum> EnumPopup(GUICon label, Enum selected, GUIStyle style, params GUILayOpt[] options)
			{
				var val = EGuiLay.EnumPopup(label, selected, style, options);

				return GUIEvent.Create(val);
			}
#endregion
#region Other
			public static GUIEvent ProgressBar(float fillAmount, string label = "", params GUILayOpt[] options)
			{
				var data = new GUIEvent {Event = new Event(Event.current), Rect = GetControlRect(options)};
				EditorGUI.ProgressBar(data.Rect, fillAmount, label);

				return data;
			}

			public static GUIEvent ProgressBarSplit(float fillAmount, string label = "", bool isPositiveLeft = true, params GUILayOpt[] options)
			{
				var data = new GUIEvent {Event = new Event(Event.current), Rect = GetControlRect(options)};
				FoCsGUI.ProgressBarSplit(data.Rect, fillAmount, label, isPositiveLeft);

				return data;
			}
#endregion
		}
	}
}
