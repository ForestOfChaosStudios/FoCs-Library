using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/RunTime/" + "Add Transform RunTime Ref")]
	public class AddToTransformRunTimeRef: BaseSetRunTimeRef<Transform, TransformRunTimeRef>
	{
		public override Transform Value => Transform;
	}
}
