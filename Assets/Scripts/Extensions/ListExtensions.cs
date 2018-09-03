﻿using System;
using System.Collections.Generic;
using System.Linq;
using URandom = UnityEngine.Random;
using SRandom = System.Random;

namespace ForestOfChaosLib.Extensions
{
	public static class ListExtenstions
	{
		public static bool IsEmpty<T>(this       List<T> list) => list.Count == 0;
		public static bool NotEmpty<T>(this      List<T> list) => list.Count > 0;
		public static bool IsNullOrEmpty<T>(this List<T> list) => (list == null) || (list.Count == 0);

		public static IList<T> Clone<T>(this IList<T> listToClone) where T: ICloneable
		{
			return listToClone.Select(item => (T)item.Clone()).ToList();
		}

		public static bool InRange<T>(this List<T> list, int index)
		{
			if(list.IsNullOrEmpty())
				return false;

			return (index >= 0) && (index < list.Count);
		}

		public static bool InRange<T>(this T[] array, int index)
		{
			if(array.IsNullOrEmpty())
				return false;

			return (index >= 0) && (index < array.Length);
		}

		public static T UnityRandomObject<T>(this T[] array)
		{
			if(array.IsNullOrEmpty())
				return default(T);

			return array[URandom.Range(0, array.Length)];
		}

		public static T UnityRandomObject<T>(this List<T> list)
		{
			if(list.IsNullOrEmpty())
				return default(T);

			return list[URandom.Range(0, list.Count)];
		}

		public static T SystemRandomObject<T>(this T[] array)
		{
			if(array.IsNullOrEmpty())
				return default(T);

			return array[new SRandom().Next(0, array.Length - 1)];
		}

		public static T SystemRandomObject<T>(this T[] array, int seed)
		{
			if(array.IsNullOrEmpty())
				return default(T);

			return array[new SRandom(seed).Next(0, array.Length - 1)];
		}

		public static T SystemRandomObject<T>(this List<T> list)
		{
			if(list.IsNullOrEmpty())
				return default(T);

			return list[new SRandom().Next(0, list.Count - 1)];
		}

		public static T SystemRandomObject<T>(this List<T> list, int seed)
		{
			if(list.IsNullOrEmpty())
				return default(T);

			return list[new SRandom(seed).Next(0, list.Count - 1)];
		}

		public static void AddWithDuplicateCheck<T>(this List<T> list, T obj)
		{
			if(!list.Contains(obj))
				list.Add(obj);
		}
	}
}
