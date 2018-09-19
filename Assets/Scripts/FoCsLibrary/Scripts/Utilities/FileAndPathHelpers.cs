using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace ForestOfChaosLibrary.Utilities
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

			return File.ReadAllText(filePath);
		}

		public static string GetStreamingAssetsPath(string name) => Application.streamingAssetsPath + "/" + name;
	}
}
