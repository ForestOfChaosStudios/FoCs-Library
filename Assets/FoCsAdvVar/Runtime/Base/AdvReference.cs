#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AdvReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using ForestOfChaos.Unity.Extensions;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Base {
    public class AdvReference<T>: AdvReference {
        [SerializeField]
        private T storedValue;

        /// <summary>
        ///     Triggered before the value is changed, passing the current value, then the new value
        /// </summary>
        [NonSerialized]
        public Action<T, T> OnValueChange;

        protected virtual T InternalValue {
            get => storedValue;
            set => storedValue = value;
        }

        public T Value {
            get => InternalValue;
            set {
                OnValueChange.Trigger(InternalValue, value);
                InternalValue = value;
            }
        }
    }

    /// <summary>
    ///     This is a base class so that as Unity needs a none generic base class for editors/property drawers
    /// </summary>
    public class AdvReference: ScriptableObject { }
}