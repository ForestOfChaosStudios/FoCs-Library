#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar.Editor
//       File: AdvEventEditor.cs
//    Created: 2020/04/25
// LastEdited: 2022/02/19
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
                var @event = FoCsGUI.Layout.Button("Invoke Event");

                if (@event)
                    Target.Invoke();
            }
        }
    }
}