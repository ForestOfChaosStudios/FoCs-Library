using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	public class AddToTransformRunTimeRef: BaseSetRunTimeRef<Transform, TransformRunTimeRef>
	{
		public override Transform Value => Transform;
	}
}
