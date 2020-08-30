#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.AdvVar.Editor
//       File: RuntimeListEditor.cs
//    Created: 2020/04/25 | 5:51 AM
// LastEdited: 2020/08/31 | 7:49 AM
#endregion


using ForestOfChaos.Unity.AdvVar.RuntimeRef;
using ForestOfChaosLibrary.Editor;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Editor.RuntimeRef {
    [CustomEditor(typeof(RunTimeList), true)]
    public class RuntimeListEditor: FoCsEditor<RunTimeList> {
        public override void OnInspectorGUI() {
            using (Disposables.HorizontalScope(GUI.skin.box))
                EditorGUILayout.LabelField($"List has {Target.Count} entries.");

            EditorGUILayout.HelpBox("Run Time Lists cause errors in Unity's serialize system.", MessageType.Warning);
        }
    }
}