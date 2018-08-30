using ForestOfChaosLib.Attributes;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers.Attributes
{
	[CustomPropertyDrawer(typeof(DisableEditingAttribute), true)]
	public class DisableEditingAttributeDrawer: FoCsPropertyDrawerWithAttribute<DisableEditingAttribute>
	{
		private const            float        WIDTH         = 16f;
		internal static readonly GUIContent[] OPTIONS_ARRAY = {new GUIContent("Enable Editing"), new GUIContent("Disable Editing")};

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = Disposables.PropertyScope(position, label, property))
			{
				label = propScope.content;

				if(GetAttribute.AllowConfirmedEdit)
					GetAttribute.CurrentlyEditable = FoCsGUI.DrawDisabledPropertyWithMenu(!GetAttribute.CurrentlyEditable, position, property, label, OPTIONS_ARRAY, GetAttribute.CurrentlyEditable? 0 : 1).Value == 0;
				else
				{
					using(Disposables.DisabledScope(true))
						FoCsGUI.PropertyField(position, property, label, true, false);
				}
			}
		}

		public override float GetPropertyHeight(SerializedProperty prop, GUIContent label) => FoCsGUI.GetPropertyHeight(prop, label, true);
	}
}
