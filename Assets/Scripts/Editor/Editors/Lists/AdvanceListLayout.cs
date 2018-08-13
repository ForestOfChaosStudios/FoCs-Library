using System;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsEditor
	{
		public class AdvanceListLayout
		{
			public SerializedProperty Property;
			public Func<SerializedProperty, float> PropertyHeight = FoCsGUI.GetPropertyHeight;
			public Action<SerializedProperty> DrawElement = FoCsGUI.PropertyField;

			public AdvanceListLayout(SerializedProperty property)
			{
				Property = property;
			}

			private const float DRAG_HANDLE_WIDTH = 18f;

			public void Draw()
			{
				DrawHeader();
				DrawElements();
				DrawFooter();
			}

			public void DrawHeader()
			{
				using(Disposables.HorizontalScope())
				{
					FoCsGUI.Layout.Label(Property.displayName,      GUILayout.ExpandWidth(true));
					FoCsGUI.Layout.Label($"[{Property.arraySize}]", GUILayout.ExpandWidth(true));
				}
			}

			public void DrawElements()
			{
				for(var i = 0; i < Property.arraySize; i++)
				{
					var  element = Property.GetArrayElementAtIndex(i);
					Rect pos = FoCsGUI.Layout.GetControlRect(true, PropertyHeight(element));
					DrawElement(pos,element);
				}
			}

			public void DrawElement(Rect pos, SerializedProperty element)
			{
				FoCsGUI.Layout.PropertyField(element, element.isExpanded);
			}

			public void DrawFooter()
			{

			}

		}
	}
}