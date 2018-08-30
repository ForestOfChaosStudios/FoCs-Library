using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEngine;
using Obj = UnityEngine.Object;

namespace ForestOfChaosLib.Editor
{
	public class EditorHelpers: FoCsEditor
	{
		private static readonly GUIContent CP_CopyContent       = new GUIContent("Copy",     "Copies the data.");
		private static readonly GUIContent CP_EditorCopyContent = new GUIContent("Copy (E)", "Copies the data. (using the EditorJSONUtility)");
		private static readonly GUIContent CopyContent          = new GUIContent("C",        "Copies the vectors data.");
		private static readonly GUIContent PasteContent         = new GUIContent("P",        "Pastes the vectors data.");
		private static readonly GUIContent ResetContent         = new GUIContent("R",        "Resets the vectors data.");

		public static Vector3 DrawVector3(string label, Vector3 vec, Vector3 defaultValue, Obj objectIAmOn, out bool GUIChanged) =>
				DrawVector3(new GUIContent(label, "The vectors X,Y,Z values."), vec, defaultValue, objectIAmOn, out GUIChanged);

		public static Vector3 DrawVector3(GUIContent label, Vector3 vec, Vector3 defaultValue, Obj objectIAmOn, out bool GUIChanged)
		{
			using(Disposables.IndentSet(1))
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
						var resetBtn = FoCsGUI.Layout.Button(ResetContent, EditorStyles.toolbarButton, GUILayout.Width(25));
						var copyBtn  = FoCsGUI.Layout.Button(CopyContent,  EditorStyles.toolbarButton, GUILayout.Width(25));
						var pasteBtn = FoCsGUI.Layout.Button(PasteContent, EditorStyles.toolbarButton, GUILayout.Width(25));

						if(resetBtn)
						{
							Undo.RecordObject(objectIAmOn, "Vector 3 Reset");
							vec        = defaultValue;
							GUIChanged = true;
						}
						else if(copyBtn)
							CopyPasteUtility.EditorCopy(vec);
						else if(pasteBtn)
						{
							Undo.RecordObject(objectIAmOn, "Vector 3 Paste");
							vec        = CopyPasteUtility.Paste<Vector3>();
							GUIChanged = true;
						}

						GUI.color = cachedGuiColor;
					}
				}
			}

			return vec;
		}

		public static Obj CopyPastObjectButtons(Obj obj, GUIStyle style)
		{
			using(Disposables.HorizontalScope(style))
				CopyPastObjectButtons(obj);

			return obj;
		}

		public static Obj CopyPastObjectButtons(Obj obj)
		{
			var canCopy        = CopyPasteUtility.CanCopy(obj);
			var guiEnableCache = GUI.enabled;
			var copyBuff       = CopyPasteUtility.CopyBuffer;

			if(canCopy)
			{
				var                  isType = CopyPasteUtility.IsTypeInBuffer(obj, copyBuff);
				FoCsGUI.GUIEventBool pasteEvent;
				GUI.enabled = true;
				var copyEvent = FoCsGUI.Layout.Button(CP_CopyContent, EditorStyles.toolbarButton);
				GUI.enabled = guiEnableCache;

				using(Disposables.ColorChanger(isType? GUI.color : Color.red))
				{
					var PasteContent = new GUIContent("Paste", "Pastes the data.\n" + copyBuff.Substring(0, copyBuff.Length >= 512? 512 : copyBuff.Length));

					if(!isType)
						PasteContent.tooltip = "Warning, this will attempt to paste any fields with the same name.\n" + PasteContent.tooltip;

					pasteEvent = FoCsGUI.Layout.Button(PasteContent, EditorStyles.toolbarButton);
				}

				if(copyEvent)
				{
					CopyPasteUtility.Copy(obj);

					return obj;
				}

				if(!pasteEvent)
					return obj;

				Undo.RecordObject(obj, "Before Paste Settings");
				CopyPasteUtility.Paste(ref obj, copyBuff, true);

				return obj;
			}

			var canEditorCopy = CopyPasteUtility.CanEditorCopy(obj);

			if(canEditorCopy)
			{
				var                  isType = CopyPasteUtility.IsTypeInBuffer(obj, copyBuff);
				FoCsGUI.GUIEventBool pasteEvent;
				GUI.enabled = true;
				var copyEvent = FoCsGUI.Layout.Button(CP_EditorCopyContent, EditorStyles.toolbarButton);
				GUI.enabled = guiEnableCache;

				using(Disposables.ColorChanger(isType? GUI.color : Color.red))
				{
					var PasteContent = new GUIContent("Paste (E)", string.Format("Pastes the data. (using the EditorJSONUtility)\n{0}", copyBuff.Substring(0, copyBuff.Length >= 512? 512 : copyBuff.Length)));

					if(!isType)
						PasteContent.tooltip = "Warning, this will attempt to paste any fields with the same name.\n" + PasteContent.tooltip;

					pasteEvent = FoCsGUI.Layout.Button(PasteContent, EditorStyles.toolbarButton);
				}

				if(copyEvent)
				{
					CopyPasteUtility.EditorCopy(obj);

					return obj;
				}

				if(!pasteEvent)
					return obj;

				Undo.RecordObject(obj, "Before Paste Settings");
				CopyPasteUtility.EditorPaste(ref obj, copyBuff, true);
			}

			return obj;
		}

		public static SerializedObject CopyPastObjectButtons(SerializedObject obj)
		{
			CopyPastObjectButtons(obj.targetObject);

			return obj;
		}

		public static SerializedObject CopyPastObjectButtons(SerializedObject obj, GUIStyle style)
		{
			if(CopyPasteUtility.GetCopyMode(obj.targetObject) != (CopyPasteUtility.CopyMode.Unknown | CopyPasteUtility.CopyMode.None))
			{
				using(Disposables.HorizontalScope(style))
					CopyPastObjectButtons(obj.targetObject);
			}

			return obj;
		}

		public static void CreateAndCheckFolder(string path, string dir)
		{
			if(!AssetDatabase.IsValidFolder(path + "/" + dir))
				AssetDatabase.CreateFolder(path, dir);
		}
	}
}
