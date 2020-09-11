#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: SetRunTimeRef.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using ForestOfChaosLibrary;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/RunTime/" + "Set RunTime Ref")]
    public class SetRunTimeRef: MonoBehaviour {
        public bool       RemoveOnDisable = true;
        public RunTimeRef RunTimeRef;

        public void OnEnable() {
            RunTimeRef?.FillReference(this);
        }

        public void OnDisable() {
            if (RemoveOnDisable)
                RunTimeRef?.EmptyReference();
        }

        private void OnDestroy() {
            RunTimeRef?.EmptyReference();
        }
    }
}