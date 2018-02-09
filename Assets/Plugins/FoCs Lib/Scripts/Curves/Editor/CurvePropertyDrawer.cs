using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.PropertyDrawers;
using ForestOfChaosLib.UnityScriptsExtensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Curves.Editor
{
	public class CurvePropertyDrawer: FoCsPropertyDrawer
	{
		private ReorderableListProperty list;

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			ListNullCheck(property);

			return (SingleLine * 2) + list.GetTotalHeight();
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var useGlobalSpaceProp = property.FindPropertyRelative("useGlobalSpace");
			var positionsProp = property.FindPropertyRelative("Positions");
			var useGlobalBoolRect = position;
			useGlobalBoolRect.height = SingleLine;
			position = position.ChangeY(SingleLine);
			EditorGUI.PropertyField(useGlobalBoolRect, useGlobalSpaceProp);

			var targ = property.GetTargetObjectOfProperty<ICurve>();
			if(targ.IsFixedLength)
			{
				if(positionsProp.arraySize != targ.Length)
					positionsProp.arraySize = targ.Length;
			}

			ListNullCheck(property);

			list.HandleDrawing(position.ChangeX(16));
		}

		private void ListNullCheck(SerializedProperty property)
		{
			var targ = property.GetTargetObjectOfProperty<ICurve>();
			if(list == null)
			{
				list = new ReorderableListProperty(property.FindPropertyRelative("Positions"));
				list.List.onCanAddCallback = reorderableList => !targ.IsFixedLength;
			}
		}
	}

	[CustomPropertyDrawer(typeof(BezierCurveV3D))]
	public class BezierCurveV3DPropertyDrawer: CurvePropertyDrawer
	{ }

	[CustomPropertyDrawer(typeof(BezierCurveQuadV3D))]
	public class BezierCurveQuadV3DPropertyDrawer: CurvePropertyDrawer
	{ }

	[CustomPropertyDrawer(typeof(BezierCurveCubeV3D))]
	public class BezierCurveCubeV3DPropertyDrawer: CurvePropertyDrawer
	{ }
}