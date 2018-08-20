using ForestOfChaosLib.AdvVar.InputSystem;
using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.InputManager.Editor
{
	[FoCsWindow]
	public class PlayerInputManagerWindow: FoCsWindow<PlayerInputManagerWindow>
	{
		public const  string InputManagerEnumName = "PlayerInputManagerEnum";
		private const string Title                = "Input Manager";

		[MenuItem(FileStrings.FORESTOFCHAOS_ + "Player Input Manager Window")]
		internal static void Init()
		{
			GetWindowAndShow();
			Window.titleContent.text = Title;
		}

		protected void Update()
		{
			Repaint();
		}

		protected override void OnGUI()
		{
			if(AdvInputManager.InstanceNull)
				return;

			using(Disposables.VerticalScope(GUI.skin.box))
			{
				foreach(var input in AdvInputManager.Instance.Axes)
					DrawInput(input.Value);
			}
		}

		private static void DrawInput(InputAxis input)
		{
			using(Disposables.HorizontalScope(GUI.skin.box))
			{
				EditorGUILayout.LabelField($"Axis: {input.Axis}");
				EditorGUILayout.LabelField($"Inverted: {input.ValueInverted}");
				var barSize = EditorGUILayout.BeginHorizontal();
				GUILayout.Space(32);

				using(Disposables.VerticalScope(GUI.skin.box))
				{
					GUILayout.Space(16);
					EditorGUI.ProgressBar(barSize, (input.Value + 1) * 0.5f, $"Value: {input.Value}");
				}

				EditorGUILayout.EndHorizontal();
			}
		}
	}
}