#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components.Editor
//       File: ButtonClickEventDrawer.cs
//    Created: 2020/04/25
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.FoCsUI.Button;
using UnityEditor;

namespace ForestOfChaos.Unity.Editor.FoCsUI {
    [CanEditMultipleObjects]
    [CustomEditor(typeof(FoCsButton), true, isFallback = true)]
    public class ButtonClickEventBaseDrawer: FoCsEditor {
        protected override void DoExtraDraw() {
            using (Disposables.HorizontalScope()) {
                if (FoCsGUI.Layout.Button("Add Object Name ID")) {
                    var btn = (FoCsButton)serializedObject.targetObject;

                    if (!btn.Button.name.Contains("_btn"))
                        btn.Button.name += "_btn";

                    btn.TextGO.name = btn.Button.name.Replace("_btn", "") + "_text";
                }

                if (!FoCsGUI.Layout.Button("Change Button Text to Button GO Name"))
                    return;

                var btn2 = (FoCsButton)serializedObject.targetObject;
                btn2.Text = btn2.Button.name.Replace("_btn", "");
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