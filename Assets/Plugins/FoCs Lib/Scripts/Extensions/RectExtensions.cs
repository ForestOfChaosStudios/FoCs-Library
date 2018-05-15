using UnityEngine;

namespace ForestOfChaosLib.Extensions
{
	public static class RectExtensions
	{
		public static Vector2 GetRandomPosInRect(this Rect rect)
		{
			var pos = new Vector2(Random.Range(rect.min.x, rect.max.x), Random.Range(rect.min.y, rect.max.y));
			return pos;
		}

		public static Rect ChangeX(this Rect pos, float size)
		{
			pos.x += size;
			pos.width -= size;
			return pos;
		}

		public static Rect ChangeY(this Rect pos, float size)
		{
			pos.y += size;
			pos.height -= size;
			return pos;
		}

		public static Rect SetX(this Rect rect, float x)
		{
			rect.x = x;
			return rect;
		}

		public static Rect SetY(this Rect rect, float y)
		{
			rect.y = y;
			return rect;
		}

		public static Rect SetHeight(this Rect rect, float height)
		{
			rect.height = height;
			return rect;
		}

		public static Rect SetWidth(this Rect rect, float width)
		{
			rect.width = width;
			return rect;
		}

		public static Rect MoveX(this Rect rect, float x)
		{
			rect.x += x;
			return rect;
		}

		public static Rect MoveY(this Rect rect, float y)
		{
			rect.y += y;
			return rect;
		}

		public static Rect MoveHeight(this Rect rect, float height)
		{
			rect.height += height;
			return rect;
		}

		public static Rect MoveWidth(this Rect rect, float width)
		{
			rect.width += width;
			return rect;
		}

		public static Rect DivideWidth(this Rect rect, float width)
		{
			rect.width /= width;
			return rect;
		}

		public static Rect DivideHeight(this Rect rect, float height)
		{
			rect.height /= height;
			return rect;
		}

		public static Rect MultiplyWidth(this Rect rect, float width)
		{
			rect.width *= width;
			return rect;
		}

		public static Rect MultiplyHeight(this Rect rect, float height)
		{
			rect.height *= height;
			return rect;
		}

		public static Rect SetPos(this Rect rect, Vector2 newPos)
		{
			rect.x = newPos.x;
			rect.y = newPos.y;
			return rect;
		}

		public static Rect SetSize(this Rect rect, Vector2 newPos)
		{
			rect.width = newPos.x;
			rect.height = newPos.y;
			return rect;
		}

		public static Rect MovePos(this Rect rect, Vector2 newPos)
		{
			rect.x += newPos.x;
			rect.y += newPos.y;
			return rect;
		}

		public static Rect MoveSize(this Rect rect, Vector2 newPos)
		{
			rect.width += newPos.x;
			rect.height += newPos.y;
			return rect;
		}
	}
}