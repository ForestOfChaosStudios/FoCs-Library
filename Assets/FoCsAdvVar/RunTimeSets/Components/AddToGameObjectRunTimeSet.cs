#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AddToGameObjectRunTimeSet.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/RunTime/" + "Add GameObject RunTime Ref")]
    public class AddToGameObjectRunTimeSet: BaseAddToRunTimeSet<GameObject> {
        public override GameObject Value => gameObject;
    }
}