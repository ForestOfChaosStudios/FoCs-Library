using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable]
	[AdvFolderNameUnityLists]
	public class GameObjectListReference: AdvListReference<GameObject>
	{ }

	[Serializable]
	public class GameObjectListVariable: AdvListVariable<GameObject, GameObjectListReference>
	{ }
}