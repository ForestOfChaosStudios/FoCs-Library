#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: FileAndPathHelpers.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
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