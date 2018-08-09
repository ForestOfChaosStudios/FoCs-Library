using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.UnitySettings;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;

namespace ForestOfChaosLib.InputManager.Editor
{
	public class InputAxisWindow: FoCsWindow<InputAxisWindow>
	{
		private const string Title = "InputAxisWindow";

		[MenuItem(FileStrings.FORESTOFCHAOS_ + Title)]
		private static void Init()
		{
			GetWindowAndShow();
			Window.titleContent.text = Title;
		}

		protected override void OnGUI()
		{
			foreach(var axisName in ReadInputManager.GetAxisProperties())
				EditorGUILayout.PropertyField(axisName, true);
		}
	}
}
