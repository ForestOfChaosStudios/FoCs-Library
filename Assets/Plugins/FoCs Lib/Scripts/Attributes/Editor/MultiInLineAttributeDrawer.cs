using ForestOfChaosLib.Attributes;
using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers.Attributes
{
	[CustomPropertyDrawer(typeof(MultiInLineAttribute), true)]
	public class MultiInLineAttributeDrawer: FoCsPropertyDrawerWithAttribute<MultiInLineAttribute>
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(FoCsEditorDisposables.LabelFieldSetWidth((position.width / GetAttribute.totalAmount) * 0.5f))
			{
				using(var scope = FoCsEditorDisposables.RectHorizontalScope(GetAttribute.totalAmount, position))
				{
					for(var i = 0; i < GetAttribute.index; i++)
						scope.GetNext();
					EditorGUI.PropertyField(scope.GetNext().MoveY(-(SingleLinePlusPadding * GetAttribute.index)).SetHeight(SingleLine), property, label);
				}
			}
		}

		public override float GetPropertyHeight(SerializedProperty prop, GUIContent label) => GetAttribute.index == 0?
			EditorGUIUtility.singleLineHeight :
			0;
	}
}