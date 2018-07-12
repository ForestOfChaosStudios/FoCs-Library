using ForestOfChaosLib.AdvVar;
using ForestOfChaosLib.AdvVar.Editor;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers.Attributes
{
	[CustomPropertyDrawer(typeof(RangeAttribute))]
	public class RangeAttributeDrawer: FoCsPropertyDrawerWithAttribute<RangeAttribute>
	{
		// Draw the property inside the given rect
		private bool foldout;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;
				// First get the attribute since it contains the range for the scrollbar
				var range = attribute as RangeAttribute;
				var pos   = position;
				pos.height = SingleLine;

				// Now draw the property as a Slider or an IntSlider based on whether it's a float or integer.
				switch(property.propertyType)
				{
					case SerializedPropertyType.Float:
						DoFloat(position, property, label, range);

						break;
					case SerializedPropertyType.String:
						DoString(position, property, label, range);

						break;
					case SerializedPropertyType.Integer:
						DoInt(position, property, label, range);

						break;
					case SerializedPropertyType.Vector2:
						DoVector2(position, property, label, range, pos);

						break;
					case SerializedPropertyType.Vector3:
						DoVector3(position, property, label, range, pos);

						break;
					//case SerializedPropertyType.Generic:
					//	foldout = DoGeneric(position, property, label, range, foldout);
                    //
					//	break;
					default:
						DrawErrorMessage(position, label);

						break;
				}
			}
		}

		private static void DrawErrorMessage(Rect position, GUIContent label)
		{
			EditorGUI.LabelField(position, label.text, "Use Range with float, int, string, Vector2 & Vector3.");
		}

		private static void DoFloat(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range)
		{
			EditorGUI.Slider(position, property, range.min, range.max, label);
		}

		private static void DoVector3(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, Rect pos)
		{
			var vec3 = property.vector3Value;
			EditorGUI.LabelField(pos, label);
			pos.x     += 60;
			pos.width -= 60;
			pos.y     += SingleLine;
			EditorGUI.LabelField(new Rect(position.x + 30, pos.y, 40, SingleLine), "X:");
			vec3.x =  EditorGUI.Slider(pos, "", vec3.x, range.min, range.max);
			pos.y  += SingleLine;
			EditorGUI.LabelField(new Rect(position.x + 30, pos.y, 40, SingleLine), "Y:");
			vec3.y =  EditorGUI.Slider(pos, "", vec3.y, range.min, range.max);
			pos.y  += SingleLine;
			EditorGUI.LabelField(new Rect(position.x + 30, pos.y, 40, SingleLine), "Z:");
			vec3.z                = EditorGUI.Slider(pos, "", vec3.z, range.min, range.max);
			property.vector3Value = vec3;
		}

		private static void DoVector2(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, Rect pos)
		{
			var vec2 = property.vector2Value;
			EditorGUI.LabelField(pos, label);
			pos.x     += 60;
			pos.width -= 60;
			pos.y     += SingleLine;
			EditorGUI.LabelField(new Rect(position.x + 30, pos.y, 40, SingleLine), "X:");
			vec2.x =  EditorGUI.Slider(pos, "", vec2.x, range.min, range.max);
			pos.y  += SingleLine;
			EditorGUI.LabelField(new Rect(position.x + 30, pos.y, 40, SingleLine), "Y:");
			vec2.y                = EditorGUI.Slider(pos, "", vec2.y, range.min, range.max);
			property.vector2Value = vec2;
		}

		private static void DoInt(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range)
		{
			EditorGUI.IntSlider(position, property, (int)range.min, (int)range.max, label);
		}

		private static void DoString(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range)
		{
			var stringLabel = new GUIContent(label);
			stringLabel.text += $"  (Total Length:{(int)range.max})";

			if(string.IsNullOrEmpty(stringLabel.tooltip))
				stringLabel.tooltip = $"This string has a Total Length:{(int)range.max})";

			EditorGUI.DelayedTextField(position, property, stringLabel);

			if(property.stringValue.Length > range.max)
				property.stringValue = property.stringValue.Substring(0, (int)range.max);
		}

		//private static bool DoGeneric(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, bool foldout)
		//{
		//	var obj = property.GetTargetObjectOfProperty();
        //
		//	if(obj is IntVariable)
		//		foldout = AdvReferencePropertyDrawerBase.DoDraw(position, property, foldout, label, rect => DoInt(rect, property.FindPropertyRelative("LocalValue"), label, range));
		//	else if(obj is FloatVariable)
		//		foldout = AdvReferencePropertyDrawerBase.DoDraw(position, property, foldout, label, rect => DoFloat(rect, property.FindPropertyRelative("LocalValue"), label, range));
		//	else if(obj is StringVariable)
		//		foldout = AdvReferencePropertyDrawerBase.DoDraw(position, property, foldout, label, rect => DoString(position, property.FindPropertyRelative("LocalValue"), label, range));
        //
		//	return foldout;
		//}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			switch(property.propertyType)
			{
				case SerializedPropertyType.Vector2: return SingleLine * 3;
				case SerializedPropertyType.Vector3: return SingleLine * 4;
				case SerializedPropertyType.Generic: return FoCsGUI.GetPropertyHeight(property, FoCsGUI.AttributeCheck.DontCheck);
				default:                             return SingleLine;
			}
		}
	}
}