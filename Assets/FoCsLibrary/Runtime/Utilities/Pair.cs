#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: Pair.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System.Collections.Generic;

public static class Pair {
    public static KeyValuePair<T1, T1> Create<T1>(T1 one, T1 two) => new KeyValuePair<T1, T1>(one, two);

    public static KeyValuePair<T1, T2> Create<T1, T2>(T1 one, T2 two) => new KeyValuePair<T1, T2>(one, two);

    public static KeyValuePair<KeyValuePair<T1, T2>, T3> Create<T1, T2, T3>(T1 one, T2 two, T3 three) => new KeyValuePair<KeyValuePair<T1, T2>, T3>(Create(one, two), three);
}