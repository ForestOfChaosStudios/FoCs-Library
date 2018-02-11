﻿using ForestOfChaosLib.Attributes;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers.Attributes
{
	[CustomPropertyDrawer(typeof(ListDrawerAttribute))]
	public class ListDrawerAttributeDrawer: PropertyDrawer
	{
		private ReorderableListProperty propertyList = null;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if(propertyList == null)
				propertyList = new ReorderableListProperty(property);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if(propertyList == null)
				propertyList = new ReorderableListProperty(property);
			return 16f;
		}
	}
}