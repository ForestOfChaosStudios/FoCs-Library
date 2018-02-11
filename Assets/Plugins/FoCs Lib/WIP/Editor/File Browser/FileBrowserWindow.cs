using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using ForestOfChaosLib.Editor.ImGUI;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.FileBrowser
{
	public class FileBrowserWindow: Window<FileBrowserWindow>
	{
		private const int INDEX_RANGE = 50;
		private static readonly GUIContent PathLabel = new GUIContent("Path");
		private static readonly GUIContent ButtonLabel = new GUIContent("Search Path");

		private static DirectoryInfo dir;

		private static string path = @"C:\";

		private static Vector2 scrollPosDirectories = Vector2.zero;
		private static Vector2 scrollPosFiles = Vector2.zero;

		private static int currentIndexRange;

		private static FileInfo[] FileArray;

		[MenuItem("Tools/File Browser")]
		private static void Init()
		{
			GetWindow();
		}

		protected override void DrawGUI()
		{
			using(EditorDisposables.VerticalScope(GUI.skin.box))
			{
				EditorGUILayout.LabelField("File path thiungy");
				path = EditorGUILayout.TextField(PathLabel, path);
				if(dir == null)
					FillDir();
				using(EditorDisposables.HorizontalScope(EditorStyles.toolbar))
				{
					if(FoCsGUILayout.Button(ButtonLabel, EditorStyles.toolbarButton))
						FillDir();
				}
			}
			if((dir == null) || !dir.Exists)
				return;
			DrawTitle(dir.FullName);
			using(EditorDisposables.HorizontalScope())
			{
				DrawFolders();
				DrawFiles();
			}
		}

		private static void FillDir()
		{
			if(!string.IsNullOrEmpty(path))
				dir = new DirectoryInfo(path);
			FileArray = null;
		}

		private void DrawFolders()
		{
			using(EditorDisposables.VerticalScope(GUI.skin.box, GUILayout.Width(300)))
			{
				DrawTitle("Folders");
				using(var scroll = EditorDisposables.ScrollViewScope(scrollPosDirectories, true, GUILayout.Width(300)))
				{
					if(dir.Parent != null)
					{
						if(FoCsGUILayout.Button($"Parent: {dir.Parent.Name}", EditorStyles.toolbarButton, GUILayout.Height(EditorStyles.toolbar.fixedHeight)))
						{
							SetNewDir(dir.Parent);
							return;
						}
					}
					else
					{
						using(EditorDisposables.DisabledScope(true))
						{
							if(FoCsGUILayout.Button("ROOT DIR", EditorStyles.toolbarButton, GUILayout.Height(EditorStyles.toolbar.fixedHeight)))
							{ }
						}
					}

					foreach(var directoryInfo in dir.EnumerateDirectories())
					{
						if(!FoCsGUILayout.Button(directoryInfo.Name, EditorStyles.toolbarButton, GUILayout.Height(EditorStyles.toolbar.fixedHeight)))
							continue;
						SetNewDir(directoryInfo);
						return;
					}
					scrollPosDirectories = scroll.scrollPosition;
				}
			}
		}

		private void SetNewDir(DirectoryInfo directoryInfo)
		{
			dir = directoryInfo;
			FileArray = null;
			Repaint();
		}

		private static void DrawFiles()
		{
			if(FileArray == null)
				FileArray = dir.EnumerateFiles().ToArray();

			var min = currentIndexRange * INDEX_RANGE;

			var max = min + INDEX_RANGE;
			max = Math.Min(max, FileArray.Length);
			using(EditorDisposables.VerticalScope())
			{
				DrawTitle("Files");
				using(var scroll = EditorDisposables.ScrollViewScope(scrollPosFiles, true))
				{
					for(var index = min; index < max; index++)
					{
						var fileInfo = FileArray[index];
						using(EditorDisposables.HorizontalScope(EditorStyles.toolbar))
						{
							if(FoCsGUILayout.Button(fileInfo.Name, EditorStyles.toolbarButton))
								CopyPasteUtility.CopyBuffer = fileInfo.Name;
							if(FoCsGUILayout.Button(fileInfo.Extension, EditorStyles.toolbarButton, GUILayout.Width(70)))
								CopyPasteUtility.CopyBuffer = fileInfo.Extension;
						}
					}
					scrollPosFiles = scroll.scrollPosition;
				}
				using(EditorDisposables.HorizontalScope(EditorStyles.toolbar))
				{
					using(EditorDisposables.DisabledScope(currentIndexRange <= 0))
					{
						if(FoCsGUILayout.Button("Previous", EditorStyles.toolbarButton))
							currentIndexRange = Math.Max(currentIndexRange - 1, 0);
					}
					FoCsGUILayout.Toggle(false, $"Range: {min},{max}", EditorStyles.toolbarButton);
					using(EditorDisposables.DisabledScope(max == FileArray.Length))
					{
						if(FoCsGUILayout.Button("Next", EditorStyles.toolbarButton))
						{
							currentIndexRange = currentIndexRange + 1;
						}
					}
				}
			}
		}

		private static void DrawTitle(string title)
		{
			using(EditorDisposables.HorizontalScope(GUI.skin.box))
				EditorGUILayout.SelectableLabel(title);
		}
	}
}