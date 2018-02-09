using UnityEngine;

namespace ForestOfChaosLib.Textures
{
	public static class CircleTextureGenerator
	{
		public static Texture2D CreateCircle(int size, float radius, Color background, Color foreground, FilterMode texFilterMode)
		{
			var tex = Texture2DHelpers.SquareTexture(size);
			tex.filterMode = texFilterMode;

			tex.Apply();
			return tex;
		}

		static Color[] GetCircleArray(int size, float radius, Color background, Color foreground)
		{
			return new Color[0];
		}
	}
}