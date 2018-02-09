using UnityEngine;

namespace ForestOfChaosLib.Components
{
	public class Rigidbody2DCopier: FoCs2DRigidbodyBehavior
	{
		[SerializeField]
		private Rigidbody2D _otherRigidbody;

		public Rigidbody2D OtherRigidbody
		{
			get { return _otherRigidbody ?? (_otherRigidbody = GetComponent<Rigidbody2D>()); }
			set { _otherRigidbody = value; }
		}

		void FixedUpdate()
		{
			if(OtherRigidbody)
			{
				Rigidbody2D.position = OtherRigidbody.position;
				Rigidbody2D.rotation = OtherRigidbody.rotation;
			}
		}
	}
}