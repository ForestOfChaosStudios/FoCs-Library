using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable]
	[AdvFolderNameUnityLists]
	public class Vector2ListReference: AdvListReference<Vector2>
	{ }

	[Serializable]
	public class Vector2ListVariable: AdvListVariable<Vector2, Vector2ListReference>
	{ }
}