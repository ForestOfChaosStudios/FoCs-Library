﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using ForestOfChaosLib.Editor.Tools;
using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace ForestOfChaosLib.Editor.Windows
{
	public abstract class EnumCreatorWindow<T>: FoCsWindow<T> where T: EditorWindow
	{
		protected abstract string          EnumName     { get; }
		protected abstract string          EnumNewEntry { get; }
		protected abstract string[]        EnumDefault  { get; }
		private static     ReorderableList ReorderableList;
		private static     bool            RLIsExpanded = true;
		protected          string          TagFilePath { get { return FileStrings.ASSETS_GENERATED_RAWDATA + "/" + EnumName + FileStrings.FOCS_EXTENSION; } }
		protected abstract List<string>    EnumList    { get; set; }

		public void InitList()
		{
			if(File.Exists(TagFilePath))
				EnumList = new List<string>(File.ReadAllLines(TagFilePath));
			else
			{
				EnumList = new List<string>(EnumDefault);
				WriteDataFile();
			}

#region ReorderableListInits
			ReorderableList = new ReorderableList(EnumList, typeof(string), true, true, true, true)
			{
					drawHeaderCallback = (rect) => RLIsExpanded = EditorGUI.ToggleLeft(rect, string.Format("{0}\t[{1}]", EnumName, ReorderableList.count), RLIsExpanded, EditorStyles.boldLabel),
					drawElementCallback = (Rect pos, int index, bool isActive, bool isFocused) =>
					{
						const float buttonWidth = 64f + 16;
						var         textAreaPos = pos;
						textAreaPos.width  -= buttonWidth;
						textAreaPos.height -= 2;
						textAreaPos        =  textAreaPos.ChangeY(2);
						textAreaPos.y      -= 1;
						var buttonPos = pos;
						buttonPos.x      += pos.width - buttonWidth;
						buttonPos.height -= 2;
						buttonPos.width  =  buttonWidth;
						var col = GUI.backgroundColor;
						var str = (string)ReorderableList.list[index];

						using(new EditorGUI.DisabledGroupScope(!str.DoesStringHaveInvalidChars()))
						{
							GUI.backgroundColor = str.DoesStringHaveInvalidChars()? Color.red : col;

							if(GUI.Button(buttonPos, new GUIContent("Fix Error", "This is caused by an invalid char existing in the string.")))
							{
								ReorderableList.list[index] = str.ReplaceStringHaveInvalidChars();
							}
						}

						ReorderableList.list[index] = EditorGUI.TextArea(textAreaPos, ((string)ReorderableList.list[index]));
						GUI.backgroundColor         = col;
					},
					onAddCallback = (list) =>
					{
						SaveDataFile();
						list.list.Add(EnumNewEntry);
					}
			};
#endregion ReorderableListInits
		}

		protected void DrawList()
		{
			if(ReorderableList == null)
				InitList();

			DrawReorderableList(ReorderableList);
		}

		protected void WriteDataFile()
		{
			SaveDataFile();
			CreateEnum();
		}

		private void CreateEnum()   { ScriptGenerators.CreateCountEnum(EnumName, EnumList.Select(s => s.ToUpperAllWordsAfterSpace().ReplaceWhiteSpace())); }
		private void SaveDataFile() { ScriptGenerators.WriteFile(TagFilePath, EnumList); }
	}
}