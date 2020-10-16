#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar.Editor
//       File: AdvEventEditor.cs
//    Created: 2020/04/25 | 5:51 AM
// LastEdited: 2020/10/11 | 10:11 PM
#endregion

using ForestOfChaos.Unity.AdvVar.Events;
using ForestOfChaos.Unity.Editor;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Editor {
    [CustomEditor(typeof(AdvEvent))]
    public class AdvEventEditor: FoCsEditor<AdvEvent> {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            using (Disposables.DisabledScope(!Application.isPlaying)) {
                var @event = FoCsGUI.Layout.Button("Trigger Event");

                if (@event)
                    Target.Trigger();
            }
        }
    }
}