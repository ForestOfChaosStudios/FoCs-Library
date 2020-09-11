#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AddToTransformRunTimeRef.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using ForestOfChaosLibrary;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/RunTime/" + "Add Transform RunTime Ref")]
    public class AddToTransformRunTimeRef: BaseSetRunTimeRef<Transform, TransformRunTimeRef> {
        public override Transform Value => Transform;
    }
}