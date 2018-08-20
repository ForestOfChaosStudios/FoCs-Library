//#define CUSTOM_LIST

using UnityEditor;

namespace ForestOfChaosLib.Editor
{
	internal class ListHandler: IPropertyLayoutHandler
	{
		private readonly UnityReorderableListStorage ListStorage;

		public ListHandler(FoCsEditor _owner)
		{
			ListStorage = _owner.URLPStorage;
		}

		public ListHandler(UnityReorderableListStorage _ListStorage)
		{
			ListStorage = _ListStorage;
		}
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
		public void HandleProperty(SerializedProperty property)
		{
			var list = ListStorage.GetList(property);

			using(Disposables.LabelFieldAddWidth(-31))
			{
				using(Disposables.HorizontalScope())
				{
					FoCsGUI.Layout.GetControlRect(UnityEngine.GUILayout.Width(5));
					list.HandleDrawing();
				}
			}
		}

		public float PropertyHeight(SerializedProperty property)
		{
			var list = ListStorage.GetList(property);

			return list.GetTotalHeight();
		}
#endif
		public bool IsValidProperty(SerializedProperty property) => property.isArray && (property.propertyType != SerializedPropertyType.String);
	}
}