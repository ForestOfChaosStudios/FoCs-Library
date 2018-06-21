using UnityEditor;
using ForestOfChaosLib.Editor.PropertyDrawers;
using UnityEngine;

namespace ForestOfChaosLib.InterfaceSerialization
{
	[CustomPropertyDrawer(typeof(InterfaceSerializer))]
	public class InterfaceSerializerPropertyDrawer: ObjectReferenceDrawer
	{
		/// <inheritdoc />
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			base.OnGUI(position, property.FindPropertyRelative("reference"), label);
		}
	}
}