#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components.Editor
//       File: ButtonClickEventDrawer.cs
//    Created: 2020/04/25 | 5:51 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using ForestOfChaosLibrary.FoCsUI.Button;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor.FoCsUI {
    [CustomEditor(typeof(FoCsButton), true, isFallback = true)]
    [CanEditMultipleObjects]
    public class ButtonClickEventBaseDrawer: FoCsEditor {
        protected override void DoExtraDraw() {
            using (Disposables.HorizontalScope()) {
                if (GUILayout.Button("Add Object Name ID")) {
                    var btn = (FoCsButton)serializedObject.targetObject;

                    if (!btn.Button.name.Contains("_btn"))
                        btn.Button.name += "_btn";

                    btn.TextGO.name = btn.Button.name.Replace("_btn", "") + "_text";
                }

                if (GUILayout.Button("Change Button Text to Button GO Name")) {
                    var btn = (FoCsButton)serializedObject.targetObject;
                    btn.Text = btn.Button.name.Replace("_btn", "");
                }
            }
        }
    }
#if TMP
	[CustomEditor(typeof(FoCsButtonClickEventTmp), true, isFallback = true)]
	[CanEditMultipleObjects]
	public class ButtonClickEvent_TMPDrawer: ButtonClickEventBaseDrawer { }
#endif
    [CustomEditor(typeof(FoCsButtonClickEvent), true, isFallback = true)]
    [CanEditMultipleObjects]
    public class ButtonClickEventDrawer: ButtonClickEventBaseDrawer { }
}