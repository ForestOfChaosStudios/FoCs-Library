using ForestOfChaosLibraryEditor.PropertyDrawers;
using ForestOfChaosLibrary.Extensions;
using ForestOfChaosLibrary.Maths.Curves;
using ForestOfChaosLibrary.Utilities;
using UnityEditor;
using UnityEngine;
using URLP = ForestOfChaosLibraryEditor.UnityReorderableListProperty;

namespace ForestOfChaosLibraryEditor.Maths.Curves
{
	public class V3DCurvePropertyDrawer: FoCsPropertyDrawer
	{
		private URLP list;

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			ListNullCheck(property);

			return SingleLine + list.GetTotalHeight();
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;
				var useGlobalSpaceProp = property.FindPropertyRelative("useGlobalSpace");
				var positionsProp      = property.FindPropertyRelative("Positions");
				var useGlobalBoolRect  = position.Edit(RectEdit.SetHeight(SingleLine));
				position = position.Edit(RectEdit.ChangeY(SingleLine));
				EditorGUI.PropertyField(useGlobalBoolRect, useGlobalSpaceProp);
				var targ = property.GetTargetObjectOfProperty<IV3Curve>();

				if(targ.IsFixedLength)
				{
					if(positionsProp.arraySize != targ.Length)
						positionsProp.arraySize = targ.Length;
				}

				ListNullCheck(property);
				list.HandleDrawing(position.Edit(RectEdit.ChangeX(16)));
			}
		}

		private void ListNullCheck(SerializedProperty property)
		{
			var targ = property.GetTargetObjectOfProperty<IV3Curve>();

			if(list == null)
			{
				list                       = new URLP(property.FindPropertyRelative("Positions"));
				list.List.onCanAddCallback = reorderableList => !targ.IsFixedLength;
			}
			else
				list.Property = property.FindPropertyRelative("Positions");
		}
	}

	[CustomPropertyDrawer(typeof(V3Curve))] public class V3DCurveArrayPropertyDrawer: V3DCurvePropertyDrawer { }

	[CustomPropertyDrawer(typeof(V3Curve3Points))] public class V3DCurve3PointsPropertyDrawer: V3DCurvePropertyDrawer { }

	[CustomPropertyDrawer(typeof(V3Curve4Points))] public class V3DCurve4PointsPropertyDrawer: V3DCurvePropertyDrawer { }
}
