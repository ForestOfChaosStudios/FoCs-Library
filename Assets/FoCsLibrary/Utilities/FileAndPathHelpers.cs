#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: FileAndPathHelpers.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace ForestOfChaos.Unity.Utilities {
    public static class FileAndPathHelpers {
        public static string GetStreamingAssetsPathFileData(string name) {
            var filePath = Application.streamingAssetsPath + "/" + name;

            if (filePath.Contains("://")) {
                var www = UnityWebRequest.Get(filePath);

                return www.downloadHandler.text;
            }

            return File.ReadAllText(filePath);
        }

        public static string GetStreamingAssetsPath(string name) => Application.streamingAssetsPath + "/" + name;
    }
}