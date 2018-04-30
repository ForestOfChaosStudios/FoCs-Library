using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.ScreenCap
{
	public class ScreenshotTab: Tab<ScreenCapWindow>
	{
		public override string TabName => "Screenshot";
		protected ScreenCapWindow Owner;

		public override void DrawTab(Window<ScreenCapWindow> owner)
		{
			Owner = owner as ScreenCapWindow;

			using(FoCsEditorDisposables.HorizontalScope())
			{
				//using(FoCsEditorDisposables.HorizontalScope(GUILayout.Width(50f)))
				//{
				//	EditorGUILayout.Space();
				//}
				using(FoCsEditorDisposables.VerticalScope())
				{
					DrawVariables();
					using(FoCsEditorDisposables.HorizontalScope())
					{
						DrawTakeImageGUI();
					}
				}
				//using(FoCsEditorDisposables.HorizontalScope(GUILayout.Width(50f)))
				//{
				//	EditorGUILayout.Space();
				//}
			}
		}

		private void DrawVariables()
		{
			DrawScale();

			//DrawFilePathGUI();
			DrawPathUI();
			DrawFileUI();
			DrawOtherVars();
			UpdateArgs();
			DrawPathAndFileUI();
		}

		public virtual void DrawOtherVars()
		{
			
		}

		private void DrawPathAndFileUI()
		{
			EditorGUILayout.LabelField($"File will be saved as \"{args.GetFileNameAndPath()}\"");
		}

		private void DrawPathUI()
		{
			using(FoCsEditorDisposables.VerticalScope(GUI.skin.box))
			{
				EditorGUILayout.LabelField("Path");
				Owner.path = EditorGUILayout.TextField(Owner.path, GUILayout.ExpandWidth(true));
			}
			PathButtons();
		}

		private void DrawFileUI()
		{
			using(FoCsEditorDisposables.VerticalScope(GUI.skin.box))
			{
				EditorGUILayout.LabelField("File Name (Leave blank for name to be the date/time)");
				Owner.filename = EditorGUILayout.TextField(Owner.filename, GUILayout.ExpandWidth(true));
			}
		}

		private void DrawFilePathGUI()
		{
			using (FoCsEditorDisposables.HorizontalScope())
			{
				GUILayout.Label("Save Path", EditorStyles.boldLabel);
			}

			EditorGUILayout.TextField(Owner.path, GUILayout.ExpandWidth(true));

			PathButtons();
		}

		private void PathButtons()
		{
			using (FoCsEditorDisposables.HorizontalScope())
			{
				if (GUILayout.Button("Browse"))
					Owner.path = EditorUtility.SaveFolderPanel("Path to Save Images", Owner.path, Application.dataPath);
				if (GUILayout.Button("Default", GUILayout.Width(120)))
					Owner.path = Owner.defaultPath;
			}
		}

		private void DrawScale()
		{
			Owner.scale = EditorGUILayout.IntSlider("Scale", Owner.scale, 0, 8);
		}

		private void DrawTakeImageGUI()
		{
			using(FoCsEditorDisposables.DisabledScope(!Application.isPlaying))
			{
				if(GUILayout.Button("Take Screenshot", GUILayout.MinHeight(40)))
				{
					if(Owner.path == "")
					{
						Owner.path = EditorUtility.SaveFolderPanel("Path to Save Images", Owner.path, Application.persistentDataPath);
						Debug.Log("Path Set");
						TakeScreenShot();
					}
					else
					{
						TakeScreenShot();
					}
				}
			}

			if(GUILayout.Button("Open Folder", GUILayout.MaxWidth(100), GUILayout.MinHeight(40)))
			{
				//Application.OpenURL("file://" + Owner.path);
				Application.OpenURL("file://" + Owner.path);
			}
		}

		ScreenShotArgs args;
		protected virtual void TakeScreenShot()
		{
			BuildArgs();

			ScreenCap.TakeScreenShot(args);
		}

		private void BuildArgs()
		{
			args = new ScreenShotArgs
				   {
					   fileName = Owner.filename,
					   Path = Owner.path,
					   ResolutionMultiplier = Owner.scale
				   };
		}

		private void UpdateArgs()
		{
			if(args == null)
				BuildArgs();
			args.fileName = Owner.filename;
			args.Path = Owner.path;
			args.ResolutionMultiplier = Owner.scale;
		}
	}
}