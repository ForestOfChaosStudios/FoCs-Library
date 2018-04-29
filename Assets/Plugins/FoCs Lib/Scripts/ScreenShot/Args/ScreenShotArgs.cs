using System;
using UnityEngine;

public class ScreenShotArgs
{
	public bool UseUnityCap = false;
	public Camera Cam = null;
	public int ResolutionMultiplier = 2;
	public int FrameHeight = 1080;
	public int FrameWidth = 1920;
	public bool ClearBackground = false;
	public string fileName = "";
	public bool SaveFile = false;

#if UNITY_EDITOR
	public string Path = Application.streamingAssetsPath + @"/../../../Screenshots";
#else
		public string Path
= Application.persistentDataPath + @"/Screenshots";
#endif

	public ScreenShotArgs()
	{
		Cam = Camera.main;

		ClearBackground = false;
	}

	public ScreenShotArgs(ScreenShotArgs other)
	{
		Cam = other.Cam;
		FrameHeight = other.FrameHeight;
		FrameWidth = other.FrameWidth;
		ClearBackground = other.ClearBackground;
		Path = other.Path;
	}

	public ScreenShotArgs(Camera cam)
	{
		Cam = cam;
		FrameHeight = cam.pixelHeight;
		FrameWidth = cam.pixelWidth;
		ClearBackground = false;
		SaveFile = false;
	}

	public ScreenShotArgs(Camera cam, int frameHeight, int frameWidth, bool saveFile = false, bool clearBackground = false)
	{
		Cam = cam;
		FrameHeight = frameHeight;
		FrameWidth = frameWidth;
		ClearBackground = clearBackground;
		SaveFile = saveFile;
	}

	public static ScreenShotArgs GetMainCam()
	{
		var screenShotArgs = new ScreenShotArgs
							 {
								 Cam = Camera.main
							 };
		return screenShotArgs;
	}

	public static ScreenShotArgs GetUnityCap()
	{
		var screenShotArgs = new ScreenShotArgs
							 {
								 UseUnityCap = true,
								 ResolutionMultiplier = 2
							 };
		return screenShotArgs;
	}

	public static ScreenShotArgs GetCurrentCam()
	{
		var screenShotArgs = new ScreenShotArgs
							 {
								 Cam = Camera.current
							 };
		return screenShotArgs;
	}

	public ScreenShotArgs GetScaledArg(int amount)
	{
		var shotArgs = new ScreenShotArgs(this);
		shotArgs.FrameWidth *= amount;
		shotArgs.FrameHeight *= amount;
		return shotArgs;
	}

	public virtual string GetFileName()
	{
		//TODO: Fix platform spaciffic url
		if(string.IsNullOrEmpty(fileName))
		{
			var strPath = "";

			strPath = $"/Screenshot[{DateTime.Now:yyyy-MM-dd(hh-mm-ss)}][{FrameWidth}x{FrameHeight}]px.png";

			return strPath;
		}
		return $"{fileName}.png";
	}

	public virtual string GetFileNameAndPath()
	{
		//TODO: Fix platform spaciffic url
		if(string.IsNullOrEmpty(fileName))
		{
			var strPath = "";

			strPath = $"{Path}/Screenshot[{DateTime.Now:yyyy-MM-dd(hh-mm-ss)}][{FrameWidth}x{FrameHeight}]px.png";

			return strPath;
		}
		return $"{Path}/{fileName}.png";
	}
}