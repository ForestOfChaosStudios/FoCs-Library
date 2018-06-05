using ForestOfChaosLib.Attributes;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers.Attributes
{
	[CustomPropertyDrawer(typeof(MultiInLineAttribute), true)]
	public class MultiInLineAttributeDrawer: FoCsPropertyDrawerWithAttribute<MultiInLineAttribute>
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;

				using(FoCsEditor.Disposables.LabelFieldSetWidth((position.width / GetAttribute.totalAmount) * 0.5f))
				{
					using(var scope = FoCsEditor.Disposables.RectHorizontalScope(GetAttribute.totalAmount, position))
					{
						for(var i = 0; i < GetAttribute.index; i++)
							scope.GetNext();

						EditorGUI.PropertyField(scope.GetNext(RectEdit.SubtractY((SingleLinePlusPadding * GetAttribute.index)), RectEdit.SetHeight(SingleLine)), property, label);
					}
				}
			}
		}

		public override float GetPropertyHeight(SerializedProperty prop, GUIContent label) => GetAttribute.index == 0? EditorGUIUtility.singleLineHeight : 0;
	}
}
