using ForestOfChaosLib.Attributes;
using ForestOfChaosLib.Editor.ImGUI;
using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers.Attributes
{
	[CustomPropertyDrawer(typeof(DisableEditingAttribute), true)]
	public class DisableEditingAttributeDrawer: FoCsPropertyDrawerWithAttribute<DisableEditingAttribute>
	{
		private const float WIDTH = 16f;

		internal static readonly GUIContent[] OPTIONS_ARRAY =
		{
			new GUIContent("Enable Editing"),
			new GUIContent("Disable Editing")
		};

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if(GetAttribute.AllowConfirmedEdit)
			{
				GetAttribute.CurrentlyEditable = FoCsGUI.DrawDisabledPropertyWithMenu(!GetAttribute.CurrentlyEditable,
																						position,
																						property,
																						label,
																						OPTIONS_ARRAY,
																						GetAttribute.CurrentlyEditable?
																							0 :
																							1) ==
												 0;
			}
			else
			{
				using(EditorDisposables.DisabledScope(true))
					EditorGUI.PropertyField(position, property, label);
			}
		}

		public override float GetPropertyHeight(SerializedProperty prop, GUIContent label) => EditorGUI.GetPropertyHeight(prop, label);
	}
}