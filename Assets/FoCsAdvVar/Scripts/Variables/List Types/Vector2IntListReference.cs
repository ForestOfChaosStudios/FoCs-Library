using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnityLists] public class Vector2IntListReference: AdvListReference<Vector2Int> { }

	[Serializable] public class Vector2IntListVariable: AdvListVariable<Vector2Int, Vector2IntListReference> { }
}
