using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnityLists] public class GameObjectListReference: AdvListReference<GameObject> { }

	[Serializable] public class GameObjectListVariable: AdvListVariable<GameObject, GameObjectListReference> { }
}
