using ForestOfChaosLib.Attributes;
using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers.Attributes
{
	[CustomPropertyDrawer(typeof(MultiInLineAttribute), true)]
	public class MultiInLineAttributeDrawer: FoCsPropertyDrawerWithAttribute<MultiInLineAttribute>
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var scope = EditorDisposables.RectHorizontalScope(GetAttribute.totalAmount, position))
			{
				for(int i = 0; i < GetAttribute.index; i++)
				{
					scope.GetNext();
				}
				EditorGUI.PropertyField(scope.GetNext(), property, label);
			}


			//EditorDrawersUtilities.DrawPropertyWidthIndexed(position.ChangeX(EditorGUI.indentLevel * 16), label, property, GetAttribute.totalAmount, GetAttribute.index, GetAttribute.expandToWidth);
		}

		public override float GetPropertyHeight(SerializedProperty prop, GUIContent label)
		{
			return GetAttribute.index == 0? EditorGUIUtility.singleLineHeight : 0;
		}
	}
}