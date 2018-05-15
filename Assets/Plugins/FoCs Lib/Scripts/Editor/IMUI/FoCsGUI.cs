using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	public static partial class FoCsGUI
	{
		#region Label
		public static GUIStyle LabelStyle { get; } = Styles.UnitySkins.Label;

		private static GUIEvent LabelMaster(Rect rect, GUIContent guiContent, GUIStyle style)
		{
			var e = Event.current;
			var e1 = new Event(e);

			var data = new GUIEvent
					   {
						   Event = e1,
						   Rect = rect
					   };

			GUI.Label(rect, guiContent, style);
			return data;
		}

		#region NoLabel
		public static GUIEvent Label(Rect rect) => LabelMaster(rect, GUIContent.none, LabelStyle);
		public static GUIEvent Label(Rect rect, GUIStyle style) => LabelMaster(rect, GUIContent.none, style);
		#endregion

		#region StringLabel
		public static GUIEvent Label(Rect rect, string label) => LabelMaster(rect, new GUIContent(label), LabelStyle);
		public static GUIEvent Label(Rect rect, string label, GUIStyle style) => LabelMaster(rect, new GUIContent(label), style);
		#endregion

		#region GUIContentLabel
		public static GUIEvent Label(Rect rect, GUIContent guiContent) => LabelMaster(rect, guiContent, LabelStyle);
		public static GUIEvent Label(Rect rect, GUIContent guiContent, GUIStyle style) => LabelMaster(rect, guiContent, style);
		#endregion

		#region Texture
		public static GUIEvent Label(Rect rect, Texture texture) => LabelMaster(rect, new GUIContent(texture), LabelStyle);
		public static GUIEvent Label(Rect rect, Texture texture, GUIStyle style) => LabelMaster(rect, new GUIContent(texture), style);
		#endregion
		#endregion

		#region Button
		public static GUIStyle ButtonStyle { get; } = Styles.UnitySkins.Button;

		private static GUIEvent ButtonMaster(Rect rect, GUIContent guiContent, GUIStyle style)
		{
			var e = Event.current;
			var e1 = new Event(e);

			var data = new GUIEvent
					   {
						   Event = e1,
						   Rect = rect
					   };

			GUI.Button(rect, guiContent, style);
			return data;
		}

		#region NoLabel
		public static GUIEvent Button(Rect rect) => ButtonMaster(rect, GUIContent.none, ButtonStyle);
		public static GUIEvent Button(Rect rect, GUIStyle style) => ButtonMaster(rect, GUIContent.none, style);
		#endregion

		#region StringLabel
		public static GUIEvent Button(Rect rect, string label) => ButtonMaster(rect, new GUIContent(label), ButtonStyle);
		public static GUIEvent Button(Rect rect, string label, GUIStyle style) => ButtonMaster(rect, new GUIContent(label), style);
		#endregion

		#region GUIContentLabel
		public static GUIEvent Button(Rect rect, GUIContent guiContent) => ButtonMaster(rect, guiContent, ButtonStyle);
		public static GUIEvent Button(Rect rect, GUIContent guiContent, GUIStyle style) => ButtonMaster(rect, guiContent, style);
		#endregion

		#region Texture
		public static GUIEvent Toggle(Rect rect, Texture texture) => ButtonMaster(rect, new GUIContent(texture), ButtonStyle);
		public static GUIEvent Toggle(Rect rect, Texture texture, GUIStyle style) => ButtonMaster(rect, new GUIContent(texture), style);
		#endregion
		#endregion

		#region Toggle
		public static GUIStyle ToggleStyle { get; } = Styles.UnitySkins.Toggle;

		public static GUIEvent ToggleMaster(Rect rect, bool toggle, GUIContent guiContent, GUIStyle style)
		{
			var e = Event.current;
			var e1 = new Event(e);

			var data = new GUIEvent
					   {
						   Event = e1,
						   Rect = rect
					   };

			GUI.Toggle(rect, toggle, guiContent, style);
			return data;
		}

		#region NoLabel
		public static GUIEvent Toggle(Rect rect, bool toggle) => ToggleMaster(rect, toggle, GUIContent.none, ToggleStyle);
		public static GUIEvent Toggle(Rect rect, bool toggle, GUIStyle style) => ToggleMaster(rect, toggle, GUIContent.none, style);
		#endregion

		#region StringLabel
		public static GUIEvent Toggle(Rect rect, bool toggle, string label) => ToggleMaster(rect, toggle, new GUIContent(label), ToggleStyle);
		public static GUIEvent Toggle(Rect rect, bool toggle, string label, GUIStyle style) => ToggleMaster(rect, toggle, new GUIContent(label), style);
		#endregion

		#region GUIContentLabel
		public static GUIEvent Toggle(Rect rect, bool toggle, GUIContent guiContent) => ToggleMaster(rect, toggle, guiContent, ToggleStyle);
		public static GUIEvent Toggle(Rect rect, bool toggle, GUIContent guiContent, GUIStyle style) => ToggleMaster(rect, toggle, guiContent, style);
		#endregion

		#region Texture
		public static GUIEvent Toggle(Rect rect, bool toggle, Texture texture) => ToggleMaster(rect, toggle, new GUIContent(texture), ToggleStyle);
		public static GUIEvent Toggle(Rect rect, bool toggle, Texture texture, GUIStyle style) => ToggleMaster(rect, toggle, new GUIContent(texture), style);
		#endregion
		#endregion

		#region Foldout
		public static GUIStyle FoldoutStyle { get; } = Styles.UnitySkins.Foldout;

		public static GUIEvent FoldoutMaster(Rect rect, bool foldout, GUIContent guiContent, GUIStyle style)
		{
			var e = Event.current;
			var e1 = new Event(e);

			var data = new GUIEvent
					   {
						   Event = e1,
						   Rect = rect
					   };

			EditorGUI.Foldout(rect, foldout, guiContent, style);
			return data;
		}

		#region NoLabel
		public static GUIEvent Foldout(Rect rect, bool foldout) => FoldoutMaster(rect, foldout, GUIContent.none, FoldoutStyle);
		public static GUIEvent Foldout(Rect rect, bool foldout, GUIStyle style) => FoldoutMaster(rect, foldout, GUIContent.none, style);
		#endregion

		#region StringLabel
		public static GUIEvent Foldout(Rect rect, bool foldout, string label) => FoldoutMaster(rect, foldout, new GUIContent(label), FoldoutStyle);
		public static GUIEvent Foldout(Rect rect, bool foldout, string label, GUIStyle style) => FoldoutMaster(rect, foldout, new GUIContent(label), style);
		#endregion

		#region GUIContentLabel
		public static GUIEvent Foldout(Rect rect, bool foldout, GUIContent guiContent) => FoldoutMaster(rect, foldout, guiContent, FoldoutStyle);
		public static GUIEvent Foldout(Rect rect, bool foldout, GUIContent guiContent, GUIStyle style) => FoldoutMaster(rect, foldout, guiContent, style);
		#endregion

		#region Texture
		public static GUIEvent Foldout(Rect rect, bool foldout, Texture texture) => FoldoutMaster(rect, foldout, new GUIContent(texture), FoldoutStyle);
		public static GUIEvent Foldout(Rect rect, bool foldout, Texture texture, GUIStyle style) => FoldoutMaster(rect, foldout, new GUIContent(texture), style);
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

			using(FoCsEditor.Disposables.DisabledScope(disabled))
				EditorGUI.PropertyField(propRect, property, label);

			var index = EditorGUI.Popup(menuRect, GUIContent.none, active, Options, Styles.InLineOptionsMenu);
			return index;
		}
		#endregion
	}
}