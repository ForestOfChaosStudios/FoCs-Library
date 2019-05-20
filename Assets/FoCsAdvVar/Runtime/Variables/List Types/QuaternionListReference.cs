using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnityLists] public class QuaternionListReference: AdvListReference<Quaternion> { }

	[Serializable] public class QuaternionListVariable: AdvListVariable<Quaternion, QuaternionListReference> { }
}
