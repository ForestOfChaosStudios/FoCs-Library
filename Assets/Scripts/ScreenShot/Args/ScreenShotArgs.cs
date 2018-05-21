using System;
using UnityEngine;

namespace ForestOfChaosLib.ScreenCap
{
	public class ScreenShotArgs
	{
		public int ResolutionMultiplier = 2;
		public string fileName = "";

#if UNITY_EDITOR
		public string Path = Application.streamingAssetsPath + @"/../../../";
#else
		public string Path = Application.persistentDataPath + @"/Screenshots";
#endif

		public ScreenShotArgs()
		{ }

		public ScreenShotArgs(ScreenShotArgs other)
		{
			ResolutionMultiplier = other.ResolutionMultiplier;
			fileName = other.fileName;
			Path = other.Path;
		}

		public static ScreenShotArgs GetUnityCap()
		{
			var screenShotArgs = new ScreenShotArgs
								 {
									 ResolutionMultiplier = 2
								 };
			return screenShotArgs;
		}

		public virtual string GetFileName()
		{
			if(string.IsNullOrEmpty(fileName))
			{
				var strPath = $"/Screenshot[{DateTime.Now:yyyy-MM-dd(hh-mm-ss)}].png";

				return strPath;
			}
			return $"{fileName}.png";
		}

		public virtual string GetFileNameAndPath()
		{
			if(string.IsNullOrEmpty(fileName))
			{
				var strPath = $"{Path}/Screenshot[{DateTime.Now:yyyy-MM-dd(hh-mm-ss)}].png";

				return strPath;
			}
			return $"{Path}/{fileName}.png";
		}
	}
}