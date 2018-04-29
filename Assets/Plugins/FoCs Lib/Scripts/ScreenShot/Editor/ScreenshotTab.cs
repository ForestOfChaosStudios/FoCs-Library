using ForestOfChaosLib.Editor.ImGUI;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;
using UnityEngine;
using UCamera = UnityEngine.Camera;

//TODO: Move this to usable in gameplay, by making a non editor script, that this calls
namespace ForestOfChaosLib.ScreenCap
{
	public class ScreenshotTab: Tab<ScreenCapWindow>
	{
		private int HighResWidth = 1920;
		private int HighResHeight = 1080;
		private int scale = 1;
		private bool unityCapping = true;
		public UCamera myCamera;

		private static string defaultPath = "";

		private static string path = "";

		private static string filename = "";


		private static bool isTransparent;

		public override string TabName => "Screenshot";

		public override void DrawTab(Window<ScreenCapWindow> owner)
		{
			CheckPath();
			using(FoCsEditorDisposables.HorizontalScope(EditorStyles.toolbar))
			{
				if(FoCsGUILayout.Toggle(unityCapping,"Use Unity Capture", EditorStyles.toolbarButton))
				{
					unityCapping = true;
				}
				if(FoCsGUILayout.Toggle(!unityCapping,"Capture From Camera", EditorStyles.toolbarButton))
				{
					unityCapping = false;
				}
			}

			using(FoCsEditorDisposables.HorizontalScope())
			{
				using(FoCsEditorDisposables.HorizontalScope(GUILayout.Width(50f)))
				{
					EditorGUILayout.Space();
				}
				using(FoCsEditorDisposables.VerticalScope())
				{
					if(unityCapping)
						UnityCap();
					else
						CameraCap();

					using(FoCsEditorDisposables.HorizontalScope())
					{
						DrawTakeImageGUI();
					}
				}
				using(FoCsEditorDisposables.HorizontalScope(GUILayout.Width(50f)))
				{
					EditorGUILayout.Space();
				}
			}
		}

		private void UnityCap()
		{
			DrawScale();
			FileName();
		}

		private void CameraCap()
		{
			DrawResolutionGUI();
			FileName();
			DrawCameraOptionsGUI();

			DrawFilePathGUI();

			EditorGUILayout.LabelField($"Screenshot will be taken at {HighResWidth * scale} x {HighResHeight * scale} px", EditorStyles.boldLabel);
		}

		private static void CheckPath()
		{
			if(path == "")
			{
				path = defaultPath = Application.persistentDataPath + @"/Screenshots";
			}
		}

		private static void FileName()
		{
			using(FoCsEditorDisposables.VerticalScope(GUI.skin.box))
			{
				EditorGUILayout.LabelField("File Name (Leave blank for name to be the date/time)");
				filename = EditorGUILayout.TextField(filename, GUILayout.ExpandWidth(true));
			}
		}

		private static void DrawFilePathGUI()
		{
			using(FoCsEditorDisposables.HorizontalScope())
			{
				GUILayout.Label("Save Path", EditorStyles.boldLabel);
			}

			EditorGUILayout.TextField(path, GUILayout.ExpandWidth(true));

			using(FoCsEditorDisposables.HorizontalScope())
			{
				if(GUILayout.Button("Browse"))
					path = EditorUtility.SaveFolderPanel("Path to Save Images", path, Application.dataPath);
				if(GUILayout.Button("Default", GUILayout.Width(120)))
					path = defaultPath;
			}
		}

		private void DrawCameraOptionsGUI()
		{
			GUILayout.Label("Select Camera", EditorStyles.boldLabel);

			myCamera = EditorGUILayout.ObjectField(myCamera, typeof(UCamera), true, null) as UCamera ?? UCamera.main;

			isTransparent = EditorGUILayout.Toggle("Transparent Background", isTransparent);
		}

		private void DrawResolutionGUI()
		{
			EditorGUILayout.LabelField("Resolution", EditorStyles.boldLabel);
			using (FoCsEditorDisposables.HorizontalScope())
			{
				HighResWidth = EditorGUILayout.IntField("Width", HighResWidth);
				HighResHeight = EditorGUILayout.IntField("Height", HighResHeight);
			}
			DrawImageSizeGUI();
			DrawScale();
		}

		private void DrawScale()
		{
			scale = EditorGUILayout.IntSlider("Scale", scale, 0, 8);
		}

		private void DrawImageSizeGUI()
		{
			using(FoCsEditorDisposables.HorizontalScope())
			{
				if(GUILayout.Button("Set To Screen Size"))
				{
					HighResHeight = (int)Handles.GetMainGameViewSize().y;
					HighResWidth = (int)Handles.GetMainGameViewSize().x;
				}

				if(GUILayout.Button("Default Size"))
				{
					HighResHeight = 1080;
					HighResWidth = 1920;
					scale = 1;
				}
			}
		}

		private void DrawTakeImageGUI()
		{
			if(GUILayout.Button("Take Screenshot", GUILayout.MinHeight(40)))
			{
				if(path == "")
				{
					path = EditorUtility.SaveFolderPanel("Path to Save Images", path, Application.persistentDataPath);
					Debug.Log("Path Set");
					TakeScreenShot();
				}
				else
				{
					TakeScreenShot();
				}
			}

			if(GUILayout.Button("Open Folder", GUILayout.MaxWidth(100), GUILayout.MinHeight(40)))
			{
				if(unityCapping)
					Application.OpenURL("file://" + Application.persistentDataPath);
				else
					Application.OpenURL("file://" + path);
			}
		}

		private void TakeScreenShot()
		{
			var args = new ScreenShotArgs
					   {
						   UseUnityCap = unityCapping,
						   fileName = filename,
						   FrameWidth = HighResWidth,
						   FrameHeight = HighResHeight,
						   Path = path,
						   ClearBackground = isTransparent,
						   ResolutionMultiplier = scale
					   };
			if(myCamera == null)
				myCamera = UCamera.main;
			if(myCamera == null)
				myCamera = Object.FindObjectOfType<UCamera>();

			args.Cam = myCamera;

			ScreenCap.TakeScreenShot(args);
		}
	}
}