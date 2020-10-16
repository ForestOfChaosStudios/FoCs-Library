#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsSubmitStringWindow.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:11 PM
#endregion

using System;
using ForestOfChaos.Unity.Editor;
using ForestOfChaos.Unity.Editor.Windows;
using ForestOfChaos.Unity.Extensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Editor.Windows {
    //TODO : Make this window better, GE add the ability to add extra functionality eg submit more data
    public class FoCsSubmitStringWindow: FoCsWindow<FoCsSubmitStringWindow> {
        private const  string                GUI_SELECTION_LABEL = "SubmitStringWindowDataField";
        private static bool                  notSelectedLabel;
        private        SubmitStringArguments currentArguments;

        private static void Init() {
            GetWindowAndOpenUtility();
        }

        public static void SetUpInstance(SubmitStringArguments Args) {
            Init();
            Window.titleContent.text = Args.WindowTitle;
            Window.currentArguments  = Args;
            notSelectedLabel         = false;
        }

        protected override void OnGUI() {
            if (currentArguments == null)
                return;

            EditorGUILayout.LabelField(currentArguments.Title);
            GUI.SetNextControlName(GUI_SELECTION_LABEL);
            currentArguments.Data = EditorGUILayout.TextField(GUIContent.none, currentArguments.Data);

            if (!notSelectedLabel) {
                EditorGUI.FocusTextInControl(GUI_SELECTION_LABEL);
                notSelectedLabel = true;
            }

            using (Disposables.HorizontalScope()) {
                if (FoCsGUI.Layout.Button(currentArguments.SubmitMessage)) {
                    currentArguments.OnSubmit.Trigger(currentArguments);
                    Close();
                    EndWindows();
                }

                if (FoCsGUI.Layout.Button(currentArguments.CancelMessage)) {
                    currentArguments.OnCancel.Trigger(currentArguments);
                    Close();
                    EndWindows();
                }
            }

            if (!currentArguments.HasAnotherButton)
                return;

            if (FoCsGUI.Layout.Button(currentArguments.SubmitAnotherMessage))
                currentArguments.OnSubmitAnother.Trigger(currentArguments);
        }

        public class SubmitStringArguments {
            public string                        CancelMessage;
            public string                        Data;
            public bool                          HasAnotherButton = false;
            public Action<SubmitStringArguments> OnCancel;
            public Action<SubmitStringArguments> OnSubmit;
            public Action<SubmitStringArguments> OnSubmitAnother;
            public string                        SubmitAnotherMessage;
            public string                        SubmitMessage;
            public string                        Title;
            public string                        WindowTitle;
        }
    }
}