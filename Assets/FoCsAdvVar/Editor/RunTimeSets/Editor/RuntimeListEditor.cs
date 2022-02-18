#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar.Editor
//       File: RuntimeListEditor.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.AdvVar.RuntimeRef;
using ForestOfChaos.Unity.Editor;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Editor.RuntimeRef {
    [CustomEditor(typeof(RunTimeList), true)]
    public class RuntimeListEditor: FoCsEditor<RunTimeList> {
        protected override void DoExtraDraw() {
            using (Disposables.HorizontalScope(GUI.skin.box))
                FoCsGUI.Layout.LabelField($"List has {Target.Count} entries.");

            FoCsGUI.Layout.WarningBox("Run Time Lists cause errors in Unity's serialize system.");
        }
    }
}