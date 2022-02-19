#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: UnityReorderableListStorage.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System.Collections.Generic;
using UnityEditor;

namespace ForestOfChaos.Unity.Editor {
    public class UnityReorderableListStorage {
        internal static List<UnityReorderableListStorage>                storage = new List<UnityReorderableListStorage>();
        internal        Dictionary<string, UnityReorderableListProperty> lists = new Dictionary<string, UnityReorderableListProperty>();

        public UnityReorderableListStorage() {
            storage.Add(this);
        }

        ~UnityReorderableListStorage() {
            storage.Remove(this);
        }

        public UnityReorderableListProperty GetList(SerializedProperty property) {
            var id = GetId(property);

            if (lists.TryGetValue(id, out var reorderableList)) {
                if (reorderableList.Property.serializedObject != null)
                    reorderableList.Property = property;
                else
                    reorderableList = new UnityReorderableListProperty(property, true, true);

                return reorderableList;
            }

            reorderableList = new UnityReorderableListProperty(property, true, true);
            lists.Add(id, reorderableList);

            return reorderableList;
        }

        public static string GetId(SerializedProperty property) => $"{property.serializedObject.targetObject.GetInstanceID()}:{property.propertyPath}-{property.name}";
    }
}