using System;
using System.Collections.Generic;
using ForestOfChaosLib.Types;
using ForestOfChaosLib.Extensions;

namespace ForestOfChaosLib.Generics
{
	public static class ArraysExtensions
	{
		public static T[] ShuffleArray<T>(T[] array, int seed)
		{
			var prng = new Random(seed);
			for(var i = 0; i < array.Length; i++)
			{
				var randomIndex = prng.Next(i, array.Length);
				var tempItem = array[randomIndex];
				array[randomIndex] = array[i];
				array[i] = tempItem;
			}
			return array;
		}

		public static List<T> ShuffleArray<T>(List<T> array, int seed)
		{
			var prng = new Random(seed);
			for(var i = 0; i < array.Count; i++)
			{
				var randomIndex = prng.Next(i, array.Count);
				var tempItem = array[randomIndex];
				array[randomIndex] = array[i];
				array[i] = tempItem;
			}
			return array;
		}
	}

	public static class Array2DHelpers
	{
		public static T GetElementAt2DCoords<T>(this T[] array, int width, Vector2I pos) => array[(pos.y * width) + pos.x];

		public static int Get1DIndexOf2DCoords<T>(this T[] array, int width, Vector2I pos) => (pos.y * width) + pos.x;

		public static T GetElementAt2DCoords<T>(this T[] array, int width, int x, int y) => array[(y * width) + x];

		public static int Get1DIndexOf2DCoords<T>(this T[] array, int width, int x, int y) => (y * width) + x;

		public static int GetXOfIndexOf2DArray<T>(this T[] array, int width, int index) => index % width;

		public static int GetYOfIndexOf2DArray<T>(this T[] array, int width, int index) => index / width;

		public static int Get1DIndexOf2DCoords(int width, Vector2I pos) => (pos.y * width) + pos.x;

		public static int Get1DIndexOf2DCoords(int width, int x, int y) => (y * width) + x;

		public static int Get1DIndexOf2DCoords(this Vector2I pos, int width) => (pos.y * width) + pos.x;

		public static int GetXOfIndexOf2DArray(int width, int index) => index % width;

		public static int GetYOfIndexOf2DArray(int width, int index) => index / width;

		public static Vector2I GetIndexOf2DArray(int width, int index) => new Vector2I(index % width, index / width);

		public static void ForLoop2D(int xCount, int yCount, Action<int, int> loopAction, bool includeLastNum = false)
		{
			ForLoop2D(xCount, yCount, 0, 0, loopAction, includeLastNum);
		}

		public static void ForLoop2D(int xCount, int yCount, Vector2I start, Action<int, int> loopAction, bool includeLastNum = false)
		{
			ForLoop2D(xCount, yCount, start.x, start.y, loopAction, includeLastNum);
		}

		public static void ForLoop2D(Vector2I count, Action<int, int> loopAction, bool includeLastNum = false)
		{
			ForLoop2D(count.x, count.y, 0, 0, loopAction, includeLastNum);
		}

		public static void ForLoop2D(Vector2I count, Vector2I start, Action<int, int> loopAction, bool includeLastNum = false)
		{
			ForLoop2D(count.x, count.y, start.x, start.y, loopAction, includeLastNum);
		}

		public static void ForLoop2D(Vector2I count, int yCount, int startX, int startY, Action<int, int> loopAction, bool includeLastNum = false)
		{
			ForLoop2D(count.x, count.y, startX, startY, loopAction, includeLastNum);
		}

		public static void ForLoop2D(int xCount, int yCount, int startX, int startY, Action<int, int> loopAction, bool includeLastNum = false)
		{
			if(includeLastNum)
			{
				for(var x = startX; x <= xCount; x++)
				{
					for(var y = startY; y <= yCount; y++)
						loopAction.Trigger(x, y);
				}
			}
			else
			{
				for(var x = startX; x < xCount; x++)
				{
					for(var y = startY; y < yCount; y++)
						loopAction.Trigger(x, y);
				}
			}
		}
	}
}