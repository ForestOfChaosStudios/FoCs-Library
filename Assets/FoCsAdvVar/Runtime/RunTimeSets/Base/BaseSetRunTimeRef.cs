#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: BaseSetRunTimeRef.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using ForestOfChaosLibrary;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef.Components {
    public abstract class BaseSetRunTimeRef<T, RT_T>: FoCsBehaviour where RT_T: RunTimeRef<T> where T: class {
        public RT_T Ref;
        public bool RemoveOnDisable = true;

        public abstract T Value { get; }

        public void OnEnable() {
            if (Ref)
                Ref.Reference = Value;
        }

        public void OnDisable() {
            if (Ref && RemoveOnDisable)
                Ref.Reference = null;
        }

        private void OnDestroy() {
            if (Ref)
                Ref.Reference = null;
        }
    }

    public abstract class BaseSetRunTimeRefWithField<T, RT_T>: BaseSetRunTimeRef<T, RT_T> where RT_T: RunTimeRef<T> where T: Object {
        [SerializeField]
        private T _referenceField;

        public T ReferenceField {
            get => _referenceField ?? (_referenceField = GetComponent<T>());
            set => _referenceField = value;
        }

        public override T Value => ReferenceField;

        private void Reset() {
            if (!_referenceField)
                _referenceField = GetComponent<T>();
        }
    }
}