#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library.Editor
//       File: UnityReorderableListStorage.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System.Collections.Generic;
using UnityEditor;

namespace ForestOfChaosLibrary.Editor {
    public class UnityReorderableListStorage {
        internal static List<UnityReorderableListStorage>                storages = new List<UnityReorderableListStorage>();
        public          IRepaintable                                     owner;
        internal        Dictionary<string, UnityReorderableListProperty> URLPList = new Dictionary<string, UnityReorderableListProperty>(1);

        public UnityReorderableListStorage() {
            storages.Add(this);
        }

        public UnityReorderableListStorage(FoCsEditor painter) {
            storages.Add(this);
            owner = painter;
        }

        public UnityReorderableListStorage(IRepaintable painter) {
            storages.Add(this);
            owner = painter;
        }

        ~UnityReorderableListStorage() {
            storages.Remove(this);
        }

        public UnityReorderableListProperty GetList(SerializedProperty property) {
            var                          id = GetId(property);
            UnityReorderableListProperty reorderableList;

            if (URLPList.TryGetValue(id, out reorderableList)) {
                if (reorderableList.Property.serializedObject != null)
                    reorderableList.Property = property;
                else
                    reorderableList = new UnityReorderableListProperty(property, true, true);

                return reorderableList;
            }

            reorderableList = new UnityReorderableListProperty(property, true, true);
            URLPList.Add(id, reorderableList);

            if (owner != null)
                reorderableList.IsExpanded.valueChanged.AddListener(owner.Repaint);

            return reorderableList;
        }

        public static string GetId(SerializedProperty property) =>
                string.Format("{0}:{1}-{2}", property.serializedObject.targetObject.GetInstanceID(), property.propertyPath, property.name);
    }
}