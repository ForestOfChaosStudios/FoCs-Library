using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnityLists] public class Vector2ListReference: AdvListReference<Vector2> { }

	[Serializable] public class Vector2ListVariable: AdvListVariable<Vector2, Vector2ListReference> { }
}
