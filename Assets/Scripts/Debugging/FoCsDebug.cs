using System.Collections.Generic;

namespace ForestOfChaosLib.Debugging
{
	public static class FoCsDebug
	{
		public static Dictionary<string, Data> DataDictionary;

		static FoCsDebug()
		{
			DataDictionary = new Dictionary<string, Data>();
		}

		public static void Log(string Key, object Data)
		{
			Log(Key, Data.ToString());
		}

		public static void Log(string Key, string Data)
		{
			if(DataDictionary.ContainsKey(Key))
				DataDictionary[Key] = FoCsDebug.Data.Build(Data, DataDictionary[Key]);
			else
				DataDictionary.Add(Key, Data);
		}

		public class Data
		{
			public Data   previousData;
			public float  Time;
			public string Value;
			public static Data Empty(string val = "") => new Data {Value = val, Time = 0};

			public static Data Build(string val)
			{
#if UNITY_EDITOR
				try
				{
					return new Data {Value = val, Time = UnityEngine.Time.time};
				}
				catch
				{
					return new Data {Value = val, Time = 0};
				}
#else
				return new Data {Value = val, Time = UnityEngine.Time.time};
#endif
			}

			public static Data Build(string val, Data other)
			{
#if UNITY_EDITOR
				try
				{
					return new Data {Value = val, Time = UnityEngine.Time.time, previousData = other};
				}
				catch
				{
					return new Data {Value = val, Time = 0, previousData = other};
				}
#else
				return new Data {Value = val, Time = UnityEngine.Time.time, previousData = other};
#endif
			}

			public static implicit operator Data(string input) => Build(input);
		}
	}
}
