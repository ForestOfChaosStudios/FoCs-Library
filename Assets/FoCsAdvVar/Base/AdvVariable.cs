#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AdvVariable.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Base {

    [Serializable]
    public class AdvVariable<TVariable> : AdvVariable {
        /// <summary>
        ///     Triggered before the value is changed, passing the current value, then the new value
        /// </summary>
        [NonSerialized]
        public Action<TVariable, TVariable> OnValueChange;

        [SerializeField]
        private TVariable LocalValue;

        [SerializeField]
        private AdvReference<TVariable> Reference;

        [NonSerialized]
        private AdvVariableInternals internalData;

        /// <summary>
        ///     Returns the value based, can throw error if set to global but nothing assigned
        /// </summary>
        public TVariable Value {
            get {
                if (UseLocal)
                    return LocalValue;

                if (Reference == null)
                    throw new AdvVariableReferenceMissingError();

                return Reference.Value;
            }
            set {
                OnValueChange?.Invoke(Value, value);

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

        public AdvVariable(TVariable localValue) {
            LocalValue = localValue;
            UseLocal   = true;
        }

        public AdvVariable(AdvReference<TVariable> reference) {
            Reference = reference;
            UseLocal  = false;
        }

        public AdvVariable(TVariable localValue, AdvReference<TVariable> reference, bool useLocal = false) {
            LocalValue = localValue;
            Reference  = reference;
            UseLocal   = useLocal;
        }

        public static implicit operator TVariable(AdvVariable<TVariable> input) => input.Value;

        public static explicit operator AdvVariable<TVariable>(TVariable input) => new AdvVariable<TVariable>(input);

        /// <summary>
        ///     This class is used to allow access to the internal values at runtime, regardless of if it is set to local or global
        /// </summary>
        public class AdvVariableInternals {
            private readonly AdvVariable<TVariable> classRef;

            /// <summary>
            ///     Get-Set the global value
            /// </summary>
            public AdvReference<TVariable> GlobalReference {
                get => classRef.Reference;
                set => classRef.Reference = value;
            }

            /// <summary>
            ///     Get-Set the local value
            /// </summary>
            public TVariable LocalValue {
                get => classRef.LocalValue;
                set => classRef.LocalValue = value;
            }

            public AdvVariableInternals(AdvVariable<TVariable> _classRef) => classRef = _classRef;
        }

        public class AdvVariableReferenceMissingError: Exception {
            public AdvVariableReferenceMissingError(): base($"Missing Reference of {typeof(AdvReference<TVariable>)}, Set to Local, or add reference.") { }
        }
    }

    /// <summary>
    ///     This is a base class so that as Unity needs a none generic base class for editors/property drawers
    /// </summary>
    public class AdvVariable {
        public bool UseLocal;
    }
}