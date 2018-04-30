using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.UnityScriptsExtensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.ImGUI
{
	public class FoCsGUI
	{
		#region Label
		public static GUIStyle LabelStyle { get; } = GUI.skin.label;

		private static FoCsGUIEvent LabelMaster(Rect rect, GUIContent guiContent, GUIStyle style)
		{
			var e = Event.current;
			var e1 = new Event(e);

			var data = new FoCsGUIEvent
					   {
						   Event = e1,
						   Rect = rect
					   };

			GUI.Label(rect, guiContent, style);
			return data;
		}

		#region NoLabel
		public static FoCsGUIEvent Label(Rect rect) => LabelMaster(rect, GUIContent.none, LabelStyle);
		public static FoCsGUIEvent Label(Rect rect, GUIStyle style) => LabelMaster(rect, GUIContent.none, style);
		#endregion

		#region StringLabel
		public static FoCsGUIEvent Label(Rect rect, string label) => LabelMaster(rect, new GUIContent(label), LabelStyle);
		public static FoCsGUIEvent Label(Rect rect, string label, GUIStyle style) => LabelMaster(rect, new GUIContent(label), style);
		#endregion

		#region GUIContentLabel
		public static FoCsGUIEvent Label(Rect rect, GUIContent guiContent) => LabelMaster(rect, guiContent, LabelStyle);
		public static FoCsGUIEvent Label(Rect rect, GUIContent guiContent, GUIStyle style) => LabelMaster(rect, guiContent, style);
		#endregion

		#region Texture
		public static FoCsGUIEvent Label(Rect rect, Texture texture) => LabelMaster(rect, new GUIContent(texture), LabelStyle);
		public static FoCsGUIEvent Label(Rect rect, Texture texture, GUIStyle style) => LabelMaster(rect, new GUIContent(texture), style);
		#endregion
		#endregion

		#region Button
		public static GUIStyle ButtonStyle { get; } = GUI.skin.button;

		private static FoCsGUIEvent ButtonMaster(Rect rect, GUIContent guiContent, GUIStyle style)
		{
			var e = Event.current;
			var e1 = new Event(e);

			var data = new FoCsGUIEvent
					   {
						   Event = e1,
						   Rect = rect
					   };

			GUI.Button(rect, guiContent, style);
			return data;
		}

		#region NoLabel
		public static FoCsGUIEvent Button(Rect rect) => ButtonMaster(rect, GUIContent.none, ButtonStyle);
		public static FoCsGUIEvent Button(Rect rect, GUIStyle style) => ButtonMaster(rect, GUIContent.none, style);
		#endregion

		#region StringLabel
		public static FoCsGUIEvent Button(Rect rect, string label) => ButtonMaster(rect, new GUIContent(label), ButtonStyle);
		public static FoCsGUIEvent Button(Rect rect, string label, GUIStyle style) => ButtonMaster(rect, new GUIContent(label), style);
		#endregion

		#region GUIContentLabel
		public static FoCsGUIEvent Button(Rect rect, GUIContent guiContent) => ButtonMaster(rect, guiContent, ButtonStyle);
		public static FoCsGUIEvent Button(Rect rect, GUIContent guiContent, GUIStyle style) => ButtonMaster(rect, guiContent, style);
		#endregion

		#region Texture
		public static FoCsGUIEvent Toggle(Rect rect, Texture texture) => ButtonMaster(rect, new GUIContent(texture), ButtonStyle);
		public static FoCsGUIEvent Toggle(Rect rect, Texture texture, GUIStyle style) => ButtonMaster(rect, new GUIContent(texture), style);
		#endregion
		#endregion

		#region Toggle
		public static GUIStyle ToggleStyle { get; } = GUI.skin.toggle;

		public static FoCsGUIEvent ToggleMaster(Rect rect, bool toggle, GUIContent guiContent, GUIStyle style)
		{
			var e = Event.current;
			var e1 = new Event(e);

			var data = new FoCsGUIEvent
					   {
						   Event = e1,
						   Rect = rect
					   };

			GUI.Toggle(rect, toggle, guiContent, style);
			return data;
		}

		#region NoLabel
		public static FoCsGUIEvent Toggle(Rect rect, bool toggle) => ToggleMaster(rect, toggle, GUIContent.none, ToggleStyle);
		public static FoCsGUIEvent Toggle(Rect rect, bool toggle, GUIStyle style) => ToggleMaster(rect, toggle, GUIContent.none, style);
		#endregion

		#region StringLabel
		public static FoCsGUIEvent Toggle(Rect rect, bool toggle, string label) => ToggleMaster(rect, toggle, new GUIContent(label), ToggleStyle);
		public static FoCsGUIEvent Toggle(Rect rect, bool toggle, string label, GUIStyle style) => ToggleMaster(rect, toggle, new GUIContent(label), style);
		#endregion

		#region GUIContentLabel
		public static FoCsGUIEvent Toggle(Rect rect, bool toggle, GUIContent guiContent) => ToggleMaster(rect, toggle, guiContent, ToggleStyle);
		public static FoCsGUIEvent Toggle(Rect rect, bool toggle, GUIContent guiContent, GUIStyle style) => ToggleMaster(rect, toggle, guiContent, style);
		#endregion

		#region Texture
		public static FoCsGUIEvent Toggle(Rect rect, bool toggle, Texture texture) => ToggleMaster(rect, toggle, new GUIContent(texture), ToggleStyle);
		public static FoCsGUIEvent Toggle(Rect rect, bool toggle, Texture texture, GUIStyle style) => ToggleMaster(rect, toggle, new GUIContent(texture), style);
		#endregion
		#endregion

		#region Other
		private const float MENU_BUTTON_SIZE = 16f;

		public static int DrawPropertyWithMenu(Rect position, SerializedProperty property, GUIContent label, GUIContent[] Options, int active) =>
				DrawDisabledPropertyWithMenu(false, position, property, label, Options, active);

		public static int DrawDisabledPropertyWithMenu(bool disabled, Rect position, SerializedProperty property, GUIContent label, GUIContent[] Options, int active)
		{
			var propRect = position.SetWidth(position.width - MENU_BUTTON_SIZE - 2).MoveHeight(-2);
			var rectWidth = position.x + (position.width - (MENU_BUTTON_SIZE * (EditorGUI.indentLevel + 1)));
			var menuRect = new Rect(rectWidth, position.y, position.width - rectWidth, position.height);

			using(FoCsEditorDisposables.DisabledScope(disabled))
				EditorGUI.PropertyField(propRect, property, label);

			var index = EditorGUI.Popup(menuRect, GUIContent.none, active, Options, FoCsGUIStyles.InLineOptionsMenu);
			return index;
		}
		#endregion
	}
}