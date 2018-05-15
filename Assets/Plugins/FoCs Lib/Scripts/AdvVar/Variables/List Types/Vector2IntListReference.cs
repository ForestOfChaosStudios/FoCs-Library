using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable]
	[AdvFolderNameUnityLists]
	public class Vector2IntListReference: AdvListReference<Vector2Int>
	{ }

	[Serializable]
	public class Vector2IntListVariable: AdvListVariable<Vector2Int, Vector2IntListReference>
	{ }
}