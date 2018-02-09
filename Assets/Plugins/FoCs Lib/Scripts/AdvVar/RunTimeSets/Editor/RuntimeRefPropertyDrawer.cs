using ForestOfChaosLib.Editor.PropertyDrawers;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Editor
{
	[CustomPropertyDrawer(typeof(RunTimeRef), true)]
	public class RuntimeRefPropertyDrawer: FoCsPropertyDrawer<RunTimeRef>
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.ObjectField(position, property, label);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => SingleLinePlusPadding;
	}
}