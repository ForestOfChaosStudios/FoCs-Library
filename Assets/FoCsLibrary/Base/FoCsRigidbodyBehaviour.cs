#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: FoCsRigidbodyBehaviour.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEngine;

namespace ForestOfChaos.Unity {
    [RequireComponent(typeof(Rigidbody))]
    public abstract class FoCsRigidbodyBehaviour: FoCsBehaviour {
        private Rigidbody m_Rigidbody;

        public Rigidbody Rigidbody {
            get => m_Rigidbody? m_Rigidbody : m_Rigidbody = GetComponent<Rigidbody>();
            set => m_Rigidbody = value;
        }

        public Vector3 Velocity {
            get => Rigidbody.velocity;
            set => Rigidbody.velocity = value;
        }

        public Vector3 AngularVelocity {
            get => Rigidbody.angularVelocity;
            set => Rigidbody.angularVelocity = value;
        }

        public float Drag {
            get => Rigidbody.drag;
            set => Rigidbody.drag = value;
        }

        public float AngularDrag {
            get => Rigidbody.angularDrag;
            set => Rigidbody.angularDrag = value;
        }

        public float Mass {
            get => Rigidbody.mass;
            set => Rigidbody.mass = value;
        }

        public Vector3 CenterOfMass {
            get => Rigidbody.centerOfMass;
            set => Rigidbody.centerOfMass = value;
        }

        public override Vector3 Position {
            get => Rigidbody.position;
            set => Rigidbody.MovePosition(value);
        }

        public override Quaternion Rotation {
            get => Rigidbody.rotation;
            set => Rigidbody.MoveRotation(value);
        }
    }

    [RequireComponent(typeof(Rigidbody2D))]
    public class FoCs2DRigidbodyBehaviour: FoCsBehaviour {
        private Rigidbody2D m_Rigidbody2D;

        public Rigidbody2D Rigidbody2D {
            get => m_Rigidbody2D? m_Rigidbody2D : m_Rigidbody2D = GetComponent<Rigidbody2D>();
            set => m_Rigidbody2D = value;
        }

        public Vector3 Velocity {
            get => Rigidbody2D.velocity;
            set => Rigidbody2D.velocity = value;
        }

        public float AngularVelocity {
            get => Rigidbody2D.angularVelocity;
            set => Rigidbody2D.angularVelocity = value;
        }

        public float Drag {
            get => Rigidbody2D.drag;
            set => Rigidbody2D.drag = value;
        }

        public float AngularDrag {
            get => Rigidbody2D.angularDrag;
            set => Rigidbody2D.angularDrag = value;
        }

        public float Mass {
            get => Rigidbody2D.mass;
            set => Rigidbody2D.mass = value;
        }

        public Vector3 CenterOfMass {
            get => Rigidbody2D.centerOfMass;
            set => Rigidbody2D.centerOfMass = value;
        }

        public new Vector3 Position {
            get => Rigidbody2D.position;
            set => Rigidbody2D.MovePosition(value);
        }

        public new float Rotation {
            get => Rigidbody2D.rotation;
            set => Rigidbody2D.MoveRotation(value);
        }
    }
}