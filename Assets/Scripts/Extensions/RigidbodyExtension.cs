using UnityEngine;

namespace ForestOfChaosLib.Extensions
{
	public static class RigidbodyExtension
	{
		public static void ResetVelocity(this Rigidbody rB)
		{
			rB.velocity        = Vector3.zero;
			rB.angularVelocity = Vector3.zero;
		}
	}
}
