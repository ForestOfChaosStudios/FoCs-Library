#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar.Editor
//       File: RuntimeRefPropertyDrawer.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.AdvVar.RuntimeRef;
using ForestOfChaos.Unity.Editor.PropertyDrawers;
using UnityEditor;

//TODO: This file
namespace ForestOfChaos.Unity.AdvVar.Editor.RuntimeRef {
    [CustomPropertyDrawer(typeof(RunTimeRef), true)]
    public class RuntimeRefPropertyDrawer: ObjectReferenceDrawer {
        protected override bool AllowFoldout => false;
    }
}