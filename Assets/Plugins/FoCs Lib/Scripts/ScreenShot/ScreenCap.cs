using System.IO;
using UnityEngine;

namespace ForestOfChaosLib.ScreenCap
{
	public static class ScreenCap
	{

		public static void TakeScreenShot()
		{
			TakeScreenShot(ScreenShotArgs.GetUnityCap());
		}

		public static byte[][] TakeScreenShot(params ScreenShotArgs[] screenShotArgs)
		{
			var array = new byte[screenShotArgs.Length][];
			for(var i = 0; i < screenShotArgs.Length; i++)
			{
				var args = screenShotArgs[i];
				byte[] bA;
				TakeScreenShot(args, out bA);
				array[i] = bA;
			}
			return array;
		}

		public static void TakeScreenShot(ScreenShotArgs screenShotArgs)
		{
			//TODO: Fix platform spaciffic url


			if(screenShotArgs.UseUnityCap)
			{
				ScreenCapture.CaptureScreenshot(screenShotArgs.GetFileName(), screenShotArgs.ResolutionMultiplier);
				return;
			}

			var rt = new RenderTexture(screenShotArgs.FrameWidth, screenShotArgs.FrameHeight, 24);
			screenShotArgs.Cam.targetTexture = rt;

			var tFormat = screenShotArgs.ClearBackground?
				TextureFormat.RGBA32 :
				TextureFormat.RGB24;

			var screenShot = new Texture2D(screenShotArgs.FrameWidth, screenShotArgs.FrameHeight, tFormat, false);
			screenShotArgs.Cam.Render();
			RenderTexture.active = rt;
			screenShot.ReadPixels(new Rect(0, 0, screenShotArgs.FrameWidth, screenShotArgs.FrameHeight), 0, 0);
			screenShotArgs.Cam.targetTexture = null;
			RenderTexture.active = null;
			var bytes = screenShot.EncodeToPNG();
			if(screenShotArgs.SaveFile)
			{
				CreateFolder(screenShotArgs.Path);
				var filename = screenShotArgs.GetFileNameAndPath();
				File.WriteAllBytes(filename, bytes);
			}
		}

		public static void TakeScreenShot(ScreenShotArgs screenShotArgs, out byte[] bytes)
		{
			if(screenShotArgs.UseUnityCap)
			{
				ScreenCapture.CaptureScreenshot(screenShotArgs.GetFileName(), screenShotArgs.ResolutionMultiplier);
				bytes = null;
				return;
			}

			var rt = new RenderTexture(screenShotArgs.FrameWidth, screenShotArgs.FrameHeight, 24);
			screenShotArgs.Cam.targetTexture = rt;

			var tFormat = screenShotArgs.ClearBackground?
				TextureFormat.RGBA32 :
				TextureFormat.RGB24;

			var screenShot = new Texture2D(screenShotArgs.FrameWidth, screenShotArgs.FrameHeight, tFormat, false);
			screenShotArgs.Cam.Render();
			RenderTexture.active = rt;
			screenShot.ReadPixels(new Rect(0, 0, screenShotArgs.FrameWidth, screenShotArgs.FrameHeight), 0, 0);
			screenShotArgs.Cam.targetTexture = null;
			RenderTexture.active = null;
			bytes = screenShot.EncodeToPNG();
			if(screenShotArgs.SaveFile)
			{
				CreateFolder(screenShotArgs.Path);
				var filename = screenShotArgs.GetFileNameAndPath();
				File.WriteAllBytes(filename, bytes);
			}
		}

		private static void CreateFolder(string path)
		{
			Directory.CreateDirectory(path);
		}
	}
}