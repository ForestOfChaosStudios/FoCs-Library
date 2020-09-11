#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: UnitySettingsReader.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:04 AM
#endregion


using System.Linq;
using ForestOfChaos.Unity.Extensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.UnitySettings {
    public class UnitySettingsReader {
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
        public static SettingsFile PresetManager        = new SettingsFile("PresetManager");
        public static SettingsFile ProjectSettings      = new SettingsFile("ProjectSettings");
        public static SettingsFile QualitySettings      = new SettingsFile("QualitySettings");
        public static SettingsFile TagManager           = new SettingsFile("TagManager");
        public static SettingsFile TimeManager          = new SettingsFile("TimeManager");
        public static SettingsFile UnityConnectSettings = new SettingsFile("UnityConnectSettings");

        public static SettingsFile[] RawAssets =>
                new[] {
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
                        PresetManager,
                        ProjectSettings,
                        QualitySettings,
                        TagManager,
                        TimeManager,
                        UnityConnectSettings
                };

        public class SettingsFile {
            private Object[] _Asset;
            public  string   FileName;

            public Object[] Assets {
                get {
                    if (_Asset.IsNullOrEmpty())
                        _Asset = AssetDatabase.LoadAllAssetsAtPath($"ProjectSettings/{FileName}.asset");

                    return _Asset;
                }
            }

            public SettingsFile(string fileName) => FileName = fileName;

            public static implicit operator Object(SettingsFile input) => input.Assets.FirstOrDefault();

            public static implicit operator Object[](SettingsFile input) => input.Assets;

            public static implicit operator string(SettingsFile input) => input.FileName;

            public static implicit operator SerializedObject(SettingsFile input) => input.GetInputAxisSerializedObject();

            public static implicit operator SerializedObject[](SettingsFile input) {
                return input.Assets.Select(a => new SerializedObject(a)).ToArray();
            }

            public SerializedObject GetInputAxisSerializedObject() => new SerializedObject(Assets.FirstOrDefault());
        }
    }
}