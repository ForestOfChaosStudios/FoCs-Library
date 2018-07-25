using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.PropertyDrawers;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;
using RLP = ForestOfChaosLib.Editor.FoCsEditor.ReorderableListProperty;

namespace ForestOfChaosLib.Curves.Editor
{
	public class CurveTDPropertyDrawer: FoCsPropertyDrawer
	{
		private RLP list;

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			ListNullCheck(property);

			return (SingleLine) + list.GetTotalHeight();
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;
				var positionsProp      = property.FindPropertyRelative("Positions");
				var useGlobalBoolRect  = position;
				useGlobalBoolRect.height = SingleLine;
				position = position.Edit(RectEdit.ChangeY(SingleLine));
				var targ = property.GetTargetObjectOfProperty<ICurveTD>();

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
			var targ = property.GetTargetObjectOfProperty<ICurveTD>();

			if(list == null)
			{
				list                       = new RLP(property.FindPropertyRelative("Positions"));
				list.List.onCanAddCallback = reorderableList => !targ.IsFixedLength;
			}
		}
	}

	[CustomPropertyDrawer(typeof(BezierCurveTD))] public class BezierCurveTDPropertyDrawer: CurveTDPropertyDrawer { }

	[CustomPropertyDrawer(typeof(BezierCurveTDQuad))] public class BezierCurveQuadTDPropertyDrawer: CurveTDPropertyDrawer { }

	[CustomPropertyDrawer(typeof(BezierCurveTDCube))] public class BezierCurveCubeTDPropertyDrawer: CurveTDPropertyDrawer { }
}