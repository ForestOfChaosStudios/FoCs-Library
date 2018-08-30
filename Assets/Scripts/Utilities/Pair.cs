using System.Collections.Generic;

public static class Pair
{
	public static KeyValuePair<T1, T1> Create<T1>(T1                           one, T1 two) => new KeyValuePair<T1, T1>(one, two);
	public static KeyValuePair<T1, T2> Create<T1, T2>(T1                       one, T2 two) => new KeyValuePair<T1, T2>(one, two);
	public static KeyValuePair<KeyValuePair<T1, T2>, T3> Create<T1, T2, T3>(T1 one, T2 two, T3 three) => new KeyValuePair<KeyValuePair<T1, T2>, T3>(Create(one, two), three);
}
