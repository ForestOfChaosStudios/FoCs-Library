#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: DictionaryExtensions.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections.Generic;

namespace ForestOfChaos.Unity.Extensions {
    public static class DictionaryExtensions {
        public static bool IsNullOrEmpty<T, T2>(this Dictionary<T, T2> dictionary) => (dictionary == null) || (dictionary.Count == 0);

        public static void ChangeKey<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey fromKey, TKey toKey) {
            var value = dic[fromKey];
            dic.Remove(fromKey);
            dic[toKey] = value;
        }
    }
}