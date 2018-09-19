using System;
using ForestOfChaosAdvVar.Base;
using UnityEngine;

namespace ForestOfChaosAdvVar
{
	[Serializable] [AdvFolderNameUnity] public class GameObjectReference: AdvReference<GameObject> { }

	[Serializable]
	public class GameObjectVariable: AdvVariable<GameObject, GameObjectReference>
	{
		public static implicit operator GameObjectVariable(GameObject input)
		{
			var fR = new GameObjectVariable {UseLocal = true, Value = input};

			return fR;
		}
	}
}
