#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Components
//       File: SetParent.cs
//    Created: 2020/10/11 | 8:42 PM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.Components {
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