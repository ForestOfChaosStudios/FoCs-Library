using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnityLists] public class TransformListReference: AdvListReference<Transform> { }

	[Serializable] public class TransformListVariable: AdvListVariable<Transform, TransformListReference> { }
}
