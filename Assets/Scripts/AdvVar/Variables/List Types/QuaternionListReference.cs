using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameUnityLists] public class QuaternionListReference: AdvListReference<Quaternion> { }

	[Serializable] public class QuaternionListVariable: AdvListVariable<Quaternion, QuaternionListReference> { }
}