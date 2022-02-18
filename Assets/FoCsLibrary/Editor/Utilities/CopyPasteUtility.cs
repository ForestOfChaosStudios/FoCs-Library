#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: CopyPasteUtility.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ForestOfChaos.Unity.Editor.Utilities {
    public static class CopyPasteUtility {
        private const   string                     COPY_SPLIT   = ">||>";
        private const   string                     COPY_SPLIT_S = COPY_SPLIT + "\n";
        private const   string                     NEEDLE       = "\".*\":";
        internal static Dictionary<Type, CopyMode> TypeCopyData;

        [Flags]
        public enum CopyMode {
            Unknown = 0,
            None    = 1,
            Normal  = 2,
            Editor  = 4
        }

        public static string CopyBuffer {
            get => EditorGUIUtility.systemCopyBuffer;
            set => EditorGUIUtility.systemCopyBuffer = value;
        }

        static CopyPasteUtility() =>
                TypeCopyData = new Dictionary<Type, CopyMode> {
                        { typeof(FlareLayer), CopyMode.None },
                        { typeof(AudioListener), CopyMode.None },
                        { typeof(Transform), CopyMode.Editor },
                        { typeof(Object), CopyMode.Unknown }
                };

        private static CopyMode DoAddToDictionary<T>(T value) {
            var type = value == null? typeof(T) : value.GetType();

            if (TypeCopyData.ContainsKey(type)) {
                if (TypeCopyData[type] != CopyMode.Unknown)
                    return TypeCopyData[type];
            }
            else
                TypeCopyData.Add(type, CopyMode.Unknown);

            var copy = InternalCanCopy(value);

            if (copy)
                return TypeCopyData[type] = CopyMode.Normal;

            var editorCopy = InternalCanEditorCopy(value);

            if (editorCopy)
                return TypeCopyData[type] = CopyMode.Editor;

            return TypeCopyData[type] = CopyMode.None;
        }

        private static CopyMode GetCopyTypeFromDictionary(Type type) {
            if (TypeCopyData.ContainsKey(type))
                return TypeCopyData[type];

            TypeCopyData.Add(type, CopyMode.Unknown);

            return CopyMode.Unknown;
        }

        public static CopyMode GetCopyMode<T>(T value) {
            var val = GetCopyTypeFromDictionary(typeof(T));

            if (val == CopyMode.Unknown)
                val = DoAddToDictionary(value);

            return val;
        }

        public static bool CanCopy<T>(T value) {
            var val = GetCopyTypeFromDictionary(typeof(T));

            if (val == CopyMode.Unknown)
                val = DoAddToDictionary(value);

            return val == CopyMode.Normal;
        }

        private static bool InternalCanCopy<T>(T value) {
            string s;

            try {
                s = JsonUtility.ToJson(value, true);
            }
            catch (ArgumentException) {
                return false;
            }

            return s != "{}";
        }

        public static bool CanEditorCopy<T>(T value) {
            var val = GetCopyTypeFromDictionary(typeof(T));

            if (val == CopyMode.Unknown)
                val = DoAddToDictionary(value);

            return val == CopyMode.Editor;
        }

        public static bool InternalCanEditorCopy<T>(T value) {
            string s;

            try {
                s = EditorJsonUtility.ToJson(value, true);
            }
            catch (ArgumentException) {
                return false;
            }

            return (s != "") || (s != "{}");
        }

        public static bool EditorCopy<T>(T value) {
            try {
                CopyBuffer = value.GetType() + COPY_SPLIT_S + EditorJsonUtility.ToJson(value, true);
            }
            catch (ArgumentException) {
                return false;
            }

            return true;
        }

        public static bool Copy<T>(T value) {
            try {
                CopyBuffer = value.GetType() + COPY_SPLIT_S + JsonUtility.ToJson(value, true);
            }
            catch (ArgumentException) {
                return false;
            }

            return true;
        }

        public static T Paste<T>() => Paste<T>(RemoveTypeFromCopyBuffer());

        private static T Paste<T>(string buffer) {
            var value = JsonUtility.FromJson<T>(buffer);

            return value;
        }

        public static T Paste<T>(string buffer, bool checkForTypeDetails) {
            T value;

            if (checkForTypeDetails) {
                var checkedBuffer = RemoveTypeFromCopyBuffer(buffer);
                value = JsonUtility.FromJson<T>(checkedBuffer);
            }
            else
                value = JsonUtility.FromJson<T>(buffer);

            return value;
        }

        public static void Paste<T>(ref T obj) {
            Paste(ref obj, RemoveTypeFromCopyBuffer());
        }

        private static void Paste<T>(ref T obj, string buffer) {
            JsonUtility.FromJsonOverwrite(buffer, obj);
        }

        public static void Paste<T>(ref T obj, string buffer, bool checkForTypeDetails) {
            if (checkForTypeDetails) {
                if (IsTypeInBuffer(obj, buffer)) {
                    var checkedBuffer = RemoveTypeFromCopyBuffer(buffer);
                    JsonUtility.FromJsonOverwrite(checkedBuffer, obj);
                }
                else if (IsValidObjectInBuffer(buffer)) {
                    var checkedBuffer = RemoveTypeFromCopyBuffer(buffer);
                    JsonUtility.FromJsonOverwrite(checkedBuffer, obj);
                }
                else
                    JsonUtility.FromJsonOverwrite(buffer, obj);
            }
            else
                JsonUtility.FromJsonOverwrite(buffer, obj);
        }

        public static void EditorPaste<T>(ref T obj) {
            EditorPaste(obj, RemoveTypeFromCopyBuffer());
        }

        private static void EditorPaste<T>(ref T obj, string buffer) {
            EditorJsonUtility.FromJsonOverwrite(buffer, obj);
        }

        public static void EditorPaste<T>(ref T obj, string buffer, bool checkForTypeDetails) {
            if (checkForTypeDetails) {
                if (IsTypeInBuffer(obj, buffer)) {
                    var checkedBuffer = RemoveTypeFromCopyBuffer(buffer);
                    EditorJsonUtility.FromJsonOverwrite(checkedBuffer, obj);
                }
                else
                    EditorJsonUtility.FromJsonOverwrite(buffer, obj);
            }
            else
                EditorJsonUtility.FromJsonOverwrite(buffer, obj);
        }

        public static void EditorPaste<T>(T obj) {
            EditorPaste(obj, RemoveTypeFromCopyBuffer());
        }

        private static void EditorPaste<T>(T obj, string buffer) {
            EditorJsonUtility.FromJsonOverwrite(buffer, obj);
        }

        public static void EditorPaste<T>(T obj, string buffer, bool checkForTypeDetails) {
            if (checkForTypeDetails) {
                var checkedBuffer = RemoveTypeFromCopyBuffer(buffer);
                EditorJsonUtility.FromJsonOverwrite(checkedBuffer, obj);
            }
            else
                EditorJsonUtility.FromJsonOverwrite(buffer, obj);
        }

        private static bool IsValidObjectInBuffer() => IsValidObjectInBuffer(CopyBuffer);

        private static bool IsValidObjectInBuffer(string buffer) => buffer.Contains(COPY_SPLIT);

        public static bool IsTypeInBuffer(object obj) => IsTypeInBuffer(obj, CopyBuffer);

        public static bool IsTypeInBuffer(object obj, string buffer) {
            if (obj == null)
                return false;

            var bufferContainsAType = IsValidObjectInBuffer();

            if (!bufferContainsAType)
                return false;

            var t = obj.GetType();

            return t.ToString() == GetJSONStoredType(buffer);
        }

        private static string RemoveTypeFromCopyBuffer() => RemoveTypeFromCopyBuffer(CopyBuffer);

        public static string RemoveTypeFromCopyBuffer(string buffer) {
            var copyBufferSplit = buffer.Split(new[] { COPY_SPLIT }, StringSplitOptions.None);

            if (copyBufferSplit.Length > 1) {
                var list = copyBufferSplit.ToList();
                list.RemoveAt(0);

                return string.Join(string.Empty, list.ToArray());
            }

            return buffer;
        }

        public static string GetJSONStoredType(string json) {
            if (json.Contains(COPY_SPLIT)) {
                var copyBufferSplit = json.Split(new[] { COPY_SPLIT }, StringSplitOptions.None);

                return copyBufferSplit[0];
            }

            return "";
        }
    }
}