using UnityEngine;

namespace ForestOfChaosLibrary.ScreenCap
{
	public static class ScreenCap
	{
		public static void TakeScreenShot()
		{
			TakeScreenShot(ScreenShotArgs.GetUnityCap());
		}

		public static void TakeScreenShot(ScreenShotArgs screenShotArgs)
		{
			ScreenCapture.CaptureScreenshot(screenShotArgs.GetFileNameAndPath(), screenShotArgs.ResolutionMultiplier);
		}
	}
}
