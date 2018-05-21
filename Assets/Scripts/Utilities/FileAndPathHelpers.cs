using UnityEngine;
using UnityEngine.Networking;

namespace ForestOfChaosLib.Utilities
{
	public static class FileAndPathHelpers
	{
		public static string GetStreamingAssetsPathFileData(string name)
		{
			var filePath = Application.streamingAssetsPath + "/" + name;

			if(filePath.Contains("://"))
			{
				var www = UnityWebRequest.Get(filePath);
				return www.downloadHandler.text;
			}
			return System.IO.File.ReadAllText(filePath);
		}

		public static string GetStreamingAssetsPath(string name) => Application.streamingAssetsPath + "/" + name;
	}
}