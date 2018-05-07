using System;
using ForestOfChaosLib.Editor.ImGUI;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Editor
{
//TODO : Make this window better, GE add the ability to add extra functionality eg submit more data
	public class SubmitStringWindow: Window<SubmitStringWindow>
	{
		private const string GUI_SELECTION_LABEL = "SubmitStringWindowDataField";

		private static bool notSelectedLabel;

		private SubmitStringArguments currentArguments;

		private static void Init()
		{
			GetWindowAndOpenUtility();
		}

		public static void SetUpInstance(SubmitStringArguments Args)
		{
			Init();
			window.titleContent.text = Args.WindowTitle;
			window.currentArguments = Args;
			notSelectedLabel = false;
		}

		protected override void DrawGUI()
		{
			if(currentArguments == null)
				return;

			EditorGUILayout.LabelField(currentArguments.Title);
			GUI.SetNextControlName(GUI_SELECTION_LABEL);
			currentArguments.Data = EditorGUILayout.TextField(GUIContent.none, currentArguments.Data);
			if(!notSelectedLabel)
			{
				EditorGUI.FocusTextInControl(GUI_SELECTION_LABEL);
				notSelectedLabel = true;
			}
			using(FoCsEditorDisposables.HorizontalScope())
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

			if(FoCsGUILayout.Button(currentArguments.SubmitAnotherMessage))
			{
				currentArguments.OnSubmitAnother.Trigger(currentArguments);
			}
		}

		public class SubmitStringArguments
		{
			public string CancelMessage;

			public string Data;
			public Action<SubmitStringArguments> OnCancel;

			public Action<SubmitStringArguments> OnSubmit;
			public string SubmitMessage;

			public Action<SubmitStringArguments> OnSubmitAnother;
			public string SubmitAnotherMessage;

			public string Title;
			public string WindowTitle;
		}
	}
}