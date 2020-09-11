#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: SetParent.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using UnityEngine;

namespace ForestOfChaosLibrary.Components {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "Set Parent")]
    public class SetParent: FoCsBehaviour {
        public enum Mode {
            OnEnable,
            Start,
            Awake
        }

        public Mode      CallMode = Mode.OnEnable;
        public Transform ChildTransform;
        public bool      DestroyComponentAfterCall = true;
        public Transform ParentTransform;

        private void OnEnable() {
            if (CallMode == Mode.OnEnable)
                DoParent();
        }

        private void Awake() {
            if (CallMode == Mode.Awake)
                DoParent();
        }

        private void Start() {
            if (CallMode == Mode.Start)
                DoParent();
        }

        private void DoParent() {
            ChildTransform.SetParent(ParentTransform);

            if (DestroyComponentAfterCall)
                Destroy(this);
        }

        private void Reset() {
            ChildTransform = transform;
        }
    }
}