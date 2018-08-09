using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameUnityLists] public class Vector3ListReference: AdvListReference<Vector3> { }

	[Serializable] public class Vector3ListVariable: AdvListVariable<Vector3, Vector3ListReference> { }
}