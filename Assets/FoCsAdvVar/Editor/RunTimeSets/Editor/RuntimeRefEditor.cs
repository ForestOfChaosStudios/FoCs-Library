#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar.Editor
//       File: RuntimeRefEditor.cs
//    Created: 2020/04/25 | 5:51 AM
// LastEdited: 2020/10/11 | 10:11 PM
#endregion

using ForestOfChaos.Unity.AdvVar.RuntimeRef;
using ForestOfChaos.Unity.Editor;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Editor.RuntimeRef {
    [CustomEditor(typeof(RunTimeRef), true)]
    public class RuntimeRefEditor: FoCsEditor<RunTimeRef> {
        protected override void DoExtraDraw() {
            using (Disposables.HorizontalScope(GUI.skin.box))
                FoCsGUI.Layout.LabelField($"Has reference: {Target.HasReference}");
        }
    }
}