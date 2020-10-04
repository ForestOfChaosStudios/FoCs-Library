#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: SetRunTimeRef.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/04 | 01:56 AM
#endregion


using ForestOfChaos.Unity.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/RunTime/" + "Set RunTime Ref")]
    public class SetRunTimeRef: MonoBehaviour {
        public AdvVariable<bool> RemoveOnDisable = (AdvVariable<bool>)true;
        public RunTimeRef        RunTimeRef;

        public void OnEnable() {
            if (RunTimeRef != null)
                RunTimeRef.FillReference(this);
        }

        public void OnDisable() {
            if (!RemoveOnDisable)
                return;

            if (RunTimeRef != null)
                RunTimeRef.EmptyReference();
        }

        private void OnDestroy() {
            if (RunTimeRef != null)
                RunTimeRef.EmptyReference();
        }
    }
}