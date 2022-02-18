#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AdvListReference.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Base {
    public class AdvListReference<T>: AdvListReference {
        [SerializeField]
        private List<T> _value;

        [NonSerialized]
        public Action<T> OnValueAdded;

        [NonSerialized]
        public Action OnValueChange;

        [NonSerialized]
        public Action<T> OnValueRemoved;

        public List<T> Value {
            get => _value;
            set {
                _value = value;
                OnValueChange?.Invoke();
            }
        }

        public void Add(T value) {
            Value.Add(value);
            OnValueAdded?.Invoke(value);
        }

        public bool Contains(T value) => Value.Contains(value);

        public void Remove(T value) {
            Value.Remove(value);
            OnValueRemoved?.Invoke(value);
        }
    }

    /// <summary>
    ///     This is a base class so that as Unity needs a non-generic base class for editors/property drawers
    /// </summary>
    public class AdvListReference: ScriptableObject { }
}