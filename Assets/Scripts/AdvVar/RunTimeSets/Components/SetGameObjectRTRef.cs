using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	public class SetGameObjectRTRef: BaseSetRTRef<GameObject, GameObjectRTRef>
	{
		public override GameObject Value => gameObject;
	}
}