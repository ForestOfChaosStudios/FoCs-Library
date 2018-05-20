using UnityEngine;
using GUICon = UnityEngine.GUIContent;
using GUILayOpt = UnityEngine.GUILayoutOption;
using eInt = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<int>;
using eBool = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<bool>;
using eFloat = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<float>;
using eString = ForestOfChaosLib.Editor.FoCsGUI.GUIEvent<string>;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public static partial class FoCsGUI
	{
		public static  class Layout
		{
			#region Label
			private static GUIEvent LabelMaster(GUICon guiCon, GUIStyle style) => LabelMaster(guiCon, style, Utilities.SingleLine);
			private static GUIEvent LabelMaster(GUICon guiCon, GUIStyle style, params GUILayOpt[] options) =>LabelMaster(guiCon, style, Utilities.SingleLine, options);
			private static GUIEvent LabelMaster(GUICon guiCon, GUIStyle style, float height) => LabelMaster(guiCon, style, height, null);
			private static GUIEvent LabelMaster(GUICon guiCon, GUIStyle style, float height, params GUILayOpt[] options)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, options);
				return FoCsGUI.Label(rect, guiCon, style);
			}

			#region NoLabel
			public static GUIEvent Label() => LabelMaster(GUICon.none, LabelStyle);
			public static GUIEvent Label(float height) => LabelMaster(GUICon.none, LabelStyle, height);

			public static GUIEvent Label(GUIStyle style) => LabelMaster(GUICon.none, style);
			public static GUIEvent Label(GUIStyle style, float height) => LabelMaster(GUICon.none, style, height);

			public static GUIEvent Label(params GUILayOpt[] options) => LabelMaster(GUICon.none, LabelStyle, options);
			public static GUIEvent Label(float height, params GUILayOpt[] options) => LabelMaster(GUICon.none, LabelStyle, height, options);

			public static GUIEvent Label(GUIStyle style, params GUILayOpt[] options) => LabelMaster(GUICon.none, style, options);
			public static GUIEvent Label(GUIStyle style, float height, params GUILayOpt[] options) => LabelMaster(GUICon.none, style, height, options);
			#endregion

			#region StringLabel
			public static GUIEvent Label(string label) => LabelMaster(new GUICon(label), LabelStyle);
			public static GUIEvent Label(string label, float height) => LabelMaster(new GUICon(label), LabelStyle, height);

			public static GUIEvent Label(string label, GUIStyle style) => LabelMaster(new GUICon(label), style);
			public static GUIEvent Label(string label, GUIStyle style, float height) => LabelMaster(new GUICon(label), style, height);

			public static GUIEvent Label(string label, params GUILayOpt[] options) => LabelMaster(new GUICon(label), LabelStyle, options);

			public static GUIEvent Label(string label, float height, params GUILayOpt[] options) =>
					LabelMaster(new GUICon(label), LabelStyle, height, options);

			public static GUIEvent Label(string label, GUIStyle style, params GUILayOpt[] options) => LabelMaster(new GUICon(label), style, options);

			public static GUIEvent Label(string label, GUIStyle style, float height, params GUILayOpt[] options) =>
					LabelMaster(new GUICon(label), style, height, options);
			#endregion

			#region GUIConLabel
			public static GUIEvent Label(GUICon guiCon) => LabelMaster(guiCon, LabelStyle);
			public static GUIEvent Label(GUICon guiCon, float height) => LabelMaster(guiCon, LabelStyle, height);

			public static GUIEvent Label(GUICon guiCon, GUIStyle style) => LabelMaster(guiCon, style);
			public static GUIEvent Label(GUICon guiCon, GUIStyle style, float height) => LabelMaster(guiCon, style, height);

			public static GUIEvent Label(GUICon guiCon, params GUILayOpt[] options) => LabelMaster(guiCon, LabelStyle, options);

			public static GUIEvent Label(GUICon guiCon, float height, params GUILayOpt[] options) => LabelMaster(guiCon, LabelStyle, height, options);

			public static GUIEvent Label(GUICon guiCon, GUIStyle style, params GUILayOpt[] options) => LabelMaster(guiCon, style, options);

			public static GUIEvent Label(GUICon guiCon, GUIStyle style, float height, params GUILayOpt[] options) =>
					LabelMaster(guiCon, style, height, options);
			#endregion

			#region Texture
			public static GUIEvent Label(Texture texture) => LabelMaster(new GUICon(texture), LabelStyle);
			public static GUIEvent Label(Texture texture, float height) => LabelMaster(new GUICon(texture), LabelStyle, height);

			public static GUIEvent Label(Texture texture, GUIStyle style) => LabelMaster(new GUICon(texture), style);
			public static GUIEvent Label(Texture texture, GUIStyle style, float height) => LabelMaster(new GUICon(texture), style, height);

			public static GUIEvent Label(Texture texture, params GUILayOpt[] options) => LabelMaster(new GUICon(texture), LabelStyle, options);

			public static GUIEvent Label(Texture texture, float height, params GUILayOpt[] options) =>
					LabelMaster(new GUICon(texture), LabelStyle, height, options);

			public static GUIEvent Label(Texture texture, GUIStyle style, params GUILayOpt[] options) => LabelMaster(new GUICon(texture), style, options);

			public static GUIEvent Label(Texture texture, GUIStyle style, float height, params GUILayOpt[] options) =>
					LabelMaster(new GUICon(texture), style, height, options);
			#endregion
			#endregion

			#region Button
			private static eBool ButtonMaster(GUICon guiCon, GUIStyle style) => ButtonMaster(guiCon, style, Utilities.SingleLine);
			private static eBool ButtonMaster(GUICon guiCon, GUIStyle style, params GUILayOpt[] options) => ButtonMaster(guiCon, style, Utilities.SingleLine, options);
			private static eBool ButtonMaster(GUICon guiCon, GUIStyle style, float height) => ButtonMaster(guiCon, style, height, null);
			private static eBool ButtonMaster(GUICon guiCon, GUIStyle style, float height, params GUILayOpt[] options)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, options);
				return FoCsGUI.Button(rect, guiCon, style);
			}

			#region NoLabel
			public static eBool Button() => ButtonMaster(GUICon.none, ButtonStyle);
			public static eBool Button(float height) => ButtonMaster(GUICon.none, ButtonStyle, height);
			public static eBool Button(GUIStyle style) => ButtonMaster(GUICon.none, style);
			public static eBool Button(GUIStyle style, float height) => ButtonMaster(GUICon.none, style, height);
			public static eBool Button(params GUILayOpt[] options) => ButtonMaster(GUICon.none, ButtonStyle, options);
			public static eBool Button(float height, params GUILayOpt[] options) => ButtonMaster(GUICon.none, ButtonStyle, height, options);
			public static eBool Button(GUIStyle style, params GUILayOpt[] options) => ButtonMaster(GUICon.none, style, options);
			public static eBool Button(GUIStyle style, float height, params GUILayOpt[] options) => ButtonMaster(GUICon.none, style, height, options);
			#endregion

			#region StringLabel
			public static eBool Button(string label) => ButtonMaster(new GUICon(label), ButtonStyle);
			public static eBool Button(string label, float height) => ButtonMaster(new GUICon(label), ButtonStyle, height);
			public static eBool Button(string label, GUIStyle style) => ButtonMaster(new GUICon(label), style);
			public static eBool Button(string label, GUIStyle style, float height) => ButtonMaster(new GUICon(label), style, height);
			public static eBool Button(string label, params GUILayOpt[] options) => ButtonMaster(new GUICon(label), ButtonStyle, options);
			public static eBool Button(string label, float height, params GUILayOpt[] options) => ButtonMaster(new GUICon(label), ButtonStyle, height, options);
			public static eBool Button(string label, GUIStyle style, params GUILayOpt[] options) => ButtonMaster(new GUICon(label), style, options);
			public static eBool Button(string label, GUIStyle style, float height, params GUILayOpt[] options) => ButtonMaster(new GUICon(label), style, height, options);
			#endregion

			#region GUIConLabel
			public static eBool Button(GUICon guiCon) => ButtonMaster(guiCon, ButtonStyle);
			public static eBool Button(GUICon guiCon, float height) => ButtonMaster(guiCon, ButtonStyle, height);
			public static eBool Button(GUICon guiCon, GUIStyle style) => ButtonMaster(guiCon, style);
			public static eBool Button(GUICon guiCon, GUIStyle style, float height) => ButtonMaster(guiCon, style, height);
			public static eBool Button(GUICon guiCon, params GUILayOpt[] options) => ButtonMaster(guiCon, ButtonStyle, options);
			public static eBool Button(GUICon guiCon, float height, params GUILayOpt[] options) => ButtonMaster(guiCon, ButtonStyle, height, options);
			public static eBool Button(GUICon guiCon, GUIStyle style, params GUILayOpt[] options) => ButtonMaster(guiCon, style, options);
			public static eBool Button(GUICon guiCon, GUIStyle style, float height, params GUILayOpt[] options) => ButtonMaster(guiCon, style, height, options);
			#endregion

			#region Texture
			public static eBool Button(Texture texture) => ButtonMaster(new GUICon(texture), ButtonStyle);
			public static eBool Button(Texture texture, float height) => ButtonMaster(new GUICon(texture), ButtonStyle, height);
			public static eBool Button(Texture texture, GUIStyle style) => ButtonMaster(new GUICon(texture), style);
			public static eBool Button(Texture texture, GUIStyle style, float height) => ButtonMaster(new GUICon(texture), style, height);
			public static eBool Button(Texture texture, params GUILayOpt[] options) => ButtonMaster(new GUICon(texture), ButtonStyle, options);
			public static eBool Button(Texture texture, float height, params GUILayOpt[] options) => ButtonMaster(new GUICon(texture), ButtonStyle, height, options);
			public static eBool Button(Texture texture, GUIStyle style, params GUILayOpt[] options) => ButtonMaster(new GUICon(texture), style, options);
			public static eBool Button(Texture texture, GUIStyle style, float height, params GUILayOpt[] options) => ButtonMaster(new GUICon(texture), style, height, options);
			#endregion
			#endregion

			#region Toggle
			private static eBool ToggleMaster(bool toggle, GUICon guiCon, GUIStyle style) => ToggleMaster(toggle, guiCon, style, Utilities.SingleLine);
			private static eBool ToggleMaster(bool toggle, GUICon guiCon, GUIStyle style, params GUILayOpt[] options) => ToggleMaster(toggle, guiCon, style, Utilities.SingleLine, options);
			private static eBool ToggleMaster(bool toggle, GUICon guiCon, GUIStyle style, float height) => ToggleMaster(toggle, guiCon, style, height, null);
			private static eBool ToggleMaster(bool toggle, GUICon guiCon, GUIStyle style, float height, params GUILayOpt[] options)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, options);
				return FoCsGUI.Toggle(rect, toggle, guiCon, style);
			}

			#region NoLabel
			public static GUIEvent Toggle(bool toggle) => ToggleMaster(toggle, GUICon.none, ToggleStyle);
			public static GUIEvent Toggle(bool toggle, float height) => ToggleMaster(toggle, GUICon.none, ToggleStyle, height);

			public static GUIEvent Toggle(bool toggle, GUIStyle style) => ToggleMaster(toggle, GUICon.none, style);
			public static GUIEvent Toggle(bool toggle, GUIStyle style, float height) => ToggleMaster(toggle, GUICon.none, style, height);

			public static GUIEvent Toggle(bool toggle, params GUILayOpt[] options) => ToggleMaster(toggle, GUICon.none, ToggleStyle, options);

			public static GUIEvent Toggle(bool toggle, float height, params GUILayOpt[] options) =>
					ToggleMaster(toggle, GUICon.none, ToggleStyle, height, options);

			public static GUIEvent Toggle(bool toggle, GUIStyle style, params GUILayOpt[] options) => ToggleMaster(toggle, GUICon.none, style, options);

			public static GUIEvent Toggle(bool toggle, GUIStyle style, float height, params GUILayOpt[] options) =>
					ToggleMaster(toggle, GUICon.none, style, height, options);
			#endregion

			#region StringLabel
			public static eBool Toggle(bool toggle, string label) => ToggleMaster(toggle, new GUICon(label), ToggleStyle);
			public static eBool Toggle(bool toggle, string label, float height) => ToggleMaster(toggle, new GUICon(label), ToggleStyle, height);
			public static eBool Toggle(bool toggle, string label, GUIStyle style) => ToggleMaster(toggle, new GUICon(label), style);
			public static eBool Toggle(bool toggle, string label, GUIStyle style, float height) => ToggleMaster(toggle, new GUICon(label), style, height);
			public static eBool Toggle(bool toggle, string label, params GUILayOpt[] options) => ToggleMaster(toggle, new GUICon(label), ToggleStyle, options);
			public static eBool Toggle(bool toggle, string label, float height, params GUILayOpt[] options) => ToggleMaster(toggle, new GUICon(label), ToggleStyle, height, options);
			public static eBool Toggle(bool toggle, string label, GUIStyle style, params GUILayOpt[] options) => ToggleMaster(toggle, new GUICon(label), style, options);
			public static eBool Toggle(bool toggle, string label, GUIStyle style, float height, params GUILayOpt[] options) => ToggleMaster(toggle, new GUICon(label), style, height, options);
			#endregion

			#region GUIConLabel
			public static eBool Toggle(bool toggle, GUICon guiCon) => ToggleMaster(toggle, guiCon, ToggleStyle);
			public static eBool Toggle(bool toggle, GUICon guiCon, float height) => ToggleMaster(toggle, guiCon, ToggleStyle, height);
			public static eBool Toggle(bool toggle, GUICon guiCon, GUIStyle style) => ToggleMaster(toggle, guiCon, style);
			public static eBool Toggle(bool toggle, GUICon guiCon, GUIStyle style, float height) => ToggleMaster(toggle, guiCon, style, height);
			public static eBool Toggle(bool toggle, GUICon guiCon, params GUILayOpt[] options) => ToggleMaster(toggle, guiCon, ToggleStyle, options);
			public static eBool Toggle(bool toggle, GUICon guiCon, float height, params GUILayOpt[] options) => ToggleMaster(toggle, guiCon, ToggleStyle, height, options);
			public static eBool Toggle(bool toggle, GUICon guiCon, GUIStyle style, params GUILayOpt[] options) => ToggleMaster(toggle, guiCon, style, options);
			public static eBool Toggle(bool toggle, GUICon guiCon, GUIStyle style, float height, params GUILayOpt[] options) => ToggleMaster(toggle, guiCon, style, height, options);
			#endregion

			#region Texture
			public static eBool Toggle(bool toggle, Texture texture) => ToggleMaster(toggle, new GUICon(texture), ToggleStyle);
			public static eBool Toggle(bool toggle, Texture texture, float height) => ToggleMaster(toggle, new GUICon(texture), ToggleStyle, height);
			public static eBool Toggle(bool toggle, Texture texture, GUIStyle style) => ToggleMaster(toggle, new GUICon(texture), style);
			public static eBool Toggle(bool toggle, Texture texture, GUIStyle style, float height) => ToggleMaster(toggle, new GUICon(texture), style, height);
			public static eBool Toggle(bool toggle, Texture texture, params GUILayOpt[] options) => ToggleMaster(toggle, new GUICon(texture), ToggleStyle, options);
			public static eBool Toggle(bool toggle, Texture texture, float height, params GUILayOpt[] options) => ToggleMaster(toggle, new GUICon(texture), ToggleStyle, height, options);
			public static eBool Toggle(bool toggle, Texture texture, GUIStyle style, params GUILayOpt[] options) => ToggleMaster(toggle, new GUICon(texture), style, options);
			public static eBool Toggle(bool toggle, Texture texture, GUIStyle style, float height, params GUILayOpt[] options) => ToggleMaster(toggle, new GUICon(texture), style, height, options);
			#endregion
			#endregion

			#region Foldout
			private static GUIEvent FoldoutMaster(bool foldout, GUICon guiCon, GUIStyle style) => FoldoutMaster(foldout, guiCon, style, Utilities.SingleLine);
			private static GUIEvent FoldoutMaster(bool foldout, GUICon guiCon, GUIStyle style, params GUILayOpt[] options) => FoldoutMaster(foldout, guiCon, style, Utilities.SingleLine, options);
			private static GUIEvent FoldoutMaster(bool foldout, GUICon guiCon, GUIStyle style, float height) => FoldoutMaster(foldout, guiCon, style, height, null);
			private static GUIEvent FoldoutMaster(bool foldout, GUICon guiCon, GUIStyle style, float height, params GUILayOpt[] options)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, options);
				return FoCsGUI.Foldout(rect, foldout, guiCon, style);
			}

			#region NoLabel
			public static GUIEvent Foldout(bool foldout) => FoldoutMaster(foldout, GUICon.none, FoldoutStyle);
			public static GUIEvent Foldout(bool foldout, float height) => FoldoutMaster(foldout, GUICon.none, FoldoutStyle, height);

			public static GUIEvent Foldout(bool foldout, GUIStyle style) => FoldoutMaster(foldout, GUICon.none, style);
			public static GUIEvent Foldout(bool foldout, GUIStyle style, float height) => FoldoutMaster(foldout, GUICon.none, style, height);

			public static GUIEvent Foldout(bool foldout, params GUILayOpt[] options) => FoldoutMaster(foldout, GUICon.none, FoldoutStyle, options);

			public static GUIEvent Foldout(bool foldout, float height, params GUILayOpt[] options) =>
					FoldoutMaster(foldout, GUICon.none, FoldoutStyle, height, options);

			public static GUIEvent Foldout(bool foldout, GUIStyle style, params GUILayOpt[] options) => FoldoutMaster(foldout, GUICon.none, style, options);

			public static GUIEvent Foldout(bool foldout, GUIStyle style, float height, params GUILayOpt[] options) =>
					FoldoutMaster(foldout, GUICon.none, style, height, options);
			#endregion

			#region StringLabel
			public static GUIEvent Foldout(bool foldout, string label) => FoldoutMaster(foldout, new GUICon(label), FoldoutStyle);
			public static GUIEvent Foldout(bool foldout, string label, float height) => FoldoutMaster(foldout, new GUICon(label), FoldoutStyle, height);

			public static GUIEvent Foldout(bool foldout, string label, GUIStyle style) => FoldoutMaster(foldout, new GUICon(label), style);
			public static GUIEvent Foldout(bool foldout, string label, GUIStyle style, float height) => FoldoutMaster(foldout, new GUICon(label), style, height);

			public static GUIEvent Foldout(bool foldout, string label, params GUILayOpt[] options) =>
					FoldoutMaster(foldout, new GUICon(label), FoldoutStyle, options);

			public static GUIEvent Foldout(bool foldout, string label, float height, params GUILayOpt[] options) =>
					FoldoutMaster(foldout, new GUICon(label), FoldoutStyle, height, options);

			public static GUIEvent Foldout(bool foldout, string label, GUIStyle style, params GUILayOpt[] options) =>
					FoldoutMaster(foldout, new GUICon(label), style, options);

			public static GUIEvent Foldout(bool foldout, string label, GUIStyle style, float height, params GUILayOpt[] options) =>
					FoldoutMaster(foldout, new GUICon(label), style, height, options);
			#endregion

			#region GUIConLabel
			public static GUIEvent Foldout(bool foldout, GUICon guiCon) => FoldoutMaster(foldout, guiCon, FoldoutStyle);
			public static GUIEvent Foldout(bool foldout, GUICon guiCon, float height) => FoldoutMaster(foldout, guiCon, FoldoutStyle, height);

			public static GUIEvent Foldout(bool foldout, GUICon guiCon, GUIStyle style) => FoldoutMaster(foldout, guiCon, style);
			public static GUIEvent Foldout(bool foldout, GUICon guiCon, GUIStyle style, float height) => FoldoutMaster(foldout, guiCon, style, height);

			public static GUIEvent Foldout(bool foldout, GUICon guiCon, params GUILayOpt[] options) =>
					FoldoutMaster(foldout, guiCon, FoldoutStyle, options);

			public static GUIEvent Foldout(bool foldout, GUICon guiCon, float height, params GUILayOpt[] options) =>
					FoldoutMaster(foldout, guiCon, FoldoutStyle, height, options);

			public static GUIEvent Foldout(bool foldout, GUICon guiCon, GUIStyle style, params GUILayOpt[] options) =>
					FoldoutMaster(foldout, guiCon, style, options);

			public static GUIEvent Foldout(bool foldout, GUICon guiCon, GUIStyle style, float height, params GUILayOpt[] options) =>
					FoldoutMaster(foldout, guiCon, style, height, options);
			#endregion

			#region Texture
			public static GUIEvent Foldout(bool foldout, Texture texture) => FoldoutMaster(foldout, new GUICon(texture), FoldoutStyle);
			public static GUIEvent Foldout(bool foldout, Texture texture, float height) => FoldoutMaster(foldout, new GUICon(texture), FoldoutStyle, height);

			public static GUIEvent Foldout(bool foldout, Texture texture, GUIStyle style) => FoldoutMaster(foldout, new GUICon(texture), style);
			public static GUIEvent Foldout(bool foldout, Texture texture, GUIStyle style, float height) => FoldoutMaster(foldout, new GUICon(texture), style, height);

			public static GUIEvent Foldout(bool foldout, Texture texture, params GUILayOpt[] options) =>
					FoldoutMaster(foldout, new GUICon(texture), FoldoutStyle, options);

			public static GUIEvent Foldout(bool foldout, Texture texture, float height, params GUILayOpt[] options) =>
					FoldoutMaster(foldout, new GUICon(texture), FoldoutStyle, height, options);

			public static GUIEvent Foldout(bool foldout, Texture texture, GUIStyle style, params GUILayOpt[] options) =>
					FoldoutMaster(foldout, new GUICon(texture), style, options);

			public static GUIEvent Foldout(bool foldout, Texture texture, GUIStyle style, float height, params GUILayOpt[] options) =>
					FoldoutMaster(foldout, new GUICon(texture), style, height, options);
			#endregion
			#endregion

			#region IntField
			private static eInt IntFieldMaster(GUICon guiCon, int value, GUIStyle style) => IntFieldMaster(guiCon, value, style, Utilities.SingleLine);
			private static eInt IntFieldMaster(GUICon guiCon, int value, GUIStyle style, params GUILayOpt[] options) => IntFieldMaster(guiCon, value, style, Utilities.SingleLine, options);
			private static eInt IntFieldMaster(GUICon guiCon, int value, GUIStyle style, float height) => IntFieldMaster(guiCon, value, style,  height, null);
			private static eInt IntFieldMaster(GUICon guiCon, int value, GUIStyle style, float height, params GUILayOpt[] options)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, options);
				return FoCsGUI.IntField(rect, guiCon, value, style);
			}

			#region NoLabel
			public static eInt IntField(int value) => IntFieldMaster(GUICon.none, value, NumberFieldStyle);
			public static eInt IntField(int value, float height) => IntFieldMaster(GUICon.none, value, NumberFieldStyle, height);
			public static eInt IntField(int value, GUIStyle style) => IntFieldMaster(GUICon.none, value, style);
			public static eInt IntField(int value, GUIStyle style, float height) => IntFieldMaster(GUICon.none, value, style, height);
			public static eInt IntField(int value, params GUILayOpt[] options) => IntFieldMaster(GUICon.none, value, NumberFieldStyle, options);
			public static eInt IntField(int value, float height, params GUILayOpt[] options) => IntFieldMaster(GUICon.none, value, NumberFieldStyle, height, options);
			public static eInt IntField(int value, GUIStyle style, params GUILayOpt[] options) => IntFieldMaster(GUICon.none, value, style, options);
			public static eInt IntField(int value, GUIStyle style, float height, params GUILayOpt[] options) => IntFieldMaster(GUICon.none, value, style, height, options);
			#endregion

			#region StringLabel
			public static eInt IntField(string label, int value) => IntFieldMaster(new GUICon(label), value, NumberFieldStyle);
			public static eInt IntField(string label, int value, float height) => IntFieldMaster(new GUICon(label), value, NumberFieldStyle, height);
			public static eInt IntField(string label, int value, GUIStyle style) => IntFieldMaster(new GUICon(label), value, style);
			public static eInt IntField(string label, int value, GUIStyle style, float height) => IntFieldMaster(new GUICon(label), value, style, height);
			public static eInt IntField(string label, int value, params GUILayOpt[] options) => IntFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			public static eInt IntField(string label, int value, float height, params GUILayOpt[] options) => IntFieldMaster(new GUICon(label), value, NumberFieldStyle, height, options);
			public static eInt IntField(string label, int value, GUIStyle style, params GUILayOpt[] options) => IntFieldMaster(new GUICon(label), value, style, options);
			public static eInt IntField(string label, int value, GUIStyle style, float height, params GUILayOpt[] options) => IntFieldMaster(new GUICon(label), value, style, height, options);
			#endregion

			#region GUIConLabel
			public static eInt IntField(GUICon guiCon, int value) => IntFieldMaster(guiCon, value, NumberFieldStyle);
			public static eInt IntField(GUICon guiCon, int value, float height) => IntFieldMaster(guiCon, value, NumberFieldStyle, height);
			public static eInt IntField(GUICon guiCon, int value, GUIStyle style) => IntFieldMaster(guiCon, value, style);
			public static eInt IntField(GUICon guiCon, int value, GUIStyle style, float height) => IntFieldMaster(guiCon, value, style, height);
			public static eInt IntField(GUICon guiCon, int value, params GUILayOpt[] options) => IntFieldMaster(guiCon, value, NumberFieldStyle, options);
			public static eInt IntField(GUICon guiCon, int value, float height, params GUILayOpt[] options) => IntFieldMaster(guiCon, value, NumberFieldStyle, height, options);
			public static eInt IntField(GUICon guiCon, int value, GUIStyle style, params GUILayOpt[] options) => IntFieldMaster(guiCon, value, style, options);
			public static eInt IntField(GUICon guiCon, int value, GUIStyle style, float height, params GUILayOpt[] options) => IntFieldMaster(guiCon, value, style, height, options);
			#endregion
			#endregion

			#region FloatField
			private static eFloat FloatFieldMaster(GUICon guiCon, float value, GUIStyle style) => FloatFieldMaster(guiCon, value, style, Utilities.SingleLine);
			private static eFloat FloatFieldMaster(GUICon guiCon, float value, GUIStyle style, params GUILayOpt[] options) => FloatFieldMaster(guiCon, value, style, Utilities.SingleLine, options);
			private static eFloat FloatFieldMaster(GUICon guiCon, float value, GUIStyle style, float height) => FloatFieldMaster(guiCon, value, style, height, null);

			private static eFloat FloatFieldMaster(GUICon guiCon, float value, GUIStyle style, float height, params GUILayOpt[] options)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, options);
				return FoCsGUI.FloatField(rect, guiCon, value, style);
			}

			#region NoLabel
			public static eFloat FloatField(float value) => FloatFieldMaster(GUICon.none, value, NumberFieldStyle);
			public static eFloat FloatField(float value, float height) => FloatFieldMaster(GUICon.none, value, NumberFieldStyle, height);
			public static eFloat FloatField(float value, GUIStyle style) => FloatFieldMaster(GUICon.none, value, style);
			public static eFloat FloatField(float value, GUIStyle style, float height) => FloatFieldMaster(GUICon.none, value, style, height);
			public static eFloat FloatField(float value, params GUILayOpt[] options) => FloatFieldMaster(GUICon.none, value, NumberFieldStyle, options);
			public static eFloat FloatField(float value, float height, params GUILayOpt[] options) => FloatFieldMaster(GUICon.none, value, NumberFieldStyle, height, options);
			public static eFloat FloatField(float value, GUIStyle style, params GUILayOpt[] options) => FloatFieldMaster(GUICon.none, value, style, options);
			public static eFloat FloatField(float value, GUIStyle style, float height, params GUILayOpt[] options) => FloatFieldMaster(GUICon.none, value, style, height, options);
			#endregion

			#region StringLabel
			public static eFloat FloatField(string label, float value) => FloatFieldMaster(new GUICon(label), value, NumberFieldStyle);
			public static eFloat FloatField(string label, float value, float height) => FloatFieldMaster(new GUICon(label), value, NumberFieldStyle, height);
			public static eFloat FloatField(string label, float value, GUIStyle style) => FloatFieldMaster(new GUICon(label), value, style);
			public static eFloat FloatField(string label, float value, GUIStyle style, float height) => FloatFieldMaster(new GUICon(label), value, style, height);
			public static eFloat FloatField(string label, float value, params GUILayOpt[] options) => FloatFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			public static eFloat FloatField(string label, float value, float height, params GUILayOpt[] options) => FloatFieldMaster(new GUICon(label), value, NumberFieldStyle, height, options);
			public static eFloat FloatField(string label, float value, GUIStyle style, params GUILayOpt[] options) => FloatFieldMaster(new GUICon(label), value, style, options);
			public static eFloat FloatField(string label, float value, GUIStyle style, float height, params GUILayOpt[] options) => FloatFieldMaster(new GUICon(label), value, style, height, options);
			#endregion

			#region GUIConLabel
			public static eFloat FloatField(GUICon guiCon, float value) => FloatFieldMaster(guiCon, value, NumberFieldStyle);
			public static eFloat FloatField(GUICon guiCon, float value, float height) => FloatFieldMaster(guiCon, value, NumberFieldStyle, height);
			public static eFloat FloatField(GUICon guiCon, float value, GUIStyle style) => FloatFieldMaster(guiCon, value, style);
			public static eFloat FloatField(GUICon guiCon, float value, GUIStyle style, float height) => FloatFieldMaster(guiCon, value, style, height);
			public static eFloat FloatField(GUICon guiCon, float value, params GUILayOpt[] options) => FloatFieldMaster(guiCon, value, NumberFieldStyle, options);
			public static eFloat FloatField(GUICon guiCon, float value, float height, params GUILayOpt[] options) => FloatFieldMaster(guiCon, value, NumberFieldStyle, height, options);
			public static eFloat FloatField(GUICon guiCon, float value, GUIStyle style, params GUILayOpt[] options) => FloatFieldMaster(guiCon, value, style, options);
			public static eFloat FloatField(GUICon guiCon, float value, GUIStyle style, float height, params GUILayOpt[] options) => FloatFieldMaster(guiCon, value, style, height, options);
			#endregion
			#endregion

			#region TextField
			private static eString TextFieldMaster(GUICon guiCon, string value, GUIStyle style) => TextFieldMaster(guiCon, value, style, Utilities.SingleLine);
			private static eString TextFieldMaster(GUICon guiCon, string value, GUIStyle style, params GUILayOpt[] options) => TextFieldMaster(guiCon, value, style, Utilities.SingleLine, options);
			private static eString TextFieldMaster(GUICon guiCon, string value, GUIStyle style, float height) => TextFieldMaster(guiCon, value, style, height, null);
			private static eString TextFieldMaster(GUICon guiCon, string value, GUIStyle style, float height, params GUILayOpt[] options)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, options);
				return FoCsGUI.TextField(rect, guiCon, value, style);
			}

			#region NoLabel
			public static eString TextField(string value) => TextFieldMaster(GUICon.none, value, NumberFieldStyle);
			public static eString TextField(string value, float height) => TextFieldMaster(GUICon.none, value, NumberFieldStyle, height);
			public static eString TextField(string value, GUIStyle style) => TextFieldMaster(GUICon.none, value, style);
			public static eString TextField(string value, GUIStyle style, float height) => TextFieldMaster(GUICon.none, value, style, height);
			public static eString TextField(string value, params GUILayOpt[] options) => TextFieldMaster(GUICon.none, value, NumberFieldStyle, options);
			public static eString TextField(string value, float height, params GUILayOpt[] options) => TextFieldMaster(GUICon.none, value, NumberFieldStyle, height, options);
			public static eString TextField(string value, GUIStyle style, params GUILayOpt[] options) => TextFieldMaster(GUICon.none, value, style, options);
			public static eString TextField(string value, GUIStyle style, float height, params GUILayOpt[] options) => TextFieldMaster(GUICon.none, value, style, height, options);
			#endregion

			#region StringLabel
			public static eString TextField(string label, string value) => TextFieldMaster(new GUICon(label), value, NumberFieldStyle);
			public static eString TextField(string label, string value, float height) => TextFieldMaster(new GUICon(label), value, NumberFieldStyle, height);
			public static eString TextField(string label, string value, GUIStyle style) => TextFieldMaster(new GUICon(label), value, style);
			public static eString TextField(string label, string value, GUIStyle style, float height) => TextFieldMaster(new GUICon(label), value, style, height);
			public static eString TextField(string label, string value, params GUILayOpt[] options) => TextFieldMaster(new GUICon(label), value, NumberFieldStyle, options);
			public static eString TextField(string label, string value, float height, params GUILayOpt[] options) => TextFieldMaster(new GUICon(label), value, NumberFieldStyle, height, options);
			public static eString TextField(string label, string value, GUIStyle style, params GUILayOpt[] options) => TextFieldMaster(new GUICon(label), value, style, options);
			public static eString TextField(string label, string value, GUIStyle style, float height, params GUILayOpt[] options) => TextFieldMaster(new GUICon(label), value, style, height, options);
			#endregion

			#region GUIConLabel
			public static eString TextField(GUICon guiCon, string value) => TextFieldMaster(guiCon, value, NumberFieldStyle);
			public static eString TextField(GUICon guiCon, string value, float height) => TextFieldMaster(guiCon, value, NumberFieldStyle, height);
			public static eString TextField(GUICon guiCon, string value, GUIStyle style) => TextFieldMaster(guiCon, value, style);
			public static eString TextField(GUICon guiCon, string value, GUIStyle style, float height) => TextFieldMaster(guiCon, value, style, height);
			public static eString TextField(GUICon guiCon, string value, params GUILayOpt[] options) => TextFieldMaster(guiCon, value, NumberFieldStyle, options);
			public static eString TextField(GUICon guiCon, string value, float height, params GUILayOpt[] options) => TextFieldMaster(guiCon, value, NumberFieldStyle, height, options);
			public static eString TextField(GUICon guiCon, string value, GUIStyle style, params GUILayOpt[] options) => TextFieldMaster(guiCon, value, style, options);
			public static eString TextField(GUICon guiCon, string value, GUIStyle style, float height, params GUILayOpt[] options) => TextFieldMaster(guiCon, value, style, height, options);
			#endregion
			#endregion

			#region TextArea
			private static eString TextAreaMaster(string value, GUIStyle style) => TextAreaMaster(value, style, Utilities.SingleLine);
			private static eString TextAreaMaster(string value, GUIStyle style, params GUILayOpt[] options) => TextAreaMaster(value, style, Utilities.SingleLine, options);
			private static eString TextAreaMaster(string value, GUIStyle style, float height) => TextAreaMaster(value, style, height, null);
			private static eString TextAreaMaster(string value, GUIStyle style, float height, params GUILayOpt[] options)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, options);
				return FoCsGUI.TextArea(rect, value, style);
			}

			#region NoLabel
			public static eString TextArea(string value) => TextAreaMaster(value, NumberFieldStyle);
			public static eString TextArea(string value, float height) => TextAreaMaster(value, NumberFieldStyle, height);
			public static eString TextArea(string value, GUIStyle style) => TextAreaMaster(value, style);
			public static eString TextArea(string value, GUIStyle style, float height) => TextAreaMaster(value, style, height);
			public static eString TextArea(string value, params GUILayOpt[] options) => TextAreaMaster(value, NumberFieldStyle, options);
			public static eString TextArea(string value, float height, params GUILayOpt[] options) => TextAreaMaster(value, NumberFieldStyle, height, options);
			public static eString TextArea(string value, GUIStyle style, params GUILayOpt[] options) => TextAreaMaster(value, style, options);
			public static eString TextArea(string value, GUIStyle style, float height, params GUILayOpt[] options) => TextAreaMaster(value, style, height, options);
			#endregion
			#endregion
		}
	}
}