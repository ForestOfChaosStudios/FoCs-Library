using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameUnityLists] public class Vector3IntListReference: AdvListReference<Vector3Int> { }

	[Serializable] public class Vector3IntListVariable: AdvListVariable<Vector3Int, Vector3IntListReference> { }
}
