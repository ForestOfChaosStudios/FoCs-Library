using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.ImGUI
{
	public class FoCsGUILayout
	{
		#region Label
		public static GUIStyle LabelStyle { get; } = GUI.skin.label;

		private static FoCsGUIEvent LabelMaster(GUIContent guiContent, GUIStyle style) => LabelMaster(guiContent, style, FoCsEditorUtilities.SingleLine);

		private static FoCsGUIEvent LabelMaster(GUIContent guiContent, GUIStyle style, params GUILayoutOption[] options) =>
				LabelMaster(guiContent, style, FoCsEditorUtilities.SingleLine, options);

		private static FoCsGUIEvent LabelMaster(GUIContent guiContent, GUIStyle style, float height)
		{
			var rect = EditorGUILayout.GetControlRect(guiContent != GUIContent.none, height, style);
			return FoCsGUI.Label(rect, guiContent, style);
		}

		private static FoCsGUIEvent LabelMaster(GUIContent guiContent, GUIStyle style, float height, params GUILayoutOption[] options)
		{
			var rect = EditorGUILayout.GetControlRect(guiContent != GUIContent.none, height, style, options);
			return FoCsGUI.Label(rect, guiContent, style);
		}

		#region NoLabel
		public static FoCsGUIEvent Label() => LabelMaster(GUIContent.none, LabelStyle);
		public static FoCsGUIEvent Label(float height) => LabelMaster(GUIContent.none, LabelStyle, height);

		public static FoCsGUIEvent Label(GUIStyle style) => LabelMaster(GUIContent.none, style);
		public static FoCsGUIEvent Label(GUIStyle style, float height) => LabelMaster(GUIContent.none, style, height);

		public static FoCsGUIEvent Label(params GUILayoutOption[] options) => LabelMaster(GUIContent.none, LabelStyle, options);
		public static FoCsGUIEvent Label(float height, params GUILayoutOption[] options) => LabelMaster(GUIContent.none, LabelStyle, height, options);

		public static FoCsGUIEvent Label(GUIStyle style, params GUILayoutOption[] options) => LabelMaster(GUIContent.none, style, options);
		public static FoCsGUIEvent Label(GUIStyle style, float height, params GUILayoutOption[] options) => LabelMaster(GUIContent.none, style, height, options);
		#endregion

		#region StringLabel
		public static FoCsGUIEvent Label(string label) => LabelMaster(new GUIContent(label), LabelStyle);
		public static FoCsGUIEvent Label(string label, float height) => LabelMaster(new GUIContent(label), LabelStyle, height);

		public static FoCsGUIEvent Label(string label, GUIStyle style) => LabelMaster(new GUIContent(label), style);
		public static FoCsGUIEvent Label(string label, GUIStyle style, float height) => LabelMaster(new GUIContent(label), style, height);

		public static FoCsGUIEvent Label(string label, params GUILayoutOption[] options) => LabelMaster(new GUIContent(label), LabelStyle, options);

		public static FoCsGUIEvent Label(string label, float height, params GUILayoutOption[] options) =>
				LabelMaster(new GUIContent(label), LabelStyle, height, options);

		public static FoCsGUIEvent Label(string label, GUIStyle style, params GUILayoutOption[] options) => LabelMaster(new GUIContent(label), style, options);

		public static FoCsGUIEvent Label(string label, GUIStyle style, float height, params GUILayoutOption[] options) =>
				LabelMaster(new GUIContent(label), style, height, options);
		#endregion

		#region GUIContentLabel
		public static FoCsGUIEvent Label(GUIContent guiContent) => LabelMaster(guiContent, LabelStyle);
		public static FoCsGUIEvent Label(GUIContent guiContent, float height) => LabelMaster(guiContent, LabelStyle, height);

		public static FoCsGUIEvent Label(GUIContent guiContent, GUIStyle style) => LabelMaster(guiContent, style);
		public static FoCsGUIEvent Label(GUIContent guiContent, GUIStyle style, float height) => LabelMaster(guiContent, style, height);

		public static FoCsGUIEvent Label(GUIContent guiContent, params GUILayoutOption[] options) => LabelMaster(guiContent, LabelStyle, options);

		public static FoCsGUIEvent Label(GUIContent guiContent, float height, params GUILayoutOption[] options) =>
				LabelMaster(guiContent, LabelStyle, height, options);

		public static FoCsGUIEvent Label(GUIContent guiContent, GUIStyle style, params GUILayoutOption[] options) => LabelMaster(guiContent, style, options);

		public static FoCsGUIEvent Label(GUIContent guiContent, GUIStyle style, float height, params GUILayoutOption[] options) =>
				LabelMaster(guiContent, style, height, options);
		#endregion

		#region Texture
		public static FoCsGUIEvent Label(Texture texture) => LabelMaster(new GUIContent(texture), LabelStyle);
		public static FoCsGUIEvent Label(Texture texture, float height) => LabelMaster(new GUIContent(texture), LabelStyle, height);

		public static FoCsGUIEvent Label(Texture texture, GUIStyle style) => LabelMaster(new GUIContent(texture), style);
		public static FoCsGUIEvent Label(Texture texture, GUIStyle style, float height) => LabelMaster(new GUIContent(texture), style, height);

		public static FoCsGUIEvent Label(Texture texture, params GUILayoutOption[] options) => LabelMaster(new GUIContent(texture), LabelStyle, options);

		public static FoCsGUIEvent Label(Texture texture, float height, params GUILayoutOption[] options) =>
				LabelMaster(new GUIContent(texture), LabelStyle, height, options);

		public static FoCsGUIEvent Label(Texture texture, GUIStyle style, params GUILayoutOption[] options) => LabelMaster(new GUIContent(texture), style, options);

		public static FoCsGUIEvent Label(Texture texture, GUIStyle style, float height, params GUILayoutOption[] options) =>
				LabelMaster(new GUIContent(texture), style, height, options);
		#endregion
		#endregion

		#region Button
		public static GUIStyle ButtonStyle { get; } = GUI.skin.button;

		private static FoCsGUIEvent ButtonMaster(GUIContent guiContent, GUIStyle style) => ButtonMaster(guiContent, style, FoCsEditorUtilities.SingleLine);

		private static FoCsGUIEvent ButtonMaster(GUIContent guiContent, GUIStyle style, params GUILayoutOption[] options) =>
				ButtonMaster(guiContent, style, FoCsEditorUtilities.SingleLine, options);

		private static FoCsGUIEvent ButtonMaster(GUIContent guiContent, GUIStyle style, float height)
		{
			var rect = EditorGUILayout.GetControlRect(guiContent != GUIContent.none, height, style);
			return FoCsGUI.Button(rect, guiContent, style);
		}

		private static FoCsGUIEvent ButtonMaster(GUIContent guiContent, GUIStyle style, float height, params GUILayoutOption[] options)
		{
			var rect = EditorGUILayout.GetControlRect(guiContent != GUIContent.none, height, style, options);
			return FoCsGUI.Button(rect, guiContent, style);
		}

		#region NoLabel
		public static FoCsGUIEvent Button() => ButtonMaster(GUIContent.none, ButtonStyle);
		public static FoCsGUIEvent Button(float height) => ButtonMaster(GUIContent.none, ButtonStyle, height);

		public static FoCsGUIEvent Button(GUIStyle style) => ButtonMaster(GUIContent.none, style);
		public static FoCsGUIEvent Button(GUIStyle style, float height) => ButtonMaster(GUIContent.none, style, height);

		public static FoCsGUIEvent Button(params GUILayoutOption[] options) => ButtonMaster(GUIContent.none, ButtonStyle, options);
		public static FoCsGUIEvent Button(float height, params GUILayoutOption[] options) => ButtonMaster(GUIContent.none, ButtonStyle, height, options);

		public static FoCsGUIEvent Button(GUIStyle style, params GUILayoutOption[] options) => ButtonMaster(GUIContent.none, style, options);
		public static FoCsGUIEvent Button(GUIStyle style, float height, params GUILayoutOption[] options) => ButtonMaster(GUIContent.none, style, height, options);
		#endregion

		#region StringLabel
		public static FoCsGUIEvent Button(string label) => ButtonMaster(new GUIContent(label), ButtonStyle);
		public static FoCsGUIEvent Button(string label, float height) => ButtonMaster(new GUIContent(label), ButtonStyle, height);

		public static FoCsGUIEvent Button(string label, GUIStyle style) => ButtonMaster(new GUIContent(label), style);
		public static FoCsGUIEvent Button(string label, GUIStyle style, float height) => ButtonMaster(new GUIContent(label), style, height);

		public static FoCsGUIEvent Button(string label, params GUILayoutOption[] options) => ButtonMaster(new GUIContent(label), ButtonStyle, options);

		public static FoCsGUIEvent Button(string label, float height, params GUILayoutOption[] options) =>
				ButtonMaster(new GUIContent(label), ButtonStyle, height, options);

		public static FoCsGUIEvent Button(string label, GUIStyle style, params GUILayoutOption[] options) => ButtonMaster(new GUIContent(label), style, options);

		public static FoCsGUIEvent Button(string label, GUIStyle style, float height, params GUILayoutOption[] options) =>
				ButtonMaster(new GUIContent(label), style, height, options);
		#endregion

		#region GUIContentLabel
		public static FoCsGUIEvent Button(GUIContent guiContent) => ButtonMaster(guiContent, ButtonStyle);
		public static FoCsGUIEvent Button(GUIContent guiContent, float height) => ButtonMaster(guiContent, ButtonStyle, height);

		public static FoCsGUIEvent Button(GUIContent guiContent, GUIStyle style) => ButtonMaster(guiContent, style);
		public static FoCsGUIEvent Button(GUIContent guiContent, GUIStyle style, float height) => ButtonMaster(guiContent, style, height);

		public static FoCsGUIEvent Button(GUIContent guiContent, params GUILayoutOption[] options) => ButtonMaster(guiContent, ButtonStyle, options);

		public static FoCsGUIEvent Button(GUIContent guiContent, float height, params GUILayoutOption[] options) =>
				ButtonMaster(guiContent, ButtonStyle, height, options);

		public static FoCsGUIEvent Button(GUIContent guiContent, GUIStyle style, params GUILayoutOption[] options) => ButtonMaster(guiContent, style, options);

		public static FoCsGUIEvent Button(GUIContent guiContent, GUIStyle style, float height, params GUILayoutOption[] options) =>
				ButtonMaster(guiContent, style, height, options);
		#endregion

		#region Texture
		public static FoCsGUIEvent Button(Texture texture) => ButtonMaster(new GUIContent(texture), ButtonStyle);
		public static FoCsGUIEvent Button(Texture texture, float height) => ButtonMaster(new GUIContent(texture), ButtonStyle, height);

		public static FoCsGUIEvent Button(Texture texture, GUIStyle style) => ButtonMaster(new GUIContent(texture), style);
		public static FoCsGUIEvent Button(Texture texture, GUIStyle style, float height) => ButtonMaster(new GUIContent(texture), style, height);

		public static FoCsGUIEvent Button(Texture texture, params GUILayoutOption[] options) => ButtonMaster(new GUIContent(texture), ButtonStyle, options);

		public static FoCsGUIEvent Button(Texture texture, float height, params GUILayoutOption[] options) =>
				ButtonMaster(new GUIContent(texture), ButtonStyle, height, options);

		public static FoCsGUIEvent Button(Texture texture, GUIStyle style, params GUILayoutOption[] options) => ButtonMaster(new GUIContent(texture), style, options);

		public static FoCsGUIEvent Button(Texture texture, GUIStyle style, float height, params GUILayoutOption[] options) =>
				ButtonMaster(new GUIContent(texture), style, height, options);
		#endregion
		#endregion

		#region Toggle
		public static GUIStyle ToggleStyle { get; } = GUI.skin.toggle;

		private static FoCsGUIEvent ToggleMaster(bool toggle, GUIContent guiContent, GUIStyle style) =>
				ToggleMaster(toggle, guiContent, style, FoCsEditorUtilities.SingleLine);

		private static FoCsGUIEvent ToggleMaster(bool toggle, GUIContent guiContent, GUIStyle style, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, guiContent, style, FoCsEditorUtilities.SingleLine, options);

		private static FoCsGUIEvent ToggleMaster(bool toggle, GUIContent guiContent, GUIStyle style, float height)
		{
			var rect = EditorGUILayout.GetControlRect(guiContent != GUIContent.none, height, style);
			return FoCsGUI.Toggle(rect, toggle, guiContent, style);
		}

		private static FoCsGUIEvent ToggleMaster(bool toggle, GUIContent guiContent, GUIStyle style, float height, params GUILayoutOption[] options)
		{
			var rect = EditorGUILayout.GetControlRect(guiContent != GUIContent.none, height, style, options);
			return FoCsGUI.Toggle(rect, toggle, guiContent, style);
		}

		#region NoLabel
		public static FoCsGUIEvent Toggle(bool toggle) => ToggleMaster(toggle, GUIContent.none, ToggleStyle);
		public static FoCsGUIEvent Toggle(bool toggle, float height) => ToggleMaster(toggle, GUIContent.none, ToggleStyle, height);

		public static FoCsGUIEvent Toggle(bool toggle, GUIStyle style) => ToggleMaster(toggle, GUIContent.none, style);
		public static FoCsGUIEvent Toggle(bool toggle, GUIStyle style, float height) => ToggleMaster(toggle, GUIContent.none, style, height);

		public static FoCsGUIEvent Toggle(bool toggle, params GUILayoutOption[] options) => ToggleMaster(toggle, GUIContent.none, ToggleStyle, options);

		public static FoCsGUIEvent Toggle(bool toggle, float height, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, GUIContent.none, ToggleStyle, height, options);

		public static FoCsGUIEvent Toggle(bool toggle, GUIStyle style, params GUILayoutOption[] options) => ToggleMaster(toggle, GUIContent.none, style, options);

		public static FoCsGUIEvent Toggle(bool toggle, GUIStyle style, float height, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, GUIContent.none, style, height, options);
		#endregion

		#region StringLabel
		public static FoCsGUIEvent Toggle(bool toggle, string label) => ToggleMaster(toggle, new GUIContent(label), ToggleStyle);
		public static FoCsGUIEvent Toggle(bool toggle, string label, float height) => ToggleMaster(toggle, new GUIContent(label), ToggleStyle, height);

		public static FoCsGUIEvent Toggle(bool toggle, string label, GUIStyle style) => ToggleMaster(toggle, new GUIContent(label), style);
		public static FoCsGUIEvent Toggle(bool toggle, string label, GUIStyle style, float height) => ToggleMaster(toggle, new GUIContent(label), style, height);

		public static FoCsGUIEvent Toggle(bool toggle, string label, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, new GUIContent(label), ToggleStyle, options);

		public static FoCsGUIEvent Toggle(bool toggle, string label, float height, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, new GUIContent(label), ToggleStyle, height, options);

		public static FoCsGUIEvent Toggle(bool toggle, string label, GUIStyle style, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, new GUIContent(label), style, options);

		public static FoCsGUIEvent Toggle(bool toggle, string label, GUIStyle style, float height, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, new GUIContent(label), style, height, options);
		#endregion

		#region GUIContentLabel
		public static FoCsGUIEvent Toggle(bool toggle, GUIContent guiContent) => ToggleMaster(toggle, guiContent, ToggleStyle);
		public static FoCsGUIEvent Toggle(bool toggle, GUIContent guiContent, float height) => ToggleMaster(toggle, guiContent, ToggleStyle, height);

		public static FoCsGUIEvent Toggle(bool toggle, GUIContent guiContent, GUIStyle style) => ToggleMaster(toggle, guiContent, style);
		public static FoCsGUIEvent Toggle(bool toggle, GUIContent guiContent, GUIStyle style, float height) => ToggleMaster(toggle, guiContent, style, height);

		public static FoCsGUIEvent Toggle(bool toggle, GUIContent guiContent, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, guiContent, ToggleStyle, options);

		public static FoCsGUIEvent Toggle(bool toggle, GUIContent guiContent, float height, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, guiContent, ToggleStyle, height, options);

		public static FoCsGUIEvent Button(bool toggle, GUIContent guiContent, GUIStyle style, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, guiContent, style, options);

		public static FoCsGUIEvent Button(bool toggle, GUIContent guiContent, GUIStyle style, float height, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, guiContent, style, height, options);
		#endregion

		#region Texture
		public static FoCsGUIEvent Toggle(bool toggle, Texture texture) => ToggleMaster(toggle, new GUIContent(texture), ToggleStyle);
		public static FoCsGUIEvent Toggle(bool toggle, Texture texture, float height) => ToggleMaster(toggle, new GUIContent(texture), ToggleStyle, height);

		public static FoCsGUIEvent Toggle(bool toggle, Texture texture, GUIStyle style) => ToggleMaster(toggle, new GUIContent(texture), style);
		public static FoCsGUIEvent Toggle(bool toggle, Texture texture, GUIStyle style, float height) => ToggleMaster(toggle, new GUIContent(texture), style, height);

		public static FoCsGUIEvent Toggle(bool toggle, Texture texture, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, new GUIContent(texture), ToggleStyle, options);

		public static FoCsGUIEvent Toggle(bool toggle, Texture texture, float height, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, new GUIContent(texture), ToggleStyle, height, options);

		public static FoCsGUIEvent Toggle(bool toggle, Texture texture, GUIStyle style, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, new GUIContent(texture), style, options);

		public static FoCsGUIEvent Toggle(bool toggle, Texture texture, GUIStyle style, float height, params GUILayoutOption[] options) =>
				ToggleMaster(toggle, new GUIContent(texture), style, height, options);
		#endregion
		#endregion
	}
}