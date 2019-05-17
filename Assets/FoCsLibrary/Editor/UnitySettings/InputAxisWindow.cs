using ForestOfChaosLibrary.Editor.UnitySettings;
using ForestOfChaosLibrary.Editor.Utilities;
using ForestOfChaosLibrary.Editor.Windows;
using UnityEditor;

namespace ForestOfChaosLibrary.Editor.InputManager
{
	public class InputAxisWindow: FoCsWindow<InputAxisWindow>
	{
		private const string Title = "InputAxisWindow";

		[MenuItem(FileStrings.FORESTOFCHAOS_TOOLS_ + Title)]
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
