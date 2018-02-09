using System;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Editor.Windows;
using ForestOfChaosLib.CSharpExtensions;
using ForestOfChaosLib.Editor.ImGUI;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Editor
{
	public class SubmitStringWindow: Window<SubmitStringWindow>
	{
		private static void Init()
		{
			GetWindow();
		}

		public static void SetUpInstance(SubmitStringArguments Args)
		{
			Init();
			window.titleContent.text = Args.WindowTitle;
			window.currentArguments = Args;
			notSelectedLabel = false;
		}

		private static bool notSelectedLabel = false;

		private SubmitStringArguments currentArguments;
		private const string GUI_SELECTION_LABEL = "SubmitStringWindowDataField";

		protected override void DrawGUI()
		{
			if(currentArguments.IsNull())
				return;

			EditorGUILayout.LabelField(currentArguments.Title);
			GUI.SetNextControlName(GUI_SELECTION_LABEL);
			currentArguments.Data = EditorGUILayout.TextField(GUIContent.none, currentArguments.Data);
			if(!notSelectedLabel)
			{
				EditorGUI.FocusTextInControl(GUI_SELECTION_LABEL);
				notSelectedLabel = true;
			}
			using(EditorDisposables.HorizontalScope())
			{
				if(FoCsGUILayout.Button(currentArguments.SubmitMessage))
				{
					currentArguments.OnSubmit.Trigger(currentArguments);
					Close();
				}
				if(FoCsGUILayout.Button(currentArguments.CancelMessage))
				{
					currentArguments.OnCancel.Trigger(currentArguments);
					Close();
				}
			}
		}

		public class SubmitStringArguments
		{
			public string WindowTitle;
			public string Title;
			public string SubmitMessage;
			public string CancelMessage;

			public string Data;

			public Action<SubmitStringArguments> OnSubmit;
			public Action<SubmitStringArguments> OnCancel;
		}
	}
}