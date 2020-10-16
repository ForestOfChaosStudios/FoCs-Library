#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: FoCsAssetFinder.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using ForestOfChaos.Unity.Extensions;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;

#else
using UnityEngine;
#endif

namespace ForestOfChaos.Unity.Utilities {
    public static class FoCsAssetFinder {
        public static T[] FindAssetsByType<T>() where T: Object => FindAssetsByType(typeof(T)).Cast<T>().ToArray();

        public static Object[] FindAssetsByType(Type type) {
#if UNITY_EDITOR
            var assets = new List<Object>();
            var guids  = AssetDatabase.FindAssets($"t:{type.ToString().Replace("UnityEngine.", "")}");

            for (var i = 0; i < guids.Length; i++) {
                var assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
                var subAssets = AssetDatabase.LoadAllAssetsAtPath(assetPath);

                foreach (var subAsset in subAssets) {
                    if (subAsset.GetType() == type)
                        assets.AddWithDuplicateCheck(subAsset);
                }
            }

            return assets.ToArray();
#else
			return Resources.FindObjectsOfTypeAll(type);
#endif
        }

        public static T[] FindAssetsByTypeWithScene<T>() where T: Object => FindAssetsByTypeWithScene(typeof(T)).Cast<T>().ToArray();

        public static Object[] FindAssetsByTypeWithScene(Type type) {
#if UNITY_EDITOR
            var assets = new List<Object>();
            var guids  = AssetDatabase.FindAssets($"t:{type.ToString().Replace("UnityEngine.", "")}");

            for (var i = 0; i < guids.Length; i++) {
                var assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
                var subAssets = AssetDatabase.LoadAllAssetsAtPath(assetPath);

                foreach (var subAsset in subAssets) {
                    if (subAsset.GetType() == type)
                        assets.AddWithDuplicateCheck(subAsset);
                }
            }

            foreach (var o in Object.FindObjectsOfType(type))
                assets.AddWithDuplicateCheck(o);

            return assets.ToArray();
#else
			return Resources.FindObjectsOfTypeAll(type);
#endif
        }
    }
}