#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: IJson.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.JSON {
    public interface IJson {
        string ToJson();

        void FromJsonOverwrite(string data);
    }

    public interface IJson<out T>: IJson {
        T FromJson(string data);
    }

    public class JsonAble<JSON_DATA>: IJson<JSON_DATA> {
        public static JSON_DATA JsonCtor(string data) => JsonUtility.FromJson<JSON_DATA>(data);

        public string ToJson() => JsonUtility.ToJson(this, true);

        public JSON_DATA FromJson(string data) => JsonUtility.FromJson<JSON_DATA>(data);

        public void FromJsonOverwrite(string data) {
            JsonUtility.FromJsonOverwrite(data, this);
        }
    }
}