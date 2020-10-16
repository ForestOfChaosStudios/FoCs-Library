#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components.Editor
//       File: ButtonClickEventDrawer.cs
//    Created: 2020/04/25 | 5:51 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using ForestOfChaos.Unity.FoCsUI.Button;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.FoCsUI {
    [CanEditMultipleObjects]
    [CustomEditor(typeof(FoCsButton), true, isFallback = true)]
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
	[CanEditMultipleObjects]
	[CustomEditor(typeof(FoCsButtonClickEventTmp), true, isFallback = true)]
	public class ButtonClickEvent_TMPDrawer: ButtonClickEventBaseDrawer { }
#endif
    [CanEditMultipleObjects]
    [CustomEditor(typeof(FoCsButtonClickEvent), true, isFallback = true)]
    public class ButtonClickEventDrawer: ButtonClickEventBaseDrawer { }
}