#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: BaseSetRunTimeRef.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.RuntimeRef.Components {
    public abstract class BaseSetRunTimeRef<TSet>: FoCsBehaviour where TSet: class {
        public RunTimeRef<TSet> Ref;
        public bool          RemoveOnDisable = true;

        public abstract TSet Value { get; }

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

    public abstract class BaseSetRunTimeRefWithField<T>: BaseSetRunTimeRef<T> where T: Component {
        [SerializeField]
        private T _referenceField;

        public T ReferenceField {
            get => _referenceField == null? _referenceField = GetComponent<T>() : _referenceField;
            set => _referenceField = value;
        }

        public override T Value => ReferenceField;
    }
}