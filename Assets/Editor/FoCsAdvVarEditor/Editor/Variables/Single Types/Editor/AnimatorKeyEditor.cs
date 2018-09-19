using ForestOfChaosAdvVar;
using ForestOfChaosLibraryEditor;
using ForestOfChaosLibraryEditor.Animation;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosAdvVarEditor
{
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
					AnimatorKeyDrawer.DoDraw(EditorGUILayout.GetControlRect(true, FoCsGUI.SingleLine), serializedObject.FindProperty("storedValue"), ValueContent);

					if(cc.changed)
						serializedObject.ApplyModifiedProperties();
				}
			}
		}
	}
}