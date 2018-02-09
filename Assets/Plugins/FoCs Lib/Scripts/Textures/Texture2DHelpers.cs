using UnityEngine;

namespace ForestOfChaosLib.Textures
{
	public static class Texture2DHelpers
	{
		public static Texture2D SquareTexture(int size)
		{
			return new Texture2D(size, size);
		}
	}
}