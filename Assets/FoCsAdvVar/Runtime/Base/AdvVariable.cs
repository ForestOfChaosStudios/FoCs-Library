#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AdvVariable.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.Extensions;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Base {

    [Serializable]
    public class AdvVariable<T>: AdvVariable {
        /// <summary>
        ///     Triggered before the value is changed, passing the current value, then the new value
        /// </summary>
        [NonSerialized]
        public Action<T, T> OnValueChange;

        [SerializeField]
        private T LocalValue;

        [SerializeField]
        private AdvReference<T> Reference;

        [NonSerialized]
        private AdvVariableInternals internalData;

        /// <summary>
        ///     Returns the value based, can throw error if set to global but nothing assigned
        /// </summary>
        public T Value {
            get {
                if (UseLocal)
                    return LocalValue;

                if (Reference == null)
                    throw new AdvVariableReferenceMissingError();

                return Reference.Value;
            }
            set {
                OnValueChange.Trigger(Value, value);

                if (UseLocal)
                    LocalValue = value;
                else
                    Reference.Value = value;
            }
        }

        /// <summary>
        ///     Allows access to the both local and global values, if required, if not, the class is never created to minimize memory impact
        /// </summary>
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

        public static explicit operator AdvVariable<T>(T input) => new AdvVariable<T>(input);

        /// <summary>
        ///     This class is used to allow access to the internal values at runtime, regardless of if it is set to local or global
        /// </summary>
        public class AdvVariableInternals {
            private readonly AdvVariable<T> classRef;

            /// <summary>
            ///     Get-Set the global value
            /// </summary>
            public AdvReference<T> GlobalReference {
                get => classRef.Reference;
                set => classRef.Reference = value;
            }

            /// <summary>
            ///     Get-Set the local value
            /// </summary>
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
        public bool UseLocal;
    }
}