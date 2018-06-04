using UnityEngine;

namespace ForestOfChaosLib.JSON
{
	public interface IJson
	{
		string ToJson();
		void FromJsonOverwrite(string data);
	}

	public interface IJson<out T>: IJson
	{
		T FromJson(string data);
	}

	public class JsonAble<JSON_DATA>: IJson<JSON_DATA>
	{
		public static JSON_DATA JsonCtor(string data) => JsonUtility.FromJson<JSON_DATA>(data);
		public string ToJson() => JsonUtility.ToJson(this, true);
		public JSON_DATA FromJson(string data) => JsonUtility.FromJson<JSON_DATA>(data);

		public void FromJsonOverwrite(string data)
		{
			JsonUtility.FromJsonOverwrite(data, this);
		}
	}
}
