using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers.Attributes
{
	[CustomPropertyDrawer(typeof(RangeAttribute))]
	public class RangeAttributeDrawer: FoCsPropertyDrawerWithAttribute<RangeAttribute>
	{
		private                 bool               foldout;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = Disposables.PropertyScope(position, label, property))
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
						DoNamedString(position, property, label, range);

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
					case SerializedPropertyType.Generic:
						foldout = DoGeneric(position, property, label, range, foldout);

						break;
					default:
						DrawErrorMessage(position, label);

						break;
				}
			}
		}

		private static void DrawErrorMessage(Rect position, GUIContent label)
		{
			FoCsGUI.Label(position, label.text);
			FoCsGUI.Label(position, "Use Range with float, int, string, Vector2 & Vector3.");
		}

		public static void DoFloat(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range)
		{
			EditorGUI.Slider(position, property, range.min, range.max, label);
		}

		public static void DoVector3(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, Rect pos)
		{
			var vec3 = property.vector3Value;
			FoCsGUI.Label(pos, label);
			pos.x     += 60;
			pos.width -= 60;
			pos.y     += SingleLine;
			FoCsGUI.Label(new Rect(position.x + 30, pos.y, 40, SingleLine), "X:");
			vec3.x =  EditorGUI.Slider(pos, "", vec3.x, range.min, range.max);
			pos.y  += SingleLine;
			FoCsGUI.Label(new Rect(position.x + 30, pos.y, 40, SingleLine), "Y:");
			vec3.y =  EditorGUI.Slider(pos, "", vec3.y, range.min, range.max);
			pos.y  += SingleLine;
			FoCsGUI.Label(new Rect(position.x + 30, pos.y, 40, SingleLine), "Z:");
			vec3.z                = EditorGUI.Slider(pos, "", vec3.z, range.min, range.max);
			property.vector3Value = vec3;
		}

		public static void DoVector2(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, Rect pos)
		{
			var vec2 = property.vector2Value;
			FoCsGUI.Label(pos, label);
			pos.x     += 60;
			pos.width -= 60;
			pos.y     += SingleLine;
			FoCsGUI.Label(new Rect(position.x + 30, pos.y, 40, SingleLine), "X:");
			vec2.x =  EditorGUI.Slider(pos, "", vec2.x, range.min, range.max);
			pos.y  += SingleLine;
			FoCsGUI.Label(new Rect(position.x + 30, pos.y, 40, SingleLine), "Y:");
			vec2.y                = EditorGUI.Slider(pos, "", vec2.y, range.min, range.max);
			property.vector2Value = vec2;
		}

		public static void DoInt(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range)
		{
			EditorGUI.IntSlider(position, property, (int)range.min, (int)range.max, label);
		}

		public static void DoNamedString(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range)
		{
			var stringLabel = new GUIContent(label);
			stringLabel.text += string.Format("  (Total Length:{0})", (int)range.max);

			if(string.IsNullOrEmpty(stringLabel.tooltip))
				stringLabel.tooltip = string.Format("This string has a Total Length:{0})", (int)range.max);

			DoString(position, property, stringLabel, range);
		}

		public static void DoString(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range)
		{
			EditorGUI.DelayedTextField(position, property, label);

			if(property.stringValue.Length > range.max)
				property.stringValue = property.stringValue.Substring(0, (int)range.max);
		}

		private static bool DoGeneric(Rect position, SerializedProperty property, GUIContent label, RangeAttribute range, bool foldout)
		{
			var obj = property.GetTargetObjectOfProperty();

			foreach(var extraDrawer in ExtraDrawers)
			{
				if(extraDrawer.IsThisType(obj))
				{
					label   = extraDrawer.ChangeLabel(label, range);
					foldout = extraDrawer.Draw(position, property, label, range, foldout);

					return foldout;
				}
			}

			DrawErrorMessage(position, label);

			return foldout;
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{

			switch(property.propertyType)
			{
				case SerializedPropertyType.Vector2: return SingleLine * 3;
				case SerializedPropertyType.Vector3: return SingleLine * 4;
				case SerializedPropertyType.Generic:

				{
					var obj = property.GetTargetObjectOfProperty();

					foreach(var extraDrawer in ExtraDrawers)
					{
						if(extraDrawer.IsThisType(obj))
							return extraDrawer.GetHeight(property, label, foldout);
					}
				}

					return SingleLine;
				default: return SingleLine;
			}
		}

		private static readonly List<ICustomRangeDrawer> ExtraDrawers = new List<ICustomRangeDrawer>();

		public static void AddCustomRangeDrawer(ICustomRangeDrawer extraDrawer)
		{
			ExtraDrawers.Add(extraDrawer);
		}

		public interface ICustomRangeDrawer
		{
			bool       IsThisType(object            obj);
			bool       Draw(Rect                    position, SerializedProperty property, GUIContent label, RangeAttribute range, bool foldout);
			float      GetHeight(SerializedProperty property, GUIContent         label,    bool       foldout);
			GUIContent ChangeLabel(GUIContent       label,    RangeAttribute     range);
		}
	}
}
