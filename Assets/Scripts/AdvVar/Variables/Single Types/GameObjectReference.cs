using System;
using ForestOfChaosLib.AdvVar.Base;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[Serializable] [AdvFolderNameUnity] public class GameObjectReference: AdvReference<GameObject> { }

	[Serializable]
	public class GameObjectVariable: AdvVariable<GameObject, GameObjectReference>
	{
		public static implicit operator GameObjectVariable(GameObject input)
		{
			var fR = new GameObjectVariable {UseConstant = true, Value = input};

			return fR;
		}
	}
}
