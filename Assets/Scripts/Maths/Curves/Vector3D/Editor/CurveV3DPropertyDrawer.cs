using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.PropertyDrawers;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;
using URLP = ForestOfChaosLib.Editor.UnityReorderableListProperty;

namespace ForestOfChaosLib.Maths.Curves.Editor
{
	public class CurveV3DPropertyDrawer: FoCsPropertyDrawer
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
				var targ = property.GetTargetObjectOfProperty<ICurveV3D>();

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
			var targ = property.GetTargetObjectOfProperty<ICurveV3D>();

			if(list == null)
			{
				list                       = new URLP(property.FindPropertyRelative("Positions"));
				list.List.onCanAddCallback = reorderableList => !targ.IsFixedLength;
			}
			else
				list.Property = property.FindPropertyRelative("Positions");
		}
	}

	[CustomPropertyDrawer(typeof(CurveV3D))] public class BezierCurveV3DPropertyDrawer: CurveV3DPropertyDrawer { }

	[CustomPropertyDrawer(typeof(CurveV3DTri))] public class BezierCurveQuadV3DPropertyDrawer: CurveV3DPropertyDrawer { }

	[CustomPropertyDrawer(typeof(CurveV3DCube))] public class BezierCurveCubeV3DPropertyDrawer: CurveV3DPropertyDrawer { }
}
