using UnityEditor;
using UnityEngine;

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
			var list = FoCsEditor.GetReorderableList(property);

			using(FoCsEditor.Disposables.LabelFieldAddWidth(-31))
			{
				using(FoCsEditor.Disposables.HorizontalScope())
				{
					FoCsGUI.Layout.GetControlRect(GUILayout.Width(5));
					list.HandleDrawing();
				}
			}
		}

		public float PropertyHeight(SerializedProperty property)
		{
			var list = FoCsEditor.GetReorderableList(property);

			return list.GetTotalHeight();
		}
	}
}
