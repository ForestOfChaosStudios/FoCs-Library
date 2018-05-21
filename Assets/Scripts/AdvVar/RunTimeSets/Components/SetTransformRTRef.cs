using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	public class SetTransformRTRef: BaseSetRTRef<Transform, TransformRTRef>
	{
		public override Transform Value => Transform;
	}
}