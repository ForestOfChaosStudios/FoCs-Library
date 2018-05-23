using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	public class AddToGameObjectRunTimeSet: BaseAddToRunTimeSet<GameObject, GameObjectRunTimeList>
	{
		public override GameObject Value => gameObject;
	}
}