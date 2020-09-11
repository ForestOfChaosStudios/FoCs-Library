#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Debugging
//       File: FoCsDebug.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System.Collections.Generic;

namespace ForestOfChaosLibrary.Debugging {
    public static class FoCsDebug {
        public static Dictionary<string, Data> DataDictionary;

        static FoCsDebug() => DataDictionary = new Dictionary<string, Data>();

        public static void Log(string Key, object Data) {
            Log(Key, Data.ToString());
        }

        public static void Log(string Key, string Data) {
            if (DataDictionary.ContainsKey(Key))
                DataDictionary[Key] = FoCsDebug.Data.Build(Data, DataDictionary[Key]);
            else
                DataDictionary.Add(Key, Data);
        }

        public class Data {
            public Data   previousData;
            public float  Time;
            public string Value;

            public int Depth {
                get {
                    if (previousData == null)
                        return 0;

                    return previousData.Depth + 1;
                }
            }

            public static implicit operator Data(string input) => Build(input);

            public static Data Empty(string val = "") => new Data {Value = val, Time = 0};

            public static Data Build(string val) {
#if UNITY_EDITOR
                try {
                    return new Data {Value = val, Time = UnityEngine.Time.time};
                }
                catch {
                    return new Data {Value = val, Time = 0};
                }
#else
				return new Data {Value = val, Time = UnityEngine.Time.time};
#endif
            }

            public static Data Build(string val, Data other) {
#if UNITY_EDITOR
                try {
                    return new Data {Value = val, Time = UnityEngine.Time.time, previousData = other};
                }
                catch {
                    return new Data {Value = val, Time = 0, previousData = other};
                }
#else
				return new Data {Value = val, Time = UnityEngine.Time.time, previousData = other};
#endif
            }
        }
    }
}