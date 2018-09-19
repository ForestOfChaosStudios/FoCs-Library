using ForestOfChaosLibrary.Attributes;
using ForestOfChaosLibrary.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibraryEditor.PropertyDrawers.Attributes
{
	[CustomPropertyDrawer(typeof(MultiInLineAttribute), true)]
	public class MultiInLineAttributeDrawer: FoCsPropertyDrawerWithAttribute<MultiInLineAttribute>
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;

				using(Disposables.LabelFieldSetWidth((position.width / GetAttribute.totalAmount) * 0.5f))
				{
					using(var scope = Disposables.RectHorizontalScope(GetAttribute.totalAmount, position))
					{
						for(var i = 0; i < GetAttribute.index; i++)
							scope.GetNext();

						FoCsGUI.PropertyField(scope.GetNext(RectEdit.SubtractY(SingleLinePlusPadding * GetAttribute.index), RectEdit.SetHeight(SingleLine)), property, label);
					}
				}
			}
		}

		public override float GetPropertyHeight(SerializedProperty prop, GUIContent label) => GetAttribute.index == 0? SingleLinePlusPadding : 0;
	}
}
