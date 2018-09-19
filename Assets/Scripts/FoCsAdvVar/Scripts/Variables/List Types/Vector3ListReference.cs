using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnityLists] public class Vector3ListReference: AdvListReference<Vector3> { }

	[Serializable] public class Vector3ListVariable: AdvListVariable<Vector3, Vector3ListReference> { }
}
