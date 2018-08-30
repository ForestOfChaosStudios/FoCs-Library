using System;
using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef
{
	public abstract class RunTimeList<T>: RunTimeList
	{
		[NonSerialized] public List<T> Items = new List<T>();
		public override        int     Count => Items.Count;

		public void Add(T t)
		{
			if(!Items.Contains(t) && (t != null))
				Items.Add(t);
		}

		public void Remove(T t)
		{
			Items.Remove(t);
		}
	}

	public abstract class RunTimeList: ScriptableObject
	{
		public abstract int Count { get; }
	}
}
