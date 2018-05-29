using UnityEngine;

namespace ForestOfChaosLib
{
	[RequireComponent(typeof(Rigidbody))]
	public class FoCsRigidbodyBehavior: FoCsBehavior
	{
		private         Rigidbody  m_Rigidbody;
		public          Rigidbody  Rigidbody       { get { return m_Rigidbody ?? (m_Rigidbody = GetComponent<Rigidbody>()); } set { m_Rigidbody               = value; } }
		public          Vector3    Velocity        { get { return Rigidbody.velocity; }                                       set { Rigidbody.velocity        = value; } }
		public          Vector3    AngularVelocity { get { return Rigidbody.angularVelocity; }                                set { Rigidbody.angularVelocity = value; } }
		public          float      Drag            { get { return Rigidbody.drag; }                                           set { Rigidbody.drag            = value; } }
		public          float      AngularDrag     { get { return Rigidbody.angularDrag; }                                    set { Rigidbody.angularDrag     = value; } }
		public          float      Mass            { get { return Rigidbody.mass; }                                           set { Rigidbody.mass            = value; } }
		public          Vector3    CenterOfMass    { get { return Rigidbody.centerOfMass; }                                   set { Rigidbody.centerOfMass    = value; } }
		public override Vector3    Position        { get { return Rigidbody.position; }                                       set { Rigidbody.MovePosition(value); } }
		public override Quaternion Rotation        { get { return Rigidbody.rotation; }                                       set { Rigidbody.MoveRotation(value); } }
	}

	[RequireComponent(typeof(Rigidbody2D))]
	public class FoCs2DRigidbodyBehavior: FoCsBehavior
	{
		private    Rigidbody2D m_Rigidbody2D;
		public     Rigidbody2D Rigidbody2D     { get { return m_Rigidbody2D ?? (m_Rigidbody2D = GetComponent<Rigidbody2D>()); } set { m_Rigidbody2D               = value; } }
		public     Vector3     Velocity        { get { return Rigidbody2D.velocity; }                                           set { Rigidbody2D.velocity        = value; } }
		public     float       AngularVelocity { get { return Rigidbody2D.angularVelocity; }                                    set { Rigidbody2D.angularVelocity = value; } }
		public     float       Drag            { get { return Rigidbody2D.drag; }                                               set { Rigidbody2D.drag            = value; } }
		public     float       AngularDrag     { get { return Rigidbody2D.angularDrag; }                                        set { Rigidbody2D.angularDrag     = value; } }
		public     float       Mass            { get { return Rigidbody2D.mass; }                                               set { Rigidbody2D.mass            = value; } }
		public     Vector3     CenterOfMass    { get { return Rigidbody2D.centerOfMass; }                                       set { Rigidbody2D.centerOfMass    = value; } }
		public new Vector3     Position        { get { return Rigidbody2D.position; }                                           set { Rigidbody2D.MovePosition(value); } }
		public new float       Rotation        { get { return Rigidbody2D.rotation; }                                           set { Rigidbody2D.MoveRotation(value); } }
	}
}