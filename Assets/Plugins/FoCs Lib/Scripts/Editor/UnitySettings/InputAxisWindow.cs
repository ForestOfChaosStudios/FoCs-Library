using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.UnitySettings;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;

namespace ForestOfChaosLib.InputManager.Editor
{
	public class InputAxisWindow: Window<InputAxisWindow>
	{
		private const string Title = "InputAxisWindow";

		[MenuItem(FileStrings.FORESTOFCHAOS_ + Title)]
		private static void Init()
		{
			GetWindowAndOpenTab();
			window.titleContent.text = Title;
		}

		protected override void DrawGUI()
		{
			foreach(var axisName in ReadInputManager.GetAxisProperties())
			{
				EditorGUILayout.PropertyField(axisName, true);
			}
		}
	}
}