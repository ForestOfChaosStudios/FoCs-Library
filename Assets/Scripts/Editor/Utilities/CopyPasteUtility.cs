using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ForestOfChaosLib.Editor.Utilities
{
	public static class CopyPasteUtility
	{
		public static string CopyBuffer
		{
			get { return EditorGUIUtility.systemCopyBuffer; }
			set { EditorGUIUtility.systemCopyBuffer = value; }
		}

		private static readonly string[] nonCopyTypes = {"MonoBehaviour", "AudioListener", "GUILayer", "FlareLayer"};

		public static bool IsEditorCopyNoEntries(string str)
		{
			foreach(var s in nonCopyTypes)
			{
				if(str.Contains(s))
					return true;
			}

			var removeTypeFromCopyBuffer = RemoveTypeFromCopyBuffer();

			switch(removeTypeFromCopyBuffer)
			{
				case "":
				case null:
				case "{}":
				case "{\n    \"MonoBehaviour\": {\n        \"m_Enabled\": true,\n        \"m_EditorHideFlags\": 0,\n        \"m_Name\": \"\",\n        \"m_EditorClassIdentifier\": \"\"\n    }\n}":
					return true;
			}

			return false;
		}
#pragma warning disable 168

		public static bool CanCopy<T>(T value)
		{
			string s;

			try
			{
				s = JsonUtility.ToJson(value, true);
			}
			catch(Exception e)
			{
				return false;
			}

			return s != "{}";
		}

		public static bool CanEditorCopy<T>(T value)
		{
			string s;

			try
			{
				s = EditorJsonUtility.ToJson(value, true);
			}
			catch(Exception e)
			{
				return false;
			}

			if(IsEditorCopyNoEntries(value.GetType().ToString()))
				return false;

			return (s != "") || (s != "{}");
		}

		private const string COPY_SPLIT   = ">||>";
		private const string COPY_SPLIT_S = COPY_SPLIT + "\n";

		public static bool EditorCopy<T>(T value)
		{
			try
			{
				CopyBuffer = value.GetType() + COPY_SPLIT_S + EditorJsonUtility.ToJson(value, true);
			}
			catch(Exception e)
			{
				return false;
			}

			return true;
		}

		public static bool Copy<T>(T value)
		{
			try
			{
				CopyBuffer = value.GetType() + COPY_SPLIT_S + JsonUtility.ToJson(value, true);
			}
			catch(Exception e)
			{
				return false;
			}

			return true;
		}

		public static T Paste<T>()
		{
			return Paste<T>(RemoveTypeFromCopyBuffer());
		}

		private static T Paste<T>(string buffer)
		{
			var value = JsonUtility.FromJson<T>(buffer);

			return value;
		}

		public static T Paste<T>(string buffer, bool checkForTypeDetails)
		{
			T value;

			if(checkForTypeDetails)
			{
				var checkedBuffer = RemoveTypeFromCopyBuffer(buffer);
				value = JsonUtility.FromJson<T>(checkedBuffer);
			}
			else
				value = JsonUtility.FromJson<T>(buffer);

			return value;
		}

		public static void Paste<T>(ref T obj)
		{
			Paste(ref obj, RemoveTypeFromCopyBuffer());
		}

		private static void Paste<T>(ref T obj, string buffer)
		{
			JsonUtility.FromJsonOverwrite(buffer, obj);
		}

		public static void Paste<T>(ref T obj, string buffer, bool checkForTypeDetails)
		{
			if(checkForTypeDetails)
			{
				var checkedBuffer = RemoveTypeFromCopyBuffer(buffer);
				JsonUtility.FromJsonOverwrite(checkedBuffer, obj);
			}
			else
				JsonUtility.FromJsonOverwrite(buffer, obj);
		}

		public static void EditorPaste<T>(ref T obj)
		{
			EditorPaste(obj, RemoveTypeFromCopyBuffer());
		}

		private static void EditorPaste<T>(ref T obj, string buffer)
		{
			EditorJsonUtility.FromJsonOverwrite(buffer, obj);
		}

		public static void EditorPaste<T>(ref T obj, string buffer, bool checkForTypeDetails)
		{
			if(checkForTypeDetails)
			{
				var checkedBuffer = RemoveTypeFromCopyBuffer(buffer);
				EditorJsonUtility.FromJsonOverwrite(checkedBuffer, obj);
			}
			else
				EditorJsonUtility.FromJsonOverwrite(buffer, obj);
		}

		public static void EditorPaste<T>(T obj)
		{
			EditorPaste(obj, RemoveTypeFromCopyBuffer());
		}

		private static void EditorPaste<T>(T obj, string buffer)
		{
			EditorJsonUtility.FromJsonOverwrite(buffer, obj);
		}

		public static void EditorPaste<T>(T obj, string buffer, bool checkForTypeDetails)
		{
			if(checkForTypeDetails)
			{
				var checkedBuffer = RemoveTypeFromCopyBuffer(buffer);
				EditorJsonUtility.FromJsonOverwrite(checkedBuffer, obj);
			}
			else
				EditorJsonUtility.FromJsonOverwrite(buffer, obj);
		}

		private const string NEEDLE = "\".*\":";

		private static bool IsValidObjectInBuffer()
		{
			return IsValidObjectInBuffer(CopyBuffer);
		}

		private static bool IsValidObjectInBuffer(string buffer)
		{
			return buffer.Contains(COPY_SPLIT_S);
		}

		public static bool IsTypeInBuffer(Object obj)
		{
			return IsTypeInBuffer(obj, CopyBuffer);
		}

		public static bool IsTypeInBuffer(Object obj, string buffer)
		{
			if(obj == null)
				return false;

			var bufferContainsAType = IsValidObjectInBuffer();

			if(!bufferContainsAType)
				return false;

			var t = obj.GetType();

			return t.ToString() == GetJSONStoredType(buffer);
		}

		private static string RemoveTypeFromCopyBuffer()
		{
			return RemoveTypeFromCopyBuffer(CopyBuffer);
		}

		public static string RemoveTypeFromCopyBuffer(string buffer)
		{
			var copyBufferSplit = buffer.Split(new[] {COPY_SPLIT_S}, StringSplitOptions.None);

			if(copyBufferSplit.Length > 1)
			{
				var list = copyBufferSplit.ToList();
				list.RemoveAt(0);

				return string.Join(string.Empty, list.ToArray());
			}

			return buffer;
		}

		public static string GetJSONStoredType(string json)
		{
			if(json.Contains('|'))
			{
				var copyBufferSplit = json.Split(new[] {COPY_SPLIT}, StringSplitOptions.None);

				return copyBufferSplit[0];
			}

			return "";
		}

#pragma warning restore 168
	}
}