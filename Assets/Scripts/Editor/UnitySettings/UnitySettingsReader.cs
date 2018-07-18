using System;
using UnityEditor;
using Object = UnityEngine.Object;

namespace ForestOfChaosLib.Editor.UnitySettings
{
	public class UnitySettingsReader
	{
		public static SettingsFile AudioManager         = new SettingsFile("AudioManager");
		public static SettingsFile ClusterInputManager  = new SettingsFile("ClusterInputManager");
		public static SettingsFile DynamicsManager      = new SettingsFile("DynamicsManager");
		public static SettingsFile EditorBuildSettings  = new SettingsFile("EditorBuildSettings");
		public static SettingsFile EditorSettings       = new SettingsFile("EditorSettings");
		public static SettingsFile GraphicsSettings     = new SettingsFile("GraphicsSettings");
		public static SettingsFile InputManager         = new SettingsFile("InputManager");
		public static SettingsFile NavMeshAreas         = new SettingsFile("NavMeshAreas");
		public static SettingsFile NetworkManager       = new SettingsFile("NetworkManager");
		public static SettingsFile Physics2DSettings    = new SettingsFile("Physics2DSettings");
		public static SettingsFile ProjectSettings      = new SettingsFile("ProjectSettings");
		public static SettingsFile QualitySettings      = new SettingsFile("QualitySettings");
		public static SettingsFile TagManager           = new SettingsFile("TagManager");
		public static SettingsFile TimeManager          = new SettingsFile("TimeManager");
		public static SettingsFile UnityConnectSettings = new SettingsFile("UnityConnectSettings");

		public static SettingsFile[] Assets
		{
			get
			{
				return new[]
 {
						AudioManager,
						ClusterInputManager,
						DynamicsManager,
						EditorBuildSettings,
						EditorSettings,
						GraphicsSettings,
						InputManager,
						NavMeshAreas,
						NetworkManager,
						Physics2DSettings,
						ProjectSettings,
						QualitySettings,
						TagManager,
						TimeManager,
						UnityConnectSettings
				};
			}
		}

		public class SettingsFile
		{
			private Object _Asset;
			public  string FileName;
			public Object Asset
			{
				get
				{
					if(!_Asset)
						_Asset = AssetDatabase.LoadAllAssetsAtPath(string.Format("ProjectSettings/{0}.asset", FileName))[0];

					return _Asset;
				}
			}

			public SettingsFile(string fileName)
			{
				FileName = fileName;
			}

			public static implicit operator Object(SettingsFile           input)
			{
				return input.Asset;
			}

			public static implicit operator string(SettingsFile           input)
			{
				return input.FileName;
			}

			public static implicit operator SerializedObject(SettingsFile input)
			{
				return input.GetInputAxisSerializedObject();
			}

			public                          SerializedObject GetInputAxisSerializedObject()
			{
				return new SerializedObject(Asset);
			}
		}
	}
}