#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsEditorUtilities.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor {
    public partial class FoCsEditor {
        public static DefaultPropertyType GetDefaultPropertyType(SerializedProperty property) {
            if (property.displayName.Equals("Object Hide Flags"))
                return DefaultPropertyType.Hidden;

            if (IsDefaultScriptProperty(property))
                return DefaultPropertyType.Disabled;

            return DefaultPropertyType.NotDefault;
        }

        public static bool IsDefaultScriptProperty(SerializedProperty property) =>
                property.name.Equals("m_Script")                                  &&
                property.type.Equals("PPtr<MonoScript>")                          &&
                (property.propertyType == SerializedPropertyType.ObjectReference) &&
                property.propertyPath.Equals("m_Script");

        public static bool IsPropertyHidden(SerializedProperty property) => GetDefaultPropertyType(property) != DefaultPropertyType.NotDefault;

        public static bool PropertyIsArrayAndNotString(SerializedProperty property) => property.isArray && (property.propertyType != SerializedPropertyType.String);

        public int FileID() {
            //From https://forum.unity.com/threads/how-to-get-the-local-identifier-in-file-for-scene-objects.265686/
            var inspectorModeInfo = typeof(SerializedObject).GetProperty("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);
            int localId;

            {
                var seriObject             = new SerializedObject(target);
                var inspectorModeInfoValue = inspectorModeInfo.GetValue(seriObject, null);
                inspectorModeInfo.SetValue(seriObject, InspectorMode.Debug, null);
                var localIdProp = seriObject.FindProperty("m_LocalIdentfierInFile"); //note the misspelling
                inspectorModeInfo.SetValue(seriObject, inspectorModeInfoValue, null);
                localId = localIdProp.intValue;
            }

            return localId;
        }

        public string AssetPath() => AssetPath(target);

        public static string AssetPath(Object target) => AssetDatabase.GetAssetPath(target);

        private static string GetUniqueStringID(SerializedProperty property) => string.Format("{0}-{1}", property.propertyPath, property.name);
    }
}