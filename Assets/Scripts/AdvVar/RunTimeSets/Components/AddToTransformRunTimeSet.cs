using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	public class AddToTransformRunTimeSet: BaseAddToRunTimeSet<Transform, TransformRunTimeList>
	{
		public override Transform Value => Transform;
	}
}