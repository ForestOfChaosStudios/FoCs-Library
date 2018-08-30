using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/RunTime/" + "Add GameObject RunTime Ref")]
	public class AddToGameObjectRunTimeSet: BaseAddToRunTimeSet<GameObject, GameObjectRunTimeList>
	{
		public override GameObject Value => gameObject;
	}
}
