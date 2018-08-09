using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	public class SetGameObjectRunTimeRef: BaseSetRunTimeRef<GameObject, GameObjectRunTimeRef>
	{
		public override GameObject Value => gameObject;
	}
}