using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	public class AddToTransformRTSet: BaseAddToRTSet<Transform, TransformRTList>
	{
		public override Transform Value => Transform;
	}
}