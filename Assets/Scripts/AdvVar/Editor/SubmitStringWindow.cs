using System;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Editor
{
	//TODO : Make this window better, GE add the ability to add extra functionality eg submit more data
	public class SubmitStringWindow: FoCsWindow<SubmitStringWindow>
	{
		private const  string                GUI_SELECTION_LABEL = "SubmitStringWindowDataField";
		private static bool                  notSelectedLabel;
		private        SubmitStringArguments currentArguments;
		private static void                  Init() { GetWindowAndOpenUtility(); }

		public static void SetUpInstance(SubmitStringArguments Args)
		{
			Init();
			Window.titleContent.text = Args.WindowTitle;
			Window.currentArguments  = Args;
			notSelectedLabel         = false;
		}

		protected override void OnGUI()
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

			using(FoCsEditor.Disposables.HorizontalScope())
			{
				if(FoCsGUI.Layout.Button(currentArguments.SubmitMessage))
				{
					currentArguments.OnSubmit.Trigger(currentArguments);
					Close();
					EndWindows();
				}

				if(FoCsGUI.Layout.Button(currentArguments.CancelMessage))
				{
					currentArguments.OnCancel.Trigger(currentArguments);
					Close();
					EndWindows();
				}
			}

			if(!currentArguments.HasAnotherButton)
				return;

			if(FoCsGUI.Layout.Button(currentArguments.SubmitAnotherMessage))
			{
				currentArguments.OnSubmitAnother.Trigger(currentArguments);
			}
		}

		public class SubmitStringArguments
		{
			public string                        CancelMessage;
			public string                        Data;
			public Action<SubmitStringArguments> OnCancel;
			public string                        SubmitMessage;
			public Action<SubmitStringArguments> OnSubmit;
			public bool                          HasAnotherButton = false;
			public string                        SubmitAnotherMessage;
			public Action<SubmitStringArguments> OnSubmitAnother;
			public string                        Title;
			public string                        WindowTitle;
		}
	}
}