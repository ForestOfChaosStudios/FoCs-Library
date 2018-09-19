using ForestOfChaosLibraryEditor.UnitySettings;
using ForestOfChaosLibraryEditor.Utilities;
using ForestOfChaosLibraryEditor.Windows;
using UnityEditor;

namespace ForestOfChaosLibraryEditor.InputManager
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
