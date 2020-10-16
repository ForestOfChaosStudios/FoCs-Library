#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: SerializedPropertyExtensions.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:10 PM
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.Utilities {
    public static class SerializedPropertyExtensions {
        private const string INDEX_NEEDLE = @"\[[\d]\]";

        public static IEnumerable<SerializedProperty> GetChildren(this SerializedProperty property, bool enterChildren = false) {
            var iterator = property.Copy();

            do
                yield return iterator.Copy();
            while (iterator.NextVisible(enterChildren) && (iterator.depth >= property.depth));
        }

        public static int GetChildrenCount(this SerializedProperty property, bool enterChildren = false) => property.GetChildren(enterChildren).Count();

        public static int GetIndex(SerializedProperty property) {
            var matches = Regex.Matches(property.propertyPath, INDEX_NEEDLE);

            if (matches.Count == 0)
                return -1;

            var str = matches[0].Value.Replace("[", "").Replace("]", "");

            return int.Parse(str);
        }

        public static int GetIndex(string path) {
            var matches = Regex.Matches(path, INDEX_NEEDLE);

            if (matches.Count == 0)
                return -1;

            var str = matches[0].Value.Replace("[", "").Replace("]", "");

            return int.Parse(str);
        }

        public static object GetValue(this SerializedProperty property) {
            var parentType = property.serializedObject.targetObject.GetType();
            var fi         = parentType.GetField(property.propertyPath);

            return fi.GetValue(property.serializedObject.targetObject);
        }

        public static void SetValue(this SerializedProperty property, object value) {
            var parentType = property.serializedObject.targetObject.GetType();
            var fi         = parentType.GetField(property.propertyPath); //this FieldInfo contains the type.
            fi.SetValue(property.serializedObject.targetObject, value);
        }

        public static Type GetPropertyType(this SerializedProperty property) {
            var slices = property.propertyPath.Split('.');
            var type   = property.serializedObject.targetObject.GetType();

            for (var i = 0; i < slices.Length; i++) {
                if (slices[i] == "Array") {
                    i++;                          //skips "data[x]"
                    type = type.GetElementType(); //gets info on array elements
                }

                //gets info on field and its type
                else
                    type = type.GetField(slices[i], BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance).FieldType;
            }

            return type;

            //var parentType = property.serializedObject.targetObject.GetType();
            //var fi         = parentType.GetField(property.propertyPath);
            //
            //return fi.FieldType;
        }

        public static void DrawCreateAndAssignObjectMenu(this SerializedProperty property) {
            var type = property.GetPropertyType();

            if (!type.IsSubclassOf(typeof(ScriptableObject)))
                return;

            var guiContent  = new GUIContent($"Create And Assign New {type.Name}");
            var genericMenu = new GenericMenu();
            genericMenu.AddItem(guiContent, false, property.GenerateAddAssignNewItem);
            genericMenu.ShowAsContext();
        }

        public static void GenerateAddAssignNewItem(this SerializedProperty property) {
            var type = property.GetPropertyType();
            var obj  = ScriptableObject.CreateInstance(type);
            EditorHelpers.CreateAndCheckFolder("Assets",      "Data");
            EditorHelpers.CreateAndCheckFolder("Assets/Data", type.Name);
            var path = AssetDatabase.GenerateUniqueAssetPath($"Assets/Data/{type.Name}/New {type.Name}.Asset");
            AssetDatabase.CreateAsset(obj, path);
            property.objectReferenceValue = AssetDatabase.LoadAssetAtPath(path, type);
            property.serializedObject.ApplyModifiedProperties();
        }
    }
}