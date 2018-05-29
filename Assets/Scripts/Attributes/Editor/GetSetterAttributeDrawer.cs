using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.PropertyDrawers;
using UnityEditor;
using UnityEditor.PostProcessing;
using UnityEngine;

namespace ForestOfChaosLib.Attributes
{
	/// <summary>
	///     This is based off of the Unity Post Processing version
	/// </summary>
	[CustomPropertyDrawer(typeof(GetSetterAttribute))]
	public class GetSetterAttributeDrawer: FoCsPropertyDrawerWithAttribute<GetSetterAttribute>
	{
		internal const string Tooltip = "Persists until recompile";

		internal static readonly GUIContent[] OPTIONS_ARRAY =
		{
				new GUIContent("Call Setter",       Tooltip),
				new GUIContent("Don't Call Setter", Tooltip)
		};

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var cc = FoCsEditor.Disposables.ChangeCheck())
			{
				GetAttribute.CallSetter = FoCsGUI.DrawPropertyWithMenu(position, property, label, OPTIONS_ARRAY, GetAttribute.CallSetter? 0 : 1).Value == 0;

				if(cc.changed)
					GetAttribute.dirty = true;
			}

			if(GetAttribute.dirty)
				ElseLogic(property);
		}

		internal void ElseLogic(SerializedProperty property)
		{
			if(!GetAttribute.CallSetter)
				return;

			var parent = ReflectionUtils.GetParentObject(property.propertyPath, property.serializedObject.targetObject);
			var type   = parent.GetType();
			var info   = type.GetProperty(GetAttribute.name);

			if(info == null)
				Debug.LogError($"Invalid property name \"{GetAttribute.name}\"");
			else
				info.SetValue(parent, fieldInfo.GetValue(parent), null);

			GetAttribute.dirty = false;
		}
	}
}