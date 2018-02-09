using ForestOfChaosLib.Editor.PropertyDrawers;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.TextureRenderer
{
	[CustomPropertyDrawer(typeof(ImageDataArrayAttribute))]
	public class ImageDataArrayDrawer: FoCsPropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty serializedProperty, GUIContent label)
		{
			int indexOfCol = GetIndexOfElement(serializedProperty);

			if((indexOfCol & 3) != 0)
			{
				return;
			}

			//int depth = serializedProperty.depth;
			var rect = position;

			var alpha = serializedProperty.Copy();

			rect.width /= 5;
			rect.height = SingleLine;
			var rectSmall = rect;
			rectSmall.width = 64;
			EditorGUI.LabelField(rect, string.Format("Pix {0}", indexOfCol / 4));

			rectSmall.x = (rect.x += rect.width) - 32;
			EditorGUI.PropertyField(rect, alpha, GUIContent.none);
			EditorGUI.LabelField(rectSmall, "     A");

			if(serializedProperty.Next(false))
			{
				rect.x += rect.width;
				rectSmall.x += rect.width;
				EditorGUI.PropertyField(rect, serializedProperty, GUIContent.none);
				EditorGUI.LabelField(rectSmall, "     R");
				if(serializedProperty.Next(false))
				{
					rect.x += rect.width;
					rectSmall.x += rect.width;
					EditorGUI.PropertyField(rect, serializedProperty, GUIContent.none);
					EditorGUI.LabelField(rectSmall, "     G");
					if(serializedProperty.Next(false))
					{
						rect.x += rect.width;
						rectSmall.x += rect.width;
						EditorGUI.PropertyField(rect, serializedProperty, GUIContent.none);
						EditorGUI.LabelField(rectSmall, "     B");
					}
				}
			}
		}

		public override float GetPropertyHeight(SerializedProperty serializedProperty, GUIContent label)
		{
			int indexOfCol = GetIndexOfElement(serializedProperty);
			return (indexOfCol & 3) == 0? SingleLine - 7 : 0;
		}

		/// <summary>
		/// Gets the index of the array eliment from the name
		/// </summary>
		/// <param name="serializedProperty"></param>
		/// <returns>Index</returns>
		private static int GetIndexOfElement(SerializedProperty serializedProperty)
		{
			string str = serializedProperty.displayName;

			str = str.Replace("Element ", "");
			int indexOfCol = int.Parse(str);
			return indexOfCol;
		}
	}
}