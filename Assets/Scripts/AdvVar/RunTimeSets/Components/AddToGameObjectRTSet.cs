using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	public class AddToGameObjectRTSet: BaseAddToRTSet<GameObject, GameObjectRTList>
	{
		public override GameObject Value => gameObject;
	}
}