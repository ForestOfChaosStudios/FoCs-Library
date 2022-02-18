#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AddToTransformRunTimeRef.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/RunTime/" + "Add Transform RunTime Ref")]
    public class AddToTransformRunTimeRef: BaseSetRunTimeRef<Transform> {
        public override Transform Value => Transform;
    }
}