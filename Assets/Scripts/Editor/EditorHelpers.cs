using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEngine;
using Obj = UnityEngine.Object;

namespace ForestOfChaosLib.Editor
{
	public class EditorHelpers: FoCsEditor
	{
		private static readonly GUIContent CP_CopyContent       = new GUIContent("Copy Data",          "Copies the data.");
		private static readonly GUIContent CP_EditorCopyContent = new GUIContent("(Editor) Copy Data", "Copies the data.");
		private static readonly GUIContent CopyContent          = new GUIContent("C",                  "Copies the vectors data.");
		private static readonly GUIContent PasteContent         = new GUIContent("P",                  "Pastes the vectors data.");
		private static readonly GUIContent ResetContent         = new GUIContent("R",                  "Resets the vectors data.");

		public static Vector3 DrawVector3(string label, Vector3 vec, Vector3 defaultValue, Obj objectIAmOn, out bool GUIChanged) =>
				DrawVector3(new GUIContent(label, "The vectors X,Y,Z values."), vec, defaultValue, objectIAmOn, out GUIChanged);

		public static Vector3 DrawVector3(GUIContent label, Vector3 vec, Vector3 defaultValue, Obj objectIAmOn, out bool GUIChanged)
		{
			using(Disposables.HorizontalScope())
			{
				using(var cc = Disposables.ChangeCheck())
				{
					vec        = EditorGUILayout.Vector3Field(label, vec);
					GUIChanged = cc.changed;
				}

				var cachedGuiColor = GUI.color;

				using(Disposables.HorizontalScope(EditorStyles.toolbar))
				{
					if(GUILayout.Button(ResetContent, EditorStyles.toolbarButton, GUILayout.Width(25)))
					{
						Undo.RecordObject(objectIAmOn, "Vector 3 Reset");
						vec        = defaultValue;
						GUIChanged = true;
					}

					if(GUILayout.Button(CopyContent, EditorStyles.toolbarButton, GUILayout.Width(25)))
					{
						CopyPasteUtility.EditorCopy(vec);
					}

					if(GUILayout.Button(PasteContent, EditorStyles.toolbarButton, GUILayout.Width(25)))
					{
						Undo.RecordObject(objectIAmOn, "Vector 3 Paste");
						vec        = CopyPasteUtility.Paste<Vector3>();
						GUIChanged = true;
					}

					GUI.color = cachedGuiColor;
				}
			}

			return vec;
		}

		public static Obj CopyPastObjectButtons(Obj obj)
		{
			var canCopy       = CopyPasteUtility.CanCopy(obj);
			var canEditorCopy = CopyPasteUtility.CanEditorCopy(obj);

			if(canCopy)
			{
				var                  isType = CopyPasteUtility.IsTypeInBuffer(obj);
				FoCsGUI.GUIEventBool pasteEvent;
				var                  copyEvent = FoCsGUI.Layout.Button(CP_CopyContent, EditorStyles.toolbarButton);

				using(Disposables.ColorChanger(isType? GUI.color : Color.red))
				{
					var PasteContent = new GUIContent("Paste Data", "Pastes the data.\n" + CopyPasteUtility.CopyBuffer.Substring(0, CopyPasteUtility.CopyBuffer.Length >= 2048? 2048 : CopyPasteUtility.CopyBuffer.Length));

					if(!isType)
						PasteContent.tooltip = "Warning, this will attempt to paste any fields with the same name.\n" + PasteContent.tooltip;

					pasteEvent = FoCsGUI.Layout.Button(PasteContent, EditorStyles.toolbarButton);
				}

				if(copyEvent)
					CopyPasteUtility.Copy(obj);

				if(!pasteEvent) return obj;
				Undo.RecordObject(obj, "Before Paste Settings");
				CopyPasteUtility.Paste(ref obj);

				return obj;
			}

			if(canEditorCopy)
			{
				var                  isType = CopyPasteUtility.IsTypeInBuffer(obj);
				FoCsGUI.GUIEventBool pasteEvent;
				var                  copyEvent = FoCsGUI.Layout.Button(CP_EditorCopyContent, EditorStyles.toolbarButton);

				using(Disposables.ColorChanger(isType? GUI.color : Color.red))
				{
					var PasteContent = new GUIContent("Paste Data (Editor)", "Pastes the data.\n" + CopyPasteUtility.CopyBuffer.Substring(0, CopyPasteUtility.CopyBuffer.Length >= 2048? 2048 : CopyPasteUtility.CopyBuffer.Length));

					if(!isType)
						PasteContent.tooltip = "Warning, this will attempt to paste any fields with the same name.\n" + PasteContent.tooltip;

					pasteEvent = FoCsGUI.Layout.Button(PasteContent, EditorStyles.toolbarButton);
				}

				if(copyEvent)
					CopyPasteUtility.EditorCopy(obj);

				if(pasteEvent)
				{
					Undo.RecordObject(obj, "Before Paste Settings");
					CopyPasteUtility.EditorPaste(ref obj);
				}

			}
			return obj;
		}

		public static SerializedObject CopyPastObjectButtons(SerializedObject obj)
		{
			CopyPastObjectButtons(obj.targetObject);

			return obj;
		}

		public static void CreateAndCheckFolder(string path, string dir)
		{
			if(!AssetDatabase.IsValidFolder(path + "/" + dir))
				AssetDatabase.CreateFolder(path, dir);
		}
	}
}