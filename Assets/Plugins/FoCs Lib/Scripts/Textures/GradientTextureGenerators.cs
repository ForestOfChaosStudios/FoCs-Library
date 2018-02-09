using ForestOfChaosLib.Generics;
using ForestOfChaosLib.Types;
using UnityEngine;

namespace ForestOfChaosLib.Textures
{
	public static class GradientGenerators
	{
		public static class Square
		{
			public static Texture2D GenerateLevelsTexture(int size, float min, float max, Color forgroundColor, Color backgroundColor)
			{
				return TextureFromLevels(GenerateLevels(size, min, max), forgroundColor, backgroundColor);
			}

			public static float[,] GenerateLevels(int size, float min, float max)
			{
				float[,] map = new float[size, size];

				for(int i = 0; i < size; i++)
				{
					for(int j = 0; j < size; j++)
					{
						float x = i / (float)size * 2 - 1;
						float y = j / (float)size * 2 - 1;

						float value = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
						map[i, j] = Evaluate(Mathf.InverseLerp(min, max, value));
					}
				}

				return map;
			}

			public static float[,] GenerateLevelsNormal(int size)
			{
				float[,] map = new float[size, size];

				for(int i = 0; i < size; i++)
				{
					for(int j = 0; j < size; j++)
					{
						float x = i / (float)size * 2 - 1;
						float y = j / (float)size * 2 - 1;

						float value = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
						map[i, j] = Evaluate(value);
					}
				}

				return map;
			}
		}

		public static class Circle
		{
			public static float[,] GenerateLevels(int size, float min, float max)
			{
				float[,] map = new float[size, size];

				int halfSize = size / 2;

				for(int xL = 0; xL < size; xL++)
				{
					for(int yL = 0; yL < size; yL++)
					{
						float x = halfSize - xL;
						float y = halfSize - yL;

						float value = (Mathf.Sqrt((x * x) + (y * y)) / size);

						if(value < min)
						{
							map[xL, yL] = 0f;
						}
						else if(value > max)
						{
							map[xL, yL] = 1f;
						}
						else
							map[xL, yL] = Evaluate(Mathf.InverseLerp(min, max, value));
					}
				}
				return map;
			}

			public static Texture2D GenerateLevelsTexture(int size, float min, float max, Color forgroundColor, Color backgroundColor)
			{
				return TextureFromLevels(GenerateLevels(size, min, max), forgroundColor, backgroundColor);
			}
		}

		private static float Evaluate(float value)
		{
			float a = 3f;
			float b = 2.2f;

			return Mathf.Pow(value, a) / (Mathf.Pow(value, a) + Mathf.Pow(b - b * value, a));
		}

		public static Texture2D TextureFromLevels(float[,] levels)
		{
			return TextureFromLevels(levels, Color.white, Color.black);
		}

		public static Texture2D TextureFromLevels(float[,] levels, Color forgroundColor, Color backgroundColor)
		{
			Vector2I size = new Vector2I(levels.GetLength(0), levels.GetLength(1));

			var tex = new Texture2D(size.x, size.y);

			var array = new Color[size.x * size.y];

			for(int x = 0; x < size.x; x++)
			{
				for(int y = 0; y < size.y; y++)
				{
					array[Array2DHelpers.Get1DIndexOf2DCoords(size.x, x, y)] = Color.Lerp(forgroundColor, backgroundColor, levels[x, y]);
				}
			}
			tex.SetPixels(array);
			tex.Apply();
			return tex;
		}
	}
}