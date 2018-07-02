using System;
using System.Collections;
using System.Collections.Generic;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEngine;

namespace ForestOfChaosLib.Editor.Utilities
{
	public abstract class RectLayoutScope: IDisposable, IEnumerable<Rect>
	{
		protected int   CurrentIndex;
		public    int   Count     { get; }
		public    Rect  Rect      { get; }
		public    Rect? LastRect  { get; protected set; }
		public    Rect  FirstRect { get; protected set; }
		protected Rect  NextRect  { get; set; }

		protected RectLayoutScope(int count, Rect rect)
		{
			Count        = count;
			Rect         = rect;
			LastRect     = null;
			CurrentIndex = 0;
			FirstRect    = NextRect = InitNextRect();
		}

		protected abstract Rect InitNextRect();
		protected abstract void DoNextRect();

		/// <summary>
		///     Gets the next rect in the layout
		/// </summary>
		/// <returns>Next rect</returns>
		public Rect GetNext()
		{
			if(CurrentIndex > Count)
				throw new IndexOutOfRangeException("Trying to create a rect, that is no longer in bounds");

			LastRect = NextRect;
			var retVal = NextRect;
			DoNextRect();

			return retVal;
		}

		/// <summary>
		///     Gets the next rect in the layout with a size of "amount" elements
		/// </summary>
		/// <param name="amount">How many spaces should this take</param>
		/// <returns>Returns the Next rect, size of "amount" elements</returns>
		public Rect GetNext(int amount)
		{
			if((CurrentIndex == Count) || (CurrentIndex + amount > Count))
				throw new IndexOutOfRangeException("Trying to create a rect, that is no longer in bounds");

			LastRect = NextRect;
			var retVal = NextRect;

			retVal = DoGetNextAmount(amount, retVal);

			for(var i = 0;i < amount;i++)
				DoNextRect();

			return retVal;
		}

		protected virtual Rect DoGetNextAmount(int amount, Rect retVal)
		{
			retVal = retVal.Edit(RectEdit.SetWidth(retVal.width * amount));
			return retVal;
		}

		/// <summary>
		///     Gets the next rect in the layout
		/// </summary>
		/// <returns>Next rect</returns>
		public Rect GetNext(params RectEdit[] edits)
		{
			if(CurrentIndex > Count)
				throw new IndexOutOfRangeException("Trying to create a rect, that is no longer in bounds");

			LastRect = NextRect;
			var retVal = NextRect;
			DoNextRect();

			return retVal.Edit(edits);
		}

		/// <summary>
		///     Gets the next rect in the layout with a size of "amount" elements
		/// </summary>
		/// <param name="amount">How many spaces should this take</param>
		/// <returns>Returns the Next rect, size of "amount" elements</returns>
		public Rect GetNext(int amount, params RectEdit[] edits)
		{
			if((CurrentIndex == Count) || (CurrentIndex + amount > Count))
				throw new IndexOutOfRangeException("Trying to create a rect, that is no longer in bounds");

			LastRect = NextRect;
			var retVal = NextRect;

			for(var i = 0; i < amount; i++)
			{
				DoNextRect();
				retVal.width += NextRect.width;
			}

			return retVal.Edit(edits);
		}

		public void Dispose()
		{
			//if(CurrentIndex != Count)
			//	Debug.LogWarning("You have not used all of the available Rects");
		}

		public IEnumerator<Rect> GetEnumerator()
		{
			while(CurrentIndex < Count)
				yield return GetNext();
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
