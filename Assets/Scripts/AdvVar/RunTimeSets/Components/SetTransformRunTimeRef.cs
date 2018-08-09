using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	public class SetTransformRunTimeRef: BaseSetRunTimeRef<Transform, TransformRunTimeRef>
	{
		public override Transform Value => Transform;
	}
}