using System.Collections.Generic;

namespace ForestOfChaosLibrary.Extensions
{
	public static class DictionaryExtensions
	{
		public static void ChangeKey<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey fromKey, TKey toKey)
		{
			var value = dic[fromKey];
			dic.Remove(fromKey);
			dic[toKey] = value;
		}
	}
}
