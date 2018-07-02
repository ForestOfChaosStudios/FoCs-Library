using ForestOfChaosLib.AdvVar;
using ForestOfChaosLib.Animation;
using ForestOfChaosLib.Editor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AnimatorKeyReference))]
[CanEditMultipleObjects]
public class AnimatorKeyEditor: FoCsEditor
{
	private static readonly GUIContent ValueContent = new GUIContent("Value");

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		using(Disposables.Indent())
		{
			using(var cc = Disposables.ChangeCheck())
			{
				AnimatorKeyDrawer.DoDraw(EditorGUILayout.GetControlRect(true, FoCsGUI.SingleLine), serializedObject.FindProperty("value"), ValueContent);

				if(cc.changed)
					serializedObject.ApplyModifiedProperties();
			}
		}
	}
}