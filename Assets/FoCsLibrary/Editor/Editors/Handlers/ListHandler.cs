#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: ListHandler.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


//#define CUSTOM_LIST

using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor {
    internal class ListHandler: IPropertyLayoutHandler {
        private readonly UnityReorderableListStorage ListStorage;

        public ListHandler(FoCsEditor _owner) => ListStorage = _owner.URLPStorage;

        public ListHandler(UnityReorderableListStorage _ListStorage) => ListStorage = _ListStorage;
#if CUSTOM_LIST
		public void HandleProperty(SerializedProperty property)
		{
			var list = owner.ALLStorage.GetList(property);

			using(Disposables.IndentOnlyIfLessThenIndent(2))
				list.Draw();
		}

		public float PropertyHeight(SerializedProperty property)
		{
			var list = owner.ALLStorage.GetList(property);

			return list.GetTotalHeight();
		}
#else
        public void HandleProperty(SerializedProperty property) {
            if (property.serializedObject.isEditingMultipleObjects) {
                FoCsGUI.Layout.PropertyField(property);

                return;
            }

            var list = ListStorage.GetList(property);

            using (Disposables.LabelFieldAddWidth(-31)) {
                using (Disposables.HorizontalScope()) {
                    FoCsGUI.Layout.GetControlRect(GUILayout.Width(5));
                    list.HandleDrawing();
                }
            }
        }

        public float PropertyHeight(SerializedProperty property) {
            if (property.serializedObject.isEditingMultipleObjects)
                return FoCsGUI.GetPropertyHeight(property);

            var list = ListStorage.GetList(property);

            return list.GetTotalHeight();
        }
#endif
        public bool IsValidProperty(SerializedProperty property) => property.isArray && (property.propertyType != SerializedPropertyType.String);

        public void DrawAfterEditor(SerializedProperty serializedProperty) { }
    }
}