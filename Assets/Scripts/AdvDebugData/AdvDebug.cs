using System.Collections.Generic;
using UnityEngine;

//using UnityEditor;

namespace ForestOfChaosLib.AdvDebug
{
	//[InitializeOnLoad]
	public static class AdvDebug
	{
		public static Dictionary<string, DictionaryData> DataDictionary = new Dictionary<string, DictionaryData>();

		static AdvDebug()
		{
			DataDictionary = new Dictionary<string, DictionaryData>();
		}

		public static void Log(string Key, string Data)
		{
			if(DataDictionary.ContainsKey(Key))
				DataDictionary[Key] = DictionaryData.Build(Data, DataDictionary[Key]);
			else
				DataDictionary.Add(Key, DictionaryData.Build(Data));
		}

		public class DictionaryData
		{
			public string Value;
			public float Time;
			public DictionaryData previousData;

			public static DictionaryData Build(string val)
			{
#if UNITY_EDITOR
				try
				{
					if(!Application.isPlaying)
					{
						return new DictionaryData
							   {
								   Value = val,
								   Time = 0
							   };
					}
				}
				catch
				{
					return new DictionaryData
						   {
							   Value = val,
							   Time = 0
						   };
				}
#endif
				return new DictionaryData
					   {
						   Value = val,
						   Time = UnityEngine.Time.time
					   };
			}

			public static DictionaryData Build(string val, DictionaryData other)
			{
#if UNITY_EDITOR
				try
				{
					if(!Application.isPlaying)
					{
						return new DictionaryData
							   {
								   Value = val,
								   Time = 0,
								   previousData = other
							   };
					}
				}
				catch
				{
					return new DictionaryData
						   {
							   Value = val,
							   Time = 0,
							   previousData = other
						   };
				}
#endif
				return new DictionaryData
					   {
						   Value = val,
						   Time = UnityEngine.Time.time,
						   previousData = other
					   };
			}

			public static implicit operator DictionaryData(string input) => Build(input);
		}
	}
}