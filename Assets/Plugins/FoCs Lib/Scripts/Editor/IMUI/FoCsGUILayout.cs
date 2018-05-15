﻿using ForestOfChaosLib.Editor.Utilities;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public static partial class FoCsGUI
	{
		public static  class Layout
		{
			#region Label
			private static GUIEvent LabelMaster(GUIContent guiContent, GUIStyle style) => LabelMaster(guiContent, style, FoCsEditorUtilities.SingleLine);

			private static GUIEvent LabelMaster(GUIContent guiContent, GUIStyle style, params GUILayoutOption[] options) =>
					LabelMaster(guiContent, style, FoCsEditorUtilities.SingleLine, options);

			private static GUIEvent LabelMaster(GUIContent guiContent, GUIStyle style, float height)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, GUILayout.ExpandWidth(true));
				return FoCsGUI.Label(rect, guiContent, style);
			}

			private static GUIEvent LabelMaster(GUIContent guiContent, GUIStyle style, float height, params GUILayoutOption[] options)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, options);
				return FoCsGUI.Label(rect, guiContent, style);
			}

			#region NoLabel
			public static GUIEvent Label() => LabelMaster(GUIContent.none, LabelStyle);
			public static GUIEvent Label(float height) => LabelMaster(GUIContent.none, LabelStyle, height);

			public static GUIEvent Label(GUIStyle style) => LabelMaster(GUIContent.none, style);
			public static GUIEvent Label(GUIStyle style, float height) => LabelMaster(GUIContent.none, style, height);

			public static GUIEvent Label(params GUILayoutOption[] options) => LabelMaster(GUIContent.none, LabelStyle, options);
			public static GUIEvent Label(float height, params GUILayoutOption[] options) => LabelMaster(GUIContent.none, LabelStyle, height, options);

			public static GUIEvent Label(GUIStyle style, params GUILayoutOption[] options) => LabelMaster(GUIContent.none, style, options);
			public static GUIEvent Label(GUIStyle style, float height, params GUILayoutOption[] options) => LabelMaster(GUIContent.none, style, height, options);
			#endregion

			#region StringLabel
			public static GUIEvent Label(string label) => LabelMaster(new GUIContent(label), LabelStyle);
			public static GUIEvent Label(string label, float height) => LabelMaster(new GUIContent(label), LabelStyle, height);

			public static GUIEvent Label(string label, GUIStyle style) => LabelMaster(new GUIContent(label), style);
			public static GUIEvent Label(string label, GUIStyle style, float height) => LabelMaster(new GUIContent(label), style, height);

			public static GUIEvent Label(string label, params GUILayoutOption[] options) => LabelMaster(new GUIContent(label), LabelStyle, options);

			public static GUIEvent Label(string label, float height, params GUILayoutOption[] options) =>
					LabelMaster(new GUIContent(label), LabelStyle, height, options);

			public static GUIEvent Label(string label, GUIStyle style, params GUILayoutOption[] options) => LabelMaster(new GUIContent(label), style, options);

			public static GUIEvent Label(string label, GUIStyle style, float height, params GUILayoutOption[] options) =>
					LabelMaster(new GUIContent(label), style, height, options);
			#endregion

			#region GUIContentLabel
			public static GUIEvent Label(GUIContent guiContent) => LabelMaster(guiContent, LabelStyle);
			public static GUIEvent Label(GUIContent guiContent, float height) => LabelMaster(guiContent, LabelStyle, height);

			public static GUIEvent Label(GUIContent guiContent, GUIStyle style) => LabelMaster(guiContent, style);
			public static GUIEvent Label(GUIContent guiContent, GUIStyle style, float height) => LabelMaster(guiContent, style, height);

			public static GUIEvent Label(GUIContent guiContent, params GUILayoutOption[] options) => LabelMaster(guiContent, LabelStyle, options);

			public static GUIEvent Label(GUIContent guiContent, float height, params GUILayoutOption[] options) => LabelMaster(guiContent, LabelStyle, height, options);

			public static GUIEvent Label(GUIContent guiContent, GUIStyle style, params GUILayoutOption[] options) => LabelMaster(guiContent, style, options);

			public static GUIEvent Label(GUIContent guiContent, GUIStyle style, float height, params GUILayoutOption[] options) =>
					LabelMaster(guiContent, style, height, options);
			#endregion

			#region Texture
			public static GUIEvent Label(Texture texture) => LabelMaster(new GUIContent(texture), LabelStyle);
			public static GUIEvent Label(Texture texture, float height) => LabelMaster(new GUIContent(texture), LabelStyle, height);

			public static GUIEvent Label(Texture texture, GUIStyle style) => LabelMaster(new GUIContent(texture), style);
			public static GUIEvent Label(Texture texture, GUIStyle style, float height) => LabelMaster(new GUIContent(texture), style, height);

			public static GUIEvent Label(Texture texture, params GUILayoutOption[] options) => LabelMaster(new GUIContent(texture), LabelStyle, options);

			public static GUIEvent Label(Texture texture, float height, params GUILayoutOption[] options) =>
					LabelMaster(new GUIContent(texture), LabelStyle, height, options);

			public static GUIEvent Label(Texture texture, GUIStyle style, params GUILayoutOption[] options) => LabelMaster(new GUIContent(texture), style, options);

			public static GUIEvent Label(Texture texture, GUIStyle style, float height, params GUILayoutOption[] options) =>
					LabelMaster(new GUIContent(texture), style, height, options);
			#endregion
			#endregion

			#region Button
			private static GUIEvent ButtonMaster(GUIContent guiContent, GUIStyle style) => ButtonMaster(guiContent, style, FoCsEditorUtilities.SingleLine);

			private static GUIEvent ButtonMaster(GUIContent guiContent, GUIStyle style, params GUILayoutOption[] options) =>
					ButtonMaster(guiContent, style, FoCsEditorUtilities.SingleLine, options);

			private static GUIEvent ButtonMaster(GUIContent guiContent, GUIStyle style, float height)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, GUILayout.ExpandWidth(true));
				return FoCsGUI.Button(rect, guiContent, style);
			}

			private static GUIEvent ButtonMaster(GUIContent guiContent, GUIStyle style, float height, params GUILayoutOption[] options)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, options);
				return FoCsGUI.Button(rect, guiContent, style);
			}

			#region NoLabel
			public static GUIEvent Button() => ButtonMaster(GUIContent.none, ButtonStyle);
			public static GUIEvent Button(float height) => ButtonMaster(GUIContent.none, ButtonStyle, height);

			public static GUIEvent Button(GUIStyle style) => ButtonMaster(GUIContent.none, style);
			public static GUIEvent Button(GUIStyle style, float height) => ButtonMaster(GUIContent.none, style, height);

			public static GUIEvent Button(params GUILayoutOption[] options) => ButtonMaster(GUIContent.none, ButtonStyle, options);
			public static GUIEvent Button(float height, params GUILayoutOption[] options) => ButtonMaster(GUIContent.none, ButtonStyle, height, options);

			public static GUIEvent Button(GUIStyle style, params GUILayoutOption[] options) => ButtonMaster(GUIContent.none, style, options);
			public static GUIEvent Button(GUIStyle style, float height, params GUILayoutOption[] options) => ButtonMaster(GUIContent.none, style, height, options);
			#endregion

			#region StringLabel
			public static GUIEvent Button(string label) => ButtonMaster(new GUIContent(label), ButtonStyle);
			public static GUIEvent Button(string label, float height) => ButtonMaster(new GUIContent(label), ButtonStyle, height);

			public static GUIEvent Button(string label, GUIStyle style) => ButtonMaster(new GUIContent(label), style);
			public static GUIEvent Button(string label, GUIStyle style, float height) => ButtonMaster(new GUIContent(label), style, height);

			public static GUIEvent Button(string label, params GUILayoutOption[] options) => ButtonMaster(new GUIContent(label), ButtonStyle, options);

			public static GUIEvent Button(string label, float height, params GUILayoutOption[] options) =>
					ButtonMaster(new GUIContent(label), ButtonStyle, height, options);

			public static GUIEvent Button(string label, GUIStyle style, params GUILayoutOption[] options) => ButtonMaster(new GUIContent(label), style, options);

			public static GUIEvent Button(string label, GUIStyle style, float height, params GUILayoutOption[] options) =>
					ButtonMaster(new GUIContent(label), style, height, options);
			#endregion

			#region GUIContentLabel
			public static GUIEvent Button(GUIContent guiContent) => ButtonMaster(guiContent, ButtonStyle);
			public static GUIEvent Button(GUIContent guiContent, float height) => ButtonMaster(guiContent, ButtonStyle, height);

			public static GUIEvent Button(GUIContent guiContent, GUIStyle style) => ButtonMaster(guiContent, style);
			public static GUIEvent Button(GUIContent guiContent, GUIStyle style, float height) => ButtonMaster(guiContent, style, height);

			public static GUIEvent Button(GUIContent guiContent, params GUILayoutOption[] options) => ButtonMaster(guiContent, ButtonStyle, options);

			public static GUIEvent Button(GUIContent guiContent, float height, params GUILayoutOption[] options) =>
					ButtonMaster(guiContent, ButtonStyle, height, options);

			public static GUIEvent Button(GUIContent guiContent, GUIStyle style, params GUILayoutOption[] options) => ButtonMaster(guiContent, style, options);

			public static GUIEvent Button(GUIContent guiContent, GUIStyle style, float height, params GUILayoutOption[] options) =>
					ButtonMaster(guiContent, style, height, options);
			#endregion

			#region Texture
			public static GUIEvent Button(Texture texture) => ButtonMaster(new GUIContent(texture), ButtonStyle);
			public static GUIEvent Button(Texture texture, float height) => ButtonMaster(new GUIContent(texture), ButtonStyle, height);

			public static GUIEvent Button(Texture texture, GUIStyle style) => ButtonMaster(new GUIContent(texture), style);
			public static GUIEvent Button(Texture texture, GUIStyle style, float height) => ButtonMaster(new GUIContent(texture), style, height);

			public static GUIEvent Button(Texture texture, params GUILayoutOption[] options) => ButtonMaster(new GUIContent(texture), ButtonStyle, options);

			public static GUIEvent Button(Texture texture, float height, params GUILayoutOption[] options) =>
					ButtonMaster(new GUIContent(texture), ButtonStyle, height, options);

			public static GUIEvent Button(Texture texture, GUIStyle style, params GUILayoutOption[] options) => ButtonMaster(new GUIContent(texture), style, options);

			public static GUIEvent Button(Texture texture, GUIStyle style, float height, params GUILayoutOption[] options) =>
					ButtonMaster(new GUIContent(texture), style, height, options);
			#endregion
			#endregion

			#region Toggle
			private static GUIEvent ToggleMaster(bool toggle, GUIContent guiContent, GUIStyle style) =>
					ToggleMaster(toggle, guiContent, style, FoCsEditorUtilities.SingleLine);

			private static GUIEvent ToggleMaster(bool toggle, GUIContent guiContent, GUIStyle style, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, guiContent, style, FoCsEditorUtilities.SingleLine, options);

			private static GUIEvent ToggleMaster(bool toggle, GUIContent guiContent, GUIStyle style, float height)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, GUILayout.ExpandWidth(true));
				return FoCsGUI.Toggle(rect, toggle, guiContent, style);
			}

			private static GUIEvent ToggleMaster(bool toggle, GUIContent guiContent, GUIStyle style, float height, params GUILayoutOption[] options)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, options);
				return FoCsGUI.Toggle(rect, toggle, guiContent, style);
			}

			#region NoLabel
			public static GUIEvent Toggle(bool toggle) => ToggleMaster(toggle, GUIContent.none, ToggleStyle);
			public static GUIEvent Toggle(bool toggle, float height) => ToggleMaster(toggle, GUIContent.none, ToggleStyle, height);

			public static GUIEvent Toggle(bool toggle, GUIStyle style) => ToggleMaster(toggle, GUIContent.none, style);
			public static GUIEvent Toggle(bool toggle, GUIStyle style, float height) => ToggleMaster(toggle, GUIContent.none, style, height);

			public static GUIEvent Toggle(bool toggle, params GUILayoutOption[] options) => ToggleMaster(toggle, GUIContent.none, ToggleStyle, options);

			public static GUIEvent Toggle(bool toggle, float height, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, GUIContent.none, ToggleStyle, height, options);

			public static GUIEvent Toggle(bool toggle, GUIStyle style, params GUILayoutOption[] options) => ToggleMaster(toggle, GUIContent.none, style, options);

			public static GUIEvent Toggle(bool toggle, GUIStyle style, float height, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, GUIContent.none, style, height, options);
			#endregion

			#region StringLabel
			public static GUIEvent Toggle(bool toggle, string label) => ToggleMaster(toggle, new GUIContent(label), ToggleStyle);
			public static GUIEvent Toggle(bool toggle, string label, float height) => ToggleMaster(toggle, new GUIContent(label), ToggleStyle, height);

			public static GUIEvent Toggle(bool toggle, string label, GUIStyle style) => ToggleMaster(toggle, new GUIContent(label), style);
			public static GUIEvent Toggle(bool toggle, string label, GUIStyle style, float height) => ToggleMaster(toggle, new GUIContent(label), style, height);

			public static GUIEvent Toggle(bool toggle, string label, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, new GUIContent(label), ToggleStyle, options);

			public static GUIEvent Toggle(bool toggle, string label, float height, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, new GUIContent(label), ToggleStyle, height, options);

			public static GUIEvent Toggle(bool toggle, string label, GUIStyle style, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, new GUIContent(label), style, options);

			public static GUIEvent Toggle(bool toggle, string label, GUIStyle style, float height, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, new GUIContent(label), style, height, options);
			#endregion

			#region GUIContentLabel
			public static GUIEvent Toggle(bool toggle, GUIContent guiContent) => ToggleMaster(toggle, guiContent, ToggleStyle);
			public static GUIEvent Toggle(bool toggle, GUIContent guiContent, float height) => ToggleMaster(toggle, guiContent, ToggleStyle, height);

			public static GUIEvent Toggle(bool toggle, GUIContent guiContent, GUIStyle style) => ToggleMaster(toggle, guiContent, style);
			public static GUIEvent Toggle(bool toggle, GUIContent guiContent, GUIStyle style, float height) => ToggleMaster(toggle, guiContent, style, height);

			public static GUIEvent Toggle(bool toggle, GUIContent guiContent, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, guiContent, ToggleStyle, options);

			public static GUIEvent Toggle(bool toggle, GUIContent guiContent, float height, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, guiContent, ToggleStyle, height, options);

			public static GUIEvent Toggle(bool toggle, GUIContent guiContent, GUIStyle style, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, guiContent, style, options);

			public static GUIEvent Toggle(bool toggle, GUIContent guiContent, GUIStyle style, float height, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, guiContent, style, height, options);
			#endregion

			#region Texture
			public static GUIEvent Toggle(bool toggle, Texture texture) => ToggleMaster(toggle, new GUIContent(texture), ToggleStyle);
			public static GUIEvent Toggle(bool toggle, Texture texture, float height) => ToggleMaster(toggle, new GUIContent(texture), ToggleStyle, height);

			public static GUIEvent Toggle(bool toggle, Texture texture, GUIStyle style) => ToggleMaster(toggle, new GUIContent(texture), style);
			public static GUIEvent Toggle(bool toggle, Texture texture, GUIStyle style, float height) => ToggleMaster(toggle, new GUIContent(texture), style, height);

			public static GUIEvent Toggle(bool toggle, Texture texture, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, new GUIContent(texture), ToggleStyle, options);

			public static GUIEvent Toggle(bool toggle, Texture texture, float height, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, new GUIContent(texture), ToggleStyle, height, options);

			public static GUIEvent Toggle(bool toggle, Texture texture, GUIStyle style, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, new GUIContent(texture), style, options);

			public static GUIEvent Toggle(bool toggle, Texture texture, GUIStyle style, float height, params GUILayoutOption[] options) =>
					ToggleMaster(toggle, new GUIContent(texture), style, height, options);
			#endregion
			#endregion

			#region Foldout
			private static GUIEvent FoldoutMaster(bool foldout, GUIContent guiContent, GUIStyle style) =>
					FoldoutMaster(foldout, guiContent, style, FoCsEditorUtilities.SingleLine);

			private static GUIEvent FoldoutMaster(bool foldout, GUIContent guiContent, GUIStyle style, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, guiContent, style, FoCsEditorUtilities.SingleLine, options);

			private static GUIEvent FoldoutMaster(bool foldout, GUIContent guiContent, GUIStyle style, float height)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, GUILayout.ExpandWidth(true));
				return FoCsGUI.Foldout(rect, foldout, guiContent, style);
			}

			private static GUIEvent FoldoutMaster(bool foldout, GUIContent guiContent, GUIStyle style, float height, params GUILayoutOption[] options)
			{
				var rect = GUILayoutUtility.GetRect(0, height, style, options);
				return FoCsGUI.Foldout(rect, foldout, guiContent, style);
			}

			#region NoLabel
			public static GUIEvent Foldout(bool foldout) => FoldoutMaster(foldout, GUIContent.none, FoldoutStyle);
			public static GUIEvent Foldout(bool foldout, float height) => FoldoutMaster(foldout, GUIContent.none, FoldoutStyle, height);

			public static GUIEvent Foldout(bool foldout, GUIStyle style) => FoldoutMaster(foldout, GUIContent.none, style);
			public static GUIEvent Foldout(bool foldout, GUIStyle style, float height) => FoldoutMaster(foldout, GUIContent.none, style, height);

			public static GUIEvent Foldout(bool foldout, params GUILayoutOption[] options) => FoldoutMaster(foldout, GUIContent.none, FoldoutStyle, options);

			public static GUIEvent Foldout(bool foldout, float height, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, GUIContent.none, FoldoutStyle, height, options);

			public static GUIEvent Foldout(bool foldout, GUIStyle style, params GUILayoutOption[] options) => FoldoutMaster(foldout, GUIContent.none, style, options);

			public static GUIEvent Foldout(bool foldout, GUIStyle style, float height, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, GUIContent.none, style, height, options);
			#endregion

			#region StringLabel
			public static GUIEvent Foldout(bool foldout, string label) => FoldoutMaster(foldout, new GUIContent(label), FoldoutStyle);
			public static GUIEvent Foldout(bool foldout, string label, float height) => FoldoutMaster(foldout, new GUIContent(label), FoldoutStyle, height);

			public static GUIEvent Foldout(bool foldout, string label, GUIStyle style) => FoldoutMaster(foldout, new GUIContent(label), style);
			public static GUIEvent Foldout(bool foldout, string label, GUIStyle style, float height) => FoldoutMaster(foldout, new GUIContent(label), style, height);

			public static GUIEvent Foldout(bool foldout, string label, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, new GUIContent(label), FoldoutStyle, options);

			public static GUIEvent Foldout(bool foldout, string label, float height, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, new GUIContent(label), FoldoutStyle, height, options);

			public static GUIEvent Foldout(bool foldout, string label, GUIStyle style, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, new GUIContent(label), style, options);

			public static GUIEvent Foldout(bool foldout, string label, GUIStyle style, float height, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, new GUIContent(label), style, height, options);
			#endregion

			#region GUIContentLabel
			public static GUIEvent Foldout(bool foldout, GUIContent guiContent) => FoldoutMaster(foldout, guiContent, FoldoutStyle);
			public static GUIEvent Foldout(bool foldout, GUIContent guiContent, float height) => FoldoutMaster(foldout, guiContent, FoldoutStyle, height);

			public static GUIEvent Foldout(bool foldout, GUIContent guiContent, GUIStyle style) => FoldoutMaster(foldout, guiContent, style);
			public static GUIEvent Foldout(bool foldout, GUIContent guiContent, GUIStyle style, float height) => FoldoutMaster(foldout, guiContent, style, height);

			public static GUIEvent Foldout(bool foldout, GUIContent guiContent, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, guiContent, FoldoutStyle, options);

			public static GUIEvent Foldout(bool foldout, GUIContent guiContent, float height, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, guiContent, FoldoutStyle, height, options);

			public static GUIEvent Foldout(bool foldout, GUIContent guiContent, GUIStyle style, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, guiContent, style, options);

			public static GUIEvent Foldout(bool foldout, GUIContent guiContent, GUIStyle style, float height, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, guiContent, style, height, options);
			#endregion

			#region Texture
			public static GUIEvent Foldout(bool foldout, Texture texture) => FoldoutMaster(foldout, new GUIContent(texture), FoldoutStyle);
			public static GUIEvent Foldout(bool foldout, Texture texture, float height) => FoldoutMaster(foldout, new GUIContent(texture), FoldoutStyle, height);

			public static GUIEvent Foldout(bool foldout, Texture texture, GUIStyle style) => FoldoutMaster(foldout, new GUIContent(texture), style);
			public static GUIEvent Foldout(bool foldout, Texture texture, GUIStyle style, float height) => FoldoutMaster(foldout, new GUIContent(texture), style, height);

			public static GUIEvent Foldout(bool foldout, Texture texture, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, new GUIContent(texture), FoldoutStyle, options);

			public static GUIEvent Foldout(bool foldout, Texture texture, float height, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, new GUIContent(texture), FoldoutStyle, height, options);

			public static GUIEvent Foldout(bool foldout, Texture texture, GUIStyle style, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, new GUIContent(texture), style, options);

			public static GUIEvent Foldout(bool foldout, Texture texture, GUIStyle style, float height, params GUILayoutOption[] options) =>
					FoldoutMaster(foldout, new GUIContent(texture), style, height, options);
			#endregion
			#endregion
		}
	}
}