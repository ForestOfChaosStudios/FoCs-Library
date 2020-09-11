#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: RunTimeRef.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaosLibrary.Extensions;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef {
    public abstract class RunTimeRef<T>: RunTimeRef where T: class {
        public  Action OnBeforeValueChange = () => { };
        public  Action OnValueChange       = () => { };
        private T      reference;

        public T Reference {
            get => reference;
            set {
                OnBeforeValueChange.Trigger();
                reference = value;
                OnValueChange.Trigger();
            }
        }

        public override bool HasReference => reference != null;

        /// <inheritdoc />
        public override void EmptyReference() {
            Reference = null;
        }

        public override void FillReference(MonoBehaviour self) {
            Reference = self.GetComponent<T>();
        }
    }

    public abstract class RunTimeRef: ScriptableObject {
        public abstract bool HasReference { get; }

        public abstract void FillReference(MonoBehaviour self);

        public abstract void EmptyReference();
    }
}