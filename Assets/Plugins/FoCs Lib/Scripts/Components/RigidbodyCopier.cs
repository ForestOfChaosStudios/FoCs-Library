using UnityEngine;

namespace ForestOfChaosLib.Components
{
	public class RigidbodyCopier: FoCsRigidbodyBehavior
	{
		[SerializeField]
		private Rigidbody _otherRigidbody;

		public Rigidbody OtherRigidbody
		{
			get { return _otherRigidbody ?? (_otherRigidbody = GetComponent<Rigidbody>()); }
			set { _otherRigidbody = value; }
		}

		void FixedUpdate()
		{
			if(OtherRigidbody)
			{
				Rigidbody.position = OtherRigidbody.position;
				Rigidbody.rotation = OtherRigidbody.rotation;
			}
		}
	}
}