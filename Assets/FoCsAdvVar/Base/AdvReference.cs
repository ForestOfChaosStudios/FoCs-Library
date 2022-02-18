#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AdvReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Base {
    public class AdvReference<TValueType>: AdvReference {
        [SerializeField]
        private TValueType storedValue;

        /// <summary>
        ///     Triggered before the value is changed, passing the current value, then the new value
        /// </summary>
        [NonSerialized]
        public Action<TValueType, TValueType> OnValueChange;

        protected virtual TValueType InternalValue {
            get => storedValue;
            set => storedValue = value;
        }

        public TValueType Value {
            get => InternalValue;
            set {
                OnValueChange?.Invoke(InternalValue, value);
                InternalValue = value;
            }
        }
    }

    /// <summary>
    ///     This is a base class so that as Unity needs a none generic base class for editors/property drawers
    /// </summary>
    public class AdvReference: ScriptableObject { }
}