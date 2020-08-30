#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: DictionaryExtensions.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System.Collections.Generic;

namespace ForestOfChaosLibrary.Extensions {
    public static class DictionaryExtensions {
        public static bool IsNullOrEmpty<T, T2>(this Dictionary<T, T2> dictionary) => (dictionary == null) || (dictionary.Count == 0);

        public static void ChangeKey<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey fromKey, TKey toKey) {
            var value = dic[fromKey];
            dic.Remove(fromKey);
            dic[toKey] = value;
        }
    }
}