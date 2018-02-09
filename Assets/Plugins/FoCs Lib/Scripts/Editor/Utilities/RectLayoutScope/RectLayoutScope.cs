using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.Editor.Utilities
{
	public abstract class RectLayoutScope: IDisposable, IEnumerable<Rect>
	{
		protected int CurrentIndex;
		public int Count { get; }
		public Rect Rect { get; }
		public Rect? LastRect { get; protected set; }
		public Rect FirstRect { get; protected set; }
		protected Rect NextRect { get; set; }


		protected RectLayoutScope(int count, Rect rect)
		{
			Count = count;
			Rect = rect;
			LastRect = null;
			CurrentIndex = 0;
			FirstRect = NextRect = InitNextRect();
		}

		protected abstract Rect InitNextRect();
		//{
		//	var lRect = Rect;
		//	lRect.width = Rect.width / Count;
		//	NextRect = lRect;
		//}

		protected abstract void DoNextRect();
		//{
		//	var nexRect = NextRect;
		//	nexRect.x += nexRect.width;
		//	NextRect = nexRect;
		//	++CurrentIndex;
		//}

		public Rect GetNext()
		{
			if(CurrentIndex == Count)
				throw new IndexOutOfRangeException("Trying to create a rect, that is no longer in bounds");

			LastRect = NextRect;
			var retVal = NextRect;
			DoNextRect();
			return retVal;
		}

		public void Dispose()
		{
			if(CurrentIndex != Count)
				Debug.LogWarning("You have not used all of the available Rects");
		}

		public IEnumerator<Rect> GetEnumerator()
		{
			while(CurrentIndex < Count)
			{
				yield return GetNext();
			}
			yield break;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}