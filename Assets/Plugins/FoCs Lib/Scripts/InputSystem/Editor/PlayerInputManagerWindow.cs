using ForestOfChaosLib.AdvVar.InputSystem;
using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.InputManager.Editor
{
	public class PlayerInputManagerWindow: Window<PlayerInputManagerWindow>
	{
		public const string InputManagerEnumName = "PlayerInputManagerEnum";

		private const string Title = "Input Manager";

		[MenuItem(FileStrings.JMILES42_ + "Player Input Manager Window")]
		private static void Init()
		{
			GetWindow();
			window.titleContent.text = Title;
		}

		protected override void Update()
		{
			Repaint();
		}

		protected override void DrawGUI()
		{
			if(AdvInputManager.InstanceNull)
				return;
			//Vertical Scope
			////An Indented way of using Unitys Scopes
			using(EditorDisposables.VerticalScope(GUI.skin.box))
			{
				foreach(var input in AdvInputManager.Instance.AxisReferences)
				{
					DrawInput(input.Value);
				}
			}
		}

		private static void DrawInput(InputAxis input)
		{
			using(EditorDisposables.HorizontalScope(GUI.skin.box))
			{
				EditorGUILayout.LabelField($"Axis: {input.Axis}");
				EditorGUILayout.LabelField($"Inverted: {input.ValueInverted}");
				var barSize = EditorGUILayout.BeginHorizontal();
				GUILayout.Space(32);
				using(EditorDisposables.VerticalScope(GUI.skin.box))
				{
					GUILayout.Space(16);
					EditorGUI.ProgressBar(barSize, (input.Value + 1) * 0.5f, $"Value: {input.Value}");
				}
				EditorGUILayout.EndHorizontal();
			}
		}
	}
}