using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnityLists] public class Vector3IntListReference: AdvListReference<Vector3Int> { }

	[Serializable] public class Vector3IntListVariable: AdvListVariable<Vector3Int, Vector3IntListReference> { }
}
