#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: TextureUtilities.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System;
using UnityEngine;

namespace ForestOfChaosLibrary.Utilities {
    public static class TextureUtilities {
        public static Texture2D GetSolidTexture(Color col) {
            var tex = new Texture2D(2, 2);
            tex.SetPixels(new[] {col, col, col, col});
            tex.Apply();

            return tex;
        }

        public static Texture2D GetDevTexture(Color col, Color altColor) {
            var tex = new Texture2D(2, 2);
            tex.SetPixels(new[] {col, altColor, altColor, col});
            tex.Apply();

            return tex;
        }

        public static Texture GetRotatedTexture(Texture2D tex) {
            if (tex.width != tex.height)
                throw new Exception("Image Dimensions are not Square");

            var newTex = new Texture2D(tex.width, tex.width);
            var pixels = tex.GetPixels32();
            pixels = RotateMatrix(pixels, tex.width);
            newTex.SetPixels32(pixels);
            newTex.Apply();

            return newTex;
        }

        private static Color32[] RotateMatrix(Color32[] matrix, int n) {
            var ret = new Color32[n * n];

            for (var i = 0; i < n; ++i) {
                for (var j = 0; j < n; ++j)
                    ret[(i * n) + j] = matrix[((n - j - 1) * n) + i];
            }

            return ret;
        }

        public static Texture2D ToTexture2D(this Color col) => GetSolidTexture(col);
    }
}