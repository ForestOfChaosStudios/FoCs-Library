using System.Collections.Generic;
using System.IO;
using ForestOfChaosLib.Editor.Tools;
using ForestOfChaosLib.Editor.Windows;
using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace ForestOfChaosLib.Editor.EditorWindows
{
	[FoCsWindow]
	public class DefineManagerWindow: FoCsWindow<DefineManagerWindow>
	{
		private const  string          WindowTitle = "Define Manager";
		private static ReorderableList tagReorderableList;
		private static bool            defineRLIsExpanded = true;
		private static List<string>    DataList           = new List<string>();

		[MenuItem(FileStrings.FORESTOFCHAOS_SYSTEMS_ + WindowTitle)]
		internal static void Init()
		{
			// Get existing open window or if none, make a new one:
			GetWindowAndShow();
			Window.titleContent = new GUIContent(WindowTitle);
			InitList();
		}

		private static void InitList()
		{
			if(File.Exists(DefineManager.DefineManagerPath))
				DataList = new List<string>(File.ReadAllLines(DefineManager.DefineManagerPath));

#region ReorderableListInits
			tagReorderableList = new ReorderableList(DataList, typeof(string), true, true, true, true)
			{
					drawHeaderCallback = rect => defineRLIsExpanded = EditorGUI.ToggleLeft(rect, string.Format("{0}\t[{1}]", "Defines", tagReorderableList.count), defineRLIsExpanded, EditorStyles.boldLabel),
					drawElementCallback = (position, index, isActive, isFocused) =>
					{
						const float buttonWidth = 64f + 16;
						const float dividingGap = 16f;
						var         newPos      = position;
						newPos.height =  position.height          * 0.9f;
						newPos.y      += (position.height * 0.1f) / 2;
						var pos  = newPos;
						var pos2 = newPos;
						pos2.x     = pos.width + pos.x             + dividingGap;
						pos2.width = (pos.width * 2) - buttonWidth - dividingGap;
						var pos3 = position;
						pos3.width = buttonWidth;
						pos3.x     = pos2.x + pos2.width;
						var col = GUI.backgroundColor;
						var str = (string)tagReorderableList.list[index];

						if(str.DoesStringHaveInvalidCharsOrWhiteSpace())
						{
							GUI.backgroundColor = Color.red;

							if(GUI.Button(pos3, "Fix Error"))
								tagReorderableList.list[index] = str.ReplaceStringHaveInvalidCharsOrWhiteSpace();
						}
						else
							GUI.backgroundColor = col;

						tagReorderableList.list[index] = EditorGUI.TextArea(pos, (string)tagReorderableList.list[index]);
						GUI.backgroundColor            = col;
					},
					onCanRemoveCallback = list => list.count > 1,
					onAddCallback       = list => list.list.Add("newDefine_DEFINE"),
					onRemoveCallback = list =>
					{
						if(list.index != 0)
							list.list.RemoveAt(list.index);
					}
			};
#endregion ReorderableListInits
		}

		protected override void OnGUI()
		{
			GUILayout.Label("Please note it is not recommended to change entries you yourself did not add.", EditorStyles.boldLabel);
			DrawTags();

			if(GUILayout.Button("Write defines to disk", GUILayout.Height(32)))
			{
				WriteDataFile();
				DefineManager.Init();
				Init();
			}
		}

		private static void DrawTags()
		{
			if(tagReorderableList == null)
				Init();

			if(defineRLIsExpanded)
				DrawReorderableList(tagReorderableList);
			else
				defineRLIsExpanded = EditorGUILayout.ToggleLeft($"Defines\t[{DataList.Count}]", defineRLIsExpanded, EditorStyles.boldLabel);
		}

		private static void WriteDataFile()
		{
			ScriptGenerators.WriteFile(DefineManager.DefineManagerPath, DataList);
		}
	}
}