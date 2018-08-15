﻿using UnityEditor;

namespace ForestOfChaosLib.Editor
{
	internal class ListHandler: IPropertyLayoutHandler
	{
		private readonly FoCsEditor owner;

		public ListHandler(FoCsEditor _owner)
		{
			owner = _owner;
		}

		public void HandleProperty(SerializedProperty property)
		{
			var list = owner.ALLStorage.GetList(property);

			using(FoCsEditor.Disposables.IndentOnlyIfLessThenIndent(2))
				list.Draw();

			//var list = owner.URLPStorage.GetList(property);
			//
			//using(FoCsEditor.Disposables.LabelFieldAddWidth(-31))
			//{
			//	using(FoCsEditor.Disposables.HorizontalScope())
			//	{
			//		FoCsGUI.Layout.GetControlRect(GUILayout.Width(5));
			//		list.HandleDrawing();
			//	}
			//}
		}

		public float PropertyHeight(SerializedProperty property)
		{
			var list = owner.ALLStorage.GetList(property);

			return list.GetTotalHeight();

			//var list = owner.URLPStorage.GetList(property);
			//
			//return list.GetTotalHeight();
		}

		public bool IsValidProperty(SerializedProperty property) => property.isArray && (property.propertyType != SerializedPropertyType.String);
	}
}
