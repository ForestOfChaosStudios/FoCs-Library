#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: RunTimeRef.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef {
    public abstract class RunTimeRef<TReferenceType>: RunTimeRef where TReferenceType: class {
        public  Action         OnBeforeValueChange;
        public  Action         OnValueChange;
        private TReferenceType reference;

        public TReferenceType Reference {
            get => reference;
            set {
                OnBeforeValueChange?.Invoke();
                reference = value;
                OnValueChange?.Invoke();
            }
        }

        public override bool HasReference => reference != null;

        /// <inheritdoc />
        public override void EmptyReference() {
            Reference = null;
        }

        public override void FillReference(MonoBehaviour self) {
            Reference = self.GetComponent<TReferenceType>();
        }
    }

    public abstract class RunTimeRef: ScriptableObject {
        public abstract bool HasReference { get; }

        public abstract void FillReference(MonoBehaviour self);

        public abstract void EmptyReference();
    }
}