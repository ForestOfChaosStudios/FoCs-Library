using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace ForestOfChaosLib.IO
{
	public static class SimpleIO
	{
		public const string FILE_EXT = "FoCsdat";

		public static void LoadGameDataUnityFile<T>(string name, out T data, Func<T> defaultDataCtor, bool saveIfNotExist = true)
		{
			LoadGameDataUnityFile(name, out data, defaultDataCtor, FILE_EXT, saveIfNotExist);
		}

		public static void LoadGameDataUnityFile<T>(string name, out T data, Func<T> defaultDataCtor, string extn, bool saveIfNotExist = true)
		{
			var filepath = $"{Application.persistentDataPath}/{name}.{extn}";

			if(File.Exists(filepath))
			{
				var bf   = new BinaryFormatter();
				var file = File.Open(filepath, FileMode.Open);
				Debug.Log("Loaded : " + filepath);
				data = (T)bf.Deserialize(file);
				file.Close();
			}
			else
			{
				data = defaultDataCtor();

				if(saveIfNotExist)
					SaveGameDataUnityFile(name, data);
			}
		}

		public static void SaveGameDataUnityFile<T>(string name, T data)
		{
			SaveGameDataUnityFile(name, data, FILE_EXT);
		}

		public static void SaveGameDataUnityFile<T>(string name, T data, string extn)
		{
			var bf       = new BinaryFormatter();
			var filepath = $"{Application.persistentDataPath}/{name}.{extn}";
			var file     = File.Open(filepath, FileMode.OpenOrCreate);
			Debug.Log("Saved : " + filepath);
			bf.Serialize(file, data);
			file.Close();
		}

		public static void LoadGameDataFilepath<T>(string filepath, out T data, Func<T> defaultDataCtor, bool saveIfNotExist = true)
		{
			if(File.Exists(filepath))
			{
				var bf   = new BinaryFormatter();
				var file = File.Open(filepath, FileMode.Open);
				Debug.Log("Loaded : " + filepath);
				data = (T)bf.Deserialize(file);
				file.Close();
			}
			else
			{
				data = defaultDataCtor();

				if(saveIfNotExist)
					SaveGameDataFilepath(filepath, data);
			}
		}

		public static void SaveGameDataFilepath<T>(string filepath, T data)
		{
			var bf   = new BinaryFormatter();
			var file = File.Open(filepath, FileMode.OpenOrCreate);
			Debug.Log("Saved : " + filepath);
			bf.Serialize(file, data);
			file.Close();
		}

		public static string LoadStringUnityFile(string name) => LoadStringUnityFile(name, FILE_EXT);

		public static string LoadStringUnityFile(string name, string extn)
		{
			var filepath = $"{Application.persistentDataPath}/{name}.{extn}";
			Debug.Log("Loaded : " + filepath);

			if(File.Exists(filepath))
				return File.ReadAllText(filepath);

			return "";
		}

		public static void SaveStringUnityFile(string name, string data)
		{
			SaveStringUnityFile(name, data, FILE_EXT);
		}

		public static void SaveStringUnityFile(string name, string data, string extn)
		{
			var filepath = $"{Application.persistentDataPath}/{name}.{extn}";
			Debug.Log("Saved : " + filepath);
			File.WriteAllText(filepath, data);
		}

		public static string LoadStringFilepath(string filepath)
		{
			if(File.Exists(filepath))
			{
				Debug.Log("Loaded : " + filepath);

				return File.ReadAllText(filepath);
			}

			Debug.Log("Failed to Load : " + filepath);

			return "";
		}

		public static void SaveStringFilepath(string filepath, string data)
		{
			File.WriteAllText(filepath, data);
			Debug.Log("Saved : " + filepath);
		}
	}
}
