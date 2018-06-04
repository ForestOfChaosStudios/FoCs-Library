using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameUnityLists] public class TransformListReference: AdvListReference<Transform> { }

	[Serializable] public class TransformListVariable: AdvListVariable<Transform, TransformListReference> { }
}
