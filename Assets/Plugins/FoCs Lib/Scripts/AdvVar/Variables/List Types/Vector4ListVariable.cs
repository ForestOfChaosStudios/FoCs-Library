using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable]
	[AdvFolderNameUnityLists]
	public class Vector4ListReference: AdvListReference<Vector4>
	{ }

	[Serializable]
	public class Vector4ListVariable: AdvListVariable<Vector4, Vector4ListReference>
	{ }
}