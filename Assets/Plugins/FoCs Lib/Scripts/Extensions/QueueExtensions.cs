﻿using System.Collections.Generic;

namespace ForestOfChaosLib.Extensions
{
	public static class QueueExtensions
	{
		public static T GetNextItemAndReAddItToTheEnd<T>(this Queue<T> queue)
		{
			//Get first
			var item = queue.Dequeue();
			//Re add
			queue.Enqueue(item);
			return item;
		}
	}
}