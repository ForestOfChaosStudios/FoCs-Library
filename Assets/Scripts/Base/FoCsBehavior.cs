using ForestOfChaosLib.Base.HiddenClasses;
using UnityEngine;

namespace ForestOfChaosLib
{
	public class FoCsBehavior: FoCsBe
	{
		private Transform m_Transform;

		public Transform Transform
		{
			get { return m_Transform ?? (m_Transform = GetComponent<Transform>()); }
			set { m_Transform = value; }
		}

		public virtual Quaternion Rotation
		{
			get { return Transform.rotation; }
			set { Transform.rotation = value; }
		}

		public virtual Vector3 EulerAngles
		{
			get { return Transform.eulerAngles; }
			set { Transform.eulerAngles = value; }
		}

		public virtual Vector3 LocalEulerAngles
		{
			get { return Transform.localEulerAngles; }
			set { Transform.localEulerAngles = value; }
		}

		public virtual Vector3 Position
		{
			get { return Transform.position; }
			set { Transform.position = value; }
		}

		public virtual Vector3 LocalPosition
		{
			get { return Transform.localPosition; }
			set { Transform.localPosition = value; }
		}

		public Vector3 Forward  => Transform.forward;
		public Vector3 Backward => -Transform.forward;
		public Vector3 Right    => Transform.right;
		public Vector3 Left     => -Transform.right;
		public Vector3 Up       => Transform.up;
		public Vector3 Down     => -Transform.up;
	}

	public class FoCs2DBehavior: FoCsBe
	{
		private RectTransform m_RectTransform;

		public RectTransform Transform
		{
			get { return m_RectTransform ?? (m_RectTransform = GetComponent<RectTransform>()); }
			set { m_RectTransform = value; }
		}

		public Quaternion Rotation
		{
			get { return Transform.rotation; }
			set { Transform.rotation = value; }
		}

		public Vector3 Position
		{
			get { return Transform.position; }
			set { Transform.position = value; }
		}

		public Vector3 LocalPosition
		{
			get { return Transform.localPosition; }
			set { Transform.localPosition = value; }
		}
	}
}
