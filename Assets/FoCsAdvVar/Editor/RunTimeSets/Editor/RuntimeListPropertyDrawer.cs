#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.AdvVar.Editor
//       File: RuntimeListPropertyDrawer.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:49 AM
#endregion


using ForestOfChaos.Unity.AdvVar.RuntimeRef;
using ForestOfChaosLibrary.Editor.PropertyDrawers;
using UnityEditor;

//TODO: This file
namespace ForestOfChaos.Unity.AdvVar.Editor.RuntimeRef {
    [CustomPropertyDrawer(typeof(RunTimeList), true)]
    public class RuntimeListPropertyDrawer: ObjectReferenceDrawer {
        protected override bool AllowFoldout => false;
    }
}