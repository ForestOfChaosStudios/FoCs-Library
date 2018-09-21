using ForestOfChaosLibrary.ScreenCap;
using UnityEditor;

namespace ForestOfChaosLibrary.Editor.ScreenCap
{
	public class TimelapseTab: ScreenshotTab
	{
		private         Timelapse Timelapse;
		public          int       times    = 20;
		public          float     waitTime = 1;
		public override string    TabName => "Timelapse";

		public override void DrawOtherVars()
		{
			times    = EditorGUILayout.IntField("How many Captures", times);
			waitTime = EditorGUILayout.FloatField("Time Between Captures", waitTime);
		}

		protected override void TakeScreenShot()
		{
			var args = new ScreenShotArgs {fileName = Owner.filename, Path = Owner.path, ResolutionMultiplier = Owner.scale};
			Timelapse?.Stop();
			Timelapse = new Timelapse(waitTime, times, args);
		}
	}
}
