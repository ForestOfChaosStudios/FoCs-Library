using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnityLists] public class Vector4ListReference: AdvListReference<Vector4> { }

	[Serializable] public class Vector4ListVariable: AdvListVariable<Vector4, Vector4ListReference> { }
}
