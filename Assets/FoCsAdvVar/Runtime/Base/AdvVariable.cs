#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AdvVariable.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.Extensions;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Base {
    [Serializable]
    public class AdvVariable<T>: AdvVariable {
        private AdvVariableInternals internalData;

        [SerializeField]
        private T LocalValue;

        [SerializeField]
        private AdvReference<T> Reference;

        public T Value {
            get {
                if (UseLocal)
                    return LocalValue;

                if (Reference == null)
                    throw new AdvVariableReferenceMissingError();

                return Reference.Value;
            }
            set {
                if (UseLocal)
                    LocalValue = value;
                else
                    Reference.Value = value;

                OnValueChange.Trigger();
            }
        }

        public AdvVariableInternals InternalData => internalData ?? (internalData = new AdvVariableInternals(this));

        public AdvVariable() { }

        public AdvVariable(T localValue) {
            LocalValue = localValue;
            UseLocal   = true;
        }

        public AdvVariable(AdvReference<T> reference) {
            Reference = reference;
            UseLocal  = false;
        }

        public AdvVariable(T localValue, AdvReference<T> reference, bool useLocal = false) {
            LocalValue = localValue;
            Reference  = reference;
            UseLocal   = useLocal;
        }

        public static implicit operator T(AdvVariable<T> input) => input.Value;

        public class AdvVariableInternals {
            private readonly AdvVariable<T> classRef;

            public AdvReference<T> GlobalReference {
                get => classRef.Reference;
                set => classRef.Reference = value;
            }

            public T LocalValue {
                get => classRef.LocalValue;
                set => classRef.LocalValue = value;
            }

            public AdvVariableInternals(AdvVariable<T> _classRef) => classRef = _classRef;
        }

        public class AdvVariableReferenceMissingError: Exception {
            public AdvVariableReferenceMissingError(): base($"Missing Reference of {typeof(AdvReference<T>)}, Set to Local, or add reference.") { }
        }
    }

    /// <summary>
    ///     This is a base class so that as Unity needs a none generic base class for editors/property drawers
    /// </summary>
    public class AdvVariable {
        public Action OnValueChange;
        public bool   UseLocal;
    }
}