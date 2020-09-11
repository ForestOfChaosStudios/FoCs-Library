#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: FoCsBehaviour.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using UnityEngine;

namespace ForestOfChaos.Unity {
    public abstract class FoCsBehaviour: MonoBehaviour {
        private Transform m_Transform;

        public Transform Transform {
            get => m_Transform? m_Transform : m_Transform = GetComponent<Transform>();
            set => m_Transform = value;
        }

        public virtual Quaternion Rotation {
            get => Transform.rotation;
            set => Transform.rotation = value;
        }

        public virtual Vector3 EulerAngles {
            get => Transform.eulerAngles;
            set => Transform.eulerAngles = value;
        }

        public virtual Vector3 LocalEulerAngles {
            get => Transform.localEulerAngles;
            set => Transform.localEulerAngles = value;
        }

        public virtual Vector3 Position {
            get => Transform.position;
            set => Transform.position = value;
        }

        public virtual Vector3 LocalPosition {
            get => Transform.localPosition;
            set => Transform.localPosition = value;
        }

        public Vector3 Forward => Transform.forward;

        public Vector3 Backward => -Transform.forward;

        public Vector3 Right => Transform.right;

        public Vector3 Left => -Transform.right;

        public Vector3 Up => Transform.up;

        public Vector3 Down => -Transform.up;
    }

    public abstract class FoCs2DBehavior: MonoBehaviour {
        private RectTransform m_RectTransform;

        public RectTransform Transform {
            get => m_RectTransform? m_RectTransform : m_RectTransform = GetComponent<RectTransform>();
            set => m_RectTransform = value;
        }

        public Quaternion Rotation {
            get => Transform.rotation;
            set => Transform.rotation = value;
        }

        public Vector3 Position {
            get => Transform.position;
            set => Transform.position = value;
        }

        public Vector3 LocalPosition {
            get => Transform.localPosition;
            set => Transform.localPosition = value;
        }
    }
}