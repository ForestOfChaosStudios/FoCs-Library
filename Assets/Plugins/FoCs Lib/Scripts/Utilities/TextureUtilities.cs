using System;
using UnityEngine;

namespace ForestOfChaosLib.Utilities
{
	public static class TextureUtilities
	{
		public static Texture GetRotatedTexture(Texture2D tex)
		{
			if(tex.width != tex.height)
				throw new Exception("Image Dimensions are not Square");
			var newTex = new Texture2D(tex.width, tex.width);

			var pixels = tex.GetPixels32();
			pixels = RotateMatrix(pixels, tex.width);
			newTex.SetPixels32(pixels);
			newTex.Apply();
			return newTex;
		}

		private static Color32[] RotateMatrix(Color32[] matrix, int n)
		{
			var ret = new Color32[n * n];

			for(var i = 0; i < n; ++i)
			{
				for(var j = 0; j < n; ++j)
				{
					ret[i * n + j] = matrix[(n - j - 1) * n + i];
				}
			}

			return ret;
		}
	}
}