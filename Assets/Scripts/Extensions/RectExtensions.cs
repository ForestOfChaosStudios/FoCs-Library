using System;
using ForestOfChaosLib.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ForestOfChaosLib.Extensions
{
	public static class RectExtensions
	{
		public static Vector2 GetRandomPosInRect(this Rect rect)
		{
			var pos = new Vector2(Random.Range(rect.min.x, rect.max.x), Random.Range(rect.min.y, rect.max.y));

			return pos;
		}
	}
}
