using UnityEngine;

namespace ForestOfChaosLib.Textures
{
	public static class DevTextureGenerator
	{
		public static Texture2D GenerateDevTexture(int size, Color A, Color B, FilterMode texFilterMode = FilterMode.Point)
		{
			var tex = new Texture2D(size, size) {filterMode = texFilterMode};
			tex.SetPixels(new Color[] {A, B, B, A});
			tex.Apply();
			return tex;
		}
	}
}